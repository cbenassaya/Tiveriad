
using MediatR;
using System.Collections.Generic;
using Tiveriad.Identities.Core.Entities;
using System;
namespace Tiveriad.Identities.Applications.Queries.MembershipQueries;

public record MembershipGetAllQueryHandlerRequest(string? Id = null, string? UserId = null, string? OrganizationId = null, int? Page = null, int? Limit = null, string? Q = null, List<string>? Orders = null) : IRequest<PagedResult<Membership>>;