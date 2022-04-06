using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using YourWay.Activities;
using YourWay.Persistence;
using YourWay.Services;
using YourWay.WorkflowBuilders;
using YourWay.WorkflowEventHandlers;

namespace YourWay.Extensions;

public static class YourWayServiceCollectionExtensions
{
    public static IServiceCollection AddYourWayCore(
        this IServiceCollection services,
        Action<YourWayBuilder> configure = null)
    {
        var configuration = new YourWayBuilder(services);
        configuration.AddWorkflowsCore();
        configure?.Invoke(configuration);

        EnsurePersistence(configuration);

        return services;
    }

    public static IServiceCollection AddActivity<T>(this IServiceCollection services)
        where T : class, IActivity
    {
        return services
            .AddTransient<T>()
            .AddTransient<IActivity>(sp => sp.GetRequiredService<T>());
    }

    private static YourWayBuilder AddWorkflowsCore(this YourWayBuilder configuration)
    {
        var services = configuration.Services;
        services.TryAddSingleton<IClock, Clock>();

        services
            .AddLogging()
            .AddTransient<Func<IEnumerable<IActivity>>>(sp => sp.GetServices<IActivity>)
            .AddTransient<IWorkflowFactory, WorkflowFactory>()
            .AddTransient<IWorkflowRegistry, WorkflowRegistry>()
            .AddScoped<IWorkflowEventHandler, PersistenceWorkflowEventHandler>()
            .AddScoped<IActivityResolver, ActivityResolver>()
            .AddScoped<IActivityRunner, ActivityRunner>()
            .AddScoped<IWorkflowRunner, WorkflowRunner>()
            .AddTransient<IWorkflowBuilder, WorkflowBuilder>()
            .AddTransient<Func<IWorkflowBuilder>>(sp => sp.GetRequiredService<IWorkflowBuilder>);

        return configuration;
    }

    private static void EnsurePersistence(YourWayBuilder configuration)
    {
        configuration.WithMemoryStores();
    }
}