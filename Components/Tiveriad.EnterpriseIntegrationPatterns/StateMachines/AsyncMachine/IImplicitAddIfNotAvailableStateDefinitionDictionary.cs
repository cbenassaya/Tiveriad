//-------------------------------------------------------------------------------

#region

using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine.States;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine;

public interface IImplicitAddIfNotAvailableStateDefinitionDictionary<TState, TEvent>
    where TState : IComparable
    where TEvent : IComparable
{
    /// <summary>
    ///     Gets the <see cref="StateDefinition{TState,TEvent}" /> with the specified state id.
    ///     If there exists no StateDefinition for the stateId, a new one is implicitly created, added and returned.
    /// </summary>
    /// <value>State with the specified id.</value>
    /// <param name="stateId">The State id.</param>
    /// <returns>The State with the specified id.</returns>
    StateDefinition<TState, TEvent> this[TState stateId] { get; }
}