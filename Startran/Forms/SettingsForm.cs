using Startran.Config;
using Startran.Trans;

namespace Startran.Forms;

public partial class SettingsForm : Form
{
    private readonly MainConfig _config;
    private readonly Translator _trans;

    public SettingsForm(MainConfig config, Translator trans)
    {
        _config = config;
        _trans = trans;
        StartPosition = FormStartPosition.CenterScreen;
        InitializeComponent();
        DirectoryPathTextBox.Text = config.DirectoryPath;
        LangTextBox.Text = config.Language;
        EnToZhRichTextBox.Text = config.EnToCn;
        ApiComboBox.Items.AddRange(trans.Apis.Select(it => it.Name).ToArray<object>());
        ApiComboBox.SelectedItem = config.ApiSelected;
        IsBackupCheckBox.Checked = config.IsBackup;
        DebugCheckBox.Checked = config.Debug;
    }

    private void ApiSettingButton_Click(object? sender, EventArgs e)
    {
        new ApiSettingForm(_config, _trans).ShowDialog();
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

    private void ApiComboBox_SelectedIndexChanged(object? sender, EventArgs e)
    {
        _config.ApiSelected = ApiComboBox.SelectedItem!.ToString()!;
        _trans.CurrentTranslator = _trans.UpdateConfig();
        _config.ApiConf = ConfigManager<ApiConfig>.Load(_config.ApiSelected);
    }
}