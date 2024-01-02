//-------------------------------------------------------------------------------

namespace Tiveriad.EnterpriseIntegrationPatterns.StateMachines.Exceptions;

public class StateMachineException : Exception
{
    public StateMachineException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}