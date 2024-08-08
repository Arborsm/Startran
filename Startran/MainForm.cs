using Newtonsoft.Json;

namespace Startran;

public partial class MainForm : Form
{
    private const string En = "default.json";
    private static string _cn = null!;
    private static string _cnI = null!;
    private static string _cnP = null!;
    private readonly AppConfig _config;
    private readonly Trans _trans;

    public MainForm()
    {
        StartPosition = FormStartPosition.CenterScreen;
        InitializeComponent();
        _config = AppConfig.Load();
        _cn = _config.Language + ".json";
        _cnI = _config.Language + "-Source.json";
        _cnP = _config.Language + "-Translated.json";
        _trans = new Trans(_config, this);
        directoryTextBox.Text = _config.DirectoryPath;
    }

    private async void TranslateButton_Click(object sender, EventArgs e)
    {
        var userInput = inputTextBox.Text.Trim();
        if (!string.IsNullOrEmpty(userInput))
        {
            outputTextBox.Text = await _trans.TranslateText(userInput) + Environment.NewLine;
        }
    }

    private async void ProcessButton_Click(object sender, EventArgs e)
    {
        var directoryPath = directoryTextBox.Text.Trim();
        if (Directory.Exists(directoryPath))
        {
            progressBar.Value = 0;
            await ProcessDirectories(directoryPath);
            MessageBox.Show("Processing completed.");
        }
        else
        {
            MessageBox.Show("Invalid directory path.");
        }
    }
    
    private void SettingsButton_Click(object sender, EventArgs e)
    {
        var settingsForm = new SettingsForm(_config);
        settingsForm.ShowDialog();
        _config.Save();
        directoryTextBox.Text = _config.DirectoryPath;
    }

    private async Task ProcessDirectories(string directoryPath)
    {
        var directories = Directory.GetDirectories(directoryPath);
        progressBar.Maximum = directories.Length;

        var tasks = directories.Select(async directory =>
        {
            await ProcessDirectory(directory);
            Invoke(new Action(() => progressBar.Value++));
        });

        await Task.WhenAll(tasks);
    }

    private async Task ProcessDirectory(string directoryPath)
    {
        var en = Trans.GetJsonString(directoryPath, En);
        var cn = Trans.GetJsonString(directoryPath, _cn);

        var mapAll = JsonConvert.DeserializeObject<Dictionary<string, string>>(en)!;
        var mapAllCn = JsonConvert.DeserializeObject<Dictionary<string, string>>(cn) ?? new();

        var path = Path.Combine(directoryPath, "i18n");
        Directory.CreateDirectory(path);
        await File.WriteAllTextAsync(Path.Combine(path, _cnI), cn);

        var tran = await _trans.ProcessText(mapAll, mapAllCn, _config.EnToCn);
        await File.WriteAllTextAsync(Path.Combine(path, _cnP), JsonConvert.SerializeObject(tran));

        var combined = mapAllCn.Union(tran).ToDictionary(k => k.Key, v => v.Value);
        await File.WriteAllTextAsync(Path.Combine(path, _cn), JsonConvert.SerializeObject(combined));
    }
}