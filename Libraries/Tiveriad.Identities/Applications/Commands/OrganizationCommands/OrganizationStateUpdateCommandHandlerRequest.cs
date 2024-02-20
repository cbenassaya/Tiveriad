using MediatR;
using Tiveriad.Identities.Core.Entities;

namespace Tiveriad.Identities.Applications.Commands.OrganizationCommands;

public record OrganizationStateUpdateCommandHandlerRequest(string Id, OrganizationEvent Event) : IRequest<Organization>;