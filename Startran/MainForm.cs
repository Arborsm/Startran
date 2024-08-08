using System.ClientModel;
using System.Collections.Concurrent;
using System.Text;
using Newtonsoft.Json;
using OpenAI;

namespace Startran;

public partial class Form1 : Form
{
    private AppConfig config;
    private const string En = "default.json";
    private const string Cn = "zh.json";
    private const string CnP = "zh-p.json";
    private const string CnI = "zh-i.json";
    private const string EnToCn = "你是一个游戏文本翻译助手，这次要翻译的是星露谷物语的一个模组，贴合游戏将英文意译成简体中文并加以润色使其更符合中文的语言环境，意译输入文本，不要直接使用原参考文本, 形如${'$'}1^1^[233]&${'$'}等符号组合不需要翻译务必保留在语句对应的位置，以输入格式直接输出结果。";
    // private const string cnToCn = "你是一个文本校对润色助手，对照英文文本校对并按照参考修改错误部分，无需修改的输出原文本，不要直接使用参考文本, 形如${'$'}1^[233]&${'$'}等符号组合务必保与英文文本一致，以输入格式直接输出润色后文本。参考文本: 能跟姐姐说说最近是发生了什么吗？我们可都已经是夫妻了耶。加油加油工作工作！以前是不是我也是这样怂恿你去干一些坏事的？下雨了！亲爱的！今天就可以不用浇水了，我们可以稍微偷懒一会, 嗯？你也要吃吗？什么嘛！不许说我胖！一到了夏天就热到不行啦！干农活很累吧？弄得灰头土脸的，过来让我把你的头发整理整理……要抱抱。";

    public Form1()
    {
        InitializeComponent();
        config = AppConfig.Load();
        directoryTextBox.Text = config.DirectoryPath;
    }

    private void translateButton_Click(object sender, EventArgs e)
    {
        var userInput = inputTextBox.Text.Trim();
        if (!string.IsNullOrEmpty(userInput))
        {
            outputTextBox.Text = TranslateText(userInput);
        }
    }

    private async void processButton_Click(object sender, EventArgs e)
    {
        var directoryPath = directoryTextBox.Text.Trim();
        if (Directory.Exists(directoryPath))
        {
            progressBar.Value = 0;
            await ProcessDirectories(directoryPath);
            MessageBox.Show("Processing completed.");
        }
        else
        {
            MessageBox.Show("Invalid directory path.");
        }
    }
    
    private void settingsButton_Click(object sender, EventArgs e)
    {
        var settingsForm = new SettingsForm(config);
        settingsForm.ShowDialog();
        config.Save();
        directoryTextBox.Text = config.DirectoryPath;
    }

    static bool ContainsChinese(string str)
    {
        return str.Any(ch => ch >= 0x4E00 && ch <= 0x9FFF);
    }

    static string TranslateText(string text)
    {
        return ContainsChinese(text) ? text : TranslateText(text, EnToCn);
    }

    static string TranslateText(string text, string role)
    {
        return StreamCallWithMessage(text, role);
    }

    private async Task ProcessDirectories(string directoryPath)
    {
        var directories = Directory.GetDirectories(directoryPath);
        progressBar.Maximum = directories.Length;

        var tasks = directories.Select(async directory =>
        {
            await ProcessDirectory(directory);
            Invoke(new Action(() => progressBar.Value++));
        });

        await Task.WhenAll(tasks);
    }

    private async Task ProcessDirectory(string directoryPath)
    {
        var en = GetJsonString(directoryPath, En);
        var cn = GetJsonString(directoryPath, Cn);

        var mapAll = JsonConvert.DeserializeObject<Dictionary<string, string>>(en)!;
        var mapAllCn = JsonConvert.DeserializeObject<Dictionary<string, string>>(cn) ?? new();

        var path = Path.Combine(directoryPath, "i18n");
        Directory.CreateDirectory(path);
        await File.WriteAllTextAsync(Path.Combine(path, CnI), cn);

        var tran = await ProcessText(mapAll, mapAllCn, EnToCn);
        await File.WriteAllTextAsync(Path.Combine(path, CnP), JsonConvert.SerializeObject(tran));

        var combined = mapAllCn.Union(tran).ToDictionary(k => k.Key, v => v.Value);
        await File.WriteAllTextAsync(Path.Combine(path, Cn), JsonConvert.SerializeObject(combined));
    }

    private string GetJsonString(string directoryPath, string fileName)
    {
        var i18nDir = Directory.GetDirectories(directoryPath, "i18n", SearchOption.AllDirectories).FirstOrDefault();
        if (i18nDir != null)
        {
            var filePath = Path.Combine(i18nDir, fileName);
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath, Encoding.UTF8);
            }
        }
        return string.Empty;
    }

    private async Task<Dictionary<string, string>> ProcessText(Dictionary<string, string> map, Dictionary<string, string>? mapAllCn, string role)
    {
        mapAllCn ??= new Dictionary<string, string>();
        var processedMap = new ConcurrentDictionary<string, string>();
        var tasks = map.Keys.Except(mapAllCn.Keys).Select(async key =>
        {
            string? result = null;
            do
            {
                try
                {
                    await Task.Delay(500);
                    result = TranslateText(map[key], role);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error occurred: " + e.Message);
                }
            } while (result == null);

            Console.WriteLine(result);
            processedMap[key] = result;
        });

        await Task.WhenAll(tasks);
        return processedMap.ToDictionary(k => k.Key, v => v.Value);
    }

    private static string StreamCallWithMessage(string text, string role)
    {
        var client = new OpenAIClient(new ApiKeyCredential("")); //TODO
        return text; // TODO: Implement your logic here
    }
}