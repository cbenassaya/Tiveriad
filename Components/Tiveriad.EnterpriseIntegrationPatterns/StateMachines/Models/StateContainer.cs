//-------------------------------------------------------------------------------

#region

using System.Collections.Concurrent;
using Tiveriad.Commons.Optionals;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Events;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Extensions;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Models;

public class StateContainer<TState, TEvent> :
    IExtensionHost<TState, TEvent>,
    IStateMachineInformation<TState, TEvent>,
    ILastActiveStateModifier<TState>
    where TState : IComparable
    where TEvent : IComparable
{
    private readonly Dictionary<TState, TState> lastActiveStates = new();

    public StateContainer()
        : this(default)
    {
    }

    public StateContainer(string name)
    {
        Name = name;
        CurrentStateId = Initializable<TState>.UnInitialized();
    }

    public List<IExtensionInternal<TState, TEvent>> Extensions { get; } = new();

    public IReadOnlyDictionary<TState, TState> LastActiveStates => lastActiveStates;

    public ConcurrentQueue<EventInformation<TEvent>> Events { get; set; } = new();

    public IReadOnlyCollection<EventInformation<TEvent>> SaveableEvents => new List<EventInformation<TEvent>>(Events);

    public ConcurrentStack<EventInformation<TEvent>> PriorityEvents { get; set; } = new();

    public IReadOnlyCollection<EventInformation<TEvent>> SaveablePriorityEvents =>
        new List<EventInformation<TEvent>>(PriorityEvents);

    public async Task ForEach(Func<IExtensionInternal<TState, TEvent>, Task> action)
    {
        foreach (var extension in Extensions)
            await action(extension)
                .ConfigureAwait(false);
    }

    public Optional<TState> GetLastActiveStateFor(TState state)
    {
        return
            lastActiveStates.TryGetValue(state, out var lastActiveState)
                ? Optional<TState>.Just(lastActiveState)
                : Optional<TState>.Nothing();
    }

    public void SetLastActiveStateFor(TState state, TState newLastActiveState)
    {
        if (lastActiveStates.ContainsKey(state))
            lastActiveStates[state] = newLastActiveState;
        else
            lastActiveStates.Add(state, newLastActiveState);
    }

    public string Name { get; }

    public IInitializable<TState> CurrentStateId { get; set; }
}