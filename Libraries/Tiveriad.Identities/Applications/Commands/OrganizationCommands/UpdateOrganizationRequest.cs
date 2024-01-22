#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.OrganizationCommands;

public record UpdateOrganizationRequest(Organization Organization) : IRequest<Organization>, ICommandRequest;