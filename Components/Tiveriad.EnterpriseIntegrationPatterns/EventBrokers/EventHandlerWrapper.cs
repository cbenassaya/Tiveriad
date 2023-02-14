namespace Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;


internal class EventHandlerWrapper<TEvent,TKey>:IEventHandler<TEvent,TKey>
    where TEvent:IDomainEvent < TKey> 
    where TKey : IEquatable<TKey>
{
    private readonly IEventHandler<TEvent,TKey> _eventHandler;
    private readonly Func<TEvent, Task> _handler;

    public EventHandlerWrapper(IEventHandler<TEvent,TKey> eventHandler)
    {
        _eventHandler = eventHandler;
        _handler = eventHandler.HandleAsync;
        IsSubscribed = true;
    }

    public EventHandlerWrapper(Func<TEvent, Task> handler, Func<TEvent, Task<bool>> filter = null, Func<Exception, TEvent, Task> onError = null)
    {
        _eventHandler = new DelegateEventHandler<TEvent,TKey>(handler, filter, onError);
        _handler = handler;
        IsSubscribed = true;
    }

    public bool IsSubscribed
    {
        get; set;
    }

    public Task HandleAsync(TEvent @event) => _eventHandler.HandleAsync(@event);

    public Task<bool> ShouldHandleAsync(TEvent @event) => _eventHandler.ShouldHandleAsync(@event);

    public Task OnErrorAsync(Exception exception, TEvent @event) => _eventHandler.OnErrorAsync(exception, @event);

    public bool IsWrapping(IEventHandler<TEvent,TKey> eventHandler) => _eventHandler == eventHandler;

    public bool IsWrapping(Func<TEvent, Task> handler) => _handler == handler;
}