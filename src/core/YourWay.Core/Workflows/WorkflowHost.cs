using YourWay.Contexts;

namespace YourWay.Workflows;

public class WorkflowHost: IWorkflowHost
{
    public WorkflowHost()
    {
        Workflows = new List<IWorkflow>();
    }

    public ICollection<IWorkflow> Workflows { get; set; }
    
    public async Task ExecuteWorkflows(CancellationToken cancellationToken)
    {
        foreach (var workflow in Workflows)
        {
            await workflow.ExecuteAsync(new WorkflowExecutionContext(workflow), cancellationToken);
        }
    }
}