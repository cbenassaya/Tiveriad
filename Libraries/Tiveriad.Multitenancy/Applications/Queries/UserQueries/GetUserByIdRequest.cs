using MediatR;
using Tiveriad.Multitenancy.Core.Entities;

namespace Tiveriad.Multitenancy.Applications.Queries.UserQueries;

public record GetUserByIdRequest(ObjectId Id) : IRequest<User>;