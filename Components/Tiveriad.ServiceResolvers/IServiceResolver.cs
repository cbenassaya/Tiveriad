namespace Tiveriad.ServiceResolvers;

public interface IServiceResolver
{
    object GetService(Type type);
    IEnumerable<object?> GetServices(Type type);
}