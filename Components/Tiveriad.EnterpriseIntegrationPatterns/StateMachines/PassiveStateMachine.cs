//-------------------------------------------------------------------------------

#region

using Tiveriad.Commons.Guards;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Extensions;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.Events;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Persistence;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines;

/// <summary>
///     A passive state machine.
///     This state machine reacts to events on the current thread.
/// </summary>
/// <typeparam name="TState">The type of the state.</typeparam>
/// <typeparam name="TEvent">The type of the event.</typeparam>
public class PassiveStateMachine<TState, TEvent> :
    IStateMachine<TState, TEvent>
    where TState : IComparable
    where TEvent : IComparable
{
    private readonly TState _initialState;

    private readonly StateContainer<TState, TEvent> _stateContainer;

    private readonly IStateDefinitionDictionary<TState, TEvent> _stateDefinitions;

    /// <summary>
    ///     The internal state machine.
    /// </summary>
    private readonly StateMachine<TState, TEvent> _stateMachine;

    /// <summary>
    ///     Whether this state machine is executing an event. Allows that events can be added while executing.
    /// </summary>
    private bool _executing;

    public PassiveStateMachine(
        StateMachine<TState, TEvent> stateMachine,
        StateContainer<TState, TEvent> stateContainer,
        IStateDefinitionDictionary<TState, TEvent> stateDefinitions,
        TState initialState)
    {
        _stateMachine = stateMachine;
        _stateContainer = stateContainer;
        _stateDefinitions = stateDefinitions;
        _initialState = initialState;
    }

    /// <summary>
    ///     Occurs when no transition could be executed.
    /// </summary>
    public event EventHandler<TransitionEventArgs<TState, TEvent>> TransitionDeclined
    {
        add => _stateMachine.TransitionDeclined += value;
        remove => _stateMachine.TransitionDeclined -= value;
    }

    /// <summary>
    ///     Occurs when an exception was thrown inside a transition of the state machine.
    /// </summary>
    public event EventHandler<TransitionExceptionEventArgs<TState, TEvent>> TransitionExceptionThrown
    {
        add => _stateMachine.TransitionExceptionThrown += value;
        remove => _stateMachine.TransitionExceptionThrown -= value;
    }

    /// <summary>
    ///     Occurs when a transition begins.
    /// </summary>
    public event EventHandler<TransitionEventArgs<TState, TEvent>> TransitionBegin
    {
        add => _stateMachine.TransitionBegin += value;
        remove => _stateMachine.TransitionBegin -= value;
    }

    /// <summary>
    ///     Occurs when a transition completed.
    /// </summary>
    public event EventHandler<TransitionCompletedEventArgs<TState, TEvent>> TransitionCompleted
    {
        add => _stateMachine.TransitionCompleted += value;
        remove => _stateMachine.TransitionCompleted -= value;
    }

    /// <summary>
    ///     Gets a value indicating whether this instance is running. The state machine is running if if was started and not
    ///     yet stopped.
    /// </summary>
    /// <value><c>true</c> if this instance is running; otherwise, <c>false</c>.</value>
    public bool IsRunning { get; private set; }

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
        _stateContainer.Events.AddLast(new EventInformation<TEvent>(eventId, eventArgument));

        _stateContainer.ForEach(extension => extension.EventQueued(eventId, eventArgument));

        Execute();
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
        _stateContainer.Events.AddFirst(new EventInformation<TEvent>(eventId, eventArgument));

        _stateContainer.ForEach(extension => extension.EventQueuedWithPriority(eventId, eventArgument));

        Execute();
    }

    /// <summary>
    ///     Starts the state machine. Events will be processed.
    ///     If the state machine is not started then the events will be queued until the state machine is started.
    ///     Already queued events are processed.
    /// </summary>
    public void Start()
    {
        IsRunning = true;

        _stateContainer.ForEach(extension => extension.StartedStateMachine());

        Execute();
    }

    /// <summary>
    ///     Creates a state machine report with the specified generator.
    /// </summary>
    /// <param name="reportGenerator">The report generator.</param>
    public void Report(IStateMachineReport<TState, TEvent> reportGenerator)
    {
        reportGenerator.Report(ToString(), _stateDefinitions.Values, _initialState);
    }

    /// <summary>
    ///     Stops the state machine. Events will be queued until the state machine is started.
    /// </summary>
    public void Stop()
    {
        IsRunning = false;

        _stateContainer.ForEach(extension => extension.StoppedStateMachine());
    }

    /// <summary>
    ///     Adds an extension.
    /// </summary>
    /// <param name="extension">The extension.</param>
    public void AddExtension(IExtension<TState, TEvent> extension)
    {
        var extensionCompose = new InternalExtension<TState, TEvent>(extension, _stateContainer);
        _stateContainer.Extensions.Add(extensionCompose);
    }

    /// <summary>
    ///     Clears all extensions.
    /// </summary>
    public void ClearExtensions()
    {
        _stateContainer.Extensions.Clear();
    }

    /// <summary>
    ///     Saves the current state and history states to a persisted state. Can be restored using <see cref="Load" />.
    /// </summary>
    /// <param name="stateMachineSaver">Data to be persisted is passed to the saver.</param>
    public void Save(IStateMachineSaver<TState, TEvent> stateMachineSaver)
    {
        NullGuard.AgainstNullArgument(nameof(stateMachineSaver), stateMachineSaver);

        stateMachineSaver.SaveCurrentState(_stateContainer.CurrentStateId);

        stateMachineSaver.SaveHistoryStates(_stateContainer.LastActiveStates);

        stateMachineSaver.SaveEvents(_stateContainer.SaveableEvents);
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
            _stateContainer.CurrentStateId = loadedCurrentState;
        }

        void SetEvents()
        {
            _stateContainer.Events = new LinkedList<EventInformation<TEvent>>(events);
        }

        void SetHistoryStates()
        {
            foreach (var historyState in historyStates)
            {
                var superState = _stateDefinitions[historyState.Key];
                var lastActiveState = historyState.Value;

                var lastActiveStateIsNotASubStateOfSuperState = superState
                                                                    .SubStates
                                                                    .Select(x => x.Id)
                                                                    .Contains(lastActiveState)
                                                                == false;
                if (lastActiveStateIsNotASubStateOfSuperState)
                    throw new InvalidOperationException(ExceptionMessages.CannotSetALastActiveStateThatIsNotASubState);

                _stateContainer.SetLastActiveStateFor(superState.Id, lastActiveState);
            }
        }

        void NotifyExtensions()
        {
            _stateContainer.Extensions.ForEach(
                extension => extension.Loaded(
                    loadedCurrentState,
                    historyStates,
                    events));
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
        return _stateContainer.Name ?? GetType().FullName;
    }

    private void CheckThatNotAlreadyInitialized()
    {
        if (_stateContainer.CurrentStateId.IsInitialized)
            throw new InvalidOperationException(ExceptionMessages.StateMachineIsAlreadyInitialized);
    }

    /// <summary>
    ///     Executes all queued events.
    /// </summary>
    private void Execute()
    {
        if (_executing || !IsRunning) return;

        _executing = true;
        try
        {
            ProcessQueuedEvents();
        }
        finally
        {
            _executing = false;
        }
    }

    /// <summary>
    ///     Processes the queued events.
    /// </summary>
    private void ProcessQueuedEvents()
    {
        InitializeStateMachineIfInitializationIsPending();

        while (_stateContainer.Events.Count > 0)
        {
            var eventToProcess = GetNextEventToProcess();
            FireEventOnStateMachine(eventToProcess);
        }
    }

    private void InitializeStateMachineIfInitializationIsPending()
    {
        if (_stateContainer.CurrentStateId.IsInitialized) return;

        _stateMachine.EnterInitialState(_stateContainer, _stateDefinitions, _initialState);
    }

    /// <summary>
    ///     Gets the next event to process for the queue.
    /// </summary>
    /// <returns>The next queued event.</returns>
    private EventInformation<TEvent> GetNextEventToProcess()
    {
        var e = _stateContainer.Events.First.Value;
        _stateContainer.Events.RemoveFirst();
        return e;
    }

    /// <summary>
    ///     Fires the event on state machine.
    /// </summary>
    /// <param name="e">The event to fire.</param>
    private void FireEventOnStateMachine(EventInformation<TEvent> e)
    {
        _stateMachine.Fire(e.EventId, e.EventArgument, _stateContainer, _stateDefinitions);
    }
}