using Startran.Trans;

namespace Startran.Forms;

public partial class SettingsForm : Form
{
    private readonly AppConfig _config;

    private void InitializeComponent()
    {
        DirectoryPathLabel = new Label();
        DirectoryPathTextBox = new TextBox();
        LangLabel = new Label();
        LangTextBox = new TextBox();
        EnToZhLabel = new Label();
        EnToZhRichTextBox = new RichTextBox();
        ApiSettingLabel = new Label();
        ApiComboBox = new ComboBox();
        ApiSettingButton = new Button();
        SaveButton = new Button();
        OtherLabel = new Label();
        IsSaveSourceCkBox = new CheckBox();
        IsSaveTranslatedCkBox = new CheckBox();
        this.DebugCheckBox = new CheckBox();
        SuspendLayout();
        // 
        // DirectoryPathLabel
        // 
        DirectoryPathLabel.AutoSize = true;
        DirectoryPathLabel.Location = new Point(12, 9);
        DirectoryPathLabel.Name = "DirectoryPathLabel";
        DirectoryPathLabel.Size = new Size(93, 17);
        DirectoryPathLabel.TabIndex = 0;
        DirectoryPathLabel.Text = "Directory Path:";
        // 
        // DirectoryPathTextBox
        // 
        DirectoryPathTextBox.Location = new Point(12, 32);
        DirectoryPathTextBox.Name = "DirectoryPathTextBox";
        DirectoryPathTextBox.Size = new Size(426, 23);
        DirectoryPathTextBox.TabIndex = 1;
        // 
        // LangLabel
        // 
        LangLabel.AutoSize = true;
        LangLabel.Location = new Point(12, 62);
        LangLabel.Name = "LangLabel";
        LangLabel.Size = new Size(68, 17);
        LangLabel.TabIndex = 2;
        LangLabel.Text = "Language:";
        // 
        // LangTextBox
        // 
        LangTextBox.Location = new Point(12, 85);
        LangTextBox.Name = "LangTextBox";
        LangTextBox.Size = new Size(426, 23);
        LangTextBox.TabIndex = 3;
        // 
        // EnToZhLabel
        // 
        EnToZhLabel.AutoSize = true;
        EnToZhLabel.Location = new Point(12, 115);
        EnToZhLabel.Name = "EnToZhLabel";
        EnToZhLabel.Size = new Size(148, 17);
        EnToZhLabel.TabIndex = 4;
        EnToZhLabel.Text = "Translation prompt text:";
        // 
        // EnToZhRichTextBox
        // 
        EnToZhRichTextBox.Location = new Point(12, 138);
        EnToZhRichTextBox.Name = "EnToZhRichTextBox";
        EnToZhRichTextBox.Size = new Size(426, 184);
        EnToZhRichTextBox.TabIndex = 5;
        EnToZhRichTextBox.Text = "";
        // 
        // ApiSettingLabel
        // 
        ApiSettingLabel.AutoSize = true;
        ApiSettingLabel.Location = new Point(12, 325);
        ApiSettingLabel.Name = "ApiSettingLabel";
        ApiSettingLabel.Size = new Size(74, 17);
        ApiSettingLabel.TabIndex = 6;
        ApiSettingLabel.Text = "Api Setting:";
        // 
        // ApiComboBox
        // 
        ApiComboBox.FormattingEnabled = true;
        ApiComboBox.Location = new Point(12, 348);
        ApiComboBox.Name = "ApiComboBox";
        ApiComboBox.Size = new Size(326, 25);
        ApiComboBox.TabIndex = 7;
        // 
        // ApiSettingButton
        // 
        ApiSettingButton.Location = new Point(344, 348);
        ApiSettingButton.Name = "ApiSettingButton";
        ApiSettingButton.Size = new Size(94, 29);
        ApiSettingButton.TabIndex = 8;
        ApiSettingButton.Text = Lang.Strings.SettingsButton;
        ApiSettingButton.UseVisualStyleBackColor = true;
        ApiSettingButton.Click += ApiSettingButton_Click;
        // 
        // SaveButton
        // 
        SaveButton.Location = new Point(344, 476);
        SaveButton.Name = "SaveButton";
        SaveButton.Size = new Size(94, 29);
        SaveButton.TabIndex = 9;
        SaveButton.Text = Lang.Strings.Save;
        SaveButton.UseVisualStyleBackColor = true;
        SaveButton.Click += SaveButton_Click;
        // 
        // OtherLabel
        // 
        OtherLabel.AutoSize = true;
        OtherLabel.Location = new Point(12, 379);
        OtherLabel.Name = "OtherLabel";
        OtherLabel.Size = new Size(44, 17);
        OtherLabel.TabIndex = 10;
        OtherLabel.Text = "Other:";
        // 
        // IsSaveSourceCkBox
        // 
        IsSaveSourceCkBox.AutoSize = true;
        IsSaveSourceCkBox.Location = new Point(12, 402);
        IsSaveSourceCkBox.Name = "IsSaveSourceCkBox";
        IsSaveSourceCkBox.Size = new Size(186, 21);
        IsSaveSourceCkBox.TabIndex = 11;
        IsSaveSourceCkBox.Text = "Save target lang source file";
        IsSaveSourceCkBox.UseVisualStyleBackColor = true;
        // 
        // IsSaveTranslatedCkBox
        // 
        IsSaveTranslatedCkBox.AutoSize = true;
        IsSaveTranslatedCkBox.Location = new Point(12, 432);
        IsSaveTranslatedCkBox.Name = "IsSaveTranslatedCkBox";
        IsSaveTranslatedCkBox.Size = new Size(166, 21);
        IsSaveTranslatedCkBox.TabIndex = 12;
        IsSaveTranslatedCkBox.Text = "Save translated lang file";
        IsSaveTranslatedCkBox.UseVisualStyleBackColor = true;
        // 
        // DebugCheckBox
        // 
        this.DebugCheckBox.AutoSize = true;
        this.DebugCheckBox.Location = new Point(12, 459);
        this.DebugCheckBox.Name = "DebugCheckBox";
        this.DebugCheckBox.Size = new Size(66, 21);
        this.DebugCheckBox.TabIndex = 13;
        this.DebugCheckBox.Text = "Debug";
        this.DebugCheckBox.UseVisualStyleBackColor = true;
        // 
        // SettingsForm
        // 
        ClientSize = new Size(450, 517);
        Controls.Add(this.DebugCheckBox);
        Controls.Add(IsSaveTranslatedCkBox);
        Controls.Add(IsSaveSourceCkBox);
        Controls.Add(OtherLabel);
        Controls.Add(SaveButton);
        Controls.Add(ApiSettingButton);
        Controls.Add(ApiComboBox);
        Controls.Add(ApiSettingLabel);
        Controls.Add(EnToZhRichTextBox);
        Controls.Add(EnToZhLabel);
        Controls.Add(LangTextBox);
        Controls.Add(LangLabel);
        Controls.Add(DirectoryPathTextBox);
        Controls.Add(DirectoryPathLabel);
        Name = "SettingsForm";
        ShowIcon = false;
        Text = "Setting";
        ResumeLayout(false);
        PerformLayout();
    }

    private void ApiSettingButton_Click(object? sender, EventArgs e)
    {
        new OpenAiSettingForm(_config).ShowDialog();
    }

    public SettingsForm(AppConfig config)
    {
        _config = config;
        StartPosition = FormStartPosition.CenterScreen;
        InitializeComponent();
        DirectoryPathTextBox.Text = config.DirectoryPath;
        LangTextBox.Text = config.Language;
        EnToZhRichTextBox.Text = config.EnToCn;
        ApiComboBox.Items.AddRange(Translator.Apis.Select(it => it.Name).ToArray<object>());
        ApiComboBox.SelectedItem = config.ApiSelected;
        IsSaveSourceCkBox.Checked = config.IsSaveSource;
        IsSaveTranslatedCkBox.Checked = config.IsSaveTranslated;
        DebugCheckBox.Checked = config.Debug;
    }

    private void SaveButton_Click(object? sender, EventArgs e)
    {
        _config.DirectoryPath = DirectoryPathTextBox.Text;
        _config.Language = LangTextBox.Text;
        _config.EnToCn = EnToZhRichTextBox.Text;
        _config.ApiSelected = ApiComboBox.SelectedItem!.ToString()!;
        _config.IsSaveSource = IsSaveSourceCkBox.Checked;
        _config.IsSaveTranslated = IsSaveTranslatedCkBox.Checked;
        _config.Debug = DebugCheckBox.Checked;
        Close();
    }
}