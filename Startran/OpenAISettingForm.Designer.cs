namespace Startran
{
    partial class OpenAISettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenAISettingForm));
            modelLabel = new Label();
            urlLabel = new Label();
            apiLabel = new Label();
            ApiComboBox = new ComboBox();
            urlTextBox = new TextBox();
            apiTextBox = new TextBox();
            SaveButton = new Button();
            SuspendLayout();
            // 
            // modelLabel
            // 
            resources.ApplyResources(modelLabel, "modelLabel");
            modelLabel.Name = "modelLabel";
            // 
            // urlLabel
            // 
            resources.ApplyResources(urlLabel, "urlLabel");
            urlLabel.Name = "urlLabel";
            // 
            // apiLabel
            // 
            resources.ApplyResources(apiLabel, "apiLabel");
            apiLabel.Name = "apiLabel";
            // 
            // modelComboBox
            // 
            resources.ApplyResources(ApiComboBox, "modelComboBox");
            ApiComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ApiComboBox.FormattingEnabled = true;
            ApiComboBox.Items.AddRange(new object[] { resources.GetString("modelComboBox.Items"), resources.GetString("modelComboBox.Items1"), resources.GetString("modelComboBox.Items2") });
            ApiComboBox.Name = "modelComboBox";
            // 
            // urlTextBox
            // 
            resources.ApplyResources(urlTextBox, "urlTextBox");
            urlTextBox.Name = "urlTextBox";
            // 
            // apiTextBox
            // 
            resources.ApplyResources(apiTextBox, "apiTextBox");
            apiTextBox.Name = "apiTextBox";
            // 
            // SaveButton
            // 
            resources.ApplyResources(SaveButton, "SaveButton");
            SaveButton.Name = "SaveButton";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += this.button1_Click;
            // 
            // OpenAISettingForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(SaveButton);
            Controls.Add(modelLabel);
            Controls.Add(urlLabel);
            Controls.Add(apiLabel);
            Controls.Add(ApiComboBox);
            Controls.Add(urlTextBox);
            Controls.Add(apiTextBox);
            Name = "OpenAISettingForm";
            Load += this.OpenAISettingForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label modelLabel;
        private Label urlLabel;
        private Label apiLabel;
        private ComboBox ApiComboBox;
        private TextBox urlTextBox;
        private TextBox apiTextBox;
        private Button SaveButton;
    }
}