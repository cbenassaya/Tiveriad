
using MediatR;
using Tiveriad.ReferenceData.Core.Entities;
using System;
namespace Tiveriad.ReferenceData.Applications.Queries.KeyValueQueries;

public record KeyValueGetByIdQueryHandlerRequest(string OrganizationId, string Id, string? Language = null) : IRequest<KeyValue?>;