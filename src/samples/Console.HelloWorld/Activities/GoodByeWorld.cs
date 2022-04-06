using YourWay.ActivityResults;
using YourWay.Contexts;
using YourWay.Services;

namespace Console.HelloWorld.Activities;

public class GoodByeWorld : Activity
{
    protected override ActivityExecutionResult OnExecute(WorkflowExecutionContext context)
    {
        System.Console.WriteLine("Goodbye cruel world...");
        return Done();
    }
}