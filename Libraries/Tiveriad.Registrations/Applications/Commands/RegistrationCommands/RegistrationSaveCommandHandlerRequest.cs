
using MediatR;
using Tiveriad.Registrations.Core.Entities;
namespace Tiveriad.Registrations.Applications.Commands.RegistrationCommands;

public record RegistrationSaveCommandHandlerRequest(Registration Registration) : IRequest<Registration>;