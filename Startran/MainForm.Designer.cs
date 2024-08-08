namespace Startran
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox inputTextBox;
        internal System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.TextBox directoryTextBox;
        private System.Windows.Forms.Button translateButton;
        private System.Windows.Forms.Button processButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.ProgressBar progressBar;

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
            progressBar = new ProgressBar();
            ModsFolderLabel = new Label();
            SuspendLayout();
            // 
            // inputTextBox
            // 
            inputTextBox.Location = new Point(14, 50);
            inputTextBox.Margin = new Padding(3, 4, 3, 4);
            inputTextBox.Multiline = true;
            inputTextBox.Name = "inputTextBox";
            inputTextBox.Size = new Size(782, 29);
            inputTextBox.TabIndex = 0;
            // 
            // outputTextBox
            // 
            outputTextBox.Location = new Point(14, 124);
            outputTextBox.Margin = new Padding(3, 4, 3, 4);
            outputTextBox.Multiline = true;
            outputTextBox.Name = "outputTextBox";
            outputTextBox.Size = new Size(872, 425);
            outputTextBox.TabIndex = 1;
            // 
            // directoryTextBox
            // 
            directoryTextBox.Location = new Point(126, 15);
            directoryTextBox.Margin = new Padding(3, 4, 3, 4);
            directoryTextBox.Name = "directoryTextBox";
            directoryTextBox.Size = new Size(580, 27);
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
            translateButton.Text = "Translate";
            translateButton.UseVisualStyleBackColor = true;
            translateButton.Click += TranslateButton_Click;
            // 
            // processButton
            // 
            processButton.Location = new Point(712, 13);
            processButton.Margin = new Padding(3, 4, 3, 4);
            processButton.Name = "processButton";
            processButton.Size = new Size(84, 29);
            processButton.TabIndex = 3;
            processButton.Text = "Process";
            processButton.UseVisualStyleBackColor = true;
            processButton.Click += ProcessButton_Click;
            // 
            // settingsButton
            // 
            settingsButton.Location = new Point(802, 15);
            settingsButton.Margin = new Padding(3, 4, 3, 4);
            settingsButton.Name = "settingsButton";
            settingsButton.Size = new Size(84, 29);
            settingsButton.TabIndex = 6;
            settingsButton.Text = "Settings";
            settingsButton.UseVisualStyleBackColor = true;
            settingsButton.Click += SettingsButton_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(16, 87);
            progressBar.Margin = new Padding(3, 4, 3, 4);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(870, 29);
            progressBar.TabIndex = 5;
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 562);
            Controls.Add(ModsFolderLabel);
            Controls.Add(settingsButton);
            Controls.Add(progressBar);
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
    }
}