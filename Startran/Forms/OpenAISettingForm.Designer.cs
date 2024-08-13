namespace Startran.Forms
{
    partial class OpenAiSettingForm
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

        private Label modelLabel;
        private Label urlLabel;
        private Label apiLabel;
        private ComboBox ModelsComboBox;
        private TextBox UrlTextBox;
        private TextBox ApiTextBox;
        private Button SaveButton;
        private Button RefreshButton;
    }
}