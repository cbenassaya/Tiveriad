namespace Tiveriad.Documents.Core.Services;

public interface IBlobProviderService
{
    IBlobProviderService Add(IBlobProvider provider);
    IBlobProvider Get();
}