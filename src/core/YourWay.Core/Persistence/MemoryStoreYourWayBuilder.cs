using Microsoft.Extensions.DependencyInjection;

namespace YourWay.Persistence;

public class MemoryStoreYourWayBuilder : YourWayBuilder
{
    public MemoryStoreYourWayBuilder(IServiceCollection services) : base(services)
    {
    }
}