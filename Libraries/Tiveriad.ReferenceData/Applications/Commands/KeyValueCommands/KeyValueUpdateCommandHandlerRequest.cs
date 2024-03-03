
using MediatR;
using Tiveriad.ReferenceData.Core.Entities;
using System;
namespace Tiveriad.ReferenceData.Applications.Commands.KeyValueCommands;

public record KeyValueUpdateCommandHandlerRequest(string OrganizationId, string Id, KeyValue KeyValue) : IRequest<KeyValue>;