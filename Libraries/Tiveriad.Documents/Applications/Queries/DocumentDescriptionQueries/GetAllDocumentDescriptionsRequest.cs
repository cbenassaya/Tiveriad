#region

using MediatR;
using Tiveriad.Documents.Core.Entities;

#endregion

namespace Tiveriad.Documents.Applications.Queries.DocumentDescriptionQueries;

public record GetAllDocumentDescriptionsRequest(
    string? Id,
    int? Page,
    int? Limit,
    string? Q,
    IEnumerable<string>? Orders) : IRequest<IEnumerable<DocumentDescription>?>;