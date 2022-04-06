using YourWay.Steps;

namespace YourWay.Contexts;

public class StepExecutionContext
{
    public StepExecutionContext(IStep step)
    {
        Step = step;
    }

    public IStep Step { get; }
}