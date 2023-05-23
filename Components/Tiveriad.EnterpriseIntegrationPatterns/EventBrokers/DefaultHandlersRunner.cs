namespace Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;

/// <summary>
///     Runs event handlers on the thread as the caller, blocking it until all handlers are runned.
/// </summary>
public class DefaultHandlersRunner : IEventHandlerRunner
{
    /// <summary>
    ///     Runs event handlers on the thread as the caller, blocking it until all handlers are runned.
    /// </summary>
    /// <param name="handlers">The event handlers to run.</param>
    public async Task RunAsync(params Func<Task>[] handlers)
    {
        foreach (var handler in handlers) await handler().ConfigureAwait(false);
    }

    /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
    public void Dispose()
    {
    }
}