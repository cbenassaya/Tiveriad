#region

using MediatR;
using Tiveriad.Documents.Core.Entities;

#endregion

namespace Tiveriad.Documents.Applications.Queries.DocumentCategoryQueries;

public record GetDocumentCategoryByIdRequest(string Id) : IRequest<DocumentCategory?>;