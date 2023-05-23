#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     AccessTokenAuthorization
/// </summary>
[DataContract]
public class AccessTokenAuthorization : IEquatable<AccessTokenAuthorization>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AccessTokenAuthorization" /> class.
    /// </summary>
    /// <param name="permissions">permissions.</param>
    public AccessTokenAuthorization(List<Permission> permissions = default)
    {
        Permissions = permissions;
    }

    /// <summary>
    ///     Gets or Sets Permissions
    /// </summary>
    [DataMember(Name = "permissions", EmitDefaultValue = false)]
    public List<Permission> Permissions { get; set; }

    /// <summary>
    ///     Returns true if AccessTokenAuthorization instances are equal
    /// </summary>
    /// <param name="input">Instance of AccessTokenAuthorization to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(AccessTokenAuthorization input)
    {
        if (input == null)
            return false;

        return
            Permissions == input.Permissions ||
            (Permissions != null &&
             input.Permissions != null &&
             Permissions.SequenceEqual(input.Permissions));
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
        sb.Append("class AccessTokenAuthorization {\n");
        sb.Append("  Permissions: ").Append(Permissions).Append("\n");
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
        return Equals(input as AccessTokenAuthorization);
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
            if (Permissions != null)
                hashCode = hashCode * 59 + Permissions.GetHashCode();
            return hashCode;
        }
    }
}