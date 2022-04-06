using YourWay.Models;

namespace YourWay.Services;

public interface IConnectionBuilder
{
    Func<IActivityBuilder> Source { get; }
    
    Func<IActivityBuilder> Target { get; }
    
    string Outcome { get; }
    
    ConnectionDefinition BuildConnection();
}