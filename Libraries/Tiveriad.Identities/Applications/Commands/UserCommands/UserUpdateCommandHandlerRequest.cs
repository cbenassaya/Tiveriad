
using MediatR;
using Tiveriad.Identities.Core.Entities;
using System;
namespace Tiveriad.Identities.Applications.Commands.UserCommands;

public record UserUpdateCommandHandlerRequest(string Id, User User) : IRequest<User>;