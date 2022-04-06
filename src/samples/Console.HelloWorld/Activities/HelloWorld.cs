using YourWay.ActivityResults;
using YourWay.Contexts;
using YourWay.Services;

namespace Console.HelloWorld.Activities;

public class HelloWorld : Activity
{
    protected override ActivityExecutionResult OnExecute(WorkflowExecutionContext context)
    {
        System.Console.WriteLine("Hello world!");
        return Done();
    }
}