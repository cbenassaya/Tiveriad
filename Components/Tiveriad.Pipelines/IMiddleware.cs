namespace Tiveriad.Pipelines;

public interface IMiddleware<TModel, TPipelineContext, TConfiguration>
    where TPipelineContext : class, IPipelineContext<TConfiguration>
    where TConfiguration : class, IPipelineConfiguration
{
    public void Run(TPipelineContext context, TModel model);
}