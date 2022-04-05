using YourWay.Abstractions.Services.Workflows;
using YourWay.Abstractions.Workflows;

namespace YourWay.Abstractions.Contexts;

public class WorkflowExecutionContext
{
    public WorkflowExecutionContext(IWorkflow workflow)
    {
        Workflow = workflow;
    }

    public IWorkflow Workflow { get; }
}