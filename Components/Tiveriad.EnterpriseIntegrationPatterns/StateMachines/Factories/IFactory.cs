//-------------------------------------------------------------------------------

#region

using Tiveriad.Commons.Optionals;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.ActionHolders;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Contexts;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.GuardHolders;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Models;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Factories;

public interface IFactory<TState, TEvent>
    where TState : IComparable
    where TEvent : IComparable
{
    IActionHolder CreateActionHolder(Func<Task> action);

    IActionHolder CreateActionHolder(Action action);

    IActionHolder CreateActionHolder<T>(Action<T> action);

    IActionHolder CreateActionHolder<T>(Action<T> action, T parameter);

    IActionHolder CreateTransitionActionHolder(Action action);

    IActionHolder CreateTransitionActionHolder<T>(Action<T> action);

    IActionHolder CreateActionHolder<T>(Func<T, Task> action);

    IActionHolder CreateActionHolder<T>(Func<T, Task> action, T parameter);

    IActionHolder CreateTransitionActionHolder(Func<Task> action);

    IActionHolder CreateTransitionActionHolder<T>(Func<T, Task> action);

    IGuardHolder CreateGuardHolder(Func<bool> guard);

    IGuardHolder CreateGuardHolder(Func<Task<bool>> guard);

    IGuardHolder CreateGuardHolder<T>(Func<T, Task<bool>> guard);

    IGuardHolder CreateGuardHolder<T>(Func<T, bool> guard);

    ITransitionContext<TState, TEvent> CreateTransitionContext(IStateDefinition<TState, TEvent> stateDefinition,
        Missable<TEvent> eventId, object eventArgument, INotifier<TState, TEvent> notifier);

    StateMachineInitializer<TState, TEvent> CreateStateMachineInitializer(IStateDefinition<TState, TEvent> initialState,
        ITransitionContext<TState, TEvent> context);
}