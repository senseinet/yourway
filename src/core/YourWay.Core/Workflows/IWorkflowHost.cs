namespace YourWay.Workflows;

public interface IWorkflowHost
{
    ICollection<IWorkflow> Workflows { get; set; }

    Task ExecuteWorkflows(CancellationToken cancellationToken);
}