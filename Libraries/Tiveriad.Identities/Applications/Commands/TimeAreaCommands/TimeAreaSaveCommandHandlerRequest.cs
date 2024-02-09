
using MediatR;
using Tiveriad.Identities.Core.Entities;
namespace Tiveriad.Identities.Applications.Commands.TimeAreaCommands;

public record TimeAreaSaveCommandHandlerRequest(TimeArea TimeArea) : IRequest<TimeArea>;