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
    }
}
