//-------------------------------------------------------------------------------

#region

using Tiveriad.Commons.Guards;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine.Events;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine.States;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine.Transitions;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncSyntax;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine;

/// <summary>
///     Provides operations to build a state machine.
/// </summary>
/// <typeparam name="TState">The type of the state.</typeparam>
/// <typeparam name="TEvent">The type of the event.</typeparam>
public sealed class StateBuilder<TState, TEvent> :
    IEntryActionSyntax<TState, TEvent>,
    IGotoInIfSyntax<TState, TEvent>,
    IOtherwiseSyntax<TState, TEvent>,
    IIfOrOtherwiseSyntax<TState, TEvent>,
    IGotoSyntax<TState, TEvent>,
    IIfSyntax<TState, TEvent>,
    IOnSyntax<TState, TEvent>
    where TState : IComparable
    where TEvent : IComparable
{
    private readonly IFactory<TState, TEvent> factory;
    private readonly StateDefinition<TState, TEvent> stateDefinition;
    private readonly IImplicitAddIfNotAvailableStateDefinitionDictionary<TState, TEvent> stateDefinitionDictionary;

    private TEvent currentEventId;

    private TransitionDefinition<TState, TEvent> currentTransitionDefinition;

    public StateBuilder(
        TState stateId,
        IImplicitAddIfNotAvailableStateDefinitionDictionary<TState, TEvent> stateDefinitionDictionary,
        IFactory<TState, TEvent> factory)
    {
        this.stateDefinitionDictionary = stateDefinitionDictionary;
        this.factory = factory;
        stateDefinition = this.stateDefinitionDictionary[stateId];
    }

    /// <summary>
    ///     Defines entry actions.
    /// </summary>
    /// <param name="action">The action.</param>
    /// <returns>Exit action syntax.</returns>
    IEntryActionSyntax<TState, TEvent> IEntryActionSyntax<TState, TEvent>.ExecuteOnEntry(Func<Task> action)
    {
        NullGuard.AgainstNullArgument("action", action);

        stateDefinition.EntryActionsModifiable.Add(factory.CreateActionHolder(action));

        return this;
    }

    IEntryActionSyntax<TState, TEvent> IEntryActionSyntax<TState, TEvent>.ExecuteOnEntry(Action action)
    {
        NullGuard.AgainstNullArgument("action", action);

        stateDefinition.EntryActionsModifiable.Add(factory.CreateActionHolder(action));

        return this;
    }

    public IEntryActionSyntax<TState, TEvent> ExecuteOnEntry<T>(Func<T, Task> action)
    {
        NullGuard.AgainstNullArgument("action", action);

        stateDefinition.EntryActionsModifiable.Add(factory.CreateActionHolder(action));

        return this;
    }

    public IEntryActionSyntax<TState, TEvent> ExecuteOnEntry<T>(Action<T> action)
    {
        NullGuard.AgainstNullArgument("action", action);

        stateDefinition.EntryActionsModifiable.Add(factory.CreateActionHolder(action));

        return this;
    }

    /// <summary>
    ///     Defines an entry action.
    /// </summary>
    /// <typeparam name="T">Type of the parameter of the entry action method.</typeparam>
    /// <param name="action">The action.</param>
    /// <param name="parameter">The parameter that will be passed to the entry action.</param>
    /// <returns>Exit action syntax.</returns>
    IEntryActionSyntax<TState, TEvent> IEntryActionSyntax<TState, TEvent>.ExecuteOnEntryParametrized<T>(
        Func<T, Task> action, T parameter)
    {
        stateDefinition.EntryActionsModifiable.Add(factory.CreateActionHolder(action, parameter));

        return this;
    }

    /// <summary>
    ///     Defines an entry action.
    /// </summary>
    /// <typeparam name="T">Type of the parameter of the entry action method.</typeparam>
    /// <param name="action">The action.</param>
    /// <param name="parameter">The parameter that will be passed to the entry action.</param>
    /// <returns>Exit action syntax.</returns>
    IEntryActionSyntax<TState, TEvent> IEntryActionSyntax<TState, TEvent>.ExecuteOnEntryParametrized<T>(
        Action<T> action, T parameter)
    {
        stateDefinition.EntryActionsModifiable.Add(factory.CreateActionHolder(action, parameter));

        return this;
    }

    /// <summary>
    ///     Defines an exit action.
    /// </summary>
    /// <param name="action">The action.</param>
    /// <returns>Event syntax.</returns>
    IExitActionSyntax<TState, TEvent> IExitActionSyntax<TState, TEvent>.ExecuteOnExit(Func<Task> action)
    {
        NullGuard.AgainstNullArgument("action", action);

        stateDefinition.ExitActionsModifiable.Add(factory.CreateActionHolder(action));

        return this;
    }

    /// <summary>
    ///     Defines an exit action.
    /// </summary>
    /// <param name="action">The action.</param>
    /// <returns>Event syntax.</returns>
    IExitActionSyntax<TState, TEvent> IExitActionSyntax<TState, TEvent>.ExecuteOnExit(Action action)
    {
        NullGuard.AgainstNullArgument("action", action);

        stateDefinition.ExitActionsModifiable.Add(factory.CreateActionHolder(action));

        return this;
    }

    public IExitActionSyntax<TState, TEvent> ExecuteOnExit<T>(Func<T, Task> action)
    {
        NullGuard.AgainstNullArgument("action", action);

        stateDefinition.ExitActionsModifiable.Add(factory.CreateActionHolder(action));

        return this;
    }

    public IExitActionSyntax<TState, TEvent> ExecuteOnExit<T>(Action<T> action)
    {
        NullGuard.AgainstNullArgument("action", action);

        stateDefinition.ExitActionsModifiable.Add(factory.CreateActionHolder(action));

        return this;
    }

    /// <summary>
    ///     Defines an exit action.
    /// </summary>
    /// <typeparam name="T">Type of the parameter of the exit action method.</typeparam>
    /// <param name="action">The action.</param>
    /// <param name="parameter">The parameter that will be passed to the exit action.</param>
    /// <returns>Exit action syntax.</returns>
    IExitActionSyntax<TState, TEvent> IExitActionSyntax<TState, TEvent>.ExecuteOnExitParametrized<T>(
        Func<T, Task> action, T parameter)
    {
        stateDefinition.ExitActionsModifiable.Add(factory.CreateActionHolder(action, parameter));

        return this;
    }

    /// <summary>
    ///     Defines an exit action.
    /// </summary>
    /// <typeparam name="T">Type of the parameter of the exit action method.</typeparam>
    /// <param name="action">The action.</param>
    /// <param name="parameter">The parameter that will be passed to the exit action.</param>
    /// <returns>Exit action syntax.</returns>
    IExitActionSyntax<TState, TEvent> IExitActionSyntax<TState, TEvent>.ExecuteOnExitParametrized<T>(Action<T> action,
        T parameter)
    {
        stateDefinition.ExitActionsModifiable.Add(factory.CreateActionHolder(action, parameter));

        return this;
    }

    /// <summary>
    ///     Builds a transition.
    /// </summary>
    /// <param name="eventId">The event that triggers the transition.</param>
    /// <returns>Syntax to build the transition.</returns>
    IOnSyntax<TState, TEvent> IEventSyntax<TState, TEvent>.On(TEvent eventId)
    {
        currentEventId = eventId;

        CreateTransition();

        return this;
    }

    IGotoInIfSyntax<TState, TEvent> IGotoInIfSyntax<TState, TEvent>.Execute(Func<Task> action)
    {
        return ExecuteInternal(action);
    }

    IGotoInIfSyntax<TState, TEvent> IGotoInIfSyntax<TState, TEvent>.Execute(Action action)
    {
        return ExecuteInternal(action);
    }

    IGotoInIfSyntax<TState, TEvent> IGotoInIfSyntax<TState, TEvent>.Execute<T>(Func<T, Task> action)
    {
        return ExecuteInternal(action);
    }

    IGotoInIfSyntax<TState, TEvent> IGotoInIfSyntax<TState, TEvent>.Execute<T>(Action<T> action)
    {
        return ExecuteInternal(action);
    }

    IIfSyntax<TState, TEvent> IGotoInIfSyntax<TState, TEvent>.If<T>(Func<T, bool> guard)
    {
        CreateTransition();

        SetGuard(guard);

        return this;
    }

    IIfSyntax<TState, TEvent> IGotoInIfSyntax<TState, TEvent>.If<T>(Func<T, Task<bool>> guard)
    {
        CreateTransition();

        SetGuard(guard);

        return this;
    }

    IIfSyntax<TState, TEvent> IGotoInIfSyntax<TState, TEvent>.If(Func<bool> guard)
    {
        CreateTransition();

        SetGuard(guard);

        return this;
    }

    IIfSyntax<TState, TEvent> IGotoInIfSyntax<TState, TEvent>.If(Func<Task<bool>> guard)
    {
        CreateTransition();

        SetGuard(guard);

        return this;
    }

    IOtherwiseSyntax<TState, TEvent> IGotoInIfSyntax<TState, TEvent>.Otherwise()
    {
        CreateTransition();

        return this;
    }

    IGotoSyntax<TState, TEvent> IGotoSyntax<TState, TEvent>.Execute(Func<Task> action)
    {
        return ExecuteInternal(action);
    }

    IGotoSyntax<TState, TEvent> IGotoSyntax<TState, TEvent>.Execute(Action action)
    {
        return ExecuteInternal(action);
    }

    IGotoSyntax<TState, TEvent> IGotoSyntax<TState, TEvent>.Execute<T>(Func<T, Task> action)
    {
        return ExecuteInternal(action);
    }

    IGotoSyntax<TState, TEvent> IGotoSyntax<TState, TEvent>.Execute<T>(Action<T> action)
    {
        return ExecuteInternal(action);
    }

    IIfOrOtherwiseSyntax<TState, TEvent> IIfOrOtherwiseSyntax<TState, TEvent>.Execute(Func<Task> action)
    {
        return ExecuteInternal(action);
    }

    IIfOrOtherwiseSyntax<TState, TEvent> IIfOrOtherwiseSyntax<TState, TEvent>.Execute(Action action)
    {
        return ExecuteInternal(action);
    }

    IIfOrOtherwiseSyntax<TState, TEvent> IIfOrOtherwiseSyntax<TState, TEvent>.Execute<T>(Func<T, Task> action)
    {
        return ExecuteInternal(action);
    }

    IIfOrOtherwiseSyntax<TState, TEvent> IIfOrOtherwiseSyntax<TState, TEvent>.Execute<T>(Action<T> action)
    {
        return ExecuteInternal(action);
    }

    IIfSyntax<TState, TEvent> IIfOrOtherwiseSyntax<TState, TEvent>.If<T>(Func<T, bool> guard)
    {
        CreateTransition();

        SetGuard(guard);

        return this;
    }

    IIfSyntax<TState, TEvent> IIfOrOtherwiseSyntax<TState, TEvent>.If<T>(Func<T, Task<bool>> guard)
    {
        CreateTransition();

        SetGuard(guard);

        return this;
    }

    IIfSyntax<TState, TEvent> IIfOrOtherwiseSyntax<TState, TEvent>.If(Func<bool> guard)
    {
        CreateTransition();

        SetGuard(guard);

        return this;
    }

    IIfSyntax<TState, TEvent> IIfOrOtherwiseSyntax<TState, TEvent>.If(Func<Task<bool>> guard)
    {
        CreateTransition();

        SetGuard(guard);

        return this;
    }

    IOtherwiseSyntax<TState, TEvent> IIfOrOtherwiseSyntax<TState, TEvent>.Otherwise()
    {
        CreateTransition();

        return this;
    }

    IGotoInIfSyntax<TState, TEvent> IIfSyntax<TState, TEvent>.Goto(TState target)
    {
        SetTargetState(target);

        return this;
    }

    IIfOrOtherwiseSyntax<TState, TEvent> IIfSyntax<TState, TEvent>.Execute(Func<Task> action)
    {
        return ExecuteInternal(action);
    }

    IIfOrOtherwiseSyntax<TState, TEvent> IIfSyntax<TState, TEvent>.Execute(Action action)
    {
        return ExecuteInternal(action);
    }

    IIfOrOtherwiseSyntax<TState, TEvent> IIfSyntax<TState, TEvent>.Execute<T>(Func<T, Task> action)
    {
        return ExecuteInternal(action);
    }

    IIfOrOtherwiseSyntax<TState, TEvent> IIfSyntax<TState, TEvent>.Execute<T>(Action<T> action)
    {
        return ExecuteInternal(action);
    }

    /// <summary>
    ///     Defines where to go in response to an event.
    /// </summary>
    /// <param name="target">The target.</param>
    /// <returns>Execute syntax.</returns>
    IGotoSyntax<TState, TEvent> IOnSyntax<TState, TEvent>.Goto(TState target)
    {
        SetTargetState(target);

        return this;
    }

    IOnExecuteSyntax<TState, TEvent> IOnExecuteSyntax<TState, TEvent>.Execute(Func<Task> action)
    {
        return ExecuteInternal(action);
    }

    IOnExecuteSyntax<TState, TEvent> IOnExecuteSyntax<TState, TEvent>.Execute(Action action)
    {
        return ExecuteInternal(action);
    }

    IOnExecuteSyntax<TState, TEvent> IOnExecuteSyntax<TState, TEvent>.Execute<T>(Func<T, Task> action)
    {
        return ExecuteInternal(action);
    }

    IOnExecuteSyntax<TState, TEvent> IOnExecuteSyntax<TState, TEvent>.Execute<T>(Action<T> action)
    {
        return ExecuteInternal(action);
    }

    IIfSyntax<TState, TEvent> IOnSyntax<TState, TEvent>.If<T>(Func<T, bool> guard)
    {
        SetGuard(guard);

        return this;
    }

    IIfSyntax<TState, TEvent> IOnSyntax<TState, TEvent>.If<T>(Func<T, Task<bool>> guard)
    {
        SetGuard(guard);

        return this;
    }

    IIfSyntax<TState, TEvent> IOnSyntax<TState, TEvent>.If(Func<bool> guard)
    {
        SetGuard(guard);

        return this;
    }

    IIfSyntax<TState, TEvent> IOnSyntax<TState, TEvent>.If(Func<Task<bool>> guard)
    {
        SetGuard(guard);

        return this;
    }

    IGotoSyntax<TState, TEvent> IOtherwiseSyntax<TState, TEvent>.Goto(TState target)
    {
        SetTargetState(target);

        return this;
    }

    IOtherwiseExecuteSyntax<TState, TEvent> IOtherwiseExecuteSyntax<TState, TEvent>.Execute(Func<Task> action)
    {
        return ExecuteInternal(action);
    }

    IOtherwiseExecuteSyntax<TState, TEvent> IOtherwiseExecuteSyntax<TState, TEvent>.Execute(Action action)
    {
        return ExecuteInternal(action);
    }

    IOtherwiseExecuteSyntax<TState, TEvent> IOtherwiseExecuteSyntax<TState, TEvent>.Execute<T>(Func<T, Task> action)
    {
        return ExecuteInternal(action);
    }

    IOtherwiseExecuteSyntax<TState, TEvent> IOtherwiseExecuteSyntax<TState, TEvent>.Execute<T>(Action<T> action)
    {
        return ExecuteInternal(action);
    }

    private void CreateTransition()
    {
        currentTransitionDefinition = new TransitionDefinition<TState, TEvent>();
        stateDefinition.TransitionsModifiable.Add(currentEventId, currentTransitionDefinition);
    }

    private StateBuilder<TState, TEvent> ExecuteInternal(Func<Task> action)
    {
        currentTransitionDefinition.ActionsModifiable.Add(factory.CreateTransitionActionHolder(action));

        CheckGuards();

        return this;
    }

    private StateBuilder<TState, TEvent> ExecuteInternal(Action action)
    {
        currentTransitionDefinition.ActionsModifiable.Add(factory.CreateTransitionActionHolder(action));

        CheckGuards();

        return this;
    }

    private StateBuilder<TState, TEvent> ExecuteInternal<T>(Func<T, Task> action)
    {
        currentTransitionDefinition.ActionsModifiable.Add(factory.CreateTransitionActionHolder(action));

        CheckGuards();

        return this;
    }

    private StateBuilder<TState, TEvent> ExecuteInternal<T>(Action<T> action)
    {
        currentTransitionDefinition.ActionsModifiable.Add(factory.CreateTransitionActionHolder(action));

        CheckGuards();

        return this;
    }

    private void SetGuard<T>(Func<T, bool> guard)
    {
        currentTransitionDefinition.Guard = factory.CreateGuardHolder(guard);
    }

    private void SetGuard<T>(Func<T, Task<bool>> guard)
    {
        currentTransitionDefinition.Guard = factory.CreateGuardHolder(guard);
    }

    private void SetGuard(Func<bool> guard)
    {
        currentTransitionDefinition.Guard = factory.CreateGuardHolder(guard);
    }

    private void SetGuard(Func<Task<bool>> guard)
    {
        currentTransitionDefinition.Guard = factory.CreateGuardHolder(guard);
    }

    private void SetTargetState(TState target)
    {
        currentTransitionDefinition.Target = stateDefinitionDictionary[target];

        CheckGuards();
    }

    private void CheckGuards()
    {
        var transitionsByEvent =
            stateDefinition.TransitionsModifiable.GetTransitions().GroupBy(t => t.EventId).ToList();
        var withMoreThenOneTransitionWithoutGuard = transitionsByEvent.Where(g => g.Count(t => t.Guard == null) > 1);

        if (withMoreThenOneTransitionWithoutGuard.Any())
            throw new InvalidOperationException(ExceptionMessages.OnlyOneTransitionMayHaveNoGuard);

        if ((from grouping in transitionsByEvent
                let transition = grouping.SingleOrDefault(t => t.Guard == null)
                where transition != null && grouping.LastOrDefault() != transition
                select grouping).Any())
            throw new InvalidOperationException(ExceptionMessages.TransitionWithoutGuardHasToBeLast);
    }
}