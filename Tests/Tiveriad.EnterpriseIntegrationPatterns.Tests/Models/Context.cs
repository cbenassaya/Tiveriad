using Tiveriad.EnterpriseIntegrationPatterns.Pipelines;

namespace Tiveriad.EnterpriseIntegrationPatterns.Tests.Models;

public class Context : PipelineContextBase<Configuration>
{
    public Context(Configuration configuration, CancellationToken cancellationToken) : base(configuration,
        cancellationToken)
    {
    }
}