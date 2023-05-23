//-------------------------------------------------------------------------------

//-------------------------------------------------------------------------------

using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.ActionHolders;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.GuardHolders;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.States;

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.Events
{
    public interface IFactory<TState, TEvent>
        where TState : IComparable
        where TEvent : IComparable
    {
        IActionHolder CreateActionHolder(Action action);

        IActionHolder CreateActionHolder<T>(Action<T> action);

        IActionHolder CreateActionHolder<T>(Action<T> action, T parameter);

        IActionHolder CreateTransitionActionHolder(Action action);

        IActionHolder CreateTransitionActionHolder<T>(Action<T> action);

        IGuardHolder CreateGuardHolder(Func<bool> guard);

        IGuardHolder CreateGuardHolder<T>(Func<T, bool> guard);

        ITransitionContext<TState, TEvent> CreateTransitionContext(IStateDefinition<TState, TEvent> stateDefinition, Missable<TEvent> eventId, object eventArgument, INotifier<TState, TEvent> notifier);

        StateMachineInitializer<TState, TEvent> CreateStateMachineInitializer(IStateDefinition<TState, TEvent> initialState, ITransitionContext<TState, TEvent> context);
    }
}