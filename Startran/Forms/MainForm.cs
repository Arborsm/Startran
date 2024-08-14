using System.IO;
using AntdUI;
using Startran.Misc;
using Startran.Mod;
using Startran.Trans;

namespace Startran.Forms;

public partial class MainForm : Window
{
    private readonly AppConfig _config;
    private readonly Translator _trans;

    public MainForm()
    {
        StartPosition = FormStartPosition.CenterScreen;
        InitializeComponent();
        menuStrip1.HideImageMargins();
        _config = AppConfig.Load();
        _trans = new Translator(_config);
        directoryTextBox.Text = _config.DirectoryPath;
    }

    private async void TranslateButton_Click(object sender, EventArgs e)
    {
        var userInput = inputTextBox.Text.Trim();
        inputTextBox.Text = string.Empty;
        if (string.IsNullOrEmpty(userInput)) return;
        MessageTool.Loading(this, "Action in progress..", _ =>
        {
            Thread.Sleep(30000);
        }, Font, 30);
        var text = await _trans.TranslateText(userInput);
        MessageTool.SuccessWithBreak(this, $"Copied: {text}");
        Clipboard.SetText(text);
    }

    private async void ProcessButton_Click(object sender, EventArgs e)
    {
        var directoryPath = directoryTextBox.Text.Trim();
        if (Directory.Exists(directoryPath))
        {
            var translateForm = new TranslateForm();
            translateForm.Show();
            await ModData.Instance.FindModsAsync(directoryPath);
            _trans.Form = translateForm;
            await _trans.ProcessDirectories();
            MessageTool.Success(this, Lang.Strings.ProcessFinished);
        }
        else
        {
            MessageTool.Error(this, Lang.Strings.InvalidDirectoryPath);
        }
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

    private void settingToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var settingsForm = new SettingsForm(_config);
        settingsForm.ShowDialog();
        _config.Save();
        directoryTextBox.Text = _config.DirectoryPath;
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var aboutBox = new AboutBox();
        aboutBox.ShowDialog();
    }

    private void proofreadToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var proofreadForm = new ProofreadForm();
        proofreadForm.ShowDialog();
    }
}