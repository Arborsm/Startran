using Startran.Lang;

namespace Startran.Forms
{
    partial class TranslateForm
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            windowBar1 = new AntdUI.WindowBar();
            MainProgress = new AntdUI.Progress();
            SonProgress = new AntdUI.Progress();
            KeyLabel = new Label();
            SuspendLayout();
            // 
            // windowBar1
            // 
            windowBar1.Dock = DockStyle.Top;
            windowBar1.Location = new Point(0, 0);
            windowBar1.MaximizeBox = false;
            windowBar1.Name = "windowBar1";
            windowBar1.ShowIcon = false;
            windowBar1.Size = new Size(200, 23);
            windowBar1.TabIndex = 0;
            windowBar1.Text = Strings.Translating;
            // 
            // MainProgress
            // 
            MainProgress.ContainerControl = this;
            MainProgress.Location = new Point(12, 207);
            MainProgress.Name = "MainProgress";
            MainProgress.Size = new Size(176, 21);
            MainProgress.TabIndex = 2;
            MainProgress.TabStop = false;
            MainProgress.Text = " ";
            // 
            // SonProgress
            // 
            SonProgress.ContainerControl = this;
            SonProgress.Location = new Point(35, 29);
            SonProgress.Name = "SonProgress";
            SonProgress.Shape = AntdUI.TShape.Circle;
            SonProgress.Size = new Size(130, 130);
            SonProgress.TabIndex = 3;
            SonProgress.TabStop = false;
            SonProgress.Text = " ";
            // 
            // KeyLabel
            // 
            KeyLabel.AutoSize = true;
            KeyLabel.Location = new Point(100, 180);
            KeyLabel.Name = "KeyLabel";
            KeyLabel.Size = new Size(12, 17);
            KeyLabel.TabIndex = 4;
            KeyLabel.Text = " ";
            // 
            // TranslateForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(200, 240);
            Controls.Add(KeyLabel);
            Controls.Add(SonProgress);
            Controls.Add(MainProgress);
            Controls.Add(windowBar1);
            Name = "TranslateForm";
            //Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private AntdUI.WindowBar windowBar1;
        private AntdUI.Progress MainProgress;
        private AntdUI.Progress SonProgress;
        private Label KeyLabel;
    }
}