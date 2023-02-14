namespace Tiveriad.Connections;

public interface IConnectionFactoryBuilder<out TConnectionConfigurator, out TConnectionConfiguration,TClient>
    where TConnectionConfigurator:class,IConnectionConfigurator
    where TConnectionConfiguration:IConnectionConfiguration
{
    public IConnectionFactoryBuilder<TConnectionConfigurator,TConnectionConfiguration,TClient> Configure(Action<TConnectionConfigurator> action);

    public TConnectionConfiguration Configuration { get; }
    public IConnectionFactory<TClient> Build();
}