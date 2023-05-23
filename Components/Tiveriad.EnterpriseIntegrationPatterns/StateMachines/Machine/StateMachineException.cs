//-------------------------------------------------------------------------------

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Machine;

public class StateMachineException : Exception
{
    public StateMachineException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}