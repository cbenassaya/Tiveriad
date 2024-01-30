using FluentValidation;

namespace Tiveriad.Documents.Applications.Queries.DocumentDescriptionQueries;

public class GetAllDocumentDescriptionsPreValidator : AbstractValidator<GetAllDocumentDescriptionsRequest>
{
    private IRepository<DocumentDescription, string> _repository;
    public GetAllDocumentDescriptionsPreValidator(IRepository<DocumentDescription, string> repository)
    {
        _repository = repository;
    }


}

