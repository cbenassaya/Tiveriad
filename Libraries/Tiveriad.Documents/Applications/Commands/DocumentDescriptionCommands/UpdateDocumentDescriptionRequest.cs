#region

using MediatR;
using Tiveriad.Documents.Core.Entities;

#endregion

namespace Tiveriad.Documents.Applications.Commands.DocumentDescriptionCommands;

public record UpdateDocumentDescriptionRequest(string Id, DocumentDescription DocumentDescription)
    : IRequest<DocumentDescription>;