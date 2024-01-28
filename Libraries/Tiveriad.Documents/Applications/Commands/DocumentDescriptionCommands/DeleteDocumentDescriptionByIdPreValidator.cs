#region

using FluentValidation;
using Tiveriad.Documents.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Documents.Applications.Commands.DocumentDescriptionCommands;

public class DeleteDocumentDescriptionByIdPreValidator : AbstractValidator<DeleteDocumentDescriptionByIdRequest>
{
    private IRepository<DocumentDescription, string> _repository;

    public DeleteDocumentDescriptionByIdPreValidator(IRepository<DocumentDescription, string> repository)
    {
        _repository = repository;
    }
}