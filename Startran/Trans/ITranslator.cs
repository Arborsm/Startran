using Startran.Config;

namespace Startran.Trans;

public interface ITranslator
{
    bool NeedApi { get; }
    string Name { get; }
    Task<string> StreamCallWithMessage(string text, string role, MainConfig config, CancellationToken cancellationToken);
    Task<List<string>> GetSupportModels(MainConfig config);
}