//-------------------------------------------------------------------------------

#region

using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine.Transitions;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine;

public interface ITransitionDictionary<TState, TEvent>
    where TState : IComparable
    where TEvent : IComparable
{
    /// <summary>
    ///     Adds the specified event id.
    /// </summary>
    /// <param name="eventId">The event id.</param>
    /// <param name="transition">The transition.</param>
    void Add(TEvent eventId, TransitionDefinition<TState, TEvent> transition);

    /// <summary>
    ///     Gets all transitions.
    /// </summary>
    /// <returns>All transitions.</returns>
    IEnumerable<TransitionInfo<TState, TEvent>> GetTransitions();
}