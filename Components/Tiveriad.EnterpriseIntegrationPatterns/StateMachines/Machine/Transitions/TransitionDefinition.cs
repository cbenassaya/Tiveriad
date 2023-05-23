//-------------------------------------------------------------------------------

#region

using System.Globalization;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.ActionHolders;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.GuardHolders;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.States;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.Transitions;

public class TransitionDefinition<TState, TEvent> : ITransitionDefinition<TState, TEvent>
    where TState : IComparable
    where TEvent : IComparable
{
    public ICollection<IActionHolder> ActionsModifiable { get; } = new List<IActionHolder>();
    public IStateDefinition<TState, TEvent> Source { get; set; }

    public IStateDefinition<TState, TEvent> Target { get; set; }

    public IGuardHolder Guard { get; set; }

    public bool IsInternalTransition => Target == null;

    public IEnumerable<IActionHolder> Actions => ActionsModifiable;

    public override string ToString()
    {
        return string.Format(CultureInfo.InvariantCulture, "Transition from state {0} to state {1}.", Source, Target);
    }
}