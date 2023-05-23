//-------------------------------------------------------------------------------

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine.Events;

/// <summary>
///     Event arguments holding context information.
/// </summary>
/// <typeparam name="TState">The type of the state.</typeparam>
/// <typeparam name="TEvent">The type of the event.</typeparam>
public class ContextEventArgs<TState, TEvent>
    : EventArgs
    where TState : IComparable
    where TEvent : IComparable
{
    protected ContextEventArgs(ITransitionContext<TState, TEvent> context)
    {
        Context = context;
    }

    protected ITransitionContext<TState, TEvent> Context { get; }
}