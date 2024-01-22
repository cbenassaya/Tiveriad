#region

using MediatR;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Documents.Applications.Commands;

public class
    DeleteDocumentDescriptionByIdRequestHandler<T> : IRequestHandler<DeleteDocumentDescriptionByIdRequest<T>, bool>
    where T : IEquatable<T>
{
    public IRepository<DocumentDescriptionBase<T>, T> _repository;

    public DeleteDocumentDescriptionByIdRequestHandler(IRepository<DocumentDescriptionBase<T>, T> repository)
    {
        _repository = repository;
    }


    public Task<bool> Handle(DeleteDocumentDescriptionByIdRequest<T> request, CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(() => _repository.DeleteMany(x => x.Id.Equals(request.Id)) == 1, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}