#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.RealmQueries;

public record RealmGetByIdQueryHandlerRequest(string Id) : IRequest<Realm?>;