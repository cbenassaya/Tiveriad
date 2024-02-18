#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.LanguageQueries;

public record LanguageGetAllQueryHandlerRequest(
    string? Id = null,
    int? Page = null,
    int? Limit = null,
    string? Q = null,
    IEnumerable<string>? Orders = null) : IRequest<List<Language>>;