#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     AccessTokenCertConf
/// </summary>
[DataContract]
public class AccessTokenCertConf : IEquatable<AccessTokenCertConf>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AccessTokenCertConf" /> class.
    /// </summary>
    /// <param name="x5tS256">x5tS256.</param>
    public AccessTokenCertConf(string x5tS256 = default)
    {
        X5tS256 = x5tS256;
    }

    /// <summary>
    ///     Gets or Sets X5tS256
    /// </summary>
    [DataMember(Name = "x5t#S256", EmitDefaultValue = false)]
    public string X5tS256 { get; set; }

    /// <summary>
    ///     Returns true if AccessTokenCertConf instances are equal
    /// </summary>
    /// <param name="input">Instance of AccessTokenCertConf to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(AccessTokenCertConf input)
    {
        if (input == null)
            return false;

        return
            X5tS256 == input.X5tS256 ||
            (X5tS256 != null &&
             X5tS256.Equals(input.X5tS256));
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
        sb.Append("class AccessTokenCertConf {\n");
        sb.Append("  X5tS256: ").Append(X5tS256).Append("\n");
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
        return Equals(input as AccessTokenCertConf);
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
            if (X5tS256 != null)
                hashCode = hashCode * 59 + X5tS256.GetHashCode();
            return hashCode;
        }
    }
}