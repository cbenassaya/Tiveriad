#region

using System.ComponentModel.DataAnnotations;
using Tiveriad.Core.Abstractions.Entities;

#endregion

namespace Tiveriad.Identities.Core.Entities;

public class Client : IEntity<string>, IAuditable<string>
{
    public string Name { get; set; }

    public string? Description { get; set; }

    public string Code { get; set; }

    public string KeyId { get; set; }

    public Organization Organization { get; set; }

    public string CreatedBy { get; set; }

    public DateTime Created { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModified { get; set; }

    [MaxLength(24)] public string? Id { get; set; }
}