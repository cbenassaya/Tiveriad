
namespace ReferenceData.Integration.Core.Services;

public interface ICurrentUserService
{
    string GetUserId();
    string GetUserName();
    string GetFirstName();
    string GetLastName();
    string GetEmail();
}

// public interface IIdentityService
// {
//     public  Task Update(User user, Organization organization);
// }