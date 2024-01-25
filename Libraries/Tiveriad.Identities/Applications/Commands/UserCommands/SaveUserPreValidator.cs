#region

using System.Data;
using FluentValidation;
using Tiveriad.Identities.Core.Entities;
using Tiveriad.Repositories;

#endregion

namespace Tiveriad.Identities.Applications.Commands.UserCommands;

public class SaveUserPreValidator : AbstractValidator<SaveUserRequest>
{
    public SaveUserPreValidator(
        IRepository<User, string> userRepository,
        IRepository<Organization, string> organizationRepository,
        IRepository<Client,string> clientRepository,
        IRepository<Membership, string> membershipRepository)
    {
        
        RuleFor(x => x.OrganizationId)
            .NotNull().NotEmpty()
            .WithMessage("OrganizationId cannot be null or empty").WithErrorCode("SAVE_USER_ORGANIZATION_ID_REQUIRED");
        RuleFor(x => x.OrganizationId)
            .Must((id) =>
            {
                var query = organizationRepository.Queryable.Where(o=>o.Id == id);
                return query.FirstOrDefault() != null;
            }).WithMessage("Organization not exists").WithErrorCode("SAVE_USER_ORGANIZATION_NOT_EXISTS");
        
        RuleFor(x => x.ClientId)
            .NotNull().NotEmpty()
            .WithMessage("ClientId cannot be null or empty").WithErrorCode("SAVE_USER_CLIENT_ID_REQUIRED");
        RuleFor(x => x)
            .Must(request =>
            {
                var query = clientRepository.Queryable.Where(o =>
                    o.Id == request.ClientId && o.Organization.Id == request.OrganizationId);
                
                return query.FirstOrDefault() != null;
            }).WithMessage("Client not exists").WithErrorCode("SAVE_USER_CLIENT_NOT_EXISTS");
        RuleFor(x => x.User)
            .NotNull()
            .WithMessage("User cannot be null").WithErrorCode("SAVE_USER_USER_REQUIRED");
        RuleFor(x => x.User.Email).NotEmpty().WithMessage("Email's User is not valid").WithErrorCode("SAVE_USER_USER_EMAIL_REQUIRED");
        
        RuleFor(x => x.User.Username)
            .NotNull()
            .WithMessage("Username's User cannot be null").WithErrorCode("SAVE_USER_USER_USERNAME_REQUIRED");
        RuleFor(x=>x.User.Password).NotEmpty().WithMessage("Password's User cannot be null").WithErrorCode("SAVE_USER_USER_PASSWORD_REQUIRED");
        RuleFor(x=>x.User.Password).MinimumLength(8).WithMessage("Password's User must be at least 8 characters").WithErrorCode("SAVE_USER_USER_PASSWORD_MIN_LENGTH");
        RuleFor(x=>x.User.Password).Matches("[A-Z]").WithMessage("Password's User must contain at least one uppercase letter").WithErrorCode("SAVE_USER_USER_PASSWORD_UPPERCASE");  
        RuleFor(x=>x.User.Password).Matches("[a-z]").WithMessage("Password's User must contain at least one lowercase letter").WithErrorCode("SAVE_USER_USER_PASSWORD_LOWERCASE");
        RuleFor(x=>x.User.Password).Matches("[0-9]").WithMessage("Password's User must contain at least one number").WithErrorCode("SAVE_USER_USER_PASSWORD_NUMBER");
        RuleFor(x=>x.User.Password).Matches("[^a-zA-Z0-9]").WithMessage("Password's User must contain at least one special character").WithErrorCode("SAVE_USER_USER_PASSWORD_SPECIAL_CHARACTER");
        
        
        RuleFor(x=>x)
            .Must(request =>
            {
                var query = membershipRepository.Queryable.Where(x => (x.User.Email == request.User.Email || x.User.Username == request.User.Username ) && x.Client.Id == request.ClientId && x.Organization.Id == request.OrganizationId);
                return query.FirstOrDefault() == null;
            }).WithMessage("User already exists").WithErrorCode("SAVE_USER_MEMBERSHIP_ALREADY_EXISTS");
        

    }
}