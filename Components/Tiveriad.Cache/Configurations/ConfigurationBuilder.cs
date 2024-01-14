namespace Tiveriad.Cache;

public class ConfigurationBuilder
{
    private CacheManagerConfigurator _configurator = new();
    private ConfigurationBuilder ()
    {
    }
    
    
    public static ConfigurationBuilder Create ()
    {
        return new ConfigurationBuilder ();
    }
    public ConfigurationBuilder Configure (Action <CacheManagerConfigurator> configurator)
    {
        configurator ( _configurator);
        return this;
    }
    
    public ICacheManagerConfiguration Build ()
    {
        return _configurator.Build ();
    }
}