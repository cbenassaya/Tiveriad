#region

using Tiveriad.Workflows.Core.Models;
using Tiveriad.Workflows.Core.Models.Search;

#endregion

namespace Tiveriad.Workflows.Core.Services;

public interface ISearchIndex
{
    Task IndexWorkflow(WorkflowInstance workflow);

    Task<Page<WorkflowSearchResult>> Search(string terms, int skip, int take, params SearchFilter[] filters);

    Task Start();

    Task Stop();
}