
using MediatR;
using Tiveriad.Notifications.Core.Entities;
namespace Tiveriad.Notifications.Applications.Commands.SubjectCommands;

public record SubjectSaveCommandHandlerRequest(Subject Subject) : IRequest<Subject>;