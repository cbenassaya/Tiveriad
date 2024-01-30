using FluentValidation;

namespace Tiveriad.Documents.Applications.Commands.DocumentDescriptionCommands;

public class SaveDocumentDescriptionPreValidator : AbstractValidator<SaveDocumentDescriptionRequest>
{
    private IRepository<DocumentDescription, string> _repository;
    public SaveDocumentDescriptionPreValidator(IRepository<DocumentDescription, string> repository)
    {
        _repository = repository;
    }


}

