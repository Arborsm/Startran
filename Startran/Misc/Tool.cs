using Newtonsoft.Json;
using Startran.Mod;
using System.IO;
using System.Text;

namespace Startran.Misc
{
    internal static class Tool
    {
        public static void HideImageMargins(this MenuStrip menuStrip)
        {
            HideImageMargins(menuStrip.Items.OfType<ToolStripMenuItem>().ToList());
        }

        private static void HideImageMargins(this List<ToolStripMenuItem> toolStripMenuItems)
        {
            toolStripMenuItems.ForEach(item =>
            {
                if (item.DropDown is not ToolStripDropDownMenu dropdown)
                {
                    return;
                }

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

                    if (char.IsWhiteSpace(c))
                    {
                        lastSpaceIndex = currentLine.Length - 1;
                    }
                }
            }

            if (currentLine.Length > 0)
            {
                result.AppendLine(currentLine.ToString());
            }

            return result.ToString();
        }

        public static Dictionary<TKey, TValue> Sort<TKey, TValue>(
            this Dictionary<TKey, TValue> unsorted, 
            Dictionary<TKey, TValue> reference) where TKey : notnull
        {
            var sortedTarget = new Dictionary<TKey, TValue>();

            foreach (var kvp in reference.Where(kvp => unsorted.ContainsKey(kvp.Key)))
            {
                sortedTarget[kvp.Key] = unsorted[kvp.Key];
            }

            return sortedTarget;
        }

        public static (Dictionary<string, string> defaultLang, Dictionary<string, string> targetLang) ReadMap(this IMod mod, string lang)
        {
            var files = Directory.GetFiles(mod.PathS + "\\i18n", "*.json");
            var defaultLangFile = files.First(x => x.Contains("default"));
            var targetLangFile = files.FirstOrDefault(x => x.Contains(lang));
            var defaultLang = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(defaultLangFile))!;
            var targetLangTemp = targetLangFile != null ?
                JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(targetLangFile))! : new Dictionary<string, string>();
            var targetLang = targetLangTemp.Sort(defaultLang);
            return (defaultLang, targetLang);
        }
    }
}
