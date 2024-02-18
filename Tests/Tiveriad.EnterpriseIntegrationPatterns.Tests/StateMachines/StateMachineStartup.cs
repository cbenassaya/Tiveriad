using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Tiveriad.Commons.Optionals;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Builders;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Events;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Extensions;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Models;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Persistence;
using Tiveriad.UnitTests;
using Xunit;

namespace Tiveriad.EnterpriseIntegrationPatterns.Tests.StateMachines;

public class Invoice
{
    public InvoiceState State { get; set; }
}

public enum InvoiceState
{
    Pending,
    Active,
    Cancelled
}

public enum Events
{
    Activate,
    Cancel
} 

public class CurrentStateExtension : ExtensionBase<InvoiceState, Events>
{
    public InvoiceState CurrentState { get; private set; }

    public override Task SwitchedState(IStateMachineInformation<InvoiceState, Events> stateMachine, IStateDefinition<InvoiceState, Events> oldState, IStateDefinition<InvoiceState, Events> newState)
    {
        this.CurrentState = newState.Id;

        return Task.CompletedTask;
    }
}

public class StateMachineStartup : StartupBase
{
    public override void Configure(IServiceCollection services)
    {
        var builder = new StateMachineDefinitionBuilder<InvoiceState, Events>();
     

        builder
            .In(InvoiceState.Pending)
            .On(Events.Activate)
            .Goto(InvoiceState.Active);
        
        builder
            .In(InvoiceState.Pending)
            .On(Events.Cancel)
            .Goto(InvoiceState.Cancelled);

        builder
            .In(InvoiceState.Active)
            .On(Events.Cancel)
            .Goto(InvoiceState.Cancelled);
        

        builder
            .WithInitialState(InvoiceState.Pending);

        services
            .AddScoped<CurrentStateExtension, CurrentStateExtension>();
        services
            .AddScoped<IStateMachine<InvoiceState, Events>>((x) =>
                {
                    var stateMachine = builder.Build().CreatePassiveStateMachine();
                    stateMachine.AddExtension(x.GetRequiredService<CurrentStateExtension>());
                    stateMachine.Start();
                    return stateMachine;
                }
                );
    }
}

public class AsyncStateMachineSaver : IAsyncStateMachineSaver<InvoiceState, Events>
{
    public Task SaveCurrentState(IInitializable<InvoiceState> currentStateId)
    {
        return Task.CompletedTask;
    }

    public Task SaveHistoryStates(IReadOnlyDictionary<InvoiceState, InvoiceState> historyStates)
    {
        return Task.CompletedTask;
    }

    public Task SaveEvents(IReadOnlyCollection<EventInformation<Events>> events)
    {
        return Task.CompletedTask;
    }

    public Task SavePriorityEvents(IReadOnlyCollection<EventInformation<Events>> priorityEvents)
    {
        return Task.CompletedTask;
    }
}

public class StateMachineTestModule : TestBase<StateMachineStartup>
{
    [Fact]
    public async void Activate()
    {
        
        var stateMachine = GetRequiredService<IStateMachine<InvoiceState, Events>>();
        var currentStateExtension = GetRequiredService<CurrentStateExtension>();
        
        
        await stateMachine.Fire(
            Events.Activate);
        currentStateExtension.CurrentState.Should().Be(InvoiceState.Active);
        stateMachine.GetCurrentState().Should().Be(InvoiceState.Active);

    }
    
    [Fact]
    public void ActivateTwice()
    {
        
        var stateMachine = GetRequiredService<IStateMachine<InvoiceState, Events>>();
        stateMachine.Fire(Events.Activate);
        stateMachine.Fire(Events.Activate);

    }

    [Fact]
    public void Cancelled()
    {
        var stateMachine = GetRequiredService<IStateMachine<InvoiceState, Events>>();
        stateMachine.Fire(
                Events.Cancel);
    }
}