namespace Tiveriad.Pipelines;

public interface IServiceResolver
{
    object Resolve(Type type);
}