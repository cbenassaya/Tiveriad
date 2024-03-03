
using MediatR;
using Tiveriad.Identities.Core.Entities;
using System;
namespace Tiveriad.Identities.Applications.Queries.OrganizationQueries;

public record OrganizationGetByIdQueryHandlerRequest(string Id) : IRequest<Organization?>;