﻿using PowerPipe.Factories;
using PowerPipe.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace PowerPipe.Extensions.MicrosoftDependencyInjection;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddPowerPipe(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddSingleton<IPipelineStepFactory, PipelineStepFactory>();
    }

    public static IServiceCollection AddPowerPipeStep<TStep, TContext, TResult>(this IServiceCollection serviceCollection)
        where TStep : class, IPipelineStep<TContext, TResult>
        where TContext : PipelineContext<TResult>
        where TResult : class
    {
        return serviceCollection.AddTransient<TStep>();
    }
}