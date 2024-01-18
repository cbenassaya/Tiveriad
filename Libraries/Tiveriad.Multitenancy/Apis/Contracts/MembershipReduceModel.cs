using System.ComponentModel.DataAnnotations;

namespace Tiveriad.Multitenancy.Apis.Contracts;
public class MembershipReduceModel
{
    [MaxLength(24)]
    public string Id { get; set; }
}