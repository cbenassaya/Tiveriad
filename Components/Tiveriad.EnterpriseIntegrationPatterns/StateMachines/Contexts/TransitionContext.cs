//-------------------------------------------------------------------------------

#region

using System.Diagnostics;
using System.Text;
using Tiveriad.Commons.Optionals;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Models;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Contexts;

/// <summary>
///     Provides context information during a transition.
/// </summary>
/// <typeparam name="TState">The type of the state.</typeparam>
/// <typeparam name="TEvent">The type of the event.</typeparam>
[DebuggerDisplay("State = {StateDefinition} Event = {EventId} EventArgument = {EventArgument}")]
public class TransitionContext<TState, TEvent> : ITransitionContext<TState, TEvent>
    where TState : IComparable
    where TEvent : IComparable
{
    private readonly List<Record> records;

    public TransitionContext(IStateDefinition<TState, TEvent> stateDefinition, Missable<TEvent> eventId,
        object eventArgument, INotifier<TState, TEvent> notifier)
    {
        StateDefinition = stateDefinition;
        EventId = eventId;
        EventArgument = eventArgument;
        Notifier = notifier;

        records = new List<Record>();
    }

    private INotifier<TState, TEvent> Notifier { get; }

    public IStateDefinition<TState, TEvent> StateDefinition { get; }

    public Missable<TEvent> EventId { get; }

    public object EventArgument { get; }

    public void OnExceptionThrown(Exception exception)
    {
        Notifier.OnExceptionThrown(this, exception);
    }

    public void OnTransitionBegin()
    {
        Notifier.OnTransitionBegin(this);
    }

    public void AddRecord(TState stateId, RecordType recordType)
    {
        records.Add(new Record(stateId, recordType));
    }

    public string GetRecords()
    {
        var result = new StringBuilder();

        records.ForEach(record => result.AppendFormat(" -> {0}", record));

        return result.ToString();
    }

    private class Record
    {
        public Record(TState stateId, RecordType recordType)
        {
            StateId = stateId;
            RecordType = recordType;
        }

        private TState StateId { get; }

        private RecordType RecordType { get; }

        public override string ToString()
        {
            return RecordType + " " + StateId;
        }
    }
}