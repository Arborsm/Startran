using OpenAI;

namespace Startran
{
    public partial class OpenAiSettingForm : Form
    {
        private readonly AppConfig _config;
        public OpenAiSettingForm(AppConfig config)
        {
            _config = config;
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenAiSettingForm));
            modelLabel = new Label();
            urlLabel = new Label();
            apiLabel = new Label();
            ModelsComboBox = new ComboBox();
            UrlTextBox = new TextBox();
            ApiTextBox = new TextBox();
            SaveButton = new Button();
            this.RefreshButton = new Button();
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
            // ModelsComboBox
            // 
            ModelsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ModelsComboBox.FormattingEnabled = true;
            resources.ApplyResources(ModelsComboBox, "ModelsComboBox");
            ModelsComboBox.Name = "ModelsComboBox";
            // 
            // UrlTextBox
            // 
            resources.ApplyResources(UrlTextBox, "UrlTextBox");
            UrlTextBox.Name = "UrlTextBox";
            // 
            // ApiTextBox
            // 
            resources.ApplyResources(ApiTextBox, "ApiTextBox");
            ApiTextBox.Name = "ApiTextBox";
            // 
            // SaveButton
            // 
            resources.ApplyResources(SaveButton, "SaveButton");
            SaveButton.Name = "SaveButton";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // RefreshButton
            // 
            resources.ApplyResources(this.RefreshButton, "RefreshButton");
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += this.RefreshButton_Click;
            // 
            // OpenAiSettingForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(this.RefreshButton);
            Controls.Add(SaveButton);
            Controls.Add(modelLabel);
            Controls.Add(urlLabel);
            Controls.Add(apiLabel);
            Controls.Add(ModelsComboBox);
            Controls.Add(UrlTextBox);
            Controls.Add(ApiTextBox);
            Name = "OpenAiSettingForm";
            Load += OpenAISettingForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private void SaveButton_Click(object? sender, EventArgs e)
        {
            Save();
            Close();
        }

        private void Save()
        {
            _config.OpenAi.Api = ApiTextBox.Text;
            _config.OpenAi.Url = UrlTextBox.Text;
            _config.OpenAi.Model = ModelsComboBox.SelectedItem!.ToString()!;
        }

        private void OpenAISettingForm_Load(object? sender, EventArgs e)
        {
            ApiTextBox.Text = _config.OpenAi.Api;
            UrlTextBox.Text = _config.OpenAi.Url;
            ModelsComboBox.Items.AddRange([.. _config.OpenAi.Models]);
            ModelsComboBox.SelectedItem = _config.OpenAi.Model;
        }

        private async void RefreshButton_Click(object? sender, EventArgs e)
        {
            Save();
            try
            {
                using var httpClient = new HttpClient();
                var api = new OpenAIAuthentication(_config.OpenAi.Api);
                var url = new OpenAIClientSettings(_config.OpenAi.Url);
                var client = new OpenAIClient(api, url, httpClient);
                var models = await client.ModelsEndpoint.GetModelsAsync();
                var list = models.Select(it => it.ToString()).ToList();
                ModelsComboBox.Items.Clear();
                ModelsComboBox.Items.AddRange([.. list]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
