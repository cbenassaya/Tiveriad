#region

using MediatR;
using Tiveriad.Documents.Core.Entities;

#endregion

namespace Tiveriad.Documents.Applications.Commands.DocumentCategoryCommands;

public record UpdateDocumentCategoryRequest(string Id, DocumentCategory DocumentCategory) : IRequest<DocumentCategory>;