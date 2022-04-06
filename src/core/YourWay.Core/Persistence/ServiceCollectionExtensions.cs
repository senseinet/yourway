using Microsoft.Extensions.DependencyInjection;

namespace YourWay.Persistence;

public static class ServiceCollectionExtensions
{
    public static MemoryStoreYourWayBuilder WithMemoryProvider(this YourWayBuilder configuration)
    {
        return new MemoryStoreYourWayBuilder(configuration.Services);
    }

    public static MemoryStoreYourWayBuilder WithMemoryStores(this YourWayBuilder configuration)
    {
        return configuration.WithMemoryProvider().WithWorkflowInstanceStore();
    }

    public static MemoryStoreYourWayBuilder WithWorkflowInstanceStore(
        this MemoryStoreYourWayBuilder configuration)
    {
        configuration.Services.AddSingleton<IWorkflowInstanceStore, MemoryWorkflowInstanceStore>();

        return configuration;
    }
}