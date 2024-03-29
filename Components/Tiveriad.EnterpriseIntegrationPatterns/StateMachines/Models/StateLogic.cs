﻿//-------------------------------------------------------------------------------

#region

using Tiveriad.Commons.Guards;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.ActionHolders;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Contexts;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Extensions;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Models;

public class StateLogic<TState, TEvent>
    : IStateLogic<TState, TEvent>
    where TState : IComparable
    where TEvent : IComparable
{
    private readonly IExtensionHost<TState, TEvent> extensionHost;
    private readonly ITransitionLogic<TState, TEvent> transitionLogic;

    public StateLogic(
        ITransitionLogic<TState, TEvent> transitionLogic,
        IExtensionHost<TState, TEvent> extensionHost)
    {
        this.extensionHost = extensionHost;
        this.transitionLogic = transitionLogic;
    }

    /// <summary>
    ///     Goes recursively up the state hierarchy until a state is found that can handle the event.
    /// </summary>
    /// <param name="stateDefinition">The state definition of the state in which the event should be fired.</param>
    /// <param name="context">The event context.</param>
    /// <param name="lastActiveStateModifier">The last active state modifier.</param>
    /// <param name="stateDefinitions">The definitions for all states of this state Machine.</param>
    /// <returns>The result of the transition.</returns>
    public async Task<ITransitionResult<TState>> Fire(
        IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context,
        ILastActiveStateModifier<TState> lastActiveStateModifier,
        IStateDefinitionDictionary<TState, TEvent> stateDefinitions)
    {
        NullGuard.AgainstNullArgument("context", context);

        var result = TransitionResult<TState>.NotFired;

        if (stateDefinition.Transitions.TryGetValue(context.EventId.Value, out var transitionsForEvent))
            foreach (var transitionDefinition in transitionsForEvent)
            {
                result = await transitionLogic
                    .Fire(transitionDefinition, context, lastActiveStateModifier, stateDefinitions)
                    .ConfigureAwait(false);
                if (result.Fired) return result;
            }

        if (stateDefinition.SuperState != null)
            result = await Fire(stateDefinition.SuperState, context, lastActiveStateModifier, stateDefinitions)
                .ConfigureAwait(false);

        return result;
    }

    public async Task Entry(
        IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context)
    {
        NullGuard.AgainstNullArgument("context", context);

        context.AddRecord(stateDefinition.Id, RecordType.Enter);

        await extensionHost.ForEach(
            extension =>
                extension.EnteringState(stateDefinition, context));

        await ExecuteEntryActions(stateDefinition, context).ConfigureAwait(false);
    }

    public async Task Exit(
        IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context,
        ILastActiveStateModifier<TState> lastActiveStateModifier)
    {
        NullGuard.AgainstNullArgument("context", context);

        context.AddRecord(stateDefinition.Id, RecordType.Exit);

        await ExecuteExitActions(stateDefinition, context).ConfigureAwait(false);
        SetThisStateAsLastStateOfSuperState(stateDefinition, lastActiveStateModifier);
    }

    public async Task<TState> EnterByHistory(
        IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context,
        ILastActiveStateModifier<TState> lastActiveStateModifier,
        IStateDefinitionDictionary<TState, TEvent> stateDefinitions)
    {
        var result = stateDefinition.Id;

        switch (stateDefinition.HistoryType)
        {
            case HistoryType.None:
                result = await EnterHistoryNone(stateDefinition, context)
                    .ConfigureAwait(false);
                break;

            case HistoryType.Shallow:
                result = await EnterHistoryShallow(stateDefinition, context, lastActiveStateModifier, stateDefinitions)
                    .ConfigureAwait(false);
                break;

            case HistoryType.Deep:
                result = await EnterHistoryDeep(stateDefinition, context, lastActiveStateModifier, stateDefinitions)
                    .ConfigureAwait(false);
                break;
        }

        return result;
    }

    public async Task<TState> EnterShallow(
        IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context)
    {
        await Entry(stateDefinition, context).ConfigureAwait(false);

        var initialState = stateDefinition.InitialState;
        if (initialState == null) return stateDefinition.Id;

        return await EnterShallow(initialState, context).ConfigureAwait(false);
    }

    public async Task<TState> EnterDeep(
        IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context,
        ILastActiveStateModifier<TState> lastActiveStateModifier,
        IStateDefinitionDictionary<TState, TEvent> stateDefinitions)
    {
        await Entry(stateDefinition, context).ConfigureAwait(false);

        var lastActiveStateId = lastActiveStateModifier.GetLastActiveStateFor(stateDefinition.Id);
        if (!lastActiveStateId.HasValue) return stateDefinition.Id;

        var lastActiveState = stateDefinitions[lastActiveStateId.Value];
        return await EnterDeep(lastActiveState, context, lastActiveStateModifier, stateDefinitions)
            .ConfigureAwait(false);
    }

    private static void HandleException(Exception exception, ITransitionContext<TState, TEvent> context)
    {
        context.OnExceptionThrown(exception);
    }

    private async Task ExecuteEntryActions(
        IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context)
    {
        foreach (var actionHolder in stateDefinition.EntryActions)
            await ExecuteEntryAction(stateDefinition, actionHolder, context)
                .ConfigureAwait(false);
    }

    private async Task ExecuteEntryAction(
        IStateDefinition<TState, TEvent> stateDefinition,
        IActionHolder actionHolder,
        ITransitionContext<TState, TEvent> context)
    {
        try
        {
            await actionHolder
                .Execute(context.EventArgument)
                .ConfigureAwait(false);
        }
        catch (Exception exception)
        {
            await HandleEntryActionException(stateDefinition, context, exception)
                .ConfigureAwait(false);
        }
    }

    private async Task HandleEntryActionException(
        IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context,
        Exception exception)
    {
        await extensionHost
            .ForEach(
                extension =>
                    extension.HandlingEntryActionException(stateDefinition, context, ref exception))
            .ConfigureAwait(false);

        HandleException(exception, context);

        await extensionHost
            .ForEach(
                extension =>
                    extension.HandledEntryActionException(stateDefinition, context, exception))
            .ConfigureAwait(false);
    }

    private async Task ExecuteExitActions(
        IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context)
    {
        foreach (var actionHolder in stateDefinition.ExitActions)
            await ExecuteExitAction(stateDefinition, actionHolder, context)
                .ConfigureAwait(false);
    }

    private async Task ExecuteExitAction(
        IStateDefinition<TState, TEvent> stateDefinition,
        IActionHolder actionHolder,
        ITransitionContext<TState, TEvent> context)
    {
        try
        {
            await actionHolder
                .Execute(context.EventArgument)
                .ConfigureAwait(false);
        }
        catch (Exception exception)
        {
            await HandleExitActionException(stateDefinition, context, exception)
                .ConfigureAwait(false);
        }
    }

    private async Task HandleExitActionException(
        IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context,
        Exception exception)
    {
        await extensionHost
            .ForEach(
                extension =>
                    extension.HandlingExitActionException(stateDefinition, context, ref exception))
            .ConfigureAwait(false);

        HandleException(exception, context);

        await extensionHost
            .ForEach(
                extension =>
                    extension.HandledExitActionException(stateDefinition, context, exception))
            .ConfigureAwait(false);
    }

    /// <summary>
    ///     Sets this instance as the last state of this instance's super state.
    /// </summary>
    private void SetThisStateAsLastStateOfSuperState(IStateDefinition<TState, TEvent> stateDefinition,
        ILastActiveStateModifier<TState> lastActiveStateModifier)
    {
        if (stateDefinition.SuperState != null)
            lastActiveStateModifier.SetLastActiveStateFor(stateDefinition.SuperState.Id, stateDefinition.Id);
    }

    private async Task<TState> EnterHistoryDeep(
        IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context,
        ILastActiveStateModifier<TState> lastActiveStateModifier,
        IStateDefinitionDictionary<TState, TEvent> stateDefinitions)
    {
        var lastActiveStateId = lastActiveStateModifier.GetLastActiveStateFor(stateDefinition.Id);
        if (!lastActiveStateId.HasValue) return stateDefinition.Id;

        var lastActiveState = stateDefinitions[lastActiveStateId.Value];
        return await EnterDeep(lastActiveState, context, lastActiveStateModifier, stateDefinitions)
            .ConfigureAwait(false);
    }

    private async Task<TState> EnterHistoryShallow(
        IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context,
        ILastActiveStateModifier<TState> lastActiveStateModifier,
        IStateDefinitionDictionary<TState, TEvent> stateDefinitions)
    {
        var lastActiveStateId = lastActiveStateModifier.GetLastActiveStateFor(stateDefinition.Id);
        if (!lastActiveStateId.HasValue) return stateDefinition.Id;

        var lastActiveState = stateDefinitions[lastActiveStateId.Value];
        return await EnterShallow(lastActiveState, context)
            .ConfigureAwait(false);
    }

    private async Task<TState> EnterHistoryNone(
        IStateDefinition<TState, TEvent> stateDefinition,
        ITransitionContext<TState, TEvent> context)
    {
        if (stateDefinition.InitialState != null)
            return await EnterShallow(stateDefinition.InitialState, context)
                .ConfigureAwait(false);

        return stateDefinition.Id;
    }
}