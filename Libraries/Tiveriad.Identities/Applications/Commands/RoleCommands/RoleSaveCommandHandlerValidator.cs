#region

using FluentValidation;
using Tiveriad.Identities.Core.Entities;

#endregion

namespace Tiveriad.Identities.Applications.Commands.RoleCommands;

public class RoleSaveCommandHandlerValidator : AbstractValidator<RoleSaveCommandHandlerRequest>
{
    private IRepository<Role, string> _repository;

    public RoleSaveCommandHandlerValidator(IRepository<Role, string> repository)
    {
        _repository = repository;
        RuleFor(x => x.OrganizationId).NotEmpty().WithErrorCode(ErrorCodes.RoleSaveCommandHandler_OrganizationId_XNotEmptyRule);
        RuleFor(x => x.Role).NotNull().WithErrorCode(ErrorCodes.RoleSaveCommandHandler_Role_XNotNullRule);
        RuleFor(x => x.Role.Name).MaximumLength(50).WithErrorCode(ErrorCodes.Role_Name_XMaxLengthRule_Max_50);
        RuleFor(x => x.Role.Name).NotEmpty().WithErrorCode(ErrorCodes.Role_Name_XNotEmptyRule);
        RuleFor(x => x.Role.Description).MaximumLength(100)
            .WithErrorCode(ErrorCodes.Role_Description_XMaxLengthRule_Max_100);
        RuleFor(x => x)
            .Must(request =>
                {
                    var query = repository.Queryable;
                    query = query.Where(x => x.Name == request.Role.Name);
                    return !query.ToList().Any();
                }
            ).WithErrorCode(ErrorCodes.Role_Name_XUniqueRule);
        RuleFor(x => x.Role.Code).MaximumLength(24).WithErrorCode(ErrorCodes.Role_Code_XMaxLengthRule_Max_24);
        RuleFor(x => x.Role.Code).NotEmpty().WithErrorCode(ErrorCodes.Role_Code_XNotEmptyRule);
        RuleFor(x => x)
            .Must(request =>
                {
                    var query = repository.Queryable;
                    query = query.Where(x => x.Code == request.Role.Code);
                    return !query.ToList().Any();
                }
            ).WithErrorCode(ErrorCodes.Role_Code_XUniqueRule);
    }
}