#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.PolicyCommands;

public record PolicyUpdateCommandHandlerRequest(
    string RealmId,
    string RoleId,
    string Id,
    Policy Policy) : IRequest<Policy>;