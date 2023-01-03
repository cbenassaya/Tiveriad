using System;

namespace Tiveriad.Repositories;

public interface IConnectionFactory<TClient> 
{
    TClient GetConnection();
}