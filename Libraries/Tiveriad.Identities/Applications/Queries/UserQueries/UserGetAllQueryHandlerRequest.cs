
using MediatR;
using System.Collections.Generic;
using Tiveriad.Identities.Core.Entities;
using System;
namespace Tiveriad.Identities.Applications.Queries.UserQueries;

public record UserGetAllQueryHandlerRequest(string? Id = null, string? Firstname = null, string? Lastname = null, string? Username = null, string? Password = null, string? Email = null, int? Page = null, int? Limit = null, string? Q = null, IEnumerable<string>? Orders = null) : IRequest<List<User>>;