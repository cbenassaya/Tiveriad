#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     ClientPoliciesRepresentation
/// </summary>
[DataContract]
public class ClientPoliciesRepresentation : IEquatable<ClientPoliciesRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ClientPoliciesRepresentation" /> class.
    /// </summary>
    /// <param name="policies">policies.</param>
    public ClientPoliciesRepresentation(List<ClientPolicyRepresentation> policies = default)
    {
        Policies = policies;
    }

    /// <summary>
    ///     Gets or Sets Policies
    /// </summary>
    [DataMember(Name = "policies", EmitDefaultValue = false)]
    public List<ClientPolicyRepresentation> Policies { get; set; }

    /// <summary>
    ///     Returns true if ClientPoliciesRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of ClientPoliciesRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(ClientPoliciesRepresentation input)
    {
        if (input == null)
            return false;

        return
            Policies == input.Policies ||
            (Policies != null &&
             input.Policies != null &&
             Policies.SequenceEqual(input.Policies));
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
        sb.Append("class ClientPoliciesRepresentation {\n");
        sb.Append("  Policies: ").Append(Policies).Append("\n");
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
        return Equals(input as ClientPoliciesRepresentation);
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
            if (Policies != null)
                hashCode = hashCode * 59 + Policies.GetHashCode();
            return hashCode;
        }
    }
}