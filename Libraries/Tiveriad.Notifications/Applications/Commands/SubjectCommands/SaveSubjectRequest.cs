#region

using MediatR;
using Tiveriad.Notifications.Core.Entities;

#endregion

namespace Tiveriad.Notifications.Applications.Commands.SubjectCommands;

public record SaveSubjectRequest(Subject Subject) : IRequest<Subject>;