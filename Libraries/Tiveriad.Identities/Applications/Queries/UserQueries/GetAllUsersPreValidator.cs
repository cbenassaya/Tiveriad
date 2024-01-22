#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Identities.Applications.Queries.UserQueries;

public class GetAllUsersPreValidator : AbstractValidator<GetAllUsersRequest>
{

    public GetAllUsersPreValidator()
    {
    }
}