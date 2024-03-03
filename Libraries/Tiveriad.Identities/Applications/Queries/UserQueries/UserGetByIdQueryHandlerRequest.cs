
using MediatR;
using Tiveriad.Identities.Core.Entities;
using System;
namespace Tiveriad.Identities.Applications.Queries.UserQueries;

public record UserGetByIdQueryHandlerRequest(string Id) : IRequest<User?>;