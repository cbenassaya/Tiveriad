#region

using FluentValidation;
using Tiveriad.Documents.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Documents.Applications.Commands.DocumentCategoryCommands;

public class DeleteDocumentCategoryByIdPreValidator : AbstractValidator<DeleteDocumentCategoryByIdRequest>
{
    private IRepository<DocumentCategory, string> _repository;

    public DeleteDocumentCategoryByIdPreValidator(IRepository<DocumentCategory, string> repository)
    {
        _repository = repository;
    }
}