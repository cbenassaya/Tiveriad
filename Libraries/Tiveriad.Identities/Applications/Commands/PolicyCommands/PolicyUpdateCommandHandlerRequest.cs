#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.PolicyCommands;

public record PolicyUpdateCommandHandlerRequest(Policy Policy) : IRequest<Policy>;