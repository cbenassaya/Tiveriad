#region

using MediatR;
using Tiveriad.Notifications.Core.Entities;

#endregion

namespace Tiveriad.Notifications.Applications.Queries.SubjectQueries;

public record GetAllSubjectsRequest(
    string? Id,
    string? Name,
    int? Page,
    int? Limit,
    string? Q,
    string[]? Orders) : IRequest<IEnumerable<Subject>>;