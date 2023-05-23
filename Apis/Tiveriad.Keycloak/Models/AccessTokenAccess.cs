#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     AccessTokenAccess
/// </summary>
[DataContract]
public class AccessTokenAccess : IEquatable<AccessTokenAccess>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AccessTokenAccess" /> class.
    /// </summary>
    /// <param name="roles">roles.</param>
    /// <param name="verifyCaller">verifyCaller.</param>
    public AccessTokenAccess(List<string> roles = default, bool? verifyCaller = default)
    {
        Roles = roles;
        VerifyCaller = verifyCaller;
    }

    /// <summary>
    ///     Gets or Sets Roles
    /// </summary>
    [DataMember(Name = "roles", EmitDefaultValue = false)]
    public List<string> Roles { get; set; }

    /// <summary>
    ///     Gets or Sets VerifyCaller
    /// </summary>
    [DataMember(Name = "verify_caller", EmitDefaultValue = false)]
    public bool? VerifyCaller { get; set; }

    /// <summary>
    ///     Returns true if AccessTokenAccess instances are equal
    /// </summary>
    /// <param name="input">Instance of AccessTokenAccess to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(AccessTokenAccess input)
    {
        if (input == null)
            return false;

        return
            (
                Roles == input.Roles ||
                (Roles != null &&
                 input.Roles != null &&
                 Roles.SequenceEqual(input.Roles))
            ) &&
            (
                VerifyCaller == input.VerifyCaller ||
                (VerifyCaller != null &&
                 VerifyCaller.Equals(input.VerifyCaller))
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
        sb.Append("class AccessTokenAccess {\n");
        sb.Append("  Roles: ").Append(Roles).Append("\n");
        sb.Append("  VerifyCaller: ").Append(VerifyCaller).Append("\n");
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
        return Equals(input as AccessTokenAccess);
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
            if (Roles != null)
                hashCode = hashCode * 59 + Roles.GetHashCode();
            if (VerifyCaller != null)
                hashCode = hashCode * 59 + VerifyCaller.GetHashCode();
            return hashCode;
        }
    }
}