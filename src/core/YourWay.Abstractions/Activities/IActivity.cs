using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using YourWay.ActivityResults;
using YourWay.Contexts;
using YourWay.Models;

namespace YourWay.Activities;

public interface IActivity
{
    Guid Id { get; set; }

    string Name { get; set; }

    string DisplayName { get; set; }

    string Description { get; set; }

    string Type { get; }
    
    JObject State { get; set; }
    
    Variables Output { get; set; }
    
    [JsonIgnore]
    Variables TransientOutput { get; }
    
    /// <summary>
    /// Returns a value of whether the specified activity can execute.
    /// </summary>
    ValueTask<bool> CanExecuteAsync(WorkflowExecutionContext context, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Executes activity
    /// </summary>
    ValueTask<ActivityExecutionResult> ExecuteAsync(WorkflowExecutionContext context, CancellationToken cancellationToken = default);

    /// <summary>
    /// Pauses activity
    /// </summary>
    ValueTask<ActivityExecutionResult> PauseAsync(WorkflowExecutionContext context, CancellationToken cancellationToken = default);

    /// <summary>
    /// Resumes activity
    /// </summary>
    ValueTask<ActivityExecutionResult> ResumeAsync(WorkflowExecutionContext context, CancellationToken cancellationToken = default);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ValueTask<ActivityExecutionResult> HaltedAsync(WorkflowExecutionContext context, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Create instance representation of this activity
    /// </summary>
    /// <returns></returns>
    ActivityInstance ToInstance();
}