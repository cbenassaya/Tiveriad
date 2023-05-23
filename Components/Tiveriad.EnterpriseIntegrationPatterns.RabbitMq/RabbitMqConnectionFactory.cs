#region

using RabbitMQ.Client;
using Tiveriad.Commons.RetryLogic;
using Tiveriad.Connections;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.RabbitMq;

public class RabbitMqConnectionFactory : IConnectionFactory<IConnection>
{
    private readonly IConnectionFactory _connectionFactory;
    private readonly object _syncRoot = new();
    private IConnection _connection;

    public RabbitMqConnectionFactory(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    private bool IsConnected => _connection is { IsOpen: true };

    public IConnection GetConnection()
    {
        if (!IsConnected)
            Retry
                .On<Exception>()
                .For(3)
                .Execute(context =>
                {
                    if (context.Exceptions.Count > 0)
                        Task.Delay(TimeSpan.FromMilliseconds(500));
                    _connection = _connectionFactory.CreateConnection();
                });

        return _connection;
    }
}