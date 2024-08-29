using System.IO;
using System.Runtime.InteropServices;
using AntdUI;
using Startran.Config;
using Startran.Lang;
using Startran.Misc;
using Startran.Mod;
using Startran.Trans;

namespace Startran.Forms;

public partial class MainForm : Form
{
    private readonly MainConfig _config;
    private readonly Translator _trans;

    public MainForm()
    {
        StartPosition = FormStartPosition.CenterScreen;
        InitializeComponent();

        _config = ConfigManager<MainConfig>.Load();
        _trans = new Translator(_config);

        if (_config.Debug) AllocConsole();

        directoryTextBox.Text = _config.DirectoryPath;
    }

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool AllocConsole();

    private async void TranslateButton_Click(object sender, EventArgs e)
    {
        var userInput = inputTextBox.Text.Trim();
        if (string.IsNullOrEmpty(userInput)) return;

        inputTextBox.Text = string.Empty;
        ShowLoadingIndicator(Strings.Translating);

        var translatedText = await _trans.TranslateText(userInput);

        if (!string.IsNullOrEmpty(translatedText))
        {
            DisplayTranslationResult(translatedText);
        }
        else
        {
            HandleTranslationError();
        }
    }

    private void ShowLoadingIndicator(string message)
    {
        MessageTool.Loading(this, message, _ => { Thread.Sleep(30000); }, Font, 30);
    }

    private void DisplayTranslationResult(string text)
    {
        MessageTool.SuccessWithBreak(this, string.Format(Strings.Copid, text));
        Clipboard.SetText(text);
    }

    private void HandleTranslationError()
    {
        MessageTool.Error(this, Strings.UnableTrans);
        new SettingsForm(_config, _trans).ShowDialog();
    }

    private async void ProcessButton_Click(object sender, EventArgs e)
    {
        var directoryPath = directoryTextBox.Text.Trim();
        if (!Directory.Exists(directoryPath))
        {
            MessageTool.Error(this, Strings.InvalidDirectoryPath);
            return;
        }

        await StartProcessingMods(directoryPath);
    }

    private async Task StartProcessingMods(string directoryPath)
    {
        var translateForm = new TranslateForm();
        translateForm.Show();
        await LoadMods(directoryPath);
        _trans.Form = translateForm;

        if (_config.IsBackup)
        {
            CreateBackup();
        }

        var result = await ProcessModsAsync();

        if (ModData.Instance.IsMismatchedTokens)
        {
            HandleMismatchedTokens();
        }

        switch (result)
        {
            case ProcessResult.Success:
                MessageTool.Success(this, Strings.ProcessFinished);
                break;
            case ProcessResult.Cancel:
                break;
            case ProcessResult.Fail:
            default:
                translateForm.Close();
                break;
        }
    }

    private async Task LoadMods(string directoryPath)
    {
        await ModData.Instance.FindModsAsync(directoryPath, _config);
    }

    private void CreateBackup()
    {
        var tempPath = Path.Combine(Path.GetTempPath(), "StarTans");

        foreach (var mod in ModData.Instance.ProcessMods)
        {
            BackupMod(mod, tempPath);
        }

        var zipFileName = $"backup-{DateTime.Now:yyyy-MM-dd-HH-mm-ss}.zip";
        tempPath.CreateZipBackup(zipFileName);
        Directory.Delete(tempPath, true);
    }

    private static void BackupMod(IMod mod, string tempPath)
    {
        var i18NFolderPath = Path.Combine(mod.PathS, "i18n");
        var files = Directory.GetFiles(i18NFolderPath, "*", SearchOption.AllDirectories);

        var backupPath = Path.Combine(tempPath, mod.Name.SanitizePath(), "i18n");
        Directory.CreateDirectory(backupPath);

        foreach (var file in files)
        {
            var newPath = file.Replace(i18NFolderPath, backupPath);
            File.Copy(file, newPath, true);
        }
    }

    private async Task<ProcessResult> ProcessModsAsync()
    {
        try
        {
            return await _trans.ProcessDirectories();
        }
        catch (OperationCanceledException)
        {
            MessageTool.Info(this, Strings.TranslationStopped);
            return ProcessResult.Cancel;
        }
        catch (Exception ex)
        {
            Console.WriteLine();
            NotifyError(Strings.ErrorTranslating,
                Strings.ErrorTranslatingMsg + ex.Message);
            return ProcessResult.Fail;
        }
    }

    private void HandleMismatchedTokens()
    {
        var result = MessageBox.Show(Strings.TranslationMismatch, Strings.Warning, MessageBoxButtons.OKCancel);
        if (result == DialogResult.OK)
        {
            var proofreadForm = new ProofreadForm(_config, true);
            proofreadForm.Show();
        }
    }

    private void NotifyError(string title, string message)
    {
        Notification.error(this, title, message);
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
        using var folderBrowserDialog = new FolderBrowserDialog();
        folderBrowserDialog.ShowNewFolderButton = true;
        folderBrowserDialog.SelectedPath = directoryTextBox.Text;

        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        {
            UpdateDirectoryPath(folderBrowserDialog.SelectedPath);
        }
    }

    private void UpdateDirectoryPath(string selectedPath)
    {
        directoryTextBox.Text = selectedPath;
        _config.DirectoryPath = selectedPath;
        ConfigManager<MainConfig>.Save(_config);
    }

    private void SettingToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var settingsForm = new SettingsForm(_config, _trans);
        settingsForm.ShowDialog();
        ConfigManager<MainConfig>.Save(_config);
        directoryTextBox.Text = _config.DirectoryPath;
    }

    private async void ProofreadButton_Click(object sender, EventArgs e)
    {
        await ModData.Instance.FindModsAsync(directoryTextBox.Text.Trim(), _config);
        new ProofreadForm(_config).ShowDialog();
    }
}