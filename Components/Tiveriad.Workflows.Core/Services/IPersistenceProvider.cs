#region

using Tiveriad.Workflows.Core.Models;

#endregion

namespace Tiveriad.Workflows.Core.Services;

public interface IPersistenceProvider : IWorkflowRepository, ISubscriptionRepository, IEventRepository,
    IScheduledCommandRepository
{
    Task PersistErrors(IEnumerable<ExecutionError> errors, CancellationToken cancellationToken = default);

    void EnsureStoreExists();
}