namespace Tiveriad.Documents.Core.Services;

public interface IBlobServiceProvider
{
    IBlobServiceProvider Add(IBlobService service) ;
    IBlobService Get(string? key = null);
}

