using FluentValidation;

namespace Tiveriad.Documents.Applications.Commands.DocumentDescriptionCommands;

public class UpdateDocumentDescriptionPreValidator : AbstractValidator<UpdateDocumentDescriptionRequest>
{
    private IRepository<DocumentDescription, string> _repository;
    public UpdateDocumentDescriptionPreValidator(IRepository<DocumentDescription, string> repository)
    {
        _repository = repository;
    }


}

