#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.UserQueries;

public record UserGetByIdQueryHandlerRequest(string Id) : IRequest<User?>;