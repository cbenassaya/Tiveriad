using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using Tiveriad.Connections;

namespace Tiveriad.EnterpriseIntegrationPatterns.RabbitMq;

public class RabbitMqConnectionFactoryBuilder : IConnectionFactoryBuilder<RabbitMqConnectionConfigurator, IRabbitMqConnectionConfiguration, IConnection>
{
    private RabbitMqConnectionConfigurator _configurator;
    private ILogger<RabbitMqConnectionFactoryBuilder> _logger;
    public IConnectionFactoryBuilder<RabbitMqConnectionConfigurator,IRabbitMqConnectionConfiguration, IConnection> Configure(Action<RabbitMqConnectionConfigurator> action)
    {
        _configurator= new RabbitMqConnectionConfigurator();
        action(_configurator);
        return this;
    }

    public IRabbitMqConnectionConfiguration Configuration => _configurator;

    public IConnectionFactory<IConnection> Build()
    {
        if (string.IsNullOrEmpty(_configurator.Host))
            _logger.LogCritical("FATAL ERROR: RabbitMQ connections could not be created and opened. Host not defined");
        
        var connectionFactory = new ConnectionFactory( );
        connectionFactory.UserName = _configurator.Username;
        connectionFactory.Password = _configurator.Password;
        connectionFactory.VirtualHost = _configurator.VirtualHost;
        connectionFactory.HostName = _configurator.Host;
        connectionFactory.Port     = _configurator.Port;
        connectionFactory.MaxMessageSize = 512 * 1024 * 1024;
        return new RabbitMqConnectionFactory(connectionFactory);
    }
}