#region

using FluentValidation;
using Tiveriad.Documents.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Documents.Applications.Queries.DocumentDescriptionQueries;

public class GetDocumentDescriptionByIdPreValidator : AbstractValidator<GetDocumentDescriptionByIdRequest>
{
    private IRepository<DocumentDescription, string> _repository;

    public GetDocumentDescriptionByIdPreValidator(IRepository<DocumentDescription, string> repository)
    {
        _repository = repository;
    }
}