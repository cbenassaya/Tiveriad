#region

using MediatR;

#endregion

namespace Tiveriad.Identities.Applications.Commands.ClientCommands;

public record DeleteClientByIdRequest(string Id, string OrganizationId) : IRequest<bool>, ICommandRequest;