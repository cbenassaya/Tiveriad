
using MediatR;
using System.Collections.Generic;
using Tiveriad.ReferenceData.Core.Entities;
using System;
namespace Tiveriad.ReferenceData.Applications.Queries.KeyValueQueries;

public record KeyValueGetAllQueryHandlerRequest(string OrganizationId, string? Id = null, string? Key = null, string? Entity = null, string? Value = null, string? Language = null, int? Page = null, int? Limit = null, string? Q = null, List<string>? Orders = null) : IRequest<List<KeyValue>>;