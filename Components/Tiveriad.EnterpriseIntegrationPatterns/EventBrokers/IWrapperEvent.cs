namespace Tiveriad.EnterpriseIntegrationPatterns.EventBrokers;

public interface IWrapperEvent
{
    EventStateWrapper State { get; }
    object Event { get; }
    void Commit();
    void Canceled();
}