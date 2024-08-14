using AntdUI;

namespace Startran.Forms
{
    public partial class TranslateForm : BorderlessForm
    {

        public TranslateForm()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        public Action MainProgressUpdate(float progress, string message)
        {
            return () =>
            {
                MainProgress.Value += progress;
                MainProgress.Text = message;
            };
        }

        public Action SonProgressUpdate(string key, string result, List<string> processedMapKeys, List<string> keys)
        {
            return () =>
            {
                var text = $@"{processedMapKeys.Count}/{keys.Count}";
                var feet = 1.0f / keys.Count;
                var g = CreateGraphics();
                var keyTextSize = g.MeasureString(key, KeyLabel.Font);
                var keyLabelPoint = KeyLabel.Location with { X = (int)(ClientSize.Width / 2f - keyTextSize.Width/ 2) };
                g.Dispose();
                KeyLabel.Text = key;
                KeyLabel.Location = keyLabelPoint;
                SonProgress.Text = text;
                SonProgress.Value += feet;
            };
        }
    }
}
