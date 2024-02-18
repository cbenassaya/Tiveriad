#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.TimeAreaCommands;

public record TimeAreaUpdateCommandHandlerRequest(TimeArea TimeArea) : IRequest<TimeArea>;