//-------------------------------------------------------------------------------

//-------------------------------------------------------------------------------

using Tiveriad.Commons.Guards;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.ActionHolders;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.Transitions;

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.States
{
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
        /// Goes recursively up the state hierarchy until a state is found that can handle the event.
        /// </summary>
        /// <param name="stateDefinition">The state definition of the state in which the event should be fired.</param>
        /// <param name="context">The event context.</param>
        /// <param name="lastActiveStateModifier">The last active state modifier.</param>
        /// <param name="stateDefinitions">The definitions for all states of this state Machine.</param>
        /// <returns>The result of the transition.</returns>
        public ITransitionResult<TState> Fire(
            IStateDefinition<TState, TEvent> stateDefinition,
            ITransitionContext<TState, TEvent> context,
            ILastActiveStateModifier<TState> lastActiveStateModifier,
            IStateDefinitionDictionary<TState, TEvent> stateDefinitions)
        {
            NullGuard.AgainstNullArgument("context", context);

            var result = TransitionResult<TState>.NotFired;

            if (stateDefinition.Transitions.TryGetValue(context.EventId.Value, out var transitionsForEvent))
            {
                foreach (var transitionDefinition in transitionsForEvent)
                {
                    result = this.transitionLogic.Fire(transitionDefinition, context, lastActiveStateModifier, stateDefinitions);
                    if (result.Fired)
                    {
                        return result;
                    }
                }
            }

            if (stateDefinition.SuperState != null)
            {
                result = this.Fire(stateDefinition.SuperState, context, lastActiveStateModifier, stateDefinitions);
            }

            return result;
        }

        public void Entry(
            IStateDefinition<TState, TEvent> stateDefinition,
            ITransitionContext<TState, TEvent> context)
        {
            NullGuard.AgainstNullArgument("context", context);

            context.AddRecord(stateDefinition.Id, RecordType.Enter);

            this.extensionHost.ForEach(
                extension =>
                    extension.EnteringState(stateDefinition, context));

            this.ExecuteEntryActions(stateDefinition, context);
        }

        public void Exit(
            IStateDefinition<TState, TEvent> stateDefinition,
            ITransitionContext<TState, TEvent> context,
            ILastActiveStateModifier<TState> lastActiveStateModifier)
        {
            NullGuard.AgainstNullArgument("context", context);

            context.AddRecord(stateDefinition.Id, RecordType.Exit);

            this.ExecuteExitActions(stateDefinition, context);
            SetThisStateAsLastStateOfSuperState(stateDefinition, lastActiveStateModifier);
        }

        public TState EnterByHistory(
            IStateDefinition<TState, TEvent> stateDefinition,
            ITransitionContext<TState, TEvent> context,
            ILastActiveStateModifier<TState> lastActiveStateModifier,
            IStateDefinitionDictionary<TState, TEvent> stateDefinitions)
        {
            var result = stateDefinition.Id;

            switch (stateDefinition.HistoryType)
            {
                case HistoryType.None:
                    result = this.EnterHistoryNone(stateDefinition, context);
                    break;

                case HistoryType.Shallow:
                    result = this.EnterHistoryShallow(stateDefinition, context, lastActiveStateModifier, stateDefinitions);
                    break;

                case HistoryType.Deep:
                    result = this.EnterHistoryDeep(stateDefinition, context, lastActiveStateModifier, stateDefinitions);
                    break;
            }

            return result;
        }

        public TState EnterShallow(
            IStateDefinition<TState, TEvent> stateDefinition,
            ITransitionContext<TState, TEvent> context)
        {
            this.Entry(stateDefinition, context);

            var initialState = stateDefinition.InitialState;
            if (initialState == null)
            {
                return stateDefinition.Id;
            }

            return this.EnterShallow(initialState, context);
        }

        private TState EnterDeep(
            IStateDefinition<TState, TEvent> stateDefinition,
            ITransitionContext<TState, TEvent> context,
            ILastActiveStateModifier<TState> lastActiveStateModifier,
            IStateDefinitionDictionary<TState, TEvent> stateDefinitions)
        {
            this.Entry(stateDefinition, context);

            var lastActiveStateId = lastActiveStateModifier.GetLastActiveStateFor(stateDefinition.Id);
            if (!lastActiveStateId.HasValue)
            {
                return stateDefinition.Id;
            }

            var lastActiveState = stateDefinitions[lastActiveStateId.Value];
            return this.EnterDeep(lastActiveState, context, lastActiveStateModifier, stateDefinitions);
        }

        private static void HandleException(Exception exception, ITransitionContext<TState, TEvent> context)
        {
            context.OnExceptionThrown(exception);
        }

        private void ExecuteEntryActions(
            IStateDefinition<TState, TEvent> stateDefinition,
            ITransitionContext<TState, TEvent> context)
        {
            foreach (var actionHolder in stateDefinition.EntryActions)
            {
                this.ExecuteEntryAction(stateDefinition, actionHolder, context);
            }
        }

        private void ExecuteEntryAction(
            IStateDefinition<TState, TEvent> stateDefinition,
            IActionHolder actionHolder,
            ITransitionContext<TState, TEvent> context)
        {
            try
            {
                actionHolder.Execute(context.EventArgument);
            }
            catch (Exception exception)
            {
                this.HandleEntryActionException(stateDefinition, context, exception);
            }
        }

        private void HandleEntryActionException(
            IStateDefinition<TState, TEvent> stateDefinition,
            ITransitionContext<TState, TEvent> context,
            Exception exception)
        {
            this.extensionHost.ForEach(
                extension =>
                extension.HandlingEntryActionException(stateDefinition, context, ref exception));

            HandleException(exception, context);

            this.extensionHost.ForEach(
                extension =>
                extension.HandledEntryActionException(stateDefinition, context, exception));
        }

        private void ExecuteExitActions(
            IStateDefinition<TState, TEvent> stateDefinition,
            ITransitionContext<TState, TEvent> context)
        {
            foreach (var actionHolder in stateDefinition.ExitActions)
            {
                this.ExecuteExitAction(stateDefinition, actionHolder, context);
            }
        }

        private void ExecuteExitAction(
            IStateDefinition<TState, TEvent> stateDefinition,
            IActionHolder actionHolder,
            ITransitionContext<TState, TEvent> context)
        {
            try
            {
                actionHolder.Execute(context.EventArgument);
            }
            catch (Exception exception)
            {
                this.HandleExitActionException(stateDefinition, context, exception);
            }
        }

        private void HandleExitActionException(
            IStateDefinition<TState, TEvent> stateDefinition,
            ITransitionContext<TState, TEvent> context,
            Exception exception)
        {
            this.extensionHost.ForEach(
                extension =>
                extension.HandlingExitActionException(stateDefinition, context, ref exception));

            HandleException(exception, context);

            this.extensionHost.ForEach(
                extension =>
                extension.HandledExitActionException(stateDefinition, context, exception));
        }

        /// <summary>
        /// Sets this instance as the last state of this instance's super state.
        /// </summary>
        private static void SetThisStateAsLastStateOfSuperState(IStateDefinition<TState, TEvent> stateDefinition, ILastActiveStateModifier<TState> lastActiveStateModifier)
        {
            if (stateDefinition.SuperState != null)
            {
                lastActiveStateModifier.SetLastActiveStateFor(stateDefinition.SuperState.Id, stateDefinition.Id);
            }
        }

        private TState EnterHistoryDeep(
            IStateDefinition<TState, TEvent> stateDefinition,
            ITransitionContext<TState, TEvent> context,
            ILastActiveStateModifier<TState> lastActiveStateModifier,
            IStateDefinitionDictionary<TState, TEvent> stateDefinitions)
        {
            var lastActiveStateId = lastActiveStateModifier.GetLastActiveStateFor(stateDefinition.Id);
            if (!lastActiveStateId.HasValue)
            {
                return stateDefinition.Id;
            }

            var lastActiveState = stateDefinitions[lastActiveStateId.Value];
            return this.EnterDeep(lastActiveState, context, lastActiveStateModifier, stateDefinitions);
        }

        private TState EnterHistoryShallow(
            IStateDefinition<TState, TEvent> stateDefinition,
            ITransitionContext<TState, TEvent> context,
            ILastActiveStateModifier<TState> lastActiveStateModifier,
            IStateDefinitionDictionary<TState, TEvent> stateDefinitions)
        {
            var lastActiveStateId = lastActiveStateModifier.GetLastActiveStateFor(stateDefinition.Id);
            if (!lastActiveStateId.HasValue)
            {
                return stateDefinition.Id;
            }

            var lastActiveState = stateDefinitions[lastActiveStateId.Value];
            return this.EnterShallow(lastActiveState, context);
        }

        private TState EnterHistoryNone(
            IStateDefinition<TState, TEvent> stateDefinition,
            ITransitionContext<TState, TEvent> context)
        {
            if (stateDefinition.InitialState != null)
            {
                return this.EnterShallow(stateDefinition.InitialState, context);
            }

            return stateDefinition.Id;
        }
    }
}