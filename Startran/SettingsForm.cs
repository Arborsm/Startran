﻿namespace Startran;

public partial class SettingsForm : Form
{
    private readonly AppConfig _config;
    public SettingsForm(AppConfig config)
    {
        _config = config;
        StartPosition = FormStartPosition.CenterScreen;
        InitializeComponent();
        DirectoryPathTextBox.Text = config.DirectoryPath;
        LangTextBox.Text = config.Language;
        EnToZhRichTextBox.Text = config.EnToCn;
        ApiComboBox.Items.AddRange([.. config.Apis]);
        ApiComboBox.SelectedItem = config.Api;
    }
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
        SuspendLayout();
        // 
        // DirectoryPathLabel
        // 
        DirectoryPathLabel.AutoSize = true;
        DirectoryPathLabel.Location = new Point(12, 9);
        DirectoryPathLabel.Name = "DirectoryPathLabel";
        DirectoryPathLabel.Size = new Size(117, 20);
        DirectoryPathLabel.TabIndex = 0;
        DirectoryPathLabel.Text = "Directory Path:";
        // 
        // DirectoryPathTextBox
        // 
        DirectoryPathTextBox.Location = new Point(12, 32);
        DirectoryPathTextBox.Name = "DirectoryPathTextBox";
        DirectoryPathTextBox.Size = new Size(426, 27);
        DirectoryPathTextBox.TabIndex = 1;
        // 
        // LangLabel
        // 
        LangLabel.AutoSize = true;
        LangLabel.Location = new Point(12, 62);
        LangLabel.Name = "LangLabel";
        LangLabel.Size = new Size(84, 20);
        LangLabel.TabIndex = 2;
        LangLabel.Text = "Language:";
        // 
        // LangTextBox
        // 
        LangTextBox.Location = new Point(12, 85);
        LangTextBox.Name = "LangTextBox";
        LangTextBox.Size = new Size(426, 27);
        LangTextBox.TabIndex = 3;
        // 
        // EnToZhLabel
        // 
        EnToZhLabel.AutoSize = true;
        EnToZhLabel.Location = new Point(12, 115);
        EnToZhLabel.Name = "EnToZhLabel";
        EnToZhLabel.Size = new Size(67, 20);
        EnToZhLabel.TabIndex = 4;
        EnToZhLabel.Text = "EnToZh:";
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
        ApiSettingLabel.Size = new Size(95, 20);
        ApiSettingLabel.TabIndex = 6;
        ApiSettingLabel.Text = "Api Setting:";
        // 
        // ApiComboBox
        // 
        ApiComboBox.FormattingEnabled = true;
        ApiComboBox.Location = new Point(12, 348);
        ApiComboBox.Name = "ApiComboBox";
        ApiComboBox.Size = new Size(326, 28);
        ApiComboBox.TabIndex = 7;
        // 
        // ApiSettingButton
        // 
        ApiSettingButton.Location = new Point(344, 348);
        ApiSettingButton.Name = "ApiSettingButton";
        ApiSettingButton.Size = new Size(94, 29);
        ApiSettingButton.TabIndex = 8;
        ApiSettingButton.Text = "Setting";
        ApiSettingButton.UseVisualStyleBackColor = true;
        ApiSettingButton.Click += ApiSettingButton_Click;
        // 
        // SaveButton
        // 
        SaveButton.Location = new Point(344, 476);
        SaveButton.Name = "SaveButton";
        SaveButton.Size = new Size(94, 29);
        SaveButton.TabIndex = 9;
        SaveButton.Text = "Save";
        SaveButton.UseVisualStyleBackColor = true;
        SaveButton.Click += SaveButton_Click;
        // 
        // SettingsForm
        // 
        ClientSize = new Size(450, 517);
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
        ResumeLayout(false);
        PerformLayout();
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
        _config.Api = ApiComboBox.SelectedItem!.ToString()!;
        Close();
    }
}