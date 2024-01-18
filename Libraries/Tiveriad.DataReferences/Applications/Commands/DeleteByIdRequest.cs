using MediatR;
using Tiveriad.Repositories;

namespace Tiveriad.DataReferences.Apis.Commands;

public record DeleteByIdRequest<TEntity, TKey>(TKey Id, TKey? OrganizationId) : IRequest<long>
    where TEntity : IDataReference<TKey>, new()
    where TKey : IEquatable<TKey>;