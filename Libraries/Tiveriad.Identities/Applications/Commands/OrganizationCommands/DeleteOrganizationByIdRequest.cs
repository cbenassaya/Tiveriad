#region

using MediatR;

#endregion

namespace Tiveriad.Identities.Applications.Commands.OrganizationCommands;

public record DeleteOrganizationByIdRequest(string Id) : IRequest<bool>, ICommandRequest;