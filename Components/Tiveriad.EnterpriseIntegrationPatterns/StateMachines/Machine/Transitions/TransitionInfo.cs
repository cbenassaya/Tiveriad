//-------------------------------------------------------------------------------

#region

using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.ActionHolders;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.GuardHolders;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.States;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.Transitions;

/// <summary>
///     Describes a transition.
/// </summary>
/// <typeparam name="TState">Type fo the states.</typeparam>
/// <typeparam name="TEvent">Type of the events.</typeparam>
public class TransitionInfo<TState, TEvent>
    where TState : IComparable
    where TEvent : IComparable
{
    public TransitionInfo(TEvent eventId, IStateDefinition<TState, TEvent> source,
        IStateDefinition<TState, TEvent> target, IGuardHolder guard, IEnumerable<IActionHolder> actions)
    {
        EventId = eventId;
        Source = source;
        Target = target;
        Guard = guard;
        Actions = actions;
    }

    /// <summary>
    ///     Gets the event id.
    /// </summary>
    /// <value>The event id.</value>
    public TEvent EventId { get; }

    /// <summary>
    ///     Gets the source.
    /// </summary>
    /// <value>The source.</value>
    public IStateDefinition<TState, TEvent> Source { get; }

    /// <summary>
    ///     Gets the target.
    /// </summary>
    /// <value>The target.</value>
    public IStateDefinition<TState, TEvent> Target { get; }

    /// <summary>
    ///     Gets the guard.
    /// </summary>
    /// <value>The guard.</value>
    public IGuardHolder Guard { get; }

    /// <summary>
    ///     Gets the actions.
    /// </summary>
    /// <value>The actions.</value>
    public IEnumerable<IActionHolder> Actions { get; }
}