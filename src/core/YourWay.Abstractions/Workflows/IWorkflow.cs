using YourWay.Activities;
using YourWay.Contexts;
using YourWay.Transitions;

namespace YourWay.Workflows;

public interface IWorkflow
{
    string Name { get; set; }

    ICollection<Activity> Activities { get; set; }

    ICollection<Transition> Transitions { get; set; }

    Task ExecuteAsync(WorkflowExecutionContext workflowExecutionContext, CancellationToken cancellationToken);
}