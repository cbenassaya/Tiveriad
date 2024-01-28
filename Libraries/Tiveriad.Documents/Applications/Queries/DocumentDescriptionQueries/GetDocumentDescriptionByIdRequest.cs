#region

using MediatR;
using Tiveriad.Documents.Core.Entities;

#endregion

namespace Tiveriad.Documents.Applications.Queries.DocumentDescriptionQueries;

public record GetDocumentDescriptionByIdRequest(string Id) : IRequest<DocumentDescription?>;