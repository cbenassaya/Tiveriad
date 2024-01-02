#region

using System.Collections.Concurrent;
using Tiveriad.Commons.Guards;
using Tiveriad.Commons.Optionals;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Events;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Exceptions;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Extensions;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Models;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Persistence;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Reports;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines;

public class ActiveStateMachine<TState, TEvent> : IStateMachine<TState, TEvent>
    where TState : IComparable
    where TEvent : IComparable
{
    private readonly TState initialState;
    private readonly StateContainer<TState, TEvent> stateContainer;
    private readonly IStateDefinitionDictionary<TState, TEvent> stateDefinitions;
    private readonly StateMachine<TState, TEvent> stateMachine;
    private CancellationTokenSource stopToken;

    private Task worker;
    private TaskCompletionSource<bool> workerCompletionSource = new(TaskCreationOptions.RunContinuationsAsynchronously);

    public ActiveStateMachine(
        StateMachine<TState, TEvent> stateMachine,
        StateContainer<TState, TEvent> stateContainer,
        IStateDefinitionDictionary<TState, TEvent> stateDefinitions,
        TState initialState)
    {
        this.stateMachine = stateMachine;
        this.stateContainer = stateContainer;
        this.stateDefinitions = stateDefinitions;
        this.initialState = initialState;
    }

    /// <summary>
    ///     Occurs when no transition could be executed.
    /// </summary>
    public event EventHandler<TransitionEventArgs<TState, TEvent>> TransitionDeclined
    {
        add => stateMachine.TransitionDeclined += value;
        remove => stateMachine.TransitionDeclined -= value;
    }

    /// <summary>
    ///     Occurs when an exception was thrown inside a transition of the state machine.
    /// </summary>
    public event EventHandler<TransitionExceptionEventArgs<TState, TEvent>> TransitionExceptionThrown
    {
        add => stateMachine.TransitionExceptionThrown += value;
        remove => stateMachine.TransitionExceptionThrown -= value;
    }

    /// <summary>
    ///     Occurs when a transition begins.
    /// </summary>
    public event EventHandler<TransitionEventArgs<TState, TEvent>> TransitionBegin
    {
        add => stateMachine.TransitionBegin += value;
        remove => stateMachine.TransitionBegin -= value;
    }

    /// <summary>
    ///     Occurs when a transition completed.
    /// </summary>
    public event EventHandler<TransitionCompletedEventArgs<TState, TEvent>> TransitionCompleted
    {
        add => stateMachine.TransitionCompleted += value;
        remove => stateMachine.TransitionCompleted -= value;
    }
    

    /// <summary>
    ///     Gets a value indicating whether this instance is running. The state machine is running if if was started and not
    ///     yet stopped.
    /// </summary>
    /// <value><c>true</c> if this instance is running; otherwise, <c>false</c>.</value>
    public bool IsRunning => worker != null && !worker.IsCompleted;

    /// <summary>
    ///     Fires the specified event.
    /// </summary>
    /// <param name="eventId">The event.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public async Task Fire(TEvent eventId)
    {
        await Fire(eventId, Missing.Value).ConfigureAwait(false);
    }

    /// <summary>
    ///     Fires the specified event.
    /// </summary>
    /// <param name="eventId">The event.</param>
    /// <param name="eventArgument">The event argument.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public async Task Fire(TEvent eventId, object eventArgument)
    {
        stateContainer.Events.Enqueue(new EventInformation<TEvent>(eventId, eventArgument));

        await stateContainer
            .ForEach(extension => extension.EventQueued(eventId, eventArgument))
            .ConfigureAwait(false);

        workerCompletionSource.TrySetResult(true);
    }

    /// <summary>
    ///     Fires the specified priority event. The event will be handled before any already queued event.
    /// </summary>
    /// <param name="eventId">The event.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public async Task FirePriority(TEvent eventId)
    {
        await FirePriority(eventId, Missing.Value).ConfigureAwait(false);
    }

    /// <summary>
    ///     Fires the specified priority event. The event will be handled before any already queued event.
    /// </summary>
    /// <param name="eventId">The event.</param>
    /// <param name="eventArgument">The event argument.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public async Task FirePriority(TEvent eventId, object eventArgument)
    {
        stateContainer.PriorityEvents.Push(new EventInformation<TEvent>(eventId, eventArgument));

        await stateContainer
            .ForEach(extension => extension.EventQueuedWithPriority(eventId, eventArgument))
            .ConfigureAwait(false);

        workerCompletionSource.TrySetResult(true);
    }

    /// <summary>
    ///     Saves the current state and history states to a persisted state. Can be restored using <see cref="Load" />.
    /// </summary>
    /// <param name="stateMachineSaver">Data to be persisted is passed to the saver.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public async Task Save(IAsyncStateMachineSaver<TState, TEvent> stateMachineSaver)
    {
        NullGuard.AgainstNullArgument(nameof(stateMachineSaver), stateMachineSaver);

        await stateMachineSaver.SaveCurrentState(stateContainer.CurrentStateId)
            .ConfigureAwait(false);

        await stateMachineSaver.SaveHistoryStates(stateContainer.LastActiveStates)
            .ConfigureAwait(false);

        await stateMachineSaver.SaveEvents(stateContainer.SaveableEvents)
            .ConfigureAwait(false);

        await stateMachineSaver.SavePriorityEvents(stateContainer.SaveablePriorityEvents)
            .ConfigureAwait(false);
    }

    /// <summary>
    ///     Loads the current state and history states from a persisted state (<see cref="Save" />).
    ///     The loader should return exactly the data that was passed to the saver.
    /// </summary>
    /// <param name="stateMachineLoader">Loader providing persisted data.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public async Task Load(IAsyncStateMachineLoader<TState, TEvent> stateMachineLoader)
    {
        NullGuard.AgainstNullArgument(nameof(stateMachineLoader), stateMachineLoader);

        CheckThatNotAlreadyInitialized();

        var loadedCurrentState = await stateMachineLoader.LoadCurrentState().ConfigureAwait(false);
        var historyStates = await stateMachineLoader.LoadHistoryStates().ConfigureAwait(false);
        var events = await stateMachineLoader.LoadEvents().ConfigureAwait(false);
        var priorityEvents = await stateMachineLoader.LoadPriorityEvents().ConfigureAwait(false);

        SetCurrentState();
        LoadHistoryStates();
        SetEvents();
        NotifyExtensions();

        void SetCurrentState()
        {
            stateContainer.CurrentStateId = loadedCurrentState;
        }

        void SetEvents()
        {
            stateContainer.Events = new ConcurrentQueue<EventInformation<TEvent>>(events);
            stateContainer.PriorityEvents = new ConcurrentStack<EventInformation<TEvent>>(priorityEvents);
        }

        void LoadHistoryStates()
        {
            foreach (var historyState in historyStates)
            {
                var superState = stateDefinitions[historyState.Key];
                var lastActiveState = historyState.Value;

                var lastActiveStateIsNotASubStateOfSuperState = superState
                                                                    .SubStates
                                                                    .Select(x => x.Id)
                                                                    .Contains(lastActiveState)
                                                                == false;
                if (lastActiveStateIsNotASubStateOfSuperState)
                    throw new InvalidOperationException(ExceptionMessages.CannotSetALastActiveStateThatIsNotASubState);

                stateContainer.SetLastActiveStateFor(superState.Id, lastActiveState);
            }
        }

        void NotifyExtensions()
        {
            stateContainer.Extensions.ForEach(
                extension => extension.Loaded(
                    loadedCurrentState,
                    historyStates,
                    events,
                    priorityEvents));
        }
    }

    /// <summary>
    ///     Starts the state machine. Events will be processed.
    ///     If the state machine is not started then the events will be queued until the state machine is started.
    ///     Already queued events are processed.
    /// </summary>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public async Task Start()
    {
        if (IsRunning) return;

        stopToken = new CancellationTokenSource();
        worker = Task.Run(
            () => ProcessEventQueue(stopToken.Token),
            CancellationToken.None);

        await stateContainer
            .ForEach(extension => extension.StartedStateMachine())
            .ConfigureAwait(false);
    }

    /// <summary>
    ///     Stops the state machine. Events will be queued until the state machine is started.
    /// </summary>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    public async Task Stop()
    {
        stopToken.Cancel();
        workerCompletionSource.TrySetCanceled();

        try
        {
            await worker
                .ConfigureAwait(false);
        }
        catch (OperationCanceledException)
        {
            // ignored intentionally
        }

        await stateContainer
            .ForEach(extension => extension.StoppedStateMachine())
            .ConfigureAwait(false);
    }

    /// <summary>
    ///     Adds an extension.
    /// </summary>
    /// <param name="extension">The extension.</param>
    public void AddExtension(IExtension<TState, TEvent> extension)
    {
        var extensionCompose = new InternalExtension<TState, TEvent>(extension, stateContainer);
        stateContainer.Extensions.Add(extensionCompose);
    }

    /// <summary>
    ///     Clears all extensions.
    /// </summary>
    public void ClearExtensions()
    {
        stateContainer.Extensions.Clear();
    }

    /// <summary>
    ///     Creates a state machine report with the specified generator.
    /// </summary>
    /// <param name="reportGenerator">The report generator.</param>
    public void Report(IStateMachineReport<TState, TEvent> reportGenerator)
    {
        reportGenerator.Report(ToString(), stateDefinitions.Values, initialState);
    }

    private async Task ProcessEventQueue(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            await InitializeStateMachineIfInitializationIsPending()
                .ConfigureAwait(false);

            await ProcessPriorityEvents(cancellationToken)
                .ConfigureAwait(false);

            if (cancellationToken.IsCancellationRequested) return;

            await ProcessNormalEvents(cancellationToken)
                .ConfigureAwait(false);

            if (cancellationToken.IsCancellationRequested) return;

            await workerCompletionSource.Task.ConfigureAwait(false);
            workerCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        }
    }
    
    /**
     * Returns the current state of the state machine.
     * @return The current state of the state machine.
     * If the state machine is not started, then null is returned.
     */
    public TState? GetCurrentState()
    {
        var result =  stateContainer.CurrentStateId;
        return result.IsInitialized && IsRunning ? result.ExtractOrThrow()  : default(TState);
    }

    private async Task ProcessNormalEvents(
        CancellationToken cancellationToken)
    {
        while (stateContainer.Events.TryDequeue(out var eventInformation))
        {
            await stateMachine.Fire(
                    eventInformation.EventId,
                    eventInformation.EventArgument,
                    stateContainer,
                    stateDefinitions)
                .ConfigureAwait(false);

            if (cancellationToken.IsCancellationRequested) return;

            await ProcessPriorityEvents(cancellationToken)
                .ConfigureAwait(false);

            if (cancellationToken.IsCancellationRequested) return;
        }
    }

    private async Task ProcessPriorityEvents(
        CancellationToken cancellationToken)
    {
        while (stateContainer.PriorityEvents.TryPop(out var eventInformation))
        {
            await stateMachine.Fire(
                    eventInformation.EventId,
                    eventInformation.EventArgument,
                    stateContainer,
                    stateDefinitions)
                .ConfigureAwait(false);

            if (cancellationToken.IsCancellationRequested) return;
        }
    }

    /// <summary>
    ///     Returns a <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
    /// </summary>
    /// <returns>
    ///     A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
    /// </returns>
    public override string ToString()
    {
        return stateContainer.Name ?? GetType().FullName;
    }

    private void CheckThatNotAlreadyInitialized()
    {
        if (stateContainer.CurrentStateId.IsInitialized)
            throw new InvalidOperationException(ExceptionMessages.StateMachineIsAlreadyInitialized);
    }

    private async Task InitializeStateMachineIfInitializationIsPending()
    {
        if (stateContainer.CurrentStateId.IsInitialized) return;

        await stateMachine
            .EnterInitialState(stateContainer, stateDefinitions, initialState)
            .ConfigureAwait(false);
    }
}