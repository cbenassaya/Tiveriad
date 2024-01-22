#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.OrganizationCommands;

public record SaveOrganizationRequest(Organization Organization, User Owner) : IRequest<Organization>, ICommandRequest;