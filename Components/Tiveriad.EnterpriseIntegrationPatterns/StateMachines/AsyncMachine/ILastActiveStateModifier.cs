//-------------------------------------------------------------------------------

#region

using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Infrastructure;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine;

public interface ILastActiveStateModifier<TState>
    where TState : IComparable
{
    Optional<TState> GetLastActiveStateFor(TState state);

    void SetLastActiveStateFor(TState state, TState newLastActiveState);
}