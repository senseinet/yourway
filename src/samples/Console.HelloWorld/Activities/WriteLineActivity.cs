using YourWay.Abstractions.Activities;
using YourWay.Abstractions.Steps;

namespace Console.HelloWorld.Activities;

public class WriteLineActivity : Activity
{
    public WriteLineActivity()
    {
        Id = "WriteLine.Activity";
        Name = "WriteLine.Activity";

        Steps = new List<Step>();
    }
}