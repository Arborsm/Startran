using System.Net.Http;
using OpenAI;
using OpenAI.Chat;
using Message = OpenAI.Chat.Message;

namespace Startran.Trans
{
    // ReSharper disable once UnusedMember.Global
    // ReSharper disable once InconsistentNaming
    internal class OpenAITrans : ITranslator
    {
        public string Name => "OpenAI";

        public async Task<string> StreamCallWithMessage(string text, string role, AppConfig config, CancellationToken cancellationToken)
        {
            using var httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(30);
            var api = new OpenAIAuthentication(config.ApiConf.Api);
            var url = new OpenAIClientSettings(config.ApiConf.Url);
            var client = new OpenAIClient(api, url, httpClient);
            var messages = new List<Message>
            {
                new(Role.System, role),
                new(Role.User, text)
            };
            var chatRequest = new ChatRequest(messages, model: config.ApiConf.Model);

            cancellationToken.ThrowIfCancellationRequested();

            var response = await client.ChatEndpoint.GetCompletionAsync(chatRequest, cancellationToken)
                .ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested();

            return response.FirstChoice;
        }
    }
}
