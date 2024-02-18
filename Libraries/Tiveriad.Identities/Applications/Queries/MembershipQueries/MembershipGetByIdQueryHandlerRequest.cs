#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.MembershipQueries;

public record MembershipGetByIdQueryHandlerRequest(string Id) : IRequest<Membership?>;