using Tiveriad.Connections;

namespace Tiveriad.EnterpriseIntegrationPatterns.RabbitMq;

public interface IRabbitMqConnectionConfiguration : IConnectionConfiguration
{
    public string Host { get; }
    public int MaxMessageSize { get; }
    public int Port { get; }
    public string VirtualHost { get; }
    public string Password { get; }
    public string Username { get; }
    public string BrokerName { get; }
}