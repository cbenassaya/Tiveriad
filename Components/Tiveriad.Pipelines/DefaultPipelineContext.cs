using System.Dynamic;

namespace Tiveriad.Pipelines;

public class DefaultPipelineContext : PipelineContextBase<DefaultConfiguration>, IPipelineContext<DefaultConfiguration>
{
    public dynamic Properties { get; }

    public DefaultPipelineContext(DefaultConfiguration configuration, CancellationToken cancellationToken) : base(configuration, cancellationToken)
    {
        Properties = new ExpandoObject();
    }
}