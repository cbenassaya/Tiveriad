#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     ManagementPermissionReference
/// </summary>
[DataContract]
public class ManagementPermissionReference : IEquatable<ManagementPermissionReference>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ManagementPermissionReference" /> class.
    /// </summary>
    /// <param name="enabled">enabled.</param>
    /// <param name="resource">resource.</param>
    /// <param name="scopePermissions">scopePermissions.</param>
    public ManagementPermissionReference(bool? enabled = default, string resource = default,
        Dictionary<string, object> scopePermissions = default)
    {
        Enabled = enabled;
        Resource = resource;
        ScopePermissions = scopePermissions;
    }

    /// <summary>
    ///     Gets or Sets Enabled
    /// </summary>
    [DataMember(Name = "enabled", EmitDefaultValue = false)]
    public bool? Enabled { get; set; }

    /// <summary>
    ///     Gets or Sets Resource
    /// </summary>
    [DataMember(Name = "resource", EmitDefaultValue = false)]
    public string Resource { get; set; }

    /// <summary>
    ///     Gets or Sets ScopePermissions
    /// </summary>
    [DataMember(Name = "scopePermissions", EmitDefaultValue = false)]
    public Dictionary<string, object> ScopePermissions { get; set; }

    /// <summary>
    ///     Returns true if ManagementPermissionReference instances are equal
    /// </summary>
    /// <param name="input">Instance of ManagementPermissionReference to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(ManagementPermissionReference input)
    {
        if (input == null)
            return false;

        return
            (
                Enabled == input.Enabled ||
                (Enabled != null &&
                 Enabled.Equals(input.Enabled))
            ) &&
            (
                Resource == input.Resource ||
                (Resource != null &&
                 Resource.Equals(input.Resource))
            ) &&
            (
                ScopePermissions == input.ScopePermissions ||
                (ScopePermissions != null &&
                 input.ScopePermissions != null &&
                 ScopePermissions.SequenceEqual(input.ScopePermissions))
            );
    }

    /// <summary>
    ///     To validate all properties of the instance
    /// </summary>
    /// <param name="validationContext">Validation context</param>
    /// <returns>Validation Result</returns>
    IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
    {
        yield break;
    }

    /// <summary>
    ///     Returns the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("class ManagementPermissionReference {\n");
        sb.Append("  Enabled: ").Append(Enabled).Append("\n");
        sb.Append("  Resource: ").Append(Resource).Append("\n");
        sb.Append("  ScopePermissions: ").Append(ScopePermissions).Append("\n");
        sb.Append("}\n");
        return sb.ToString();
    }

    /// <summary>
    ///     Returns the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public virtual string ToJson()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

    /// <summary>
    ///     Returns true if objects are equal
    /// </summary>
    /// <param name="input">Object to be compared</param>
    /// <returns>Boolean</returns>
    public override bool Equals(object input)
    {
        return Equals(input as ManagementPermissionReference);
    }

    /// <summary>
    ///     Gets the hash code
    /// </summary>
    /// <returns>Hash code</returns>
    public override int GetHashCode()
    {
        unchecked // Overflow is fine, just wrap
        {
            var hashCode = 41;
            if (Enabled != null)
                hashCode = hashCode * 59 + Enabled.GetHashCode();
            if (Resource != null)
                hashCode = hashCode * 59 + Resource.GetHashCode();
            if (ScopePermissions != null)
                hashCode = hashCode * 59 + ScopePermissions.GetHashCode();
            return hashCode;
        }
    }
}