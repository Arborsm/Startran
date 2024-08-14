﻿using System.IO;
using Newtonsoft.Json;

namespace Startran;

public class AppConfig
{
    public bool IsSaveSource { get; set; } = false;
    public bool IsSaveTranslated { get; set; } = false;
    public string ApiSelected = "OpenAI";
    public string DirectoryPath { get; set; } = AppDomain.CurrentDomain.BaseDirectory;
    public string Language { get; set; } = "zh";
    public string EnToCn { get; set; } = "你是一个游戏文本翻译助手，这次要翻译的是星露谷物语的一个模组，" +
                                         "贴合游戏将英文意译成简体中文并加以润色使其更符合中文的语言环境，" +
                                         "意译输入文本，不要直接使用原参考文本, " +
                                         "符号组合不需要翻译并务必保留在语句对应的位置，以输入格式直接输出结果。";
    public ApiConfig ApiConf { get; set; } = new();
    private static readonly string AppSavingPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "StarTran");
    private static readonly string ConfigFilePath = Path.Combine(AppSavingPath, "config.json");

    public static AppConfig Load()
    {
        if (!File.Exists(ConfigFilePath))
        {
            Directory.CreateDirectory(AppSavingPath);
            return new AppConfig();
        }
        var json = File.ReadAllText(ConfigFilePath);
        return JsonConvert.DeserializeObject<AppConfig>(json)!;
    }

    public void Save()
    {
        var json = JsonConvert.SerializeObject(this, Formatting.Indented);
        File.WriteAllText(ConfigFilePath, json);
    }

    public class ApiConfig
    {
        public string Api { get; set; } = "your-api-key";
        public string Url { get; set; } = "https://api.openai.com";
        public string Model { get; set; } = "gpt-3.5-turbo";
        public List<string> Models { get; set; } =
            new() { "gpt-3.5-turbo", "gpt-4o", "gpt-4o-mini" };
    }

    public string GetAppSavingPath()
    {
        return AppSavingPath;
    }
}

