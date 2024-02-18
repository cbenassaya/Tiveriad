#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.RealmQueries;

public record RealmGetAllQueryHandlerRequest(
    string? Id = null,
    string? Name = null,
    int? Page = null,
    int? Limit = null,
    string? Q = null,
    IEnumerable<string>? Orders = null) : IRequest<List<Realm>>;