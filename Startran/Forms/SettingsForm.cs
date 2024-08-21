namespace Startran.Forms;

public partial class SettingsForm : Form
{
    private readonly Config.MainConfig _config;

    public SettingsForm(Config.MainConfig config)
    {
        _config = config;
        StartPosition = FormStartPosition.CenterScreen;
        InitializeComponent();
        DirectoryPathTextBox.Text = config.DirectoryPath;
        LangTextBox.Text = config.Language;
        EnToZhRichTextBox.Text = config.EnToCn;
        ApiComboBox.Items.AddRange(Trans.Translator.Apis.Select(it => it.Name).ToArray<object>());
        ApiComboBox.SelectedItem = config.ApiSelected;
        IsBackupCheckBox.Checked = config.IsBackup;
        DebugCheckBox.Checked = config.Debug;
    }

    private void ApiSettingButton_Click(object? sender, EventArgs e)
    {
        new OpenAiSettingForm(_config).ShowDialog();
    }

    private void SaveButton_Click(object? sender, EventArgs e)
    {
        _config.DirectoryPath = DirectoryPathTextBox.Text;
        _config.Language = LangTextBox.Text;
        _config.EnToCn = EnToZhRichTextBox.Text;
        _config.ApiSelected = ApiComboBox.SelectedItem!.ToString()!;
        _config.Debug = DebugCheckBox.Checked;
        _config.IsBackup = IsBackupCheckBox.Checked;
        Close();
    }
}