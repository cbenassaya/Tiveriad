#region

using MediatR;

#endregion

namespace Tiveriad.Notifications.Applications.Commands.SubjectCommands;

public record DeleteSubjectByIdRequest(string Id) : IRequest<bool>;