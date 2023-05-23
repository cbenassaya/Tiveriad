//-------------------------------------------------------------------------------

//-------------------------------------------------------------------------------

using System.Globalization;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine.ActionHolders;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine.GuardHolders;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine.States;

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine.Transitions
{
    public class TransitionDefinition<TState, TEvent> : ITransitionDefinition<TState, TEvent>
        where TState : IComparable
        where TEvent : IComparable
    {
        public IStateDefinition<TState, TEvent> Source { get; set; }

        public IStateDefinition<TState, TEvent> Target { get; set; }

        public IGuardHolder Guard { get; set; }

        public ICollection<IActionHolder> ActionsModifiable { get; } = new List<IActionHolder>();

        public bool IsInternalTransition => this.Target == null;

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "Transition from state {0} to state {1}.", this.Source, this.Target);
        }

        public IEnumerable<IActionHolder> Actions => this.ActionsModifiable;
    }
}