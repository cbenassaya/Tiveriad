using Tiveriad.EnterpriseIntegrationPatterns.StateMachines;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Builders;
using Tiveriad.Identities.Core.Entities;

namespace Tiveriad.Identities.Core.StateMachines;

public static class OrganizationStateMachine
{
    public static PassiveStateMachine<OrganizationState, OrganizationEvent> GetStateMachine(this OrganizationState? initialState)
    {
        
        var stateMachineDefinitionBuilder = new StateMachineDefinitionBuilder<OrganizationState, OrganizationEvent>();
        stateMachineDefinitionBuilder.WithInitialState(initialState ?? OrganizationState.Pending);
        stateMachineDefinitionBuilder.In(OrganizationState.Pending).On(OrganizationEvent.Validate).Goto(OrganizationState.Validated);
        stateMachineDefinitionBuilder.In(OrganizationState.Pending).On(OrganizationEvent.Cancel).Goto(OrganizationState.Canceled);
        var stateMachine = stateMachineDefinitionBuilder.Build().CreatePassiveStateMachine();
        stateMachine.Start();
        return stateMachine;
    }
}