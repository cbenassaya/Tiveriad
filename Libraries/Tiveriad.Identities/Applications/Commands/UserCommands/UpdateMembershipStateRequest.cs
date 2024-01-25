#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.UserCommands;

public record UpdateMembershipStateRequest(string OrganizationId, string ClientId,  string userId, string membershipState)
    : IRequest<User>, ICommandRequest;