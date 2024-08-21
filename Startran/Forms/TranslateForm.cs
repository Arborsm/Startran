using AntdUI;

namespace Startran.Forms;

public partial class TranslateForm : BorderlessForm
{
    public CancellationTokenSource Tsl;

    public TranslateForm()
    {
        StartPosition = FormStartPosition.CenterScreen;
        InitializeComponent();
        Tsl = new CancellationTokenSource();
        FormClosing += Form2_FormClosing;
    }

    private void Form2_FormClosing(object? sender, FormClosingEventArgs e)
    {
        Tsl.Cancel();
    }

    public Action MainProgressUpdate(float progress, string message)
    {
        return () =>
        {
            MainProgress.Value += progress;
            MainProgress.Text = message;
        };
    }

    public Action SonProgressUpdate(string key, List<string> processedMapKeys, List<string> keys)
    {
        return () =>
        {
            var text = $@"{processedMapKeys.Count}/{keys.Count}";
            var g = CreateGraphics();
            var keyTextSize = g.MeasureString(key, KeyLabel.Font);
            var keyLabelPoint = KeyLabel.Location with { X = (int)(ClientSize.Width / 2f - keyTextSize.Width / 2) };
            g.Dispose();
            KeyLabel.Text = key;
            KeyLabel.Location = keyLabelPoint;
            SonProgress.Text = text;
            SonProgress.Value = processedMapKeys.Count / (float) keys.Count;
        };
    }
}