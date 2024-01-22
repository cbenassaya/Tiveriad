#region

using MediatR;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Documents.Applications.Queries;

public class GetAllDocumentDescriptionRequestHandler<T> : IRequestHandler<GetAllDocumentDescriptionRequest<T>,
    IEnumerable<DocumentDescriptionBase<T>>>
    where T : IEquatable<T>
{
    public IRepository<DocumentDescriptionBase<T>, T> _repository;


    public Task<IEnumerable<DocumentDescriptionBase<T>>> Handle(
        GetAllDocumentDescriptionRequest<T> documentDescriptionRequest, CancellationToken cancellationToken)
    {
        var query = _repository.Queryable;
        if (documentDescriptionRequest.Id != null && !documentDescriptionRequest.Id.Equals(default))
            query = query.Where(x => x.Id.Equals(documentDescriptionRequest.Id));
        if (documentDescriptionRequest.Reference != null)
            query = query.Where(x => x.Reference == documentDescriptionRequest.Reference);
        if (documentDescriptionRequest.ReferenceType != null)
            query = query.Where(x => x.ReferenceType == documentDescriptionRequest.ReferenceType);
        if (documentDescriptionRequest.Name != null)
            query = query.Where(x => x.Name == documentDescriptionRequest.Name);
        if (documentDescriptionRequest.Q != null)
            query = query.Where(x =>
                x.Name.Contains(documentDescriptionRequest.Q) || x.Reference.Contains(documentDescriptionRequest.Q));

        if (documentDescriptionRequest.Orders != null && documentDescriptionRequest.Orders.Any())
            foreach (var order in documentDescriptionRequest.Orders)
                query = order.StartsWith("-")
                    ? query.OrderByDescending(order.Substring(1))
                    : query.OrderBy(order);
        if (documentDescriptionRequest.Page.HasValue && documentDescriptionRequest.Limit.HasValue)
            query = query.Skip(documentDescriptionRequest.Page.Value * documentDescriptionRequest.Limit.Value)
                .Take(documentDescriptionRequest.Limit.Value);
        return Task.Run(() => query.ToList().AsEnumerable(), cancellationToken);
    }
}