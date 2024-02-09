
using MediatR;
using Tiveriad.Notifications.Core.Entities;
namespace Tiveriad.Notifications.Applications.Commands.SubjectCommands;

public record SubjectUpdateCommandHandlerRequest(Subject Subject) : IRequest<Subject>;