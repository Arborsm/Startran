using System.Net.Http;
using OpenAI;
using OpenAI.Chat;
using Startran.Config;
using Message = OpenAI.Chat.Message;

namespace Startran.Trans;

internal class OpenAITrans : ITranslator
{
    public bool NeedApi => true;
    public string Name => "OpenAI";

    public async Task<string> StreamCallWithMessage(string text, string role, MainConfig config, CancellationToken cancellationToken)
    {
        using var httpClient = new HttpClient();
        httpClient.Timeout = TimeSpan.FromSeconds(10);
        var api = new OpenAIAuthentication(config.ApiConf.Api);
        var url = new OpenAIClientSettings(config.ApiConf.Url);
        var client = new OpenAIClient(api, url, httpClient);
        var messages = new List<Message>
        {
            new(Role.System, role),
            new(Role.User, text)
        };
        var chatRequest = new ChatRequest(messages, config.ApiConf.Model);

        var response = await client.ChatEndpoint.GetCompletionAsync(chatRequest, cancellationToken);

        return response.FirstChoice;
    }

    public async Task<List<string>> GetSupportModels(MainConfig config)
    {
        using var httpClient = new HttpClient();
        var api = new OpenAIAuthentication(config.ApiConf.Api);
        var url = new OpenAIClientSettings(config.ApiConf.Url);
        var client = new OpenAIClient(api, url, httpClient);
        var models = await client.ModelsEndpoint.GetModelsAsync();
        return models.Select(it => it.ToString()).ToList();
    }
}