#region

using System.Collections.ObjectModel;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;

public class DomainEventStore : IDomainEventStore
{
    private readonly IList<IWrapperEvent> _list = new List<IWrapperEvent>();
    private readonly object _locker = new();

    public void Add<TEvent, TKey>(TEvent @event)
        where TEvent : IDomainEvent<TKey>
        where TKey : IEquatable<TKey>
    {
        lock (_locker)
        {
            _list.Add(new EventWrapper<TEvent, TKey>(@event));
        }
    }

    public void Commit()

    {
        lock (_locker)
        {
            var items = _list.Where(x => x.State == EventStateWrapper.Pending).ToList();
            foreach (var item in items)
                item.Commit();
        }
    }

    public void Rollback()
    {
        lock (_locker)
        {
            var items = _list.Where(x => x.State == EventStateWrapper.Pending).ToList();
            foreach (var item in items)
                item.Canceled();
        }
    }

    public IReadOnlyCollection<object> GetDomainEvents()
    {
        lock (_locker)
        {
            return new ReadOnlyCollection<object>(_list.Where(x => x.State == EventStateWrapper.Commit)
                .Select(x => x.Event).ToList());
        }
    }
}