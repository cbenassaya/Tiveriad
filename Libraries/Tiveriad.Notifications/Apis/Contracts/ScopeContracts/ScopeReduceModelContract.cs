
using System;
namespace Tiveriad.Notifications.Apis.Contracts.ScopeContracts;

public class ScopeReduceModelContract
{


    public string? Id { get; set; }
    public string? OrganizationId { get; set; }
    public string? ClientId { get; set; }
    public string? RoleId { get; set; }
    public string? GroupId { get; set; }
    public string? UserId { get; set; }
    public string? ReferenceType { get; set; }
    public string? ReferenceId { get; set; }

}

