using YourWay.Services;
using YourWay.Workflows;

namespace Console.HelloWorld;

public class HelloWorldWorkflow : IWorkflow
{
    public void Build(IWorkflowBuilder builder)
    {
        builder
            .StartWith<Activities.HelloWorld>()
            .Then<Activities.GoodByeWorld>();
    }
}