namespace Tiveriad.Workflows.Core.Exceptions;

public class WorkflowDefinitionLoadException : Exception
{
    public WorkflowDefinitionLoadException(string message)
        : base(message)
    {
    }
}