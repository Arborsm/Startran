namespace Startran
{
    public interface ITranslator
    {
        string Name { get; }
        Task<string> StreamCallWithMessage(string text, string role, AppConfig config);
    }
}
