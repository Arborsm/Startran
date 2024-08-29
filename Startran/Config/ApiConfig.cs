namespace Startran.Config
{
    public class ApiConfig
    {
        public string Api { get; set; } = "your-api-key";
        public string Url { get; set; } = "https://api.openai.com";
        public string Model { get; set; } = "gpt-3.5-turbo";
        public List<string> Models { get; set; } = new();
    }
}
