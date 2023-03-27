#region

using Tiveriad.Workflows.Core.Models.LifeCycleEvents;

#endregion

namespace Tiveriad.Workflows.Core.Services;

public interface ILifeCycleEventPublisher : IBackgroundTask
{
    void PublishNotification(LifeCycleEvent evt);
}