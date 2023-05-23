#region

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.ObjectPool;
using Tiveriad.Workflows.Core.Primitives;
using Tiveriad.Workflows.Core.Services;
using Tiveriad.Workflows.Services;
using Tiveriad.Workflows.Services.DefaultProviders;
using Tiveriad.Workflows.Services.ErrorHandlers;
using Tiveriad.Workflows.Services.FluentBuilders;

#endregion

namespace Tiveriad.Workflows.DependencyInjection;

public static class Extensions
{
    public static IServiceCollection AddWorkflow(this IServiceCollection services)
    {
        if (services.Any(x => x.ServiceType == typeof(IWorkflowOptions)))
            throw new InvalidOperationException("Workflow services already registered");

        var serviceProvider = new DependencyInjectionServiceResolver(services.BuildServiceProvider());
        services.AddSingleton<IWorkflowOptions, WorkflowOptions>();
        services.AddSingleton<ISingletonMemoryProvider, MemoryPersistenceProvider>();
        services.AddTransient(sp => sp.GetRequiredService<IWorkflowOptions>().PersistenceFactory(serviceProvider));
        services.AddTransient<IWorkflowRepository>(sp =>
            sp.GetRequiredService<IWorkflowOptions>().PersistenceFactory(serviceProvider));
        services.AddTransient<ISubscriptionRepository>(sp =>
            sp.GetRequiredService<IWorkflowOptions>().PersistenceFactory(serviceProvider));
        services.AddTransient<IEventRepository>(sp =>
            sp.GetRequiredService<IWorkflowOptions>().PersistenceFactory(serviceProvider));
        services.AddSingleton(sp => sp.GetRequiredService<IWorkflowOptions>().QueueProvider);
        services.AddSingleton(sp => sp.GetRequiredService<IWorkflowOptions>().DistributedLockProvider);
        services.AddSingleton(sp => sp.GetRequiredService<IWorkflowOptions>().LifeCycleEventHub);
        services.AddSingleton(sp => sp.GetRequiredService<IWorkflowOptions>().SearchIndex);

        services.AddSingleton<IWorkflowRegistry, WorkflowRegistry>();
        services.AddSingleton<ILifeCycleEventPublisher, LifeCycleEventPublisher>();

        //if (options.EnableWorkflows) services.AddTransient<IBackgroundTask, WorkflowConsumer>();

        //if (options.EnableEvents) services.AddTransient<IBackgroundTask, EventConsumer>();

        //if (options.EnableIndexes) services.AddTransient<IBackgroundTask, IndexConsumer>();

        //if (options.EnablePolling) services.AddTransient<IBackgroundTask, RunnablePoller>();

        services.AddTransient<IBackgroundTask>(sp => sp.GetService<ILifeCycleEventPublisher>());

        services.AddTransient<IWorkflowErrorHandler, CompensateHandler>();
        services.AddTransient<IWorkflowErrorHandler, RetryHandler>();
        services.AddTransient<IWorkflowErrorHandler, TerminateHandler>();
        services.AddTransient<IWorkflowErrorHandler, SuspendHandler>();

        services.AddSingleton<IGreyList, GreyList>();
        services.AddSingleton<IWorkflowController, WorkflowController>();
        services.AddSingleton<IActivityController, ActivityController>();
        services.AddSingleton<IWorkflowHost, WorkflowHost>();
        services.AddTransient<IStepExecutor, StepExecutor>();
        services.AddTransient<IWorkflowMiddlewareErrorHandler, DefaultWorkflowMiddlewareErrorHandler>();
        services.AddTransient<IWorkflowMiddlewareRunner, WorkflowMiddlewareRunner>();
        services.AddTransient<IScopeProvider, ScopeProvider>();
        services.AddTransient<IWorkflowExecutor, WorkflowExecutor>();
        services.AddTransient<ICancellationProcessor, CancellationProcessor>();
        services.AddTransient<IWorkflowBuilder, WorkflowBuilder>();
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        services.AddTransient<IExecutionResultProcessor, ExecutionResultProcessor>();
        services.AddTransient<IExecutionPointerFactory, ExecutionPointerFactory>();

        services
            .AddTransient<IPooledObjectPolicy<IPersistenceProvider>, InjectedObjectPoolPolicy<IPersistenceProvider>>();
        services.AddTransient<IPooledObjectPolicy<IWorkflowExecutor>, InjectedObjectPoolPolicy<IWorkflowExecutor>>();

        services.AddTransient<ISyncWorkflowRunner, SyncWorkflowRunner>();

        services.AddTransient<Foreach>();

        return services;
    }

    /// <summary>
    ///     Adds a middleware that will run around the execution of a workflow step.
    /// </summary>
    /// <param name="services">The services collection.</param>
    /// <param name="factory">Optionally configure using your own factory.</param>
    /// <typeparam name="TMiddleware">
    ///     The type of middleware.
    ///     It must implement <see cref="IWorkflowStepMiddleware" />.
    /// </typeparam>
    /// <returns>The services collection for chaining.</returns>
    public static IServiceCollection AddWorkflowStepMiddleware<TMiddleware>(
        this IServiceCollection services,
        Func<IServiceProvider, TMiddleware> factory = null)
        where TMiddleware : class, IWorkflowStepMiddleware
    {
        return factory == null
            ? services.AddTransient<IWorkflowStepMiddleware, TMiddleware>()
            : services.AddTransient<IWorkflowStepMiddleware, TMiddleware>(factory);
    }

    /// <summary>
    ///     Adds a middleware that will run either before a workflow is kicked off or after
    ///     a workflow completes. Specify the phase of the workflow execution process that
    ///     you want to execute this middleware using <see cref="IWorkflowMiddleware.Phase" />.
    /// </summary>
    /// <param name="services">The services collection.</param>
    /// <param name="factory">Optionally configure using your own factory.</param>
    /// <typeparam name="TMiddleware">
    ///     The type of middleware.
    ///     It must implement <see cref="IWorkflowMiddleware" />.
    /// </typeparam>
    /// <returns>The services collection for chaining.</returns>
    public static IServiceCollection AddWorkflowMiddleware<TMiddleware>(
        this IServiceCollection services,
        Func<IServiceProvider, TMiddleware> factory = null)
        where TMiddleware : class, IWorkflowMiddleware
    {
        return factory == null
            ? services.AddTransient<IWorkflowMiddleware, TMiddleware>()
            : services.AddTransient<IWorkflowMiddleware, TMiddleware>(factory);
    }
}