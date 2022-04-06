using YourWay.Activities;
using YourWay.Models;
using YourWay.Services;
using YourWay.Workflows;

namespace YourWay.Contexts;

public class WorkflowExecutionContext
{
    private readonly IClock _clock;
    private readonly Stack<IActivity> scheduledActivities;

    public WorkflowExecutionContext(Workflow workflow, IClock clock, IServiceProvider serviceProvider)
    {
        _clock = clock;
        ServiceProvider = serviceProvider;
        Workflow = workflow;
        IsFirstPass = true;
        scheduledActivities = new Stack<IActivity>();
    }

    public Guid Id { get; set; }

    public WorkflowDefinitionVersion Definition { get; }

    public Guid CorrelationId { get; set; }

    public WorkflowExecutionStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? StartedAt { get; set; }

    public DateTime? FinishedAt { get; set; }

    public Workflow Workflow { get; }

    public IServiceProvider ServiceProvider { get; }

    public IActivity CurrentActivity { get; private set; }

    public bool HasScheduledActivities => scheduledActivities.Any();

    public bool IsFirstPass { get; set; }

    public IActivity PopScheduledActivity()
    {
        return CurrentActivity = scheduledActivities.Pop();
    }

    public void ScheduleActivities(IEnumerable<IActivity> activities)
    {
        foreach (var activity in activities) ScheduleActivity(activity);
    }

    public void Start()
    {
        Workflow.StartedAt = _clock.Now();
        Workflow.ExecutionStatus = WorkflowExecutionStatus.Executing;
    }

    public void ScheduleActivity(IActivity activity)
    {
        scheduledActivities.Push(activity);
    }

    public void Finish()
    {
        Workflow.FinishedAt = _clock.Now();
        Workflow.ExecutionStatus = WorkflowExecutionStatus.Finished;
    }

    public void Fault(IActivity activity, Exception exception)
    {
        Fault(activity, exception.Message, exception);
    }

    public void Fault(IActivity activity, string errorMessage, Exception exception = null)
    {
        Workflow.FaultedAt = _clock.Now();
        Workflow.ExecutionStatus = WorkflowExecutionStatus.Faulted;
    }
}