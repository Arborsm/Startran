using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Text;
using Newtonsoft.Json;
using Startran.Config;
using Startran.Mod;
using Startran.Trans;

namespace Startran.Misc;

internal static class Tools
{
    public static void HideImageMargins(this MenuStrip menuStrip)
    {
        HideImageMargins(menuStrip.Items.OfType<ToolStripMenuItem>().ToList());
    }

    private static void HideImageMargins(this List<ToolStripMenuItem> toolStripMenuItems)
    {
        toolStripMenuItems.ForEach(item =>
        {
            if (item.DropDown is not ToolStripDropDownMenu dropdown) return;

            dropdown.ShowImageMargin = false;

            HideImageMargins(item.DropDownItems.OfType<ToolStripMenuItem>().ToList());
        });
    }

    public static string BreakTextEn(this string text, Graphics g, Font font, int maxWidth)
    {
        var result = new StringBuilder();
        var currentLine = new StringBuilder();
        var currentWidth = 0f;

        var lastSpaceIndex = -1;

        foreach (var c in text)
        {
            var size = g.MeasureString(c.ToString(), font);

            if (currentWidth + size.Width > maxWidth)
            {
                if (currentLine.Length > 0 && lastSpaceIndex != -1)
                {
                    result.AppendLine(currentLine.ToString(0, lastSpaceIndex));

                    currentLine.Remove(0, lastSpaceIndex + 1);
                    currentWidth = g.MeasureString(currentLine.ToString(), font).Width;
                }
                else
                {
                    result.AppendLine(currentLine.ToString());
                    currentLine.Clear();
                    currentWidth = 0;
                }

                currentLine.Append(c);
                currentWidth += size.Width;
                lastSpaceIndex = -1;
            }
            else
            {
                currentLine.Append(c);
                currentWidth += size.Width;

                if (char.IsWhiteSpace(c)) lastSpaceIndex = currentLine.Length - 1;
            }
        }

        if (currentLine.Length > 0) result.AppendLine(currentLine.ToString());

        return result.ToString();
    }

    public static Dictionary<TKey, TValue> Sort<TKey, TValue>(
        this Dictionary<TKey, TValue> unsorted,
        Dictionary<TKey, TValue> reference) where TKey : notnull
    {
        var sortedTarget = new Dictionary<TKey, TValue>();

        foreach (var kvp in reference.Where(kvp => unsorted.ContainsKey(kvp.Key)))
            sortedTarget[kvp.Key] = unsorted[kvp.Key];

        return sortedTarget;
    }

    public static (Dictionary<string, string> defaultLang, Dictionary<string, string> targetLang) ReadMap(this IMod mod,
        string lang)
    {
        var files = Directory.GetFiles(mod.PathS + "\\i18n", "*.json");
        var defaultLangFile = files.First(x => x.Contains("default"));
        var targetLangFile = files.FirstOrDefault(x => x.Contains(lang));
        var defaultLang = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(defaultLangFile))!;
        var targetLangTemp = targetLangFile != null
            ? JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(targetLangFile))!
            : new Dictionary<string, string>();
        var targetLang = targetLangTemp.Sort(defaultLang);
        return (defaultLang, targetLang);
    }

    public static string ToStringI(this double value)
    {
        return ((int)value).ToString(CultureInfo.InvariantCulture);
    }

    public static void CreateZipBackup(this string directoryPath, string zipFileName)
    {
        var backupPath = Path.Combine(Environment.CurrentDirectory, "Backup");
        if (!Directory.Exists(backupPath)) Directory.CreateDirectory(backupPath);
        var zipFilePath = Path.Combine(backupPath, zipFileName);
        using var archive = ZipFile.Open(zipFilePath, ZipArchiveMode.Create);
        ZipDirectory(directoryPath, archive);
    }

    private static void ZipDirectory(string directoryPath, ZipArchive archive, string entryRootPath = "")
    {
        foreach (var filePath in Directory.GetFiles(directoryPath))
        {
            var relativeFilePath = Path.Combine(entryRootPath, Path.GetFileName(filePath));
            archive.CreateEntryFromFile(filePath, relativeFilePath);
        }

        foreach (var directory in Directory.GetDirectories(directoryPath))
        {
            var relativeDirectoryPath = Path.Combine(entryRootPath, Path.GetFileName(directory));
            ZipDirectory(directory, archive, relativeDirectoryPath);
        }
    }

    public static string SanitizePath(this string path)
    {
        return Path.GetInvalidFileNameChars().Aggregate(path, (current, c) => current.Replace(c, '_'));
    }

    public static string GetJsonString(this string directoryPath, string fileName)
    {
        var i18NDir = Directory.GetDirectories(directoryPath, "i18n", SearchOption.AllDirectories).FirstOrDefault();
        if (i18NDir == null) return string.Empty;
        var filePath = Path.Combine(i18NDir, fileName);
        return File.Exists(filePath) ? File.ReadAllText(filePath, Encoding.UTF8) : string.Empty;
    }

    public static Dictionary<string, string> GetTargetLang(this string path, string fileName)
    {
        var target = path.GetJsonString(fileName);
        return JsonConvert.DeserializeObject<Dictionary<string, string>>(target) ??
                         new Dictionary<string, string>();
    }

    public static Dictionary<string, string> GetTargetLang(this string path, MainConfig config)
    {
        return GetTargetLang(path, config.Language + ".json");
    }

    public static Dictionary<string, string> GetDefaultLang(this string path)
    {
        var en = path.GetJsonString("default.json");
        return JsonConvert.DeserializeObject<Dictionary<string, string>>(en)!;
    }
}

public class KeyValuePairComparer<TKey, TValue> : IEqualityComparer<KeyValuePair<TKey, TValue>>
{
    private readonly IEqualityComparer<TKey> _keyComparer;
    private readonly IEqualityComparer<TValue> _valueComparer;

    public KeyValuePairComparer(IEqualityComparer<TKey>? keyComparer = null,
        IEqualityComparer<TValue>? valueComparer = null)
    {
        _keyComparer = keyComparer ?? EqualityComparer<TKey>.Default;
        _valueComparer = valueComparer ?? EqualityComparer<TValue>.Default;
    }

    public bool Equals(KeyValuePair<TKey, TValue> x, KeyValuePair<TKey, TValue> y)
    {
        return _keyComparer.Equals(x.Key, y.Key) && _valueComparer.Equals(x.Value, y.Value);
    }

    public int GetHashCode(KeyValuePair<TKey, TValue> obj)
    {
        var keyHashCode = obj.Key != null ? _keyComparer.GetHashCode(obj.Key) : 0;
        var valueHashCode = obj.Value != null ? _valueComparer.GetHashCode(obj.Value) : 0;

        return (keyHashCode * 397) ^ valueHashCode;
    }
}

enum ProcessResult
{
    Success,
    Fail,
    Cancel
}