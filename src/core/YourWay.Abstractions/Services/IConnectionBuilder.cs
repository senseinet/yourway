using YourWay.Models;
using YourWay.Results;

namespace YourWay.Services;

public interface IConnectionBuilder
{
    Func<IActivityBuilder> Source { get; }

    Func<IActivityBuilder> Target { get; }

    OutcomeResultName? Outcome { get; }

    ConnectionDefinition BuildConnection();
}