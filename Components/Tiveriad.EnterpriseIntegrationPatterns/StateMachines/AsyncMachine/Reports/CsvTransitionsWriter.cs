//-------------------------------------------------------------------------------

#region

using Tiveriad.Commons.Guards;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine.States;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine.Transitions;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine.Reports;

/// <summary>
///     Writes the transitions of a state machine to a stream as csv.
/// </summary>
/// <typeparam name="TState">The type of the state.</typeparam>
/// <typeparam name="TEvent">The type of the event.</typeparam>
public class CsvTransitionsWriter<TState, TEvent>
    where TState : IComparable
    where TEvent : IComparable
{
    private readonly StreamWriter writer;

    /// <summary>
    ///     Initializes a new instance of the <see cref="CsvTransitionsWriter&lt;TState, TEvent&gt;" /> class.
    /// </summary>
    /// <param name="writer">The writer.</param>
    public CsvTransitionsWriter(StreamWriter writer)
    {
        this.writer = writer;
    }

    /// <summary>
    ///     Writes the transitions of the specified states.
    /// </summary>
    /// <param name="states">The states.</param>
    public void Write(IEnumerable<IStateDefinition<TState, TEvent>> states)
    {
        states = states.ToList();

        NullGuard.AgainstNullArgument("states", states);

        WriteTransitionsHeader();

        foreach (var state in states) ReportTransitionsOfState(state);
    }

    private void WriteTransitionsHeader()
    {
        writer.WriteLine("Source;Event;Guard;Target;Actions");
    }

    private void ReportTransitionsOfState(IStateDefinition<TState, TEvent> state)
    {
        foreach (var transition in state.TransitionInfos) ReportTransition(transition);
    }

    private void ReportTransition(TransitionInfo<TState, TEvent> transition)
    {
        var source = transition.Source.ToString();
        var target = transition.Target != null ? transition.Target.Id.ToString() : "internal transition";
        var eventId = transition.EventId.ToString();

        var guard = transition.Guard != null ? transition.Guard.Describe() : string.Empty;
        var actions = string.Join(", ", transition.Actions.Select(action => action.Describe()));

        writer.WriteLine(
            "{0};{1};{2};{3};{4}",
            source,
            eventId,
            guard,
            target,
            actions);
    }
}