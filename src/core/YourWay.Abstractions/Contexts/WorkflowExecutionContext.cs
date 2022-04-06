using YourWay.Workflows;

namespace YourWay.Contexts;

public class WorkflowExecutionContext
{
    public WorkflowExecutionContext(IWorkflow workflow)
    {
        Workflow = workflow;
    }

    public IWorkflow Workflow { get; }
}