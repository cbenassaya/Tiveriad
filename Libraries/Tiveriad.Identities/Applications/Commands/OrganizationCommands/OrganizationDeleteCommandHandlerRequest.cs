#region

using MediatR;

#endregion

namespace Tiveriad.Identities.Applications.Commands.OrganizationCommands;

public record OrganizationDeleteCommandHandlerRequest(string Id) : IRequest<bool>;