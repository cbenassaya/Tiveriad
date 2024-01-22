#region

using MediatR;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.ClientCommands;

public record SaveClientRequest(Client Client, string OrganizationId) : IRequest<Client>, ICommandRequest;