namespace Tiveriad.Integration.Infrastructure.Services;

public class RabbitMqConfigurationService
{
    private readonly IConfiguration _configuration;

    public RabbitMqConfigurationService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string? Hostname => Environment.GetEnvironmentVariable("BROKERSERVICE_HOSTNAME") ??
                               _configuration.GetSection("BrokerService").GetSection("Hostname").Value;

    public string? Username => Environment.GetEnvironmentVariable("BROKERSERVICE_USERNAME") ??
                               _configuration.GetSection("BrokerService").GetSection("Username").Value;

    public string? Password => Environment.GetEnvironmentVariable("BROKERSERVICE_PASSWORD") ??
                               _configuration.GetSection("BrokerService").GetSection("Password").Value;

    public string? Exchange => Environment.GetEnvironmentVariable("BROKERSERVICE_EXCHANGE") ??
                               _configuration.GetSection("BrokerService").GetSection("Exchange").Value;
}