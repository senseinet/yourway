using Newtonsoft.Json.Linq;
using YourWay.Activities;

namespace YourWay.Models;

public class ActivityDefinition<T> : ActivityDefinition where T : IActivity
{
    public ActivityDefinition(Guid id, JObject state, int left = 0, int top = 0) : base(
        id,
        typeof(T).Name,
        state,
        left,
        top)
    {
    }

    public ActivityDefinition(Guid id, object state, int left = 0, int top = 0) : base(
        id,
        typeof(T).Name,
        JObject.FromObject(state),
        left,
        top)
    {
    }
}