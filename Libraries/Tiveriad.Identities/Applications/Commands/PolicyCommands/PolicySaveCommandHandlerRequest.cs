#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.PolicyCommands;

public record PolicySaveCommandHandlerRequest(
    string RealmId,
    string RoleId,
    Policy Policy) : IRequest<Policy>;