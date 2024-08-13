using Newtonsoft.Json;

// ReSharper disable InconsistentNaming

namespace Startran.Mod
{
    internal sealed class IMod
    {
        public IMod(string path)
        {
            var manifestPath = Path.GetFullPath(path);
            var parentDirectory = Path.GetDirectoryName(manifestPath)!;
            var manifest = File.ReadAllText(path);
            List<string> i18n = [];
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
        }
        public string Name { get; }
        public string Description { get; }
        public string Version { get; }
        public string UniqueID { get; }
        public string PathS { get; }
        public List<string> Lang { get; }
    }
}
