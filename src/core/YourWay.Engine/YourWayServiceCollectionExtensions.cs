﻿using Microsoft.Extensions.DependencyInjection;

namespace YourWay.Engine;

public static class YourWayServiceCollectionExtensions
{
    public static IServiceCollection AddYourWay(
        this IServiceCollection services,
        Action<YourWayBuilder> configure = null)
    {
        return services;
    }
}