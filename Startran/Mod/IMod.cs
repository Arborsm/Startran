using System.IO;
using Newtonsoft.Json;
using Startran.Config;
using Startran.Misc;

// ReSharper disable InconsistentNaming

namespace Startran.Mod;

internal sealed class IMod
{
    public IMod(string path, MainConfig config)
    {
        var manifestPath = Path.GetFullPath(path);
        var parentDirectory = Path.GetDirectoryName(manifestPath)!;
        var manifest = File.ReadAllText(path);
        List<string> i18n = new();
        try
        {
            var i18nFiles = Directory.GetFiles(parentDirectory + @"\\i18n", "*.json");
            i18n.AddRange(i18nFiles.Select(Path.GetFileNameWithoutExtension)!);
        }
        catch (Exception)
        {
            // ignored
        }

        dynamic modData = JsonConvert.DeserializeObject(manifest)!;
        Name = modData.Name;
        Description = modData.Description;
        Version = modData.Version;
        UniqueID = modData.UniqueID;
        Lang = i18n;
        PathS = parentDirectory;
        TargetLang = PathS.GetTargetLang(config);
        DefaultLang = PathS.GetDefaultLang();
    }

    public string Name { get; }
    public string Description { get; }
    public string Version { get; }
    public string UniqueID { get; }
    public string PathS { get; }
    public List<string> Lang { get; }
    public Dictionary<string, string> TargetLang { get; }
    public Dictionary<string, string> DefaultLang { get; }
}