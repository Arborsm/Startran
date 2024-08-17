using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Runtime.InteropServices;
using AntdUI;
using Startran.Misc;
using Startran.Mod;
using Startran.Trans;

namespace Startran.Forms;

public partial class MainForm : Form
{
    private readonly AppConfig _config;
    private readonly Translator _trans;

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool AllocConsole();

    public MainForm()
    {
        StartPosition = FormStartPosition.CenterScreen;
        InitializeComponent();
        menuStrip1.HideImageMargins();
        _config = AppConfig.Load();
        _trans = new Translator(_config);
        if (_config.Debug)
        {
            AllocConsole();
        }
        directoryTextBox.Text = _config.DirectoryPath;
    }

    private async void TranslateButton_Click(object sender, EventArgs e)
    {
        var userInput = inputTextBox.Text.Trim();
        inputTextBox.Text = string.Empty;
        var text = string.Empty;
        if (string.IsNullOrEmpty(userInput)) return;
        MessageTool.Loading(this, "Action in progress..", _ =>
        {
            Thread.Sleep(30000);
        }, Font, 30);
        
        text = await _trans.TranslateText(userInput);

        if (!string.IsNullOrEmpty(text))
        {
            MessageTool.SuccessWithBreak(this, $"Copied: {text}");
            Clipboard.SetText(text);
        } 
        else
        {
            MessageTool.Error(this, "Unable to translate");
            new SettingsForm(_config).ShowDialog();
        }
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
            var success = false;
            try
            {
                success = await _trans.ProcessDirectories();
            }
            catch (Exception ex)
            {
                if (ex is OperationCanceledException)
                {
                    MessageTool.Info(this, "Stop Translating");
                }
                else
                {
                    Console.WriteLine(ex.Message);
                    Notification.error(this, "Error while translating", @$"Unable to get translated result, maybe you need to check you setting!");
                }
            }

            if (success) MessageTool.Success(this, Lang.Strings.ProcessFinished);
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

    private void SettingToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var settingsForm = new SettingsForm(_config);
        settingsForm.ShowDialog();
        _config.Save();
        directoryTextBox.Text = _config.DirectoryPath;
    }

    private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var aboutBox = new AboutBox();
        aboutBox.ShowDialog();
    }

    private async void ProofreadToolStripMenuItem_Click(object sender, EventArgs e)
    {
        await ModData.Instance.FindModsAsync(directoryTextBox.Text.Trim());
        var proofreadForm = new ProofreadForm(_config);
        proofreadForm.ShowDialog();
    }
}