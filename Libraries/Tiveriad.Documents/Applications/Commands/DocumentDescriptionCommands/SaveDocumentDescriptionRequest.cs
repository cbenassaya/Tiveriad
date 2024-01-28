#region

using MediatR;
using Tiveriad.Documents.Core.Entities;

#endregion

namespace Tiveriad.Documents.Applications.Commands.DocumentDescriptionCommands;

public record SaveDocumentDescriptionRequest(DocumentDescription DocumentDescription) : IRequest<DocumentDescription>;