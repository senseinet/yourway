using YourWay.Abstractions.Endpoints;

namespace YourWay.Abstractions.Transitions;

public class Transition : ITransition
{
    public string Id { get; set; }
    public string Name { get; set; }
    public bool IsEnabled { get; set; }

    public SourceEndpoint SourceEndpoint { get; set; }

    public DestinationEndpoint DestinationEndpoint { get; set; }
}