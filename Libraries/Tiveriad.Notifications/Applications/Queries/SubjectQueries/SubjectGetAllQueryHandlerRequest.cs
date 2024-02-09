
using MediatR;
using System.Collections.Generic;
using Tiveriad.Notifications.Core.Entities;
using System;
namespace Tiveriad.Notifications.Applications.Queries.SubjectQueries;

public record SubjectGetAllQueryHandlerRequest(string? Id = null, int? Page = null, int? Limit = null, string? Q = null, IEnumerable<string>? Orders = null) : IRequest<List<Subject>>;