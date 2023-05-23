//-------------------------------------------------------------------------------

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.AsyncMachine;

public class StateMachineException : Exception
{
    public StateMachineException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}