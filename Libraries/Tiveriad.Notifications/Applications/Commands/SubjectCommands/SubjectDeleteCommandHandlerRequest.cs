
using MediatR;
using System;
namespace Tiveriad.Notifications.Applications.Commands.SubjectCommands;

public record SubjectDeleteCommandHandlerRequest(string Id) : IRequest<bool>;