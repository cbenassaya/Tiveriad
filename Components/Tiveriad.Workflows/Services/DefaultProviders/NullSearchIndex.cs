#region

using Tiveriad.Workflows.Core.Models;
using Tiveriad.Workflows.Core.Models.Search;
using Tiveriad.Workflows.Core.Services;

#endregion

namespace Tiveriad.Workflows.Services.DefaultProviders;

public class NullSearchIndex : ISearchIndex
{
    public Task IndexWorkflow(WorkflowInstance workflow)
    {
        return Task.CompletedTask;
    }

    public Task<Page<WorkflowSearchResult>> Search(string terms, int skip, int take, params SearchFilter[] filters)
    {
        throw new NotImplementedException();
    }

    public Task Start()
    {
        return Task.CompletedTask;
    }

    public Task Stop()
    {
        return Task.CompletedTask;
    }
}