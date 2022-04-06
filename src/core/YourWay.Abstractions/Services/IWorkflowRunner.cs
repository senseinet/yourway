using YourWay.Activities;
using YourWay.Contexts;
using YourWay.Models;
using YourWay.Workflows;

namespace YourWay.Services;

public interface IWorkflowRunner
{
    #region PAUSE

    ValueTask<WorkflowExecutionContext> PauseAsync(
        WorkflowInstance workflowInstance,
        CancellationToken cancellationToken = default
    );

    #endregion

    #region START

    ValueTask<WorkflowExecutionContext> StartAsync(
        Workflow workflow,
        IEnumerable<IActivity> startActivities = default,
        CancellationToken cancellationToken = default
    );

    ValueTask<WorkflowExecutionContext> StartAsync(
        WorkflowDefinitionVersion workflowDefinition,
        Variables input = default,
        IEnumerable<Guid> startActivityIds = default,
        Guid correlationId = default,
        CancellationToken cancellationToken = default
    );

    ValueTask<WorkflowExecutionContext> StartAsync<T>(
        Variables input = default,
        IEnumerable<Guid> startActivityIds = default,
        Guid correlationId = default,
        CancellationToken cancellationToken = default) where T : IWorkflow, new();

    #endregion

    #region RESUME

    ValueTask<WorkflowExecutionContext> ResumeAsync(
        Workflow workflow,
        IEnumerable<IActivity> startActivities = default,
        CancellationToken cancellationToken = default
    );

    ValueTask<WorkflowExecutionContext> ResumeAsync<T>(
        WorkflowInstance workflowInstance,
        Variables input = default,
        IEnumerable<Guid> startActivityIds = default,
        CancellationToken cancellationToken = default
    ) where T : IWorkflow, new();

    ValueTask<WorkflowExecutionContext> ResumeAsync(
        WorkflowInstance workflowInstance,
        Variables input = default,
        IEnumerable<Guid> startActivityIds = default,
        CancellationToken cancellationToken = default
    );

    #endregion
}