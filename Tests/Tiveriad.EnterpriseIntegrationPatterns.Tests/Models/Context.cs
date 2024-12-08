#region

using Tiveriad.EnterpriseIntegrationPatterns.Pipelines;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.Tests.Models;

public class Context : PipelineContextBase<Model, Configuration>
{
    public Context(Model model, Configuration configuration, CancellationToken cancellationToken) : base(model, configuration,
        cancellationToken)
    {
    }
}