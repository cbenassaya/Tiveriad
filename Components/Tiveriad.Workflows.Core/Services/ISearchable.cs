namespace Tiveriad.Workflows.Core.Services;

public interface ISearchable
{
    IEnumerable<string> GetSearchTokens();
}