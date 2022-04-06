using Microsoft.Extensions.Logging;
using YourWay.Activities;
using YourWay.ActivityResults;
using YourWay.Contexts;
using YourWay.Extensions;
using YourWay.Models;
using YourWay.Workflows;

namespace YourWay.Services;

public class WorkflowRunner : IWorkflowRunner
{
    private readonly IActivityRunner _activityRunner;
    private readonly IClock _clock;
    private readonly ILogger _logger;
    private readonly IServiceProvider _serviceProvider;
    private readonly IEnumerable<IWorkflowEventHandler> _workflowEventHandlers;
    private readonly IWorkflowFactory _workflowFactory;

    public WorkflowRunner(
        IActivityRunner activityRunner,
        IClock clock,
        IEnumerable<IWorkflowEventHandler> workflowEventHandlers,
        ILogger<WorkflowRunner> logger,
        IServiceProvider serviceProvider,
        IWorkflowFactory workflowFactory
    )
    {
        _activityRunner = activityRunner;
        _clock = clock;
        _workflowEventHandlers = workflowEventHandlers;
        _logger = logger;
        _serviceProvider = serviceProvider;
        _workflowFactory = workflowFactory;
    }

    public ValueTask<WorkflowExecutionContext> StartAsync(Workflow workflow,
        IEnumerable<IActivity> startActivities = default,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<WorkflowExecutionContext> StartAsync(WorkflowDefinitionVersion workflowDefinition,
        Variables input = default,
        IEnumerable<Guid> startActivityIds = default, Guid correlationId = default,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<WorkflowExecutionContext> StartAsync<T>(Variables input = default,
        IEnumerable<Guid> startActivityIds = default, Guid correlationId = default,
        CancellationToken cancellationToken = default) where T : IWorkflow, new()
    {
        var workflow = _workflowFactory.CreateWorkflow<T>(input, correlationId: correlationId);
        var startActivities = workflow.Activities.Find(startActivityIds);

        return ExecuteAsync(workflow, false, startActivities, cancellationToken);
    }

    public ValueTask<WorkflowExecutionContext> PauseAsync(WorkflowInstance workflowInstance,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<WorkflowExecutionContext> ResumeAsync(Workflow workflow,
        IEnumerable<IActivity> startActivities = default,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<WorkflowExecutionContext> ResumeAsync<T>(WorkflowInstance workflowInstance,
        Variables input = default,
        IEnumerable<Guid> startActivityIds = default, CancellationToken cancellationToken = default)
        where T : IWorkflow, new()
    {
        throw new NotImplementedException();
    }

    public ValueTask<WorkflowExecutionContext> ResumeAsync(WorkflowInstance workflowInstance, Variables input = default,
        IEnumerable<Guid> startActivityIds = default,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    private async ValueTask<WorkflowExecutionContext> ExecuteAsync(
        Workflow workflow,
        bool resume,
        IEnumerable<IActivity> startActivities = default,
        CancellationToken cancellationToken = default)
    {
        var workflowExecutionContext = await CreateWorkflowExecutionContextAsync(
            workflow,
            startActivities,
            cancellationToken
        );

        var start = !resume;

        while (workflowExecutionContext.HasScheduledActivities)
        {
            var currentActivity = workflowExecutionContext.PopScheduledActivity();

            var result = start
                ? await ExecuteActivityAsync(workflowExecutionContext, currentActivity, cancellationToken)
                : await ResumeActivityAsync(workflowExecutionContext, currentActivity, cancellationToken);

            if (result == null)
                break;

            await result.ExecuteAsync(this, workflowExecutionContext, cancellationToken);

            workflowExecutionContext.IsFirstPass = false;
            start = true;
        }

        await FinalizeWorkflowExecutionAsync(workflowExecutionContext, cancellationToken);

        return workflowExecutionContext;
    }

    private async Task<WorkflowExecutionContext> CreateWorkflowExecutionContextAsync(
        Workflow workflow,
        IEnumerable<IActivity> startActivities,
        CancellationToken cancellationToken)
    {
        var workflowExecutionContext = new WorkflowExecutionContext(workflow, _clock, _serviceProvider);
        var startActivityList = startActivities?.ToList() ?? workflow.GetStartActivities().Take(1).ToList();

        foreach (var startActivity in startActivityList)
            if (await startActivity.CanExecuteAsync(workflowExecutionContext, cancellationToken))
                workflowExecutionContext.ScheduleActivity(startActivity);

        if (workflowExecutionContext.HasScheduledActivities)
            if (workflowExecutionContext.Workflow.ExecutionStatus == WorkflowExecutionStatus.Idle)
                workflowExecutionContext.Start();

        return workflowExecutionContext;
    }

    private async Task<ActivityExecutionResult> ExecuteActivityAsync(
        WorkflowExecutionContext workflowContext,
        IActivity activity,
        CancellationToken cancellationToken)
    {
        return await InvokeActivityAsync(
            workflowContext,
            activity,
            async () => await _activityRunner.ExecuteAsync(workflowContext, activity, cancellationToken),
            cancellationToken
        );
    }

    private async Task<ActivityExecutionResult> ResumeActivityAsync(
        WorkflowExecutionContext workflowContext,
        IActivity activity,
        CancellationToken cancellationToken)
    {
        return await InvokeActivityAsync(
            workflowContext,
            activity,
            async () => await _activityRunner.ResumeAsync(workflowContext, activity, cancellationToken),
            cancellationToken
        );
    }

    private async Task<ActivityExecutionResult> InvokeActivityAsync(
        WorkflowExecutionContext workflowContext,
        IActivity activity,
        Func<Task<ActivityExecutionResult>> executeAction,
        CancellationToken cancellationToken)
    {
        try
        {
            if (cancellationToken.IsCancellationRequested)
            {
                workflowContext.Workflow.ExecutionStatus = WorkflowExecutionStatus.Aborted;
                workflowContext.Workflow.FinishedAt = _clock.Now();
                return null;
            }

            return await executeAction();
        }
        catch (Exception ex)
        {
            FaultWorkflow(workflowContext, activity, ex);
        }

        return null;
    }

    private void FaultWorkflow(WorkflowExecutionContext workflowContext, IActivity activity, Exception ex)
    {
        _logger.LogError(
            ex,
            "An unhandled error occurred while executing an activity. Putting the workflow in the faulted state."
        );
        workflowContext.Fault(activity, ex);
    }

    private async ValueTask FinalizeWorkflowExecutionAsync(
        WorkflowExecutionContext workflowExecutionContext,
        CancellationToken cancellationToken)
    {
        if (workflowExecutionContext.Workflow.IsExecuting()) workflowExecutionContext.Finish();

        await _workflowEventHandlers.InvokeAsync(
            async x => await x.WorkflowExecutedAsync(workflowExecutionContext, cancellationToken),
            _logger
        );
    }
}