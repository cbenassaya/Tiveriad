
using MediatR;
using System.Collections.Generic;
using Tiveriad.Registrations.Core.Entities;
using System;
namespace Tiveriad.Registrations.Applications.Queries.RegistrationModelQueries;

public record RegistrationModelGetAllQueryHandlerRequest(string? Id = null, string? Name = null, int? Page = null, int? Limit = null, string? Q = null, IEnumerable<string>? Orders = null) : IRequest<List<RegistrationModel>>;