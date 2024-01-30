using FluentValidation;

namespace Tiveriad.Documents.Applications.Commands.DocumentCategoryCommands;

public class UpdateDocumentCategoryPreValidator : AbstractValidator<UpdateDocumentCategoryRequest>
{
    private IRepository<DocumentCategory, string> _repository;
    public UpdateDocumentCategoryPreValidator(IRepository<DocumentCategory, string> repository)
    {
        _repository = repository;
    }


}

