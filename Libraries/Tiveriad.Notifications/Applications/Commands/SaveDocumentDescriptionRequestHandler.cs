#region

using MediatR;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Documents.Applications.Commands;

public class
    SaveDocumentDescriptionRequestHandler<T> : IRequestHandler<SaveDocumentDescriptionRequest<T>,
    DocumentDescriptionBase<T>>
    where T : IEquatable<T>
{
    public IRepository<DocumentDescriptionBase<T>, T> _repository;

    public SaveDocumentDescriptionRequestHandler(IRepository<DocumentDescriptionBase<T>, T> repository)
    {
        _repository = repository;
    }

    public Task<DocumentDescriptionBase<T>> Handle(SaveDocumentDescriptionRequest<T> request,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        return Task.Run(async () =>
        {
            var result = await _repository.GetByIdAsync(request.DocumentDescriptionBase.Id, cancellationToken);
            if (result == null)
                await _repository.AddOneAsync(request.DocumentDescriptionBase, cancellationToken);

            return request.DocumentDescriptionBase;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}