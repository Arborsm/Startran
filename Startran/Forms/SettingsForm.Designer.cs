namespace Startran.Forms;

public partial class SettingsForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
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
        DebugCheckBox = new CheckBox();
        IsBackupCheckBox = new CheckBox();
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
        // DebugCheckBox
        // 
        DebugCheckBox.AutoSize = true;
        DebugCheckBox.Location = new Point(12, 405);
        DebugCheckBox.Name = "DebugCheckBox";
        DebugCheckBox.Size = new Size(66, 21);
        DebugCheckBox.TabIndex = 13;
        DebugCheckBox.Text = "Debug";
        DebugCheckBox.UseVisualStyleBackColor = true;
        // 
        // IsBackupCheckBox
        // 
        IsBackupCheckBox.AutoSize = true;
        IsBackupCheckBox.Location = new Point(12, 432);
        IsBackupCheckBox.Name = "IsBackupCheckBox";
        IsBackupCheckBox.Size = new Size(70, 21);
        IsBackupCheckBox.TabIndex = 14;
        IsBackupCheckBox.Text = "Backup";
        IsBackupCheckBox.UseVisualStyleBackColor = true;
        // 
        // SettingsForm
        // 
        ClientSize = new Size(450, 517);
        Controls.Add(IsBackupCheckBox);
        Controls.Add(DebugCheckBox);
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
    #endregion

    private Label DirectoryPathLabel;
    private TextBox DirectoryPathTextBox;
    private Label LangLabel;
    private TextBox LangTextBox;
    private Label EnToZhLabel;
    private RichTextBox EnToZhRichTextBox;
    private Label ApiSettingLabel;
    private ComboBox ApiComboBox;
    private Button ApiSettingButton;
    private Button SaveButton;
    private Label OtherLabel;
    private CheckBox DebugCheckBox;
    private CheckBox IsBackupCheckBox;
}