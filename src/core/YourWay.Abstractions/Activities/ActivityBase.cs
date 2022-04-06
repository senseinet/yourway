using Newtonsoft.Json;
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

    public virtual string Type => GetType().Name;

    public JObject State { get; set; } = new();

    public Variables Output { get; set; } = new();

    [JsonIgnore] public Variables TransientOutput { get; } = new();

    public ValueTask<bool> CanExecuteAsync(WorkflowExecutionContext context,
        CancellationToken cancellationToken = default)
    {
        return OnCanExecuteAsync(context, cancellationToken);
    }

    public ValueTask<ActivityExecutionResult> ExecuteAsync(WorkflowExecutionContext context,
        CancellationToken cancellationToken = default)
    {
        return OnExecuteAsync(context, cancellationToken);
    }

    public ValueTask<ActivityExecutionResult> PauseAsync(WorkflowExecutionContext context,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<ActivityExecutionResult> ResumeAsync(WorkflowExecutionContext context,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<ActivityExecutionResult> HaltedAsync(WorkflowExecutionContext context,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ActivityInstance ToInstance()
    {
        throw new NotImplementedException();
    }

    protected virtual ValueTask<bool> OnCanExecuteAsync(WorkflowExecutionContext context,
        CancellationToken cancellationToken)
    {
        return ValueTask.FromResult(OnCanExecute(context));
    }

    protected virtual bool OnCanExecute(WorkflowExecutionContext context)
    {
        return true;
    }

    protected virtual ValueTask<ActivityExecutionResult> OnExecuteAsync(WorkflowExecutionContext context,
        CancellationToken cancellationToken)
    {
        return ValueTask.FromResult(OnExecute(context));
    }

    protected virtual ActivityExecutionResult OnExecute(WorkflowExecutionContext context)
    {
        return Noop();
    }

    protected ActivityExecutionResult Noop()
    {
        return new NoopActivityExecutionResult();
    }
}