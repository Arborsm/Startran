using Startran.Config;

namespace Startran.Trans;

public interface ITranslator
{
    string Name { get; }
    Task<string> StreamCallWithMessage(string text, string role, MainConfig config, CancellationToken cancellationToken);
}