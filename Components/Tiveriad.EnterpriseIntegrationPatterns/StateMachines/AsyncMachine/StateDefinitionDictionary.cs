//-------------------------------------------------------------------------------

//-------------------------------------------------------------------------------

using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine.States;

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine
{
    public class StateDefinitionDictionary<TState, TEvent> : IStateDefinitionDictionary<TState, TEvent>
        where TState : IComparable
        where TEvent : IComparable
    {
        private readonly IReadOnlyDictionary<TState, IStateDefinition<TState, TEvent>> stateDefinitions;

        public StateDefinitionDictionary(IReadOnlyDictionary<TState, IStateDefinition<TState, TEvent>> stateDefinitions)
        {
            this.stateDefinitions = stateDefinitions;
        }

        public IStateDefinition<TState, TEvent> this[TState key]
        {
            get
            {
                if (this.stateDefinitions.TryGetValue(key, out var stateDefinition))
                {
                    return stateDefinition;
                }

                throw new InvalidOperationException(
                    ExceptionMessages.CannotFindStateDefinition(key));
            }
        }

        public IEnumerable<IStateDefinition<TState, TEvent>> Values => this.stateDefinitions.Values;
    }
}