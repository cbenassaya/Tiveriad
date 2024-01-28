#region

using FluentValidation;

#endregion

namespace Tiveriad.Identities.Applications.Commands.UserCommands;

public class DeleteUserByIdPreValidator : AbstractValidator<DeleteUserByIdRequest>
{
    public DeleteUserByIdPreValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required").WithErrorCode("DELETE_USER_BY_ID_ID_REQUIRED");
    }
}