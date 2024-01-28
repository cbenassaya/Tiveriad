using Tiveriad.Documents.Core.Exceptions;

namespace Tiveriad.Documents.Core.Services;

public class BlobProviderService : IBlobProviderService
{
    private readonly IDictionary<string, IBlobProvider> _providers = new Dictionary<string, IBlobProvider>();

    public IBlobProviderService Add(IBlobProvider provider)
    {
        var providerName = (provider.GetType()
            .GetCustomAttributes(typeof(BlobProviderNameAttribute), false)
            .FirstOrDefault() as BlobProviderNameAttribute)?.Name;

        if (_providers.Any(x => x.Key == providerName)) return this;
        _providers.Add(providerName ?? throw new InvalidOperationException(), provider);
        return this;
    }

    public IBlobProvider Get(string? key = null)
    {
        IBlobProvider provider;
        if (key == null) key = _providers.Keys.FirstOrDefault();
        if (key == null) throw new BlobProviderMissingException("No provider defined.");
        _providers.TryGetValue(key ?? throw new InvalidOperationException(), out provider);

        if (provider == null) throw new BlobProviderMissingException($"{key} blob provider \"{key}\" not found.");

        return provider;
    }
}