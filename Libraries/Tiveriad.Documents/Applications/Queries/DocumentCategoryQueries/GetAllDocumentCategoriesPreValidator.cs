#region

using FluentValidation;
using Tiveriad.Documents.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Documents.Applications.Queries.DocumentCategoryQueries;

public class GetAllDocumentCategoriesPreValidator : AbstractValidator<GetAllDocumentCategoriesRequest>
{
    private IRepository<DocumentCategory, string> _repository;

    public GetAllDocumentCategoriesPreValidator(IRepository<DocumentCategory, string> repository)
    {
        _repository = repository;
    }
}