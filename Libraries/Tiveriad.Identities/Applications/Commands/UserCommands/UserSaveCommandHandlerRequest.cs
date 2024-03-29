
using MediatR;
using Tiveriad.Identities.Core.Entities;
namespace Tiveriad.Identities.Applications.Commands.UserCommands;

public record UserSaveCommandHandlerRequest(User User) : IRequest<User>;