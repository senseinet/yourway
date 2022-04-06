using Newtonsoft.Json.Linq;
using YourWay.ActivityResults;
using YourWay.Contexts;
using YourWay.Models;

namespace YourWay.Activities;

public class ActivityBase : IActivity
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string DisplayName { get; set; }
    
    public string Description { get; set; }
    
    public string Type { get; }
    
    public JObject State { get; set; }
    
    public Variables Output { get; set; }
    
    public Variables TransientOutput { get; }
    
    public ValueTask<bool> CanExecuteAsync(WorkflowExecutionContext context, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<ActivityExecutionResult> ExecuteAsync(WorkflowExecutionContext context, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<ActivityExecutionResult> PauseAsync(WorkflowExecutionContext context, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<ActivityExecutionResult> ResumeAsync(WorkflowExecutionContext context, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<ActivityExecutionResult> HaltedAsync(WorkflowExecutionContext context, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ActivityInstance ToInstance()
    {
        throw new NotImplementedException();
    }
}