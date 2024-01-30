using Tiveriad.Documents.Core.Exceptions;

namespace Tiveriad.Documents.Core.Services;

public class BlobServiceProvider : IBlobServiceProvider
{
    private readonly IDictionary<string, IBlobService> _providers = new Dictionary<string, IBlobService>();

    public IBlobServiceProvider Add(IBlobService service)
    {
        var providerName = (service.GetType()
            .GetCustomAttributes(typeof(BlobProviderNameAttribute), false)
            .FirstOrDefault() as BlobProviderNameAttribute)?.Name;

        if (_providers.Any(x => x.Key == providerName)) return this;
        _providers.Add(providerName ?? throw new InvalidOperationException(), service);
        return this;
    }
    

    public IBlobService Get(string? key = null)
    {
        IBlobService service;
        key ??= _providers.Keys.FirstOrDefault();
        if (key == null) throw new BlobProviderMissingException("No provider defined.");
        _providers.TryGetValue(key ?? throw new InvalidOperationException(), out service);
        if (service == null) throw new BlobProviderMissingException($"{key} blob provider \"{key}\" not found.");
        return service;
    }
}