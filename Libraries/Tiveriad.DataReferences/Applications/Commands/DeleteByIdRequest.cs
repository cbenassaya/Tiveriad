#region

using MediatR;
using Tiveriad.Core.Abstractions.Entities;

#endregion

namespace Tiveriad.DataReferences.Applications.Commands;

public record DeleteByIdRequest<TEntity, TKey>(TKey Id, TKey? OrganizationId) : IRequest<long>
    where TEntity : IDataReference<TKey>, new()
    where TKey : IEquatable<TKey>;