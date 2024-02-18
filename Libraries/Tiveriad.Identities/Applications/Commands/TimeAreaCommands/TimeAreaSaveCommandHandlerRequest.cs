#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.TimeAreaCommands;

public record TimeAreaSaveCommandHandlerRequest(TimeArea TimeArea) : IRequest<TimeArea>;