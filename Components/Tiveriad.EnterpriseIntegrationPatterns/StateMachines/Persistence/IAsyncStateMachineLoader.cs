//-------------------------------------------------------------------------------

#region

using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Infrastructure;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Persistence;

public interface IAsyncStateMachineLoader<TState, TEvent>
    where TState : IComparable
    where TEvent : IComparable
{
    /// <summary>
    ///     Returns the state to be set as the current state of the state machine.
    /// </summary>
    /// <returns>State id.</returns>
    Task<IInitializable<TState>> LoadCurrentState();

    /// <summary>
    ///     Returns the last active state of all super states that have a last active state (i.e. they count as visited).
    /// </summary>
    /// <returns>Key = id of super state, Value = id of last active state.</returns>
    Task<IReadOnlyDictionary<TState, TState>> LoadHistoryStates();

    /// <summary>
    ///     Returns the events to be processed by the state machine.
    /// </summary>
    /// <returns>The events.</returns>
    Task<IReadOnlyCollection<EventInformation<TEvent>>> LoadEvents();

    /// <summary>
    ///     Returns the priority events to be processed by the state machine.
    /// </summary>
    /// <returns>The priority events.</returns>
    Task<IReadOnlyCollection<EventInformation<TEvent>>> LoadPriorityEvents();
}