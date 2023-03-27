#region

using System.Collections.Concurrent;
using Tiveriad.Workflows.Core.Services;

#endregion

namespace Tiveriad.Workflows.Services.DefaultProviders;
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

/// <summary>
///     Single node in-memory implementation of IQueueProvider
/// </summary>
public class SingleNodeQueueProvider : IQueueProvider
{
    private readonly Dictionary<QueueType, BlockingCollection<string>> _queues = new()
    {
        [QueueType.Workflow] = new(),
        [QueueType.Event] = new(),
        [QueueType.Index] = new()
    };

    public bool IsDequeueBlocking => true;

    public Task QueueWork(string id, QueueType queue)
    {
        _queues[queue].Add(id);
        return Task.CompletedTask;
    }

    public Task<string> DequeueWork(QueueType queue, CancellationToken cancellationToken)
    {
        if (_queues[queue].TryTake(out var id, 100, cancellationToken))
            return Task.FromResult(id);

        return Task.FromResult<string>(null);
    }

    public Task Start()
    {
        return Task.CompletedTask;
    }

    public Task Stop()
    {
        return Task.CompletedTask;
    }

    public void Dispose()
    {
    }
}

#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously