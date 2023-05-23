#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     Permission
/// </summary>
[DataContract]
public class Permission : IEquatable<Permission>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="Permission" /> class.
    /// </summary>
    /// <param name="claims">claims.</param>
    /// <param name="rsid">rsid.</param>
    /// <param name="rsname">rsname.</param>
    /// <param name="scopes">scopes.</param>
    public Permission(Dictionary<string, object> claims = default, string rsid = default, string rsname = default,
        List<string> scopes = default)
    {
        Claims = claims;
        Rsid = rsid;
        Rsname = rsname;
        Scopes = scopes;
    }

    /// <summary>
    ///     Gets or Sets Claims
    /// </summary>
    [DataMember(Name = "claims", EmitDefaultValue = false)]
    public Dictionary<string, object> Claims { get; set; }

    /// <summary>
    ///     Gets or Sets Rsid
    /// </summary>
    [DataMember(Name = "rsid", EmitDefaultValue = false)]
    public string Rsid { get; set; }

    /// <summary>
    ///     Gets or Sets Rsname
    /// </summary>
    [DataMember(Name = "rsname", EmitDefaultValue = false)]
    public string Rsname { get; set; }

    /// <summary>
    ///     Gets or Sets Scopes
    /// </summary>
    [DataMember(Name = "scopes", EmitDefaultValue = false)]
    public List<string> Scopes { get; set; }

    /// <summary>
    ///     Returns true if Permission instances are equal
    /// </summary>
    /// <param name="input">Instance of Permission to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(Permission input)
    {
        if (input == null)
            return false;

        return
            (
                Claims == input.Claims ||
                (Claims != null &&
                 input.Claims != null &&
                 Claims.SequenceEqual(input.Claims))
            ) &&
            (
                Rsid == input.Rsid ||
                (Rsid != null &&
                 Rsid.Equals(input.Rsid))
            ) &&
            (
                Rsname == input.Rsname ||
                (Rsname != null &&
                 Rsname.Equals(input.Rsname))
            ) &&
            (
                Scopes == input.Scopes ||
                (Scopes != null &&
                 input.Scopes != null &&
                 Scopes.SequenceEqual(input.Scopes))
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
        sb.Append("class Permission {\n");
        sb.Append("  Claims: ").Append(Claims).Append("\n");
        sb.Append("  Rsid: ").Append(Rsid).Append("\n");
        sb.Append("  Rsname: ").Append(Rsname).Append("\n");
        sb.Append("  Scopes: ").Append(Scopes).Append("\n");
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
        return Equals(input as Permission);
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
            if (Claims != null)
                hashCode = hashCode * 59 + Claims.GetHashCode();
            if (Rsid != null)
                hashCode = hashCode * 59 + Rsid.GetHashCode();
            if (Rsname != null)
                hashCode = hashCode * 59 + Rsname.GetHashCode();
            if (Scopes != null)
                hashCode = hashCode * 59 + Scopes.GetHashCode();
            return hashCode;
        }
    }
}