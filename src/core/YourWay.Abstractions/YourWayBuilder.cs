using Microsoft.Extensions.DependencyInjection;

namespace YourWay;

public class YourWayBuilder
{
    public YourWayBuilder(IServiceCollection services)
    {
        Services = services;
    }

    public IServiceCollection Services { get; }
}