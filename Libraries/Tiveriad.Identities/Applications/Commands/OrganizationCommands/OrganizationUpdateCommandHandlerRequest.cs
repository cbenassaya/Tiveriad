
using MediatR;
using Tiveriad.Identities.Core.Entities;
namespace Tiveriad.Identities.Applications.Commands.OrganizationCommands;

public record OrganizationUpdateCommandHandlerRequest(Organization Organization) : IRequest<Organization>;