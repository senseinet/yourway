using YourWay.Abstractions.Activities;
using YourWay.Abstractions.Contexts;
using YourWay.Abstractions.Transitions;

namespace YourWay.Abstractions.Workflows;

public interface IWorkflow
{
    string Name { get; set; }

    ICollection<Activity> Activities { get; set; }

    ICollection<Transition> Transitions { get; set; }

    Task ExecuteAsync(WorkflowExecutionContext workflowExecutionContext, CancellationToken cancellationToken);
}