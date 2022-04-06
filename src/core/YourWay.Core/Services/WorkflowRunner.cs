using YourWay.Activities;
using YourWay.Contexts;
using YourWay.Models;
using YourWay.Workflows;

namespace YourWay.Services;

public class WorkflowRunner : IWorkflowRunner
{
    public Task<WorkflowExecutionContext> StartAsync(Workflow workflow, IEnumerable<IActivity> startActivities = default,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<WorkflowExecutionContext> StartAsync(WorkflowDefinitionVersion workflowDefinition, Variables input = default,
        IEnumerable<string> startActivityIds = default, string correlationId = default,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<WorkflowExecutionContext> StartAsync<T>(Variables input = default, IEnumerable<string> startActivityIds = default, string correlationId = default,
        CancellationToken cancellationToken = default) where T : IWorkflow, new()
    {
        throw new NotImplementedException();
    }

    public Task<WorkflowExecutionContext> PauseAsync(WorkflowInstance workflowInstance, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<WorkflowExecutionContext> ResumeAsync(Workflow workflow, IEnumerable<IActivity> startActivities = default,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<WorkflowExecutionContext> ResumeAsync<T>(WorkflowInstance workflowInstance, Variables input = default,
        IEnumerable<string> startActivityIds = default, CancellationToken cancellationToken = default) where T : IWorkflow, new()
    {
        throw new NotImplementedException();
    }

    public Task<WorkflowExecutionContext> ResumeAsync(WorkflowInstance workflowInstance, Variables input = default, IEnumerable<string> startActivityIds = default,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}