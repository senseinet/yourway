using Microsoft.Extensions.DependencyInjection;
using YourWay.Activities;

namespace YourWay.Services;

public class ActivityResolver : IActivityResolver
{
    private readonly Lazy<IDictionary<string, Type>> lazyActivityTypeLookup;
    private readonly IServiceProvider serviceProvider;

    public ActivityResolver(IServiceProvider serviceProvider, Func<IEnumerable<IActivity>> activitiesFunc)
    {
        this.serviceProvider = serviceProvider;
        lazyActivityTypeLookup = new Lazy<IDictionary<string, Type>>(
            () =>
            {
                var activities = activitiesFunc();
                return activities.Select(x => x.GetType()).Distinct().ToDictionary(x => x.Name);
            });
    }

    private IDictionary<string, Type> ActivityTypeLookup => lazyActivityTypeLookup.Value;

    public IActivity ResolveActivity(string activityTypeName, Action<IActivity> setup = null)
    {
        var activityType = ResolveActivityType(activityTypeName);
        var activity = (IActivity) ActivatorUtilities.GetServiceOrCreateInstance(serviceProvider, activityType);

        setup?.Invoke(activity);
        return activity;
    }

    public T ResolveActivity<T>(Action<T> setup = null) where T : class, IActivity
    {
        return (T) ResolveActivity(typeof(T).Name, setup != null ? x => setup((T) x) : default(Action<IActivity>));
    }

    public Type ResolveActivityType(string activityTypeName)
    {
        if (!ActivityTypeLookup.ContainsKey(activityTypeName))
        {
            var activityType = Type.GetType(activityTypeName);

            if (activityType == null)
                throw new ArgumentException($"No such activity type: {activityTypeName}", nameof(activityTypeName));

            ActivityTypeLookup[activityTypeName] = activityType;
        }

        return ActivityTypeLookup[activityTypeName];
    }
}