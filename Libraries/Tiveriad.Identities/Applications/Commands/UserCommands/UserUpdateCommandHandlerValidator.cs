
using FluentValidation;
using MediatR;
using Tiveriad.Identities.Core.Entities;
using System;
using Tiveriad.Core.Abstractions.Entities;
namespace Tiveriad.Identities.Applications.Commands.UserCommands;

public class UserUpdateCommandHandlerValidator : AbstractValidator<UserUpdateCommandHandlerRequest>
{
    private IRepository<User, string> _repository;
    public UserUpdateCommandHandlerValidator(IRepository<User, string> repository)
    {
        _repository = repository;

        RuleFor(x => x.Id).NotNull().WithErrorCode(ErrorCodes.UserUpdateCommandHandler_Id_XNotNullRule);
        RuleFor(x => x.User).NotNull().WithErrorCode(ErrorCodes.UserUpdateCommandHandler_User_XNotNullRule);
        RuleFor(x => x.User.Firstname).MaximumLength(100).WithErrorCode(ErrorCodes.User_Firstname_XMaxLengthRule_Max_100);
        RuleFor(x => x.User.Firstname).NotEmpty().WithErrorCode(ErrorCodes.User_Firstname_XNotEmptyRule);
        RuleFor(x => x.User.Lastname).MaximumLength(100).WithErrorCode(ErrorCodes.User_Lastname_XMaxLengthRule_Max_100);
        RuleFor(x => x.User.Lastname).NotEmpty().WithErrorCode(ErrorCodes.User_Lastname_XNotEmptyRule);
        RuleFor(x => x.User.Username).MaximumLength(100).WithErrorCode(ErrorCodes.User_Username_XMaxLengthRule_Max_100);
        RuleFor(x => x.User.Username).NotEmpty().WithErrorCode(ErrorCodes.User_Username_XNotEmptyRule);
        RuleFor(x => x.User.Password).MaximumLength(12).WithErrorCode(ErrorCodes.User_Password_XMaxLengthRule_Max_12);
        RuleFor(x => x.User.Password).NotEmpty().WithErrorCode(ErrorCodes.User_Password_XNotEmptyRule);
        RuleFor(x => x.User.Language).MaximumLength(12).WithErrorCode(ErrorCodes.User_Language_XMaxLengthRule_Max_12);
        RuleFor(x => x.User.Language).NotEmpty().WithErrorCode(ErrorCodes.User_Language_XNotEmptyRule);
        RuleFor(x => x.User.Locale).MaximumLength(12).WithErrorCode(ErrorCodes.User_Locale_XMaxLengthRule_Max_12);
        RuleFor(x => x.User.Locale).NotEmpty().WithErrorCode(ErrorCodes.User_Locale_XNotEmptyRule);
        RuleFor(x => x.User.Email).MaximumLength(100).WithErrorCode(ErrorCodes.User_Email_XMaxLengthRule_Max_100);
        RuleFor(x => x.User.Email).NotEmpty().WithErrorCode(ErrorCodes.User_Email_XNotEmptyRule);
        RuleFor(x => x.User.Avatar).MaximumLength(24).WithErrorCode(ErrorCodes.User_Avatar_XMaxLengthRule_Max_24);
        RuleFor(x => x)
        .Must(request =>
        {
            var query = repository.Queryable; query = query.Where(x => x.Id != request.User.Id);
            query = query.Where(x => x.Username == request.User.Username);
            return !query.ToList().Any();
        }
        ).WithErrorCode(ErrorCodes.User_Username_XUniqueRule);
        RuleFor(x => x)
        .Must(request =>
        {
            var query = repository.Queryable; query = query.Where(x => x.Id != request.User.Id);
            query = query.Where(x => x.Email == request.User.Email);
            return !query.ToList().Any();
        }
        ).WithErrorCode(ErrorCodes.User_Email_XUniqueRule); RuleFor(x => x)
        .Must(request =>
        {
            var query = repository.Queryable; query = query.Where(x => x.Id != request.User.Id); query = query.Where(x => x.Username == request.User.Username);
            query = query.Where(x => x.Email == request.User.Email);
            return !query.ToList().Any();
        }
        ).WithErrorCode(ErrorCodes.User_XBusinessKeyRule);
    }


}

