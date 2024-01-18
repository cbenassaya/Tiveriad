using MediatR;
using Tiveriad.Multitenancy.Core.Entities;

namespace Tiveriad.Multitenancy.Applications.Commands.OrganizationCommands;

public record UpdateOrganizationRequest(Organization Organization) : IRequest<Organization>,ICommandRequest;