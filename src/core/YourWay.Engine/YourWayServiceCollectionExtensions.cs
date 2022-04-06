using Microsoft.Extensions.DependencyInjection;
using YourWay.Extensions;

namespace YourWay.Engine;

public static class YourWayServiceCollectionExtensions
{
    public static IServiceCollection AddYourWay(
        this IServiceCollection services,
        Action<YourWayBuilder> configure = null)
    {
        return services
            .AddYourWayCore(configure);
    }
}