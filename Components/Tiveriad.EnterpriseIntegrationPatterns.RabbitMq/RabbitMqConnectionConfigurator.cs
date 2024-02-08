#region

using RabbitMQ.Client;
using Tiveriad.Connections;

#endregion

namespace Tiveriad.EnterpriseIntegrationPatterns.RabbitMq;

public class RabbitMqConnectionConfigurator : IConnectionConfigurator, IRabbitMqConnectionConfiguration
{
    public string Host { get; private set; }
    public int MaxMessageSize { get; private set; } = 512 * 1024 * 1024;
    public int Port { get; private set; } = AmqpTcpEndpoint.UseDefaultPort;
    public string VirtualHost { get; private set; } = ConnectionFactory.DefaultVHost;
    public string Password { get; private set; } = ConnectionFactory.DefaultPass;
    public string Username { get; private set; } = ConnectionFactory.DefaultUser;
    public string BrokerName { get; private set; }

    public RabbitMqConnectionConfigurator SetPort(int value)
    {
        Port = value;
        return this;
    }

    public RabbitMqConnectionConfigurator SetMaxMessageSize(int value)
    {
        MaxMessageSize = value;
        return this;
    }

    public RabbitMqConnectionConfigurator SetVirtualHost(string value)
    {
        VirtualHost = value;
        return this;
    }

    public RabbitMqConnectionConfigurator SetPassword(string value)
    {
        Password = value;
        return this;
    }

    public RabbitMqConnectionConfigurator SetUsername(string value)
    {
        Username = value;
        return this;
    }

    public RabbitMqConnectionConfigurator SetHost(string value)
    {
        Host = value;
        return this;
    }

    public RabbitMqConnectionConfigurator SetBrokerName(string value)
    {
        BrokerName = value;
        return this;
    }
}