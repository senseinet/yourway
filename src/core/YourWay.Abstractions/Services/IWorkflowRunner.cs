using YourWay.Activities;
using YourWay.Contexts;
using YourWay.Models;
using YourWay.Workflows;

namespace YourWay.Services;

public interface IWorkflowRunner
{
    #region START

    Task<WorkflowExecutionContext> StartAsync(
        Workflow workflow,
        IEnumerable<IActivity> startActivities = default,
        CancellationToken cancellationToken = default
    );
    
    Task<WorkflowExecutionContext> StartAsync(
        WorkflowDefinitionVersion workflowDefinition,
        Variables input = default,
        IEnumerable<string> startActivityIds = default,
        string correlationId = default,
        CancellationToken cancellationToken = default
    );
    
    Task<WorkflowExecutionContext> StartAsync<T>(
        Variables input = default,
        IEnumerable<string> startActivityIds = default,
        string correlationId = default,
        CancellationToken cancellationToken = default) where T : IWorkflow, new();
    
    #endregion

    #region PAUSE

    Task<WorkflowExecutionContext> PauseAsync(
        WorkflowInstance workflowInstance,
        CancellationToken cancellationToken = default
    );

    #endregion

    #region RESUME

    Task<WorkflowExecutionContext> ResumeAsync(
        Workflow workflow,
        IEnumerable<IActivity> startActivities = default,
        CancellationToken cancellationToken = default
    );

    Task<WorkflowExecutionContext> ResumeAsync<T>(
        WorkflowInstance workflowInstance,
        Variables input = default,
        IEnumerable<string> startActivityIds = default,
        CancellationToken cancellationToken = default
    ) where T : IWorkflow, new();

    Task<WorkflowExecutionContext> ResumeAsync(
        WorkflowInstance workflowInstance,
        Variables input = default,
        IEnumerable<string> startActivityIds = default,
        CancellationToken cancellationToken = default
    );

    #endregion
}