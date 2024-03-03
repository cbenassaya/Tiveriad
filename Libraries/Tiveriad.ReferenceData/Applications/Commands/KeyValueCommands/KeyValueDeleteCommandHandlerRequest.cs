
using MediatR;
using System;
namespace Tiveriad.ReferenceData.Applications.Commands.KeyValueCommands;

public record KeyValueDeleteCommandHandlerRequest(string OrganizationId, string Id) : IRequest<bool>;