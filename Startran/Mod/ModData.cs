using System.IO;
using Startran.Config;
using Startran.Lang;

namespace Startran.Mod;

internal class ModData
{
    public static ModData Instance = new();
    public Dictionary<string, IMod> Mods = null!;
    public IMod[] ProcessMods = null!;
    public bool IsMismatchedTokens;
    public async Task FindModsAsync(string path, MainConfig config)
    {
        if (Directory.Exists(path))
        {
            Mods = new Dictionary<string, IMod>();
            var manifestFiles = new List<string>();
            await FindManifestFilesAsync(path, manifestFiles);
            Mods = manifestFiles
                .Select(manifestFile => new IMod(manifestFile, config))
                .Where(mod => mod.Lang.Count > 0 && Directory.Exists(mod.PathS))
                .ToDictionary(mod => mod.Name, mod => mod);
            InitProcessMods();
        }
        else
        {
            MessageBox.Show(Strings.InvalidDirectoryPath);
        }
    }

    public void InitProcessMods()
    {
        ProcessMods = Mods.Values
            .Where(it => it.DefaultLang.Keys.Any(key => !it.TargetLang.ContainsKey(key)))
            .ToArray();
    }

    private static async Task FindManifestFilesAsync(string path, List<string> manifestFiles)
    {
        try
        {
            var files = await Task.Run(() => Directory.GetFiles(path));
            manifestFiles.AddRange(files.Where(file =>
                Path.GetFileName(file).Equals("manifest.json", StringComparison.OrdinalIgnoreCase)));

            var directories = await Task.Run(() => Directory.GetDirectories(path));

            foreach (var directory in directories) await FindManifestFilesAsync(directory, manifestFiles);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}