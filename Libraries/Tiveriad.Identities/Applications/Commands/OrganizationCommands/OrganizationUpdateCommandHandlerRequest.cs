#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.OrganizationCommands;

public record OrganizationUpdateCommandHandlerRequest(Organization Organization) : IRequest<Organization>;

public record OrganizationStateUpdateCommandHandlerRequest(string Id, OrganizationEvent Event) : IRequest<Organization>;