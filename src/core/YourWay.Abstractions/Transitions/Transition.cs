using YourWay.Endpoints;

namespace YourWay.Transitions;

public class Transition : ITransition
{
    public string Id { get; set; }
    public string Name { get; set; }
    public bool IsEnabled { get; set; }

    public SourceEndpoint SourceEndpoint { get; set; }

    public TargetEndpoint TargetEndpoint { get; set; }
}