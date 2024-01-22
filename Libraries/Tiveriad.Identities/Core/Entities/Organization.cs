#region

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Tiveriad.Core.Abstractions.Entities;

#endregion

namespace Tiveriad.Identities.Core.Entities;

public class Organization : IEntity<string>, IAuditable<string>
{
    [MaxLength(50)] public string Name { get; set; } = string.Empty;

    [MaxLength(500)] [JsonIgnore] public string? Description { get; set; } = string.Empty;

    public OrganizationState? State { get; set; } = OrganizationState.Pending;

    [JsonIgnore] public string CreatedBy { get; set; } = string.Empty;

    [JsonIgnore] public DateTime Created { get; set; } = DateTime.Now;

    [JsonIgnore] public string? LastModifiedBy { get; set; } = string.Empty;

    [JsonIgnore] public DateTime? LastModified { get; set; }


    [MaxLength(24)] public string? Id { get; set; }

    protected bool Equals(Organization other)
    {
        return Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Organization)obj);
    }

    public override int GetHashCode()
    {
        return string.IsNullOrEmpty(Id) ? 0 : Id.GetHashCode();
    }

    public static bool operator ==(Organization? left, Organization? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Organization? left, Organization? right)
    {
        return !Equals(left, right);
    }
}