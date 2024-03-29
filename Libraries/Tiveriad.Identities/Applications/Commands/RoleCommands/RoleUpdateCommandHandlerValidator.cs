#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.RoleCommands;

public class RoleUpdateCommandHandlerValidator : AbstractValidator<RoleUpdateCommandHandlerRequest>
{
    private IRepository<Role, string> _repository;

    public RoleUpdateCommandHandlerValidator(IRepository<Role, string> repository)
    {
        _repository = repository;
        RuleFor(x => x.Id).NotEmpty().WithErrorCode(ErrorCodes.RoleUpdateCommandHandler_Id_XNotEmptyRule);
        RuleFor(x => x.Role).NotNull().WithErrorCode(ErrorCodes.RoleUpdateCommandHandler_Role_XNotNullRule);
        RuleFor(x => x.Role.Name).MaximumLength(50).WithErrorCode(ErrorCodes.Role_Name_XMaxLengthRule_Max_50);
        RuleFor(x => x.Role.Name).NotEmpty().WithErrorCode(ErrorCodes.Role_Name_XNotEmptyRule);
        RuleFor(x => x.Role.Description).MaximumLength(100)
            .WithErrorCode(ErrorCodes.Role_Description_XMaxLengthRule_Max_100);
        RuleFor(x => x)
            .Must(request =>
                {
                    var query = repository.Queryable;
                    query = query.Where(x => x.Id != request.Id);
                    query = query.Where(x => x.Name == request.Role.Name);
                    return !query.ToList().Any();
                }
            ).WithErrorCode(ErrorCodes.Role_Name_XUniqueRule);
        RuleFor(x => x)
            .Must(request =>
                {
                    var query = repository.Queryable;
                    query = query.Where(x => x.Id != request.Id);
                    query = query.Where(x => x.Code == request.Role.Code);
                    return !query.ToList().Any();
                }
            ).WithErrorCode(ErrorCodes.Role_Code_XUniqueRule);
    }
}