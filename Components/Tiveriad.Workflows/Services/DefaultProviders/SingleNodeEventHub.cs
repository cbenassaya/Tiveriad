#region

using Microsoft.Extensions.Logging;
using Tiveriad.Workflows.Core.Models.LifeCycleEvents;
using Tiveriad.Workflows.Core.Services;

#endregion

namespace Tiveriad.Workflows.Services.DefaultProviders;

public class SingleNodeEventHub : ILifeCycleEventHub
{
    private readonly ILogger _logger;
    private readonly ICollection<Action<LifeCycleEvent>> _subscribers = new HashSet<Action<LifeCycleEvent>>();

    public SingleNodeEventHub(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<SingleNodeEventHub>();
    }

    public Task PublishNotification(LifeCycleEvent evt)
    {
        Task.Run(() =>
        {
            foreach (var subscriber in _subscribers)
                try
                {
                    subscriber(evt);
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(default, ex, $"Error on event subscriber: {ex.Message}");
                }
        });
        return Task.CompletedTask;
    }

    public void Subscribe(Action<LifeCycleEvent> action)
    {
        _subscribers.Add(action);
    }

    public Task Start()
    {
        return Task.CompletedTask;
    }

    public Task Stop()
    {
        _subscribers.Clear();
        return Task.CompletedTask;
    }
}