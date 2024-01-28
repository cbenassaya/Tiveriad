#region

using FluentValidation;
using Tiveriad.Documents.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Documents.Applications.Commands.DocumentCategoryCommands;

public class SaveDocumentCategoryPreValidator : AbstractValidator<SaveDocumentCategoryRequest>
{
    private IRepository<DocumentCategory, string> _repository;

    public SaveDocumentCategoryPreValidator(IRepository<DocumentCategory, string> repository)
    {
        _repository = repository;
    }
}