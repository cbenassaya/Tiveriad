namespace Tiveriad.Workflows.Core.Services;

public interface IServiceResolver
{
    object GetService(Type type);
    IEnumerable<object?> GetServices(Type type);

    T GetService<T>();
}