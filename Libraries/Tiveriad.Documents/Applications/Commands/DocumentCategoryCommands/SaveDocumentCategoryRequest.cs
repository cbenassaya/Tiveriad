#region

using MediatR;
using Tiveriad.Documents.Core.Entities;

#endregion

namespace Tiveriad.Documents.Applications.Commands.DocumentCategoryCommands;

public record SaveDocumentCategoryRequest(DocumentCategory DocumentCategory) : IRequest<DocumentCategory>;