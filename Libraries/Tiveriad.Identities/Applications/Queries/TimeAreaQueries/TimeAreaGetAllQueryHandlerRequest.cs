#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.TimeAreaQueries;

public record TimeAreaGetAllQueryHandlerRequest(
    string? Id = null,
    int? Page = null,
    int? Limit = null,
    string? Q = null,
    IEnumerable<string>? Orders = null) : IRequest<List<TimeArea>>;