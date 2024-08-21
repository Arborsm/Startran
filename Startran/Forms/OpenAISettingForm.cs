using System.ComponentModel;
using System.Net.Http;
using OpenAI;
using Startran.Config;
using Startran.Lang;

namespace Startran.Forms;

public partial class OpenAiSettingForm : Form
{
    private readonly MainConfig _config;

    public OpenAiSettingForm(MainConfig config)
    {
        _config = config;
        StartPosition = FormStartPosition.CenterScreen;
        InitializeComponent();
        SaveButton.Focus();
    }

    private void SaveButton_Click(object? sender, EventArgs e)
    {
        Save();
        Close();
    }

    private void Save()
    {
        _config.ApiConf.Api = ApiTextBox.Text;
        _config.ApiConf.Url = UrlTextBox.Text;
        _config.ApiConf.Model = ModelsComboBox.SelectedItem!.ToString()!;
        _config.ApiConf.Models.Clear();
        foreach (var item in ModelsComboBox.Items) _config.ApiConf.Models.Add(item.ToString()!);
        ConfigManager<MainConfig>.Save(_config);
    }

    private void OpenAISettingForm_Load(object? sender, EventArgs e)
    {
        ApiTextBox.Text = _config.ApiConf.Api;
        UrlTextBox.Text = _config.ApiConf.Url;
        ModelsComboBox.Items.AddRange(_config.ApiConf.Models.ToArray<object>());
        ModelsComboBox.SelectedItem = _config.ApiConf.Model;
    }

    private async void RefreshButton_Click(object? sender, EventArgs e)
    {
        Save();
        try
        {
            using var httpClient = new HttpClient();
            var api = new OpenAIAuthentication(_config.ApiConf.Api);
            var url = new OpenAIClientSettings(_config.ApiConf.Url);
            var client = new OpenAIClient(api, url, httpClient);
            var models = await client.ModelsEndpoint.GetModelsAsync();
            var list = models.Select(it => it.ToString()).ToList();
            ModelsComboBox.Items.Clear();
            ModelsComboBox.Items.AddRange(list.ToArray<object>());
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///     Required method for Designer support - do not modify
    ///     the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        var resources = new ComponentResourceManager(typeof(OpenAiSettingForm));
        modelLabel = new Label();
        urlLabel = new Label();
        apiLabel = new Label();
        ModelsComboBox = new ComboBox();
        UrlTextBox = new TextBox();
        ApiTextBox = new TextBox();
        SaveButton = new Button();
        RefreshButton = new Button();
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
        UrlTextBox.TabStop = false;
        UrlTextBox.UseSystemPasswordChar = true;
        UrlTextBox.Enter += UrlTextBox_Enter;
        UrlTextBox.Leave += UrlTextBox_Leave;
        // 
        // ApiTextBox
        // 
        resources.ApplyResources(ApiTextBox, "ApiTextBox");
        ApiTextBox.Name = "ApiTextBox";
        ApiTextBox.TabStop = false;
        ApiTextBox.UseSystemPasswordChar = true;
        ApiTextBox.Enter += ApiTextBox_Enter;
        ApiTextBox.Leave += ApiTextBox_Leave;
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
        resources.ApplyResources(RefreshButton, "RefreshButton");
        RefreshButton.Name = "RefreshButton";
        RefreshButton.UseVisualStyleBackColor = true;
        RefreshButton.Click += RefreshButton_Click;
        // 
        // OpenAiSettingForm
        // 
        resources.ApplyResources(this, "$this");
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(RefreshButton);
        Controls.Add(SaveButton);
        Controls.Add(modelLabel);
        Controls.Add(urlLabel);
        Controls.Add(apiLabel);
        Controls.Add(ModelsComboBox);
        Controls.Add(UrlTextBox);
        Controls.Add(ApiTextBox);
        Name = "OpenAiSettingForm";
        Load += OpenAISettingForm_Load;
        ShowIcon = false;
        ResumeLayout(false);
        PerformLayout();
    }

    private void ApiTextBox_Leave(object? sender, EventArgs e)
    {
        ApiTextBox.UseSystemPasswordChar = true;
    }

    private void ApiTextBox_Enter(object? sender, EventArgs e)
    {
        ApiTextBox.UseSystemPasswordChar = false;
    }

    private void UrlTextBox_Leave(object? sender, EventArgs e)
    {
        UrlTextBox.UseSystemPasswordChar = true;
    }

    private void UrlTextBox_Enter(object? sender, EventArgs e)
    {
        UrlTextBox.UseSystemPasswordChar = false;
    }

    #endregion
}