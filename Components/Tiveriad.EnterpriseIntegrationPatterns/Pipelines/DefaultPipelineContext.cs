#region

using Tiveriad.Commons.Extensions;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.Pipelines;

public class DefaultPipelineContext<TModel> : PipelineContextBase<TModel, DefaultConfiguration>, IPipelineContext<TModel, DefaultConfiguration>
    where TModel : class
{
    public DefaultPipelineContext(TModel model, DefaultConfiguration configuration, CancellationToken cancellationToken) :
        base(model, configuration, cancellationToken)
    {
    }

    public Dictionary<string, object> Properties { get; } = new();

    public object this[string name]
    {
        get => Properties.GetOrDefault(name);
        set => Properties[name] = value;
    }

    public virtual DefaultPipelineContext<TModel> WithProperty(string key, object value)
    {
        Properties[key] = value;
        return this;
    }
}