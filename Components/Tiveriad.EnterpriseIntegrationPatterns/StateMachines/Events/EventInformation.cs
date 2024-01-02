//-------------------------------------------------------------------------------

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Events;

/// <summary>
///     Container holding an event and its argument.
/// </summary>
/// <typeparam name="TEvent">The type of the event.</typeparam>
public class EventInformation<TEvent>
    where TEvent : IComparable
{
    public EventInformation(TEvent eventId, object eventArgument)
    {
        EventId = eventId;
        EventArgument = eventArgument;
    }

    public TEvent EventId { get; }

    public object EventArgument { get; }
}