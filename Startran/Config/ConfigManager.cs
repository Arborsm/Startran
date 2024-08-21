using System.IO;
using Newtonsoft.Json;

using static Startran.StartranMain;

namespace Startran.Config;

public class ConfigManager<T> where T : new()
{
    private static readonly string ConfigFilePath = Path.Combine(AppSavingPath, typeof(T).Name + ".json");

    public static T Load()
    {
        if (!File.Exists(ConfigFilePath))
        {
            Directory.CreateDirectory(AppSavingPath);
            return new T();
        }

        var json = File.ReadAllText(ConfigFilePath);
        return JsonConvert.DeserializeObject<T>(json)!;
    }

    public static void Save(T config)
    {
        var json = JsonConvert.SerializeObject(config, Formatting.Indented);
        File.WriteAllText(ConfigFilePath, json);
    }

    public static string GetAppSavingPath()
    {
        return AppSavingPath;
    }
}