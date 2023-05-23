#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     ClientInitialAccessCreatePresentation
/// </summary>
[DataContract]
public class ClientInitialAccessCreatePresentation : IEquatable<ClientInitialAccessCreatePresentation>,
    IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ClientInitialAccessCreatePresentation" /> class.
    /// </summary>
    /// <param name="count">count.</param>
    /// <param name="expiration">expiration.</param>
    public ClientInitialAccessCreatePresentation(int? count = default, int? expiration = default)
    {
        Count = count;
        Expiration = expiration;
    }

    /// <summary>
    ///     Gets or Sets Count
    /// </summary>
    [DataMember(Name = "count", EmitDefaultValue = false)]
    public int? Count { get; set; }

    /// <summary>
    ///     Gets or Sets Expiration
    /// </summary>
    [DataMember(Name = "expiration", EmitDefaultValue = false)]
    public int? Expiration { get; set; }

    /// <summary>
    ///     Returns true if ClientInitialAccessCreatePresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of ClientInitialAccessCreatePresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(ClientInitialAccessCreatePresentation input)
    {
        if (input == null)
            return false;

        return
            (
                Count == input.Count ||
                (Count != null &&
                 Count.Equals(input.Count))
            ) &&
            (
                Expiration == input.Expiration ||
                (Expiration != null &&
                 Expiration.Equals(input.Expiration))
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
        sb.Append("class ClientInitialAccessCreatePresentation {\n");
        sb.Append("  Count: ").Append(Count).Append("\n");
        sb.Append("  Expiration: ").Append(Expiration).Append("\n");
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
        return Equals(input as ClientInitialAccessCreatePresentation);
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
            if (Count != null)
                hashCode = hashCode * 59 + Count.GetHashCode();
            if (Expiration != null)
                hashCode = hashCode * 59 + Expiration.GetHashCode();
            return hashCode;
        }
    }
}