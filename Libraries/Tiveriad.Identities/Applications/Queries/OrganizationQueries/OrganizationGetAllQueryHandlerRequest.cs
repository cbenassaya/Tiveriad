
using MediatR;
using System.Collections.Generic;
using Tiveriad.Identities.Core.Entities;
using System;
namespace Tiveriad.Identities.Applications.Queries.OrganizationQueries;

public record OrganizationGetAllQueryHandlerRequest(string? Id = null, string? Name = null, string? Domain = null, OrganizationState? State = null, int? Page = null, int? Limit = null, string? Q = null, IEnumerable<string>? Orders = null) : IRequest<List<Organization>>;