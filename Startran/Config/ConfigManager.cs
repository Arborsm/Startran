using System.IO;
using Newtonsoft.Json;
using static Startran.StartranMain;

namespace Startran.Config;

public static class ConfigManager<T> where T : new()
{
    public static T Load(string? additionName = null)
    {
        additionName = additionName == null ? string.Empty : "_" + additionName;
        var configFilePath = Path.Combine(AppSavingPath, typeof(T).Name + additionName + ".json");
        if (!File.Exists(configFilePath))
        {
            Directory.CreateDirectory(AppSavingPath);
            return new T();
        }

        var json = File.ReadAllText(configFilePath);
        return JsonConvert.DeserializeObject<T>(json)!;
    }

    public static void Save(T config, string? additionName = null)
    {
        additionName = additionName == null ? string.Empty : "_" + additionName;
        var configFilePath = Path.Combine(AppSavingPath, typeof(T).Name + additionName + ".json");
        var json = JsonConvert.SerializeObject(config, Formatting.Indented);
        File.WriteAllText(configFilePath, json);
    }
}