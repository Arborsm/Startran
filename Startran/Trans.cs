using OpenAI;
using System.Collections.Concurrent;
using System.Text;
using OpenAI.Chat;
using Message = OpenAI.Chat.Message;

namespace Startran;

public class Trans(AppConfig config, MainForm main)
{
    private static bool ContainsChinese(string str)
    {
        return str.Any(ch => ch >= 0x4E00 && ch <= 0x9FFF);
    }

    internal async Task<string> TranslateText(string text)
    {
        return ContainsChinese(text) ? text : await TranslateText(text, config.EnToCn);
    }

    internal async Task<string> TranslateText(string text, string role)
    {
        return await StreamCallWithMessage(text, role);
    }

    internal static string GetJsonString(string directoryPath, string fileName)
    {
        var i18nDir = Directory.GetDirectories(directoryPath, "i18n", SearchOption.AllDirectories).FirstOrDefault();
        if (i18nDir == null) return string.Empty;
        var filePath = Path.Combine(i18nDir, fileName);
        return File.Exists(filePath) ? File.ReadAllText(filePath, Encoding.UTF8) : string.Empty;
    }

    internal async Task<Dictionary<string, string>> ProcessText(Dictionary<string, string> map, Dictionary<string, string>? mapAllCn, string role)
    {
        mapAllCn ??= [];
        var processedMap = new ConcurrentDictionary<string, string>();
        var tasks = map.Keys.Except(mapAllCn.Keys).Select(async key =>
        {
            string? result = null;
            do
            {
                try
                {
                    if (key.Length <= 20)
                    {
                        await Task.Delay(500);
                    }
                    result = await TranslateText(map[key], role);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error occurred: " + e.Message);
                }
            } while (result == null);
            Console.WriteLine(result);
            main.outputTextBox.Text += result + Environment.NewLine;
            processedMap[key] = result;
        });

        await Task.WhenAll(tasks);
        return processedMap.ToDictionary(k => k.Key, v => v.Value);
    }

    private async Task<string> StreamCallWithMessage(string text, string role)
    {
        using var httpClient = new HttpClient();
        var api = new OpenAIAuthentication(config.OpenAi.Api);
        var url = new OpenAIClientSettings(config.OpenAi.Url);
        var client = new OpenAIClient(api, url, httpClient);
        var messages = new List<Message>
        {
            new(Role.System, role),
            new(Role.User, text)
        };
        var chatRequest = new ChatRequest(messages, model: config.OpenAi.Model);
        var response = await client.ChatEndpoint.GetCompletionAsync(chatRequest);

        return response.FirstChoice; ;
    }
}