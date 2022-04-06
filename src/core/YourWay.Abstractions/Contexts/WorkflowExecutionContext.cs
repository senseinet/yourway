using YourWay.Activities;
using YourWay.Models;
using YourWay.Services;
using YourWay.Workflows;

namespace YourWay.Contexts;

public class WorkflowExecutionContext
{
    private readonly IClock _clock;
    private readonly Stack<IActivity> scheduledActivities;
    
    public WorkflowExecutionContext(IClock clock)
    {
        _clock = clock;
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
    
    public void ScheduleActivities(IEnumerable<IActivity> activities)
    {
        foreach (var activity in activities)
        {
            ScheduleActivity(activity);
        }
    }

    public void ScheduleActivity(IActivity activity)
    {
        scheduledActivities.Push(activity);
    }
    
    public void Finish()
    {
        Workflow.FinishedAt = _clock.Now();
        Workflow.Status = WorkflowExecutionStatus.Finished;
    }
}