using YourWay.Contexts;
using YourWay.Persistence;
using YourWay.Services;
using YourWay.Workflows;

namespace YourWay.WorkflowEventHandlers;

public class PersistenceWorkflowEventHandler : WorkflowEventHandlerBase
{
    private readonly IWorkflowInstanceStore workflowInstanceStore;

    public PersistenceWorkflowEventHandler(IWorkflowInstanceStore workflowInstanceStore)
    {
        this.workflowInstanceStore = workflowInstanceStore;
    }

    public override async ValueTask WorkflowExecutedAsync(WorkflowExecutionContext workflowExecutionContext, CancellationToken cancellationToken)
    {
        await SaveWorkflowAsync(workflowExecutionContext.Workflow, cancellationToken);
    }
    
    private async ValueTask SaveWorkflowAsync(Workflow workflow, CancellationToken cancellationToken)
    {
        var workflowInstance = workflow.ToInstance();
        await workflowInstanceStore.SaveAsync(workflowInstance, cancellationToken);
    }
}