namespace Tiveriad.Connections;

public interface IConnectionFactory<TClient>
{
    TClient GetConnection();
}