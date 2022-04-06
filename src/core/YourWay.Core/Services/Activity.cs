using YourWay.Activities;
using YourWay.ActivityResults;
using YourWay.Results;

namespace YourWay.Services;

public abstract class Activity : ActivityBase
{
    protected ActivityExecutionResult Outcomes(IEnumerable<OutcomeResultName> names)
    {
        return new OutcomeResult(names);
    }

    protected ActivityExecutionResult Outcome(OutcomeResultName name)
    {
        return Outcomes(new[] {name});
    }

    protected ActivityExecutionResult Done()
    {
        return Outcome(OutcomeResultName.Done);
    }
}