
using MediatR;
using Tiveriad.Registrations.Core.Entities;
namespace Tiveriad.Registrations.Applications.Commands.RegistrationModelCommands;

public record RegistrationModelSaveCommandHandlerRequest(RegistrationModel RegistrationModel) : IRequest<RegistrationModel>;