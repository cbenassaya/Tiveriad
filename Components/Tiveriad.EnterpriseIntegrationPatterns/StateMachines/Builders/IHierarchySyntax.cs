//-------------------------------------------------------------------------------

using Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Models;

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Builders;

public interface IHierarchySyntax<in TState>
{
    IInitialSubStateSyntax<TState> WithHistoryType(HistoryType historyType);
}

public interface IInitialSubStateSyntax<in TState>
{
    ISubStateSyntax<TState> WithInitialSubState(TState stateId);
}

public interface ISubStateSyntax<in TState>
{
    ISubStateSyntax<TState> WithSubState(TState stateId);
}