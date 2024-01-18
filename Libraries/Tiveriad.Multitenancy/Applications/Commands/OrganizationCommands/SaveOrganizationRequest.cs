using MediatR;
using Tiveriad.Multitenancy.Core.Entities;

namespace Tiveriad.Multitenancy.Applications.Commands.OrganizationCommands;

public record SaveOrganizationRequest(Organization Organization, User Owner) : IRequest<Organization>,ICommandRequest;