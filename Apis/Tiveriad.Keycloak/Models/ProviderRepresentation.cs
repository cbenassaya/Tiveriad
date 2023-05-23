#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     ProviderRepresentation
/// </summary>
[DataContract]
public class ProviderRepresentation : IEquatable<ProviderRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ProviderRepresentation" /> class.
    /// </summary>
    /// <param name="operationalInfo">operationalInfo.</param>
    /// <param name="order">order.</param>
    public ProviderRepresentation(Dictionary<string, object> operationalInfo = default, int? order = default)
    {
        OperationalInfo = operationalInfo;
        Order = order;
    }

    /// <summary>
    ///     Gets or Sets OperationalInfo
    /// </summary>
    [DataMember(Name = "operationalInfo", EmitDefaultValue = false)]
    public Dictionary<string, object> OperationalInfo { get; set; }

    /// <summary>
    ///     Gets or Sets Order
    /// </summary>
    [DataMember(Name = "order", EmitDefaultValue = false)]
    public int? Order { get; set; }

    /// <summary>
    ///     Returns true if ProviderRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of ProviderRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(ProviderRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                OperationalInfo == input.OperationalInfo ||
                (OperationalInfo != null &&
                 input.OperationalInfo != null &&
                 OperationalInfo.SequenceEqual(input.OperationalInfo))
            ) &&
            (
                Order == input.Order ||
                (Order != null &&
                 Order.Equals(input.Order))
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
        sb.Append("class ProviderRepresentation {\n");
        sb.Append("  OperationalInfo: ").Append(OperationalInfo).Append("\n");
        sb.Append("  Order: ").Append(Order).Append("\n");
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
        return Equals(input as ProviderRepresentation);
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
            if (OperationalInfo != null)
                hashCode = hashCode * 59 + OperationalInfo.GetHashCode();
            if (Order != null)
                hashCode = hashCode * 59 + Order.GetHashCode();
            return hashCode;
        }
    }
}