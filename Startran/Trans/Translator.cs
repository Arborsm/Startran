using System.Collections.Concurrent;
using System.Text;
using Newtonsoft.Json;
using Startran.Forms;

namespace Startran.Trans;

public class Translator
{
    public static List<ITranslator> Apis { get; } = [];
    private readonly AppConfig _config;
    private readonly MainForm _main;
    private const string En = "default.json";
    private readonly string _cn;
    private readonly string _cnSource;
    private readonly string _cnTranslated;
    public Translator(AppConfig config, MainForm main) 
    {
        FindAllApis();
        _config = config;
        _main = main;
        _cn = config.Language + ".json";
        _cnSource = config.Language + "-Source.json";
        _cnTranslated = config.Language + "-Translated.json";
    }

    private void FindAllApis()
    {
        var types = GetType().Assembly.GetTypes();
        foreach (var type in types)
        {
            if (!type.GetInterfaces().Contains(typeof(ITranslator))) continue;
            var instance = (ITranslator)Activator.CreateInstance(type)!;
            Apis.Add(instance);
        }
    }

    private static bool ContainsChinese(string str)
    {
        return str.Any(ch => ch >= 0x4E00 && ch <= 0x9FFF);
    }

    internal async Task<string> TranslateText(string text)
    {
        return ContainsChinese(text) ? text : await TranslateText(text, _config.EnToCn);
    }

    internal async Task<string> TranslateText(string text, string role)
    {
        return await Apis.First(it => it.Name == _config.ApiSelected).StreamCallWithMessage(text, role, _config);
    }

    internal static string GetJsonString(string directoryPath, string fileName)
    {
        var i18NDir = Directory.GetDirectories(directoryPath, "i18n", SearchOption.AllDirectories).FirstOrDefault();
        if (i18NDir == null) return string.Empty;
        var filePath = Path.Combine(i18NDir, fileName);
        return File.Exists(filePath) ? File.ReadAllText(filePath, Encoding.UTF8) : string.Empty;
    }

    internal async Task<Dictionary<string, string>> ProcessText(Dictionary<string, string> map, Dictionary<string, string>? mapAllCn, string role)
    {
        mapAllCn ??= [];
        var processedMap = new ConcurrentDictionary<string, string>();
        var keys = map.Keys.Except(mapAllCn.Keys).ToList();
        _main.sonProgressPar.Maximum = keys.Count;
        var tasks = keys.Select(async key =>
        {
            string? result = null;
            do
            {
                try
                {
                    if (key.Length <= 20)
                    {
                        await Task.Delay(500);
                    }
                    result = await TranslateText(map[key], role);
                }
                catch (Exception e)
                {
                    Console.WriteLine(Lang.Strings.ErrorOccurred + e.Message);
                }
            } while (result == null);
            Console.WriteLine(result);
            _main.Invoke(_main.UpdateText(key, result, processedMap.Keys.ToList(), keys));
            processedMap[key] = result;
        });

        await Task.WhenAll(tasks);
        return processedMap.ToDictionary(k => k.Key, v => v.Value);
    }

    internal async Task ProcessDirectories(string directoryPath)
    {
        var i = -1;
        var directories = Directory.GetDirectories(directoryPath);
        _main.mainPogressBar.Maximum = directories.Length;

        var tasks = directories.Select(async directory =>
        {
            _main.Invoke(_main.UpdateMainText(++i));
            await ProcessDirectory(directory);
            _main.Invoke(new Action(() => _main.mainPogressBar.Value++));
        });

        await Task.WhenAll(tasks);
    }

    private async Task ProcessDirectory(string directoryPath)
    {
        var en = GetJsonString(directoryPath, En);
        var cn = GetJsonString(directoryPath, _cn);

        var mapAll = JsonConvert.DeserializeObject<Dictionary<string, string>>(en)!;
        var mapAllCn = JsonConvert.DeserializeObject<Dictionary<string, string>>(cn) ?? [];
        var path = Path.Combine(directoryPath, "i18n");
        if (_config.IsSaveSource)
        {
            await File.WriteAllTextAsync(Path.Combine(path, _cnSource), cn);
        }

        var tran = await ProcessText(mapAll, mapAllCn, _config.EnToCn);
        if (_config.IsSaveTranslated)
        {
            await File.WriteAllTextAsync(Path.Combine(path, _cnTranslated), JsonConvert.SerializeObject(tran));
        }

        var combined = mapAllCn.Union(tran).ToDictionary(k => k.Key, v => v.Value);
        await File.WriteAllTextAsync(Path.Combine(path, _cn), JsonConvert.SerializeObject(combined));
    }
}