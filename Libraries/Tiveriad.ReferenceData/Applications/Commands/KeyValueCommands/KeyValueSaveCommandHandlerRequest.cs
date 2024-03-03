
using MediatR;
using Tiveriad.ReferenceData.Core.Entities;
using System;
namespace Tiveriad.ReferenceData.Applications.Commands.KeyValueCommands;

public record KeyValueSaveCommandHandlerRequest(string OrganizationId, KeyValue KeyValue) : IRequest<KeyValue>;