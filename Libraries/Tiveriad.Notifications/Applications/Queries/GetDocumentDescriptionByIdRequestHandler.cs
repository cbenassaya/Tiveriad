#region

using MediatR;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Documents.Applications.Queries;

public class
    GetDocumentDescriptionByIdRequestHandler<T> : IRequestHandler<GetDocumentDescriptionByIdRequest<T>,
    DocumentDescriptionBase<T>>
    where T : IEquatable<T>
{
    public IRepository<DocumentDescriptionBase<T>, T> _repository;


    public Task<DocumentDescriptionBase<T>> Handle(GetDocumentDescriptionByIdRequest<T> request,
        CancellationToken cancellationToken)
    {
        return Task.Run(async () => await _repository.GetByIdAsync(request.Id, cancellationToken), cancellationToken);
    }
}