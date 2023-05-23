#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     ClientPolicyConditionRepresentation
/// </summary>
[DataContract]
public class ClientPolicyConditionRepresentation : IEquatable<ClientPolicyConditionRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ClientPolicyConditionRepresentation" /> class.
    /// </summary>
    /// <param name="condition">condition.</param>
    /// <param name="configuration">configuration.</param>
    public ClientPolicyConditionRepresentation(string condition = default, JsonNode configuration = default)
    {
        Condition = condition;
        Configuration = configuration;
    }

    /// <summary>
    ///     Gets or Sets Condition
    /// </summary>
    [DataMember(Name = "condition", EmitDefaultValue = false)]
    public string Condition { get; set; }

    /// <summary>
    ///     Gets or Sets Configuration
    /// </summary>
    [DataMember(Name = "configuration", EmitDefaultValue = false)]
    public JsonNode Configuration { get; set; }

    /// <summary>
    ///     Returns true if ClientPolicyConditionRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of ClientPolicyConditionRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(ClientPolicyConditionRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                Condition == input.Condition ||
                (Condition != null &&
                 Condition.Equals(input.Condition))
            ) &&
            (
                Configuration == input.Configuration ||
                (Configuration != null &&
                 Configuration.Equals(input.Configuration))
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
        sb.Append("class ClientPolicyConditionRepresentation {\n");
        sb.Append("  Condition: ").Append(Condition).Append("\n");
        sb.Append("  Configuration: ").Append(Configuration).Append("\n");
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
        return Equals(input as ClientPolicyConditionRepresentation);
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
            if (Condition != null)
                hashCode = hashCode * 59 + Condition.GetHashCode();
            if (Configuration != null)
                hashCode = hashCode * 59 + Configuration.GetHashCode();
            return hashCode;
        }
    }
}