using YourWay.Abstractions.Activities;
using YourWay.Abstractions.Contexts;
using YourWay.Abstractions.Services.Workflows;
using YourWay.Abstractions.Transitions;

namespace YourWay.Abstractions.Workflows;

public class Workflow : IWorkflow
{
    public string Name { get; set; }

    public ICollection<Activity> Activities { get; set; }

    public ICollection<Transition> Transitions { get; set; }

    public Workflow()
    {
        Activities = new List<Activity>();
        Transitions = new List<Transition>();
    }

    public async Task ExecuteAsync(WorkflowExecutionContext workflowExecutionContext)
    {
        foreach (var activity in Activities)
        {
            await activity.ExecuteAsync(new ActivityExecutionContext(activity), new CancellationToken());
        }
    }
}