
using MediatR;
using Tiveriad.Identities.Core.Entities;
using System;
namespace Tiveriad.Identities.Applications.Queries.MembershipQueries;

public record MembershipGetByIdQueryHandlerRequest(string Id) : IRequest<Membership?>;