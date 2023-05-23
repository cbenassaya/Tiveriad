namespace Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;

public class EventWrapper<TEvent, TKey> : IWrapperEvent
    where TEvent : IDomainEvent<TKey>
    where TKey : IEquatable<TKey>
{
    private readonly TEvent _event;
    private readonly TKey _id;

    public EventWrapper(TEvent @event)
    {
        _event = @event;
        _id = @event.Id;
        State = EventStateWrapper.Pending;
    }

    public object Event => _event;

    public EventStateWrapper State { get; private set; }

    public void Commit()
    {
        State = EventStateWrapper.Commit;
    }

    public void Canceled()
    {
        State = EventStateWrapper.Canceled;
    }

    protected bool Equals(EventWrapper<TEvent, TKey> other)
    {
        return EqualityComparer<TKey>.Default.Equals(_id, other._id);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((EventWrapper<TEvent, TKey>)obj);
    }

    public override int GetHashCode()
    {
        return EqualityComparer<TKey>.Default.GetHashCode(_id);
    }

    public static bool operator ==(EventWrapper<TEvent, TKey>? left, EventWrapper<TEvent, TKey>? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(EventWrapper<TEvent, TKey>? left, EventWrapper<TEvent, TKey>? right)
    {
        return !Equals(left, right);
    }
}