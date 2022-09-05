using System;

namespace Tiveriad.Repositories;

public interface IConnectionFactory<T> where T : IConnectionConfigurator
{
    IConnectionFactory<T> Configure(Action<T> configurator);
    void Build();
}