using System;

namespace Tiveriad.Repositories;

public interface IConnectionFactoryBuilder<out TConnectionConfigurator,TClient> where TConnectionConfigurator:class,IConnectionConfigurator
{
    public IConnectionFactoryBuilder<TConnectionConfigurator,TClient> Configure(Action<TConnectionConfigurator> action);

    public IConnectionFactory<TClient> Build();
}