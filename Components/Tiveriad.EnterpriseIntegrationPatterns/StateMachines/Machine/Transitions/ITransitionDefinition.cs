//-------------------------------------------------------------------------------

#region

using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.ActionHolders;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.GuardHolders;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.States;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.Transitions;

public interface ITransitionDefinition<TState, TEvent>
    where TState : IComparable
    where TEvent : IComparable
{
    IStateDefinition<TState, TEvent> Source { get; }

    IStateDefinition<TState, TEvent> Target { get; }

    IGuardHolder Guard { get; }

    IEnumerable<IActionHolder> Actions { get; }

    bool IsInternalTransition { get; }
}