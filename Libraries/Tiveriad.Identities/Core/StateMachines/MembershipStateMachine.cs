using Tiveriad.EnterpriseIntegrationPatterns.StateMachines;
using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Builders;
using Tiveriad.Identities.Core.Entities;

namespace Tiveriad.Identities.Core.StateMachines;

public static class MembershipStateMachine
{
    public static PassiveStateMachine<MembershipState, MembershipEvent> GetStateMachine(this MembershipState initialState)
    {
        var stateMachineDefinitionBuilder = new StateMachineDefinitionBuilder<MembershipState, MembershipEvent>();
        stateMachineDefinitionBuilder.WithInitialState(initialState);
        stateMachineDefinitionBuilder.In(MembershipState.Pending).On(MembershipEvent.Validate).Goto(MembershipState.Validated);
        stateMachineDefinitionBuilder.In(MembershipState.Pending).On(MembershipEvent.Cancel).Goto(MembershipState.Canceled);
        var stateMachine = stateMachineDefinitionBuilder.Build().CreatePassiveStateMachine();
        stateMachine.Start();
        return stateMachine;
    }
}