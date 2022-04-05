using YourWay.Abstractions.Workflows;

namespace YourWay.Core.Workflows;

public interface IWorkflowHost
{
    ICollection<IWorkflow> Workflows { get; set; }

    Task ExecuteWorkflows(CancellationToken cancellationToken);
}