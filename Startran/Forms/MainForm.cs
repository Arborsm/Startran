using Startran.Trans;
using System.DirectoryServices.ActiveDirectory;
using Startran.Mod;

namespace Startran.Forms;

public partial class MainForm : Form
{
    private readonly AppConfig _config;
    private readonly Translator _trans;

    public MainForm()
    {
        StartPosition = FormStartPosition.CenterScreen;
        InitializeComponent();
        _config = AppConfig.Load();
        _trans = new Translator(_config, this);
        directoryTextBox.Text = _config.DirectoryPath;
    }

    private async void TranslateButton_Click(object sender, EventArgs e)
    {
        var userInput = inputTextBox.Text.Trim();
        inputTextBox.Text = string.Empty;
        if (string.IsNullOrEmpty(userInput)) return;
        outputTextBox.AppendText(await _trans.TranslateText(userInput) + Environment.NewLine);
    }

    private async void ProcessButton_Click(object sender, EventArgs e)
    {
        var directoryPath = directoryTextBox.Text.Trim();
        if (Directory.Exists(directoryPath))
        {
            ModData.Instance.FindMods(directoryPath);
            mainPogressBar.Value = 0;
            outputTextBox.Text = string.Empty;
            await _trans.ProcessDirectories(directoryPath);
            sonLabel.Text = Lang.Strings.BeforTrans;
            InforLabel.Text = string.Empty;
            NumLabel.Text = string.Empty;
            MainNumLabel.Text = string.Empty;
            MessageBox.Show(Lang.Strings.ProcessFinished);
        }
        else
        {
            MessageBox.Show(Lang.Strings.InvalidDirectoryPath);
        }
    }

    private void SettingsButton_Click(object sender, EventArgs e)
    {
        var settingsForm = new SettingsForm(_config);
        settingsForm.ShowDialog();
        _config.Save();
        directoryTextBox.Text = _config.DirectoryPath;
    }

    private void InputTextBox_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            translateButton.PerformClick();
        }
    }

    private void SelectFolder_Click(object sender, EventArgs e)
    {
        var folderBrowserDialog1 = new FolderBrowserDialog
        {
            ShowNewFolderButton = true,
            SelectedPath = directoryTextBox.Text
        };
        if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
        {
            directoryTextBox.Text = folderBrowserDialog1.SelectedPath;
            _config.DirectoryPath = directoryTextBox.Text;
        }
    }

    public Action UpdateText(string key, string result, List<string> processedMapKeys, List<string> keys)
    {
        return () =>
        {
            var text = $@"{processedMapKeys.Count}/{keys.Count}";
            var g = CreateGraphics();
            var numLabelTextSize = g.MeasureString(text, NumLabel.Font);
            var numLabelPoint = NumLabel.Location with { X = (int)(ClientSize.Width - numLabelTextSize.Width - 12) };
            g.Dispose();
            sonLabel.Text = Lang.Strings.Translating;
            InforLabel.Text = key;
            NumLabel.Text = text;
            NumLabel.Location = numLabelPoint;
            outputTextBox.AppendText(result + Environment.NewLine);
            outputTextBox.ScrollToCaret();
            sonProgressPar.Value++;
        };
    }

    public Action UpdateMainText(int num)
    {
        return () =>
        {
            var text = $@"{num}/{mainPogressBar.Maximum}";
            var g = CreateGraphics();
            var mainNumLabelTextSize = g.MeasureString(text, MainNumLabel.Font);
            var mainNumLabelPoint = MainNumLabel.Location with { X = (int)(ClientSize.Width - mainNumLabelTextSize.Width - 12) };
            g.Dispose();
            MainNumLabel.Text = text;
            MainNumLabel.Location = mainNumLabelPoint;
        };
    }
}