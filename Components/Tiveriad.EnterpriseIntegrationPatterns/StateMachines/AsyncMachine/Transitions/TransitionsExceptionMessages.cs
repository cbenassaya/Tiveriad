//-------------------------------------------------------------------------------

#region

using System.Globalization;
using Tiveriad.Commons.Guards;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine.States;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine.Transitions;

/// <summary>
///     Holds all exception messages.
/// </summary>
public static class TransitionsExceptionMessages
{
    /// <summary>
    ///     Transition cannot be added to the state because it has already been added to the state.
    /// </summary>
    /// <typeparam name="TState">The type of the state.</typeparam>
    /// <typeparam name="TEvent">The type of the event.</typeparam>
    /// <param name="transition">The transition.</param>
    /// <param name="state">The state.</param>
    /// <returns>error message.</returns>
    public static string TransitionDoesAlreadyExist<TState, TEvent>(ITransitionDefinition<TState, TEvent> transition,
        IStateDefinition<TState, TEvent> state)
        where TState : IComparable
        where TEvent : IComparable
    {
        NullGuard.AgainstNullArgument("transition", transition);

        return string.Format(
            CultureInfo.InvariantCulture,
            "Transition {0} cannot be added to the state {1} because it has already been added to the state {2}.",
            transition,
            state,
            transition.Source);
    }
}