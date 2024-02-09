
using System;
namespace Tiveriad.Identities.Apis.Contracts.UserContracts;

public class UserReduceModelContract
{


    public string? Id { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? ProfileImage { get; set; }

}

