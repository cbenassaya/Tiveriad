//-------------------------------------------------------------------------------

#region

#endregion

using Tiveriad.Commons.Optionals;

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Models;

public interface ILastActiveStateModifier<TState>
    where TState : IComparable
{
    Optional<TState> GetLastActiveStateFor(TState state);

    void SetLastActiveStateFor(TState state, TState newLastActiveState);
}