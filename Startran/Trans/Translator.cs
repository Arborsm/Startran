using System.Collections.Concurrent;
using System.IO;
using Newtonsoft.Json;
using Startran.Config;
using Startran.Forms;
using Startran.Misc;
using Startran.Mod;

namespace Startran.Trans;

public class Translator
{
    private readonly MainConfig _config;
    public TranslateForm Form { get; set; } = null!;
    public static List<ITranslator> Apis { get; } = new();

    public Translator(MainConfig config)
    {
        FindAllApis();
        _config = config;
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

    internal async Task<string?> TranslateText(string text)
    {
        return ContainsChinese(text) ? text : await TranslateText(text, _config.EnToCn);
    }

    internal async Task<string> TranslateText(string text, string role)
    {
        return await Apis.First(it => it.Name == _config.ApiSelected)
            .StreamCallWithMessage(text, role, _config, Form.Tsl.Token);
    }

    internal async Task<Dictionary<string, string>> ProcessText(
        Dictionary<string, string> map,
        Dictionary<string, string>? mapAllCn,
        string role)
    {
        mapAllCn ??= new Dictionary<string, string>();
        var processedMap = new ConcurrentDictionary<string, string>();
        var keys = map.Keys.Except(mapAllCn.Keys).ToList();
        //_main.sonProgressPar.Maximum = keys.Count;
        var tasks = keys.Select(async key =>
        {
            if (map[key].Length <= 20) await Task.Delay(500);
            var result = await TranslateText(map[key], role);

            if (result != string.Empty)
            {
                Console.WriteLine(result);
                Form.Invoke(Form.SonProgressUpdate(key, processedMap.Keys.ToList(), keys));
                processedMap[key] = result;
            }
        });

        await Task.WhenAll(tasks);
        return processedMap.ToDictionary(k => k.Key, v => v.Value);
    }

    internal async Task<ProcessResult> ProcessDirectories()
    {
        var i = 0;
        var directories = ModData.Instance.ProcessMods.Select(it => it.PathS).ToArray();
        var maximum = (float) directories.Length;

        var tasks = directories.Select(async directory =>
        {
            Form.Invoke(Form.MainProgressUpdate(0, $@"0/{maximum}"));
            await ProcessDirectory(directory);
            Form.Invoke(Form.MainProgressUpdate(1.0f / maximum, $@"{++i}/{maximum}"));
        });

        await Task.WhenAll(tasks);
        return ProcessResult.Success;
    }

    private async Task ProcessDirectory(string directoryPath)
    {
        var target = _config.Language + ".json";
        var defaultLang = directoryPath.GetDefaultLang();
        var targetLang = directoryPath.GetTargetLang(target);
        targetLang = targetLang.Sort(defaultLang);
        var path = Path.Combine(directoryPath, "i18n");

        var tran = await ProcessText(defaultLang, targetLang, _config.EnToCn);

        if (defaultLang.IsMismatchedTokens(tran))
        {
            ModData.Instance.IsMismatchedTokens = true;
        }

        var combined = targetLang
            .Union(tran, new KeyValuePairComparer<string, string>())
            .ToDictionary(k => k.Key, v => v.Value);

        await File.WriteAllTextAsync(Path.Combine(path, target), JsonConvert.SerializeObject(combined));
    }
}