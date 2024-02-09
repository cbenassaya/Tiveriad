
using MediatR;
using System;
namespace Tiveriad.Registrations.Applications.Commands.RegistrationModelCommands;

public record RegistrationModelDeleteCommandHandlerRequest(string Id) : IRequest<bool>;