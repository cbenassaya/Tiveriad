#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Identities.Applications.Queries.UserQueries;

public class GetUserByIdPreValidator : AbstractValidator<GetUserByIdRequest>
{

    public GetUserByIdPreValidator()
    {
    }
}