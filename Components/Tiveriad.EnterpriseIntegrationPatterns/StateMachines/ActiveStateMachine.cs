#region

using Tiveriad.Commons.Guards;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Extensions;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.Events;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Persistence;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines;

/// <summary>
///     An active state machine.
///     This state machine reacts to events on its own worker thread and the <see cref="Fire(TEvent,object)" /> or
///     <see cref="FirePriority(TEvent,object)" /> methods return immediately back to the caller.
/// </summary>
/// <typeparam name="TState">The type of the state.</typeparam>
/// <typeparam name="TEvent">The type of the event.</typeparam>
public class ActiveStateMachine<TState, TEvent> :
    IStateMachine<TState, TEvent>
    where TState : IComparable
    where TEvent : IComparable
{
    private readonly TState initialState;
    private readonly StateContainer<TState, TEvent> stateContainer;
    private readonly IStateDefinitionDictionary<TState, TEvent> stateDefinitions;
    private readonly StateMachine<TState, TEvent> stateMachine;
    private CancellationTokenSource stopToken;


    private Task worker;

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
    public void Fire(TEvent eventId)
    {
        Fire(eventId, null);
    }

    /// <summary>
    ///     Fires the specified event.
    /// </summary>
    /// <param name="eventId">The event.</param>
    /// <param name="eventArgument">The event argument.</param>
    public void Fire(TEvent eventId, object eventArgument)
    {
        lock (stateContainer.Events)
        {
            stateContainer.Events.AddLast(new EventInformation<TEvent>(eventId, eventArgument));
            Monitor.Pulse(stateContainer.Events);
        }

        stateContainer.ForEach(extension => extension.EventQueued(eventId, eventArgument));
    }

    /// <summary>
    ///     Fires the specified priority event. The event will be handled before any already queued event.
    /// </summary>
    /// <param name="eventId">The event.</param>
    public void FirePriority(TEvent eventId)
    {
        FirePriority(eventId, null);
    }

    /// <summary>
    ///     Fires the specified priority event. The event will be handled before any already queued event.
    /// </summary>
    /// <param name="eventId">The event.</param>
    /// <param name="eventArgument">The event argument.</param>
    public void FirePriority(TEvent eventId, object eventArgument)
    {
        lock (stateContainer.Events)
        {
            stateContainer.Events.AddFirst(new EventInformation<TEvent>(eventId, eventArgument));
            Monitor.Pulse(stateContainer.Events);
        }

        stateContainer.ForEach(extension => extension.EventQueuedWithPriority(eventId, eventArgument));
    }

    /// <summary>
    ///     Saves the current state and history states to a persisted state. Can be restored using <see cref="Load" />.
    /// </summary>
    /// <param name="stateMachineSaver">Data to be persisted is passed to the saver.</param>
    public void Save(IStateMachineSaver<TState, TEvent> stateMachineSaver)
    {
        NullGuard.AgainstNullArgument(nameof(stateMachineSaver), stateMachineSaver);

        stateMachineSaver.SaveCurrentState(stateContainer.CurrentStateId);
        stateMachineSaver.SaveHistoryStates(stateContainer.LastActiveStates);
        stateMachineSaver.SaveEvents(stateContainer.SaveableEvents);
    }

    /// <summary>
    ///     Loads the current state and history states from a persisted state (<see cref="Save" />).
    ///     The loader should return exactly the data that was passed to the saver.
    /// </summary>
    /// <param name="stateMachineLoader">Loader providing persisted data.</param>
    public void Load(IStateMachineLoader<TState, TEvent> stateMachineLoader)
    {
        NullGuard.AgainstNullArgument(nameof(stateMachineLoader), stateMachineLoader);

        CheckThatNotAlreadyInitialized();

        var loadedCurrentState = stateMachineLoader.LoadCurrentState();
        var historyStates = stateMachineLoader.LoadHistoryStates();
        var events = stateMachineLoader.LoadEvents();

        SetCurrentState();
        SetHistoryStates();
        SetEvents();
        NotifyExtensions();

        void SetCurrentState()
        {
            stateContainer.CurrentStateId = loadedCurrentState;
        }

        void SetEvents()
        {
            stateContainer.Events = new LinkedList<EventInformation<TEvent>>(events);
        }

        void SetHistoryStates()
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
                    events));
        }
    }

    /// <summary>
    ///     Starts the state machine. Events will be processed.
    ///     If the state machine is not started then the events will be queued until the state machine is started.
    ///     Already queued events are processed.
    /// </summary>
    public void Start()
    {
        if (IsRunning) return;

        stopToken = new CancellationTokenSource();
        worker = Task.Factory.StartNew(
            () => ProcessEventQueue(stopToken.Token),
            stopToken.Token,
            TaskCreationOptions.LongRunning,
            TaskScheduler.Default);

        stateContainer.ForEach(extension => extension.StartedStateMachine());
    }

    /// <summary>
    ///     Stops the state machine. Events will be queued until the state machine is started.
    /// </summary>
    public void Stop()
    {
        if (!IsRunning || stopToken.IsCancellationRequested) return;

        lock (stateContainer.Events)
        {
            stopToken.Cancel();
            Monitor.Pulse(stateContainer.Events); // wake up task to get a chance to stop
        }

        try
        {
            worker.Wait();
        }
        catch (AggregateException)
        {
            // in case the task was stopped before it could actually start, it will be canceled.
            if (worker.IsFaulted) throw;
        }

        worker = null;

        stateContainer.ForEach(extension => extension.StoppedStateMachine());
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

    private void ProcessEventQueue(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            InitializeStateMachineIfInitializationIsPending();

            EventInformation<TEvent> eventInformation;
            lock (stateContainer.Events)
            {
                if (stateContainer.Events.Count > 0)
                {
                    eventInformation = stateContainer.Events.First.Value;
                    stateContainer.Events.RemoveFirst();
                }
                else
                {
                    // ReSharper disable once ConditionIsAlwaysTrueOrFalse because it is multi-threaded and can change in the mean time
                    if (!cancellationToken.IsCancellationRequested) Monitor.Wait(stateContainer.Events);

                    continue;
                }
            }

            stateMachine.Fire(eventInformation.EventId, eventInformation.EventArgument, stateContainer,
                stateDefinitions);
        }
    }

    private void InitializeStateMachineIfInitializationIsPending()
    {
        if (stateContainer.CurrentStateId.IsInitialized) return;

        stateMachine.EnterInitialState(stateContainer, stateDefinitions, initialState);
    }

    private void CheckThatNotAlreadyInitialized()
    {
        if (stateContainer.CurrentStateId.IsInitialized)
            throw new InvalidOperationException(ExceptionMessages.StateMachineIsAlreadyInitialized);
    }
}