#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Queries.OrganizationQueries;

public record OrganizationGetByIdQueryHandlerRequest(string Id) : IRequest<Organization?>;