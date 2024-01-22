#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace Tiveriad.Identities.Apis.Contracts;

public class MembershipReduceModel
{
    [MaxLength(24)] public string Id { get; set; }
}