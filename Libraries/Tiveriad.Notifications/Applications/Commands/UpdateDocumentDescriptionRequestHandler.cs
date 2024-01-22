#region

using MediatR;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Documents.Applications.Commands;

public class
    UpdateDocumentDescriptionRequestHandler<T> : IRequestHandler<UpdateDocumentDescriptionRequest<T>,
    DocumentDescriptionBase<T>>
    where T : IEquatable<T>
{
    public IRepository<DocumentDescriptionBase<T>, T> _repository;


    public Task<DocumentDescriptionBase<T>> Handle(UpdateDocumentDescriptionRequest<T> request,
        CancellationToken cancellationToken)
    {
        //<-- START CUSTOM CODE-->
        if (request.DocumentDescriptionBase.Id == null)
            throw new ArgumentNullException(nameof(request.DocumentDescriptionBase.Id));

        return Task.Run(async () =>
        {
            var result = await _repository.GetByIdAsync(request.DocumentDescriptionBase.Id, cancellationToken);
            result.Name = request.DocumentDescriptionBase.Name;
            result.Properties = request.DocumentDescriptionBase.Properties;
            result.Reference = request.DocumentDescriptionBase.Reference;
            result.ReferenceType = request.DocumentDescriptionBase.ReferenceType;
            return result;
        }, cancellationToken);
        //<-- END CUSTOM CODE-->
    }
}