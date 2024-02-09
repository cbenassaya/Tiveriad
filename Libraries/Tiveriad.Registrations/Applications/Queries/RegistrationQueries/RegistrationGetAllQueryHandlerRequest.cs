
using MediatR;
using System.Collections.Generic;
using Tiveriad.Registrations.Core.Entities;
using System;
namespace Tiveriad.Registrations.Applications.Queries.RegistrationQueries;

public record RegistrationGetAllQueryHandlerRequest(string? Id = null, string? OrganizationName = null, string? Firstname = null, string? Lastname = null, string? Username = null, string? Password = null, string? Email = null, string? DefaultLocale = null, int? Page = null, int? Limit = null, string? Q = null, IEnumerable<string>? Orders = null) : IRequest<List<Registration>>;