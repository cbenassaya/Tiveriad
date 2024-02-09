
using System;
namespace Tiveriad.Notifications.Apis.Contracts.ScopeContracts;

public class ScopeReaderModelContract
{


    public string? Id { get; set; }
    public string? OrganizationId { get; set; }
    public string? ClientId { get; set; }
    public string? RoleId { get; set; }
    public string? GroupId { get; set; }
    public string? UserId { get; set; }
    public string? ReferenceType { get; set; }
    public string? ReferenceId { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? Created { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }

}

