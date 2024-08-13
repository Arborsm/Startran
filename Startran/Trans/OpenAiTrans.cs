using OpenAI;
using OpenAI.Chat;
using Message = OpenAI.Chat.Message;

namespace Startran.Trans
{
    internal class OpenDAiTrans : ITranslator
    {
        public string Name => "OpenAI";

        public async Task<string> StreamCallWithMessage(string text, string role, AppConfig config)
        {
            using var httpClient = new HttpClient();
            var api = new OpenAIAuthentication(config.ApiConf.Api);
            var url = new OpenAIClientSettings(config.ApiConf.Url);
            var client = new OpenAIClient(api, url, httpClient);
            var messages = new List<Message>
            {
                new(Role.System, role),
                new(Role.User, text)
            };
            var chatRequest = new ChatRequest(messages, model: config.ApiConf.Model);
            var response = await client.ChatEndpoint.GetCompletionAsync(chatRequest);

            return response.FirstChoice;
        }
    }
}
