
using MediatR;
using Tiveriad.Identities.Core.Entities;
namespace Tiveriad.Identities.Applications.Commands.OrganizationCommands;

public record OrganizationSaveCommandHandlerRequest(Organization Organization) : IRequest<Organization>;