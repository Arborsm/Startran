namespace Startran.Forms
{
    partial class MainForm
    {
        internal System.ComponentModel.IContainer components = null;
        internal System.Windows.Forms.TextBox inputTextBox;
        internal System.Windows.Forms.TextBox outputTextBox;
        internal System.Windows.Forms.TextBox directoryTextBox;
        internal System.Windows.Forms.Button translateButton;
        internal System.Windows.Forms.Button processButton;
        internal System.Windows.Forms.Button settingsButton;
        internal System.Windows.Forms.ProgressBar mainPogressBar;

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
            outputTextBox = new TextBox();
            directoryTextBox = new TextBox();
            translateButton = new Button();
            processButton = new Button();
            settingsButton = new Button();
            mainPogressBar = new ProgressBar();
            ModsFolderLabel = new Label();
            sonLabel = new Label();
            sonProgressPar = new ProgressBar();
            SelectFolder = new Button();
            InforLabel = new Label();
            NumLabel = new Label();
            MainNumLabel = new Label();
            SuspendLayout();
            // 
            // inputTextBox
            // 
            inputTextBox.Location = new Point(14, 50);
            inputTextBox.Margin = new Padding(3, 4, 3, 4);
            inputTextBox.Multiline = true;
            inputTextBox.Name = "inputTextBox";
            inputTextBox.Size = new Size(682, 29);
            inputTextBox.TabIndex = 0;
            inputTextBox.KeyDown += InputTextBox_KeyDown;
            // 
            // outputTextBox
            // 
            outputTextBox.Location = new Point(14, 194);
            outputTextBox.Margin = new Padding(3, 4, 3, 4);
            outputTextBox.Multiline = true;
            outputTextBox.Name = "outputTextBox";
            outputTextBox.ReadOnly = true;
            outputTextBox.ScrollBars = ScrollBars.Vertical;
            outputTextBox.Size = new Size(872, 355);
            outputTextBox.TabIndex = 1;
            // 
            // directoryTextBox
            // 
            directoryTextBox.Location = new Point(126, 15);
            directoryTextBox.Margin = new Padding(3, 4, 3, 4);
            directoryTextBox.Name = "directoryTextBox";
            directoryTextBox.Size = new Size(570, 27);
            directoryTextBox.TabIndex = 4;
            directoryTextBox.Text = "src/main/resources/";
            // 
            // translateButton
            // 
            translateButton.Location = new Point(802, 50);
            translateButton.Margin = new Padding(3, 4, 3, 4);
            translateButton.Name = "translateButton";
            translateButton.Size = new Size(84, 29);
            translateButton.TabIndex = 2;
            translateButton.Text = Lang.Strings.TranslateButton;
            translateButton.UseVisualStyleBackColor = true;
            translateButton.Click += TranslateButton_Click;
            // 
            // processButton
            // 
            processButton.Location = new Point(802, 15);
            processButton.Margin = new Padding(3, 4, 3, 4);
            processButton.Name = "processButton";
            processButton.Size = new Size(84, 29);
            processButton.TabIndex = 3;
            processButton.Text = Lang.Strings.ProcessButton;
            processButton.UseVisualStyleBackColor = true;
            processButton.Click += ProcessButton_Click;
            // 
            // settingsButton
            // 
            settingsButton.Location = new Point(702, 50);
            settingsButton.Margin = new Padding(3, 4, 3, 4);
            settingsButton.Name = "settingsButton";
            settingsButton.Size = new Size(94, 29);
            settingsButton.TabIndex = 6;
            settingsButton.Text = Lang.Strings.SettingsButton;
            settingsButton.UseVisualStyleBackColor = true;
            settingsButton.Click += SettingsButton_Click;
            // 
            // mainPogressBar
            // 
            mainPogressBar.Location = new Point(14, 107);
            mainPogressBar.Margin = new Padding(3, 4, 3, 4);
            mainPogressBar.Name = "mainPogressBar";
            mainPogressBar.Size = new Size(872, 29);
            mainPogressBar.TabIndex = 5;
            // 
            // ModsFolderLabel
            // 
            ModsFolderLabel.AutoSize = true;
            ModsFolderLabel.Location = new Point(14, 18);
            ModsFolderLabel.Name = "ModsFolderLabel";
            ModsFolderLabel.Size = new Size(106, 20);
            ModsFolderLabel.TabIndex = 7;
            ModsFolderLabel.Text = "Mods Folder:";
            // 
            // sonLabel
            // 
            sonLabel.AutoSize = true;
            sonLabel.Location = new Point(12, 83);
            sonLabel.Name = "sonLabel";
            sonLabel.Size = new Size(439, 20);
            sonLabel.TabIndex = 8;
            sonLabel.Text = "After setting up, select the 'mods' folder and press process";
            // 
            // sonProgressPar
            // 
            sonProgressPar.Location = new Point(14, 163);
            sonProgressPar.Name = "sonProgressPar";
            sonProgressPar.Size = new Size(872, 15);
            sonProgressPar.TabIndex = 9;
            // 
            // SelectFolder
            // 
            SelectFolder.Font = new Font("Microsoft YaHei UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 134);
            SelectFolder.Location = new Point(702, 15);
            SelectFolder.Name = "SelectFolder";
            SelectFolder.Size = new Size(94, 29);
            SelectFolder.TabIndex = 10;
            SelectFolder.Text = Lang.Strings.SelectFolderButton;
            SelectFolder.UseVisualStyleBackColor = true;
            SelectFolder.Click += SelectFolder_Click;
            // 
            // InforLabel
            // 
            InforLabel.AutoSize = true;
            InforLabel.Location = new Point(12, 140);
            InforLabel.Name = "InforLabel";
            InforLabel.Size = new Size(0, 20);
            InforLabel.TabIndex = 11;
            // 
            // NumLabel
            // 
            NumLabel.AutoSize = true;
            NumLabel.Location = new Point(828, 140);
            NumLabel.Name = "NumLabel";
            NumLabel.Size = new Size(0, 20);
            NumLabel.TabIndex = 12;
            // 
            // MainNumLabel
            // 
            MainNumLabel.AutoSize = true;
            MainNumLabel.Location = new Point(833, 83);
            MainNumLabel.Name = "MainNumLabel";
            MainNumLabel.Size = new Size(0, 20);
            MainNumLabel.TabIndex = 13;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 562);
            Controls.Add(MainNumLabel);
            Controls.Add(NumLabel);
            Controls.Add(InforLabel);
            Controls.Add(SelectFolder);
            Controls.Add(sonProgressPar);
            Controls.Add(sonLabel);
            Controls.Add(ModsFolderLabel);
            Controls.Add(settingsButton);
            Controls.Add(mainPogressBar);
            Controls.Add(directoryTextBox);
            Controls.Add(processButton);
            Controls.Add(translateButton);
            Controls.Add(outputTextBox);
            Controls.Add(inputTextBox);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "Translator App";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label ModsFolderLabel;
        internal Label sonLabel;
        internal ProgressBar sonProgressPar;
        private Button SelectFolder;
        internal Label InforLabel;
        internal Label NumLabel;
        private Label MainNumLabel;
    }
}