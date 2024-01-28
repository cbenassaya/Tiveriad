#region

using MediatR;
using Tiveriad.Notifications.Core.Entities;

#endregion

namespace Tiveriad.Notifications.Application.Queries.SubjectQueries;

public record GetSubjectByIdRequest(string Id) : IRequest<Subject?>;