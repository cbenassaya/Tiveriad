//-------------------------------------------------------------------------------

#region

using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.ActionHolders;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.Transitions;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine.States;

/// <summary>
///     A state of the state machine.
///     A state can be a sub-state or super-state of another state.
/// </summary>
/// <typeparam name="TState">The type of the state id.</typeparam>
/// <typeparam name="TEvent">The type of the event id.</typeparam>
public class StateDefinition<TState, TEvent> : IStateDefinition<TState, TEvent>
    where TState : IComparable
    where TEvent : IComparable
{
    /// <summary>
    ///     Collection of transitions that start in this state (<see cref="ITransitionDefinition{TState,TEvent}.Source" /> is
    ///     equal to this state).
    /// </summary>
    private readonly TransitionDictionary<TState, TEvent> transitions;

    /// <summary>
    ///     The initial sub-state of this state.
    /// </summary>
    private StateDefinition<TState, TEvent> initialState;

    /// <summary>
    ///     The level of this state within the state hierarchy [1..maxLevel].
    /// </summary>
    private int level;

    /// <summary>
    ///     The super-state of this state. Null for states with <see cref="level" /> equal to 1.
    /// </summary>
    private StateDefinition<TState, TEvent> superState;

    /// <summary>
    ///     Initializes a new instance of the <see cref="StateDefinition{TState,TEvent}" /> class.
    /// </summary>
    /// <param name="id">The unique id of this state.</param>
    public StateDefinition(TState id)
    {
        Id = id;
        level = 1;

        transitions = new TransitionDictionary<TState, TEvent>(this);
    }

    /// <summary>
    ///     Gets the entry actions.
    /// </summary>
    /// <value>The entry actions.</value>
    public IList<IActionHolder> EntryActionsModifiable { get; } = new List<IActionHolder>();

    /// <summary>
    ///     Gets the exit actions.
    /// </summary>
    /// <value>The exit action.</value>
    public IList<IActionHolder> ExitActionsModifiable { get; } = new List<IActionHolder>();

    /// <summary>
    ///     Gets or sets the initial sub state of this state.
    /// </summary>
    /// <value>The initial sub state of this state.</value>
    public StateDefinition<TState, TEvent> InitialStateModifiable
    {
        get => initialState;
        set
        {
            CheckInitialStateIsNotThisInstance(value);
            CheckInitialStateIsASubState(value);

            initialState = value;
        }
    }

    /// <summary>
    ///     Gets or sets the super-state of this state.
    /// </summary>
    /// <remarks>
    ///     The <see cref="Level" /> of this state is changed accordingly to the super-state.
    /// </remarks>
    /// <value>The super-state of this super.</value>
    public StateDefinition<TState, TEvent> SuperStateModifiable
    {
        get => superState;
        set
        {
            CheckSuperStateIsNotThisInstance(value);

            superState = value;

            SetInitialLevel();
        }
    }

    /// <summary>
    ///     Gets or sets the history type of this state.
    /// </summary>
    /// <value>The type of the history.</value>
    public HistoryType HistoryTypeModifiable { get; set; } = HistoryType.None;

    /// <summary>
    ///     Gets the sub-states of this state.
    /// </summary>
    /// <value>The sub-states of this state.</value>
    public ICollection<StateDefinition<TState, TEvent>> SubStatesModifiable { get; } =
        new List<StateDefinition<TState, TEvent>>();

    /// <summary>
    ///     Gets the transitions that start in this state.
    /// </summary>
    /// <value>The transitions.</value>
    public ITransitionDictionary<TState, TEvent> TransitionsModifiable => transitions;

    /// <summary>
    ///     Gets the unique id of this state.
    /// </summary>
    /// <value>The id of this state.</value>
    public TState Id { get; }

    /// <summary>
    ///     Gets or sets the level of this state in the state hierarchy.
    ///     When set then the levels of all sub-states are changed accordingly.
    /// </summary>
    /// <value>The level.</value>
    public int Level
    {
        get => level;
        set
        {
            level = value;

            SetLevelOfSubStates();
        }
    }

    public IReadOnlyDictionary<TEvent, IEnumerable<ITransitionDefinition<TState, TEvent>>> Transitions =>
        transitions.Transitions;

    public IEnumerable<TransitionInfo<TState, TEvent>> TransitionInfos => transitions.GetTransitions();

    public IStateDefinition<TState, TEvent> InitialState => InitialStateModifiable;

    public HistoryType HistoryType => HistoryTypeModifiable;

    public IStateDefinition<TState, TEvent> SuperState => SuperStateModifiable;

    public IEnumerable<IStateDefinition<TState, TEvent>> SubStates => SubStatesModifiable;

    public IEnumerable<IActionHolder> EntryActions => EntryActionsModifiable;

    public IEnumerable<IActionHolder> ExitActions => ExitActionsModifiable;

    public override string ToString()
    {
        return Id.ToString();
    }

    /// <summary>
    ///     Sets the initial level depending on the level of the super state of this instance.
    /// </summary>
    private void SetInitialLevel()
    {
        Level = superState != null ? superState.Level + 1 : 1;
    }

    /// <summary>
    ///     Sets the level of all sub states.
    /// </summary>
    private void SetLevelOfSubStates()
    {
        foreach (var state in SubStatesModifiable) state.Level = level + 1;
    }

    /// <summary>
    ///     Throws an exception if the new super state is this instance.
    /// </summary>
    /// <param name="newSuperState">The value.</param>
    // ReSharper disable once UnusedParameter.Local
    private void CheckSuperStateIsNotThisInstance(StateDefinition<TState, TEvent> newSuperState)
    {
        if (this == newSuperState)
            throw new ArgumentException(StatesExceptionMessages.StateCannotBeItsOwnSuperState(ToString()));
    }

    /// <summary>
    ///     Throws an exception if the new initial state is this instance.
    /// </summary>
    /// <param name="newInitialState">The value.</param>
    // ReSharper disable once UnusedParameter.Local
    private void CheckInitialStateIsNotThisInstance(StateDefinition<TState, TEvent> newInitialState)
    {
        if (this == newInitialState)
            throw new ArgumentException(StatesExceptionMessages.StateCannotBeTheInitialSubStateToItself(ToString()));
    }

    /// <summary>
    ///     Throws an exception if the new initial state is not a sub-state of this instance.
    /// </summary>
    /// <param name="value">The value.</param>
    private void CheckInitialStateIsASubState(StateDefinition<TState, TEvent> value)
    {
        if (value.SuperState != this)
            throw new ArgumentException(
                StatesExceptionMessages.StateCannotBeTheInitialStateOfSuperStateBecauseItIsNotADirectSubState(
                    value.ToString(), ToString()));
    }
}