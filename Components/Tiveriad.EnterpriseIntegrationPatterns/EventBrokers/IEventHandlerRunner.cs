namespace Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;

/// <summary>
///     Represents runner of event handlers.
/// </summary>
public interface IEventHandlerRunner : IDisposable
{
    /// <summary>
    ///     Runs event handlers.
    /// </summary>
    /// <param name="handlers">The event handlers to run.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    Task RunAsync(params Func<Task>[] handlers);
}