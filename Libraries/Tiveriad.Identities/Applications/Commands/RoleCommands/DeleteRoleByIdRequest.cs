#region

using MediatR;

#endregion

namespace Tiveriad.Identities.Applications.Commands.RoleCommands;

public record DeleteRoleByIdRequest(
    string OrganizationId,
    string ClientId,
    string Id) : IRequest<bool>, ICommandRequest;