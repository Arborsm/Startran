using System.IO;

namespace Startran.Mod
{
    internal class ModData
    {
        public static ModData Instance = new();
        public Dictionary<string, IMod> Mods = null!;   

        public async Task FindModsAsync(string path)
        {
            if (Directory.Exists(path))
            {
                Mods = new Dictionary<string, IMod>();
                var manifestFiles = new List<string>();
                await FindManifestFilesAsync(path, manifestFiles);
                Mods = manifestFiles
                    .Select(manifestFile => new IMod(manifestFile))
                    .Where(mod => mod.Lang.Count > 0 && Directory.Exists(mod.PathS))
                    .ToDictionary(mod => mod.Name, mod => mod);
            }
            else
            {
                MessageBox.Show(Lang.Strings.InvalidDirectoryPath);
            }
        }

        private static async Task FindManifestFilesAsync(string path, List<string> manifestFiles)
        {
            try
            {
                var files = await Task.Run(() => Directory.GetFiles(path));
                manifestFiles.AddRange(files.Where(file => Path.GetFileName(file).Equals("manifest.json", StringComparison.OrdinalIgnoreCase)));

                var directories = await Task.Run(() => Directory.GetDirectories(path));

                foreach (var directory in directories)
                {
                    await FindManifestFilesAsync(directory, manifestFiles);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
