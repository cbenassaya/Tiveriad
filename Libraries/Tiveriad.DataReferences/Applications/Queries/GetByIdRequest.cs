#region

using MediatR;
using Tiveriad.Core.Abstractions.Entities;

#endregion

namespace Tiveriad.DataReferences.Applications.Queries;

public record GetByIdRequest<TEntity, TKey>(TKey Id, TKey? OrganizationId) : IRequest<TEntity>
    where TEntity : IDataReference<TKey>, new()
    where TKey : IEquatable<TKey>;