using YourWay.Models;
using YourWay.Results;

namespace YourWay.Services;

public class ConnectionBuilder : IConnectionBuilder
{
    public ConnectionBuilder(IWorkflowBuilder workflowBuilder, Func<IActivityBuilder> source,
        Func<IActivityBuilder> target, OutcomeResultName? outcome = null)
    {
        Source = source;
        Target = target;
        WorkflowBuilder = workflowBuilder;
        Outcome = outcome;
    }

    public IWorkflowBuilder WorkflowBuilder { get; }
    public Func<IActivityBuilder> Source { get; }
    public Func<IActivityBuilder> Target { get; }
    public OutcomeResultName? Outcome { get; }

    public ConnectionDefinition BuildConnection()
    {
        return new ConnectionDefinition(Source().Activity.Id, Target().Activity.Id, Outcome);
    }
}