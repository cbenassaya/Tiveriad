#region

using MediatR;
using Tiveriad.Notifications.Core.Entities;

#endregion

namespace Tiveriad.Notifications.Applications.Queries.SubjectQueries;

public record GetSubjectByIdRequest(string Id) : IRequest<Subject?>;