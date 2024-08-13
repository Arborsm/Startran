using System;
using System.Text.Json.Nodes;

namespace Startran.Mod
{
    internal class ModData
    {
        public static ModData Instance = new();
        public Dictionary<string, IMod> Mods = [];

        public void FindMods(string path)
        {
            if (Directory.Exists(path))
            {
                var manifestFiles = new List<string>();
                FindManifestFiles(path, manifestFiles);
                manifestFiles.ForEach(manifestFile =>
                {
                    var mod = new IMod(manifestFile);
                    Mods.Add(mod.Name, mod);
                });
            }
            else
            {
                MessageBox.Show(Lang.Strings.InvalidDirectoryPath);
            }
        }


        private static void FindManifestFiles(string path, List<string> manifestFiles)
        {
            try
            {
                var files = Directory.GetFiles(path);
                manifestFiles.AddRange(files.Where(file => Path.GetFileName(file).Equals("manifest.json", StringComparison.OrdinalIgnoreCase)));
                var directories = Directory.GetDirectories(path);

                foreach (var directory in directories)
                {
                    FindManifestFiles(directory, manifestFiles);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
