using Startran.Lang;

namespace Startran.Forms
{
    partial class MainForm
    {
        internal System.ComponentModel.IContainer components = null;
        internal System.Windows.Forms.TextBox inputTextBox;
        internal System.Windows.Forms.TextBox directoryTextBox;
        internal System.Windows.Forms.Button translateButton;
        internal System.Windows.Forms.Button processButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            inputTextBox = new TextBox();
            directoryTextBox = new TextBox();
            translateButton = new Button();
            processButton = new Button();
            ModsFolderLabel = new Label();
            sonLabel = new Label();
            SelectFolder = new Button();
            TanslateTextLabel = new Label();
            menuStrip1 = new MenuStrip();
            mainToolStripMenuItem = new ToolStripMenuItem();
            settingToolStripMenuItem = new ToolStripMenuItem();
            TabControl = new TabControl();
            ProcessPage = new TabPage();
            TranslatePage = new TabPage();
            AutoCopyLabel = new Label();
            AutoCopySwitch = new AntdUI.Switch();
            ProofreadButton = new Button();
            menuStrip1.SuspendLayout();
            TabControl.SuspendLayout();
            ProcessPage.SuspendLayout();
            TranslatePage.SuspendLayout();
            SuspendLayout();
            // 
            // inputTextBox
            // 
            inputTextBox.Location = new Point(7, 23);
            inputTextBox.Margin = new Padding(2, 3, 2, 3);
            inputTextBox.Multiline = true;
            inputTextBox.Name = "inputTextBox";
            inputTextBox.Size = new Size(355, 103);
            inputTextBox.TabIndex = 2;
            inputTextBox.KeyDown += InputTextBox_KeyDown;
            // 
            // directoryTextBox
            // 
            directoryTextBox.Location = new Point(7, 40);
            directoryTextBox.Margin = new Padding(2, 3, 2, 3);
            directoryTextBox.Name = "directoryTextBox";
            directoryTextBox.Size = new Size(352, 23);
            directoryTextBox.TabIndex = 4;
            directoryTextBox.Text = "src/main/resources/";
            // 
            // translateButton
            // 
            translateButton.Location = new Point(289, 132);
            translateButton.Margin = new Padding(2, 3, 2, 3);
            translateButton.Name = "translateButton";
            translateButton.Size = new Size(73, 25);
            translateButton.TabIndex = 0;
            translateButton.Text = Strings.TranslateButton;
            translateButton.UseVisualStyleBackColor = true;
            translateButton.Click += TranslateButton_Click;
            // 
            // processButton
            // 
            processButton.Location = new Point(267, 118);
            processButton.Margin = new Padding(2, 3, 2, 3);
            processButton.Name = "processButton";
            processButton.Size = new Size(92, 35);
            processButton.TabIndex = 3;
            processButton.Text = Strings.ProcessButton;
            processButton.UseVisualStyleBackColor = true;
            processButton.Click += ProcessButton_Click;
            // 
            // ModsFolderLabel
            // 
            ModsFolderLabel.AutoSize = true;
            ModsFolderLabel.Location = new Point(5, 3);
            ModsFolderLabel.Margin = new Padding(2, 0, 2, 0);
            ModsFolderLabel.Name = "ModsFolderLabel";
            ModsFolderLabel.Size = new Size(86, 17);
            ModsFolderLabel.TabIndex = 7;
            ModsFolderLabel.Text = Strings.ModsFolder;
            // 
            // sonLabel
            // 
            sonLabel.AutoSize = true;
            sonLabel.Location = new Point(5, 20);
            sonLabel.Margin = new Padding(2, 0, 2, 0);
            sonLabel.Name = "sonLabel";
            sonLabel.Size = new Size(354, 17);
            sonLabel.TabIndex = 8;
            sonLabel.Text = Strings.BeforeTrans;
            // 
            // SelectFolder
            // 
            SelectFolder.Font = new Font("Microsoft YaHei UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            SelectFolder.Location = new Point(7, 118);
            SelectFolder.Margin = new Padding(2, 3, 2, 3);
            SelectFolder.Name = "SelectFolder";
            SelectFolder.Size = new Size(92, 35);
            SelectFolder.TabIndex = 10;
            SelectFolder.Text = Strings.SelectFolderButton;
            SelectFolder.UseVisualStyleBackColor = true;
            SelectFolder.Click += SelectFolder_Click;
            // 
            // TanslateTextLabel
            // 
            TanslateTextLabel.AutoSize = true;
            TanslateTextLabel.Location = new Point(7, 3);
            TanslateTextLabel.Margin = new Padding(2, 0, 2, 0);
            TanslateTextLabel.Name = "TanslateTextLabel";
            TanslateTextLabel.Size = new Size(79, 17);
            TanslateTextLabel.TabIndex = 14;
            TanslateTextLabel.Text = Strings.SourceText;
            // 
            // menuStrip1
            // 
            menuStrip1.Anchor = AnchorStyles.Right;
            menuStrip1.BackColor = SystemColors.Control;
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mainToolStripMenuItem });
            menuStrip1.Location = new Point(296, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            menuStrip1.RightToLeft = RightToLeft.Yes;
            menuStrip1.Size = new Size(72, 25);
            menuStrip1.Stretch = false;
            menuStrip1.TabIndex = 15;
            //menuStrip1.Text = "menuStrip1";
            // 
            // mainToolStripMenuItem
            // 
            mainToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { settingToolStripMenuItem });
            mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            mainToolStripMenuItem.RightToLeft = RightToLeft.Yes;
            mainToolStripMenuItem.Size = new Size(65, 21);
            mainToolStripMenuItem.Text = Strings.Main;
            // 
            // settingToolStripMenuItem
            // 
            settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            settingToolStripMenuItem.Size = new Size(180, 22);
            settingToolStripMenuItem.Text = Strings.SettingsButton;
            settingToolStripMenuItem.Click += SettingToolStripMenuItem_Click;
            // 
            // TabControl
            // 
            TabControl.Controls.Add(ProcessPage);
            TabControl.Controls.Add(TranslatePage);
            TabControl.Location = new Point(0, 5);
            TabControl.Name = "TabControl";
            TabControl.SelectedIndex = 0;
            TabControl.Size = new Size(376, 189);
            TabControl.TabIndex = 16;
            // 
            // ProcessPage
            // 
            ProcessPage.Controls.Add(ProofreadButton);
            ProcessPage.Controls.Add(directoryTextBox);
            ProcessPage.Controls.Add(ModsFolderLabel);
            ProcessPage.Controls.Add(sonLabel);
            ProcessPage.Controls.Add(SelectFolder);
            ProcessPage.Controls.Add(processButton);
            ProcessPage.Location = new Point(4, 26);
            ProcessPage.Name = "ProcessPage";
            ProcessPage.Padding = new Padding(3);
            ProcessPage.Size = new Size(368, 159);
            ProcessPage.TabIndex = 0;
            ProcessPage.Text = Strings.ProcessButton;
            ProcessPage.UseVisualStyleBackColor = true;
            // 
            // TranslatePage
            // 
            TranslatePage.Controls.Add(AutoCopyLabel);
            TranslatePage.Controls.Add(AutoCopySwitch);
            TranslatePage.Controls.Add(TanslateTextLabel);
            TranslatePage.Controls.Add(translateButton);
            TranslatePage.Controls.Add(inputTextBox);
            TranslatePage.Location = new Point(4, 26);
            TranslatePage.Name = "TranslatePage";
            TranslatePage.Padding = new Padding(3);
            TranslatePage.Size = new Size(368, 159);
            TranslatePage.TabIndex = 1;
            TranslatePage.Text = Strings.TranslateButton;
            TranslatePage.UseVisualStyleBackColor = true;
            // 
            // AutoCopyLabel
            // 
            AutoCopyLabel.Location = new Point(46, 136);
            AutoCopyLabel.Name = "AutoCopyLabel";
            AutoCopyLabel.Size = new Size(75, 23);
            AutoCopyLabel.TabIndex = 16;
            AutoCopyLabel.Text = Strings.AutoCopy;
            // 
            // AutoCopySwitch
            // 
            AutoCopySwitch.AutoCheck = true;
            AutoCopySwitch.Checked = true;
            AutoCopySwitch.Location = new Point(7, 132);
            AutoCopySwitch.Name = "AutoCopySwitch";
            AutoCopySwitch.Size = new Size(42, 25);
            AutoCopySwitch.TabIndex = 15;
            //AutoCopySwitch.Text = "switch1";
            // 
            // ProofreadButton
            // 
            ProofreadButton.Font = new Font("Microsoft YaHei UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            ProofreadButton.Location = new Point(137, 118);
            ProofreadButton.Margin = new Padding(2, 3, 2, 3);
            ProofreadButton.Name = "ProofreadButton";
            ProofreadButton.Size = new Size(92, 35);
            ProofreadButton.TabIndex = 11;
            ProofreadButton.Text = Strings.Proofread;
            ProofreadButton.UseVisualStyleBackColor = true;
            ProofreadButton.Click += ProofreadButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(374, 191);
            Controls.Add(menuStrip1);
            Controls.Add(TabControl);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2, 3, 2, 3);
            MaximizeBox = false;
            Name = "MainForm";
            ShowIcon = false;
            Text = Strings.StarTranslator;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            TabControl.ResumeLayout(false);
            ProcessPage.ResumeLayout(false);
            ProcessPage.PerformLayout();
            TranslatePage.ResumeLayout(false);
            TranslatePage.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label ModsFolderLabel;
        internal Label sonLabel;
        private Button SelectFolder;
        private Label TanslateTextLabel;
        private MenuStrip menuStrip1;
        private TabControl TabControl;
        private TabPage ProcessPage;
        private TabPage TranslatePage;
        private ToolStripMenuItem mainToolStripMenuItem;
        private AntdUI.Switch AutoCopySwitch;
        private Label AutoCopyLabel;
        private ToolStripMenuItem settingToolStripMenuItem;
        private Button ProofreadButton;
    }
}