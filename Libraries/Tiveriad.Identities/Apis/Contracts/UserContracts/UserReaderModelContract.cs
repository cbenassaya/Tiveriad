
using System;
using Tiveriad.Core.Abstractions.Entities;
using Tiveriad.Identities.Apis.Contracts.FeatureContracts;
using Tiveriad.Identities.Apis.Contracts.MembershipContracts;
using Tiveriad.Identities.Apis.Contracts.RealmContracts;
using Tiveriad.Identities.Apis.Contracts.RoleContracts;
using Tiveriad.Identities.Core.Entities;

namespace Tiveriad.Identities.Apis.Contracts.UserContracts;

public class UserReaderModelContract
{


    public string? Id { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Language { get; set; }
    public string? Locale { get; set; }
    public string? Email { get; set; }
    public string? Avatar { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public Metadata? Properties { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? Created { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModified { get; set; }

}

public class UserInfoReaderModelContract:UserReaderModelContract
{
    public List<MembershipInfoReaderModelContract> Memberships { get; set; } = new();
}

