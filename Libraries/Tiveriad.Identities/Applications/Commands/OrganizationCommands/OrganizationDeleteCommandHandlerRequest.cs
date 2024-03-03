
using MediatR;
using System;
namespace Tiveriad.Identities.Applications.Commands.OrganizationCommands;

public record OrganizationDeleteCommandHandlerRequest(string Id) : IRequest<bool>;