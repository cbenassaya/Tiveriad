#region

using Tiveriad.Workflows.Core.Models.LifeCycleEvents;

#endregion

namespace Tiveriad.Workflows.Core.Services;

public interface ILifeCycleEventHub
{
    Task PublishNotification(LifeCycleEvent evt);
    void Subscribe(Action<LifeCycleEvent> action);
    Task Start();
    Task Stop();
}