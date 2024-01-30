using FluentValidation;

namespace Tiveriad.Documents.Applications.Queries.DocumentCategoryQueries;

public class GetDocumentCategoryByIdPreValidator : AbstractValidator<GetDocumentCategoryByIdRequest>
{
    private IRepository<DocumentCategory, string> _repository;
    public GetDocumentCategoryByIdPreValidator(IRepository<DocumentCategory, string> repository)
    {
        _repository = repository;
    }


}

