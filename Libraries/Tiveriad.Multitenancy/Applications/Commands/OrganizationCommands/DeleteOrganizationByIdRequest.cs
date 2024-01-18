using MediatR;

namespace Tiveriad.Multitenancy.Applications.Commands.OrganizationCommands;

public record DeleteOrganizationByIdRequest(ObjectId Id) : IRequest<bool>,ICommandRequest;