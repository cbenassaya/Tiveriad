#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     ClientInitialAccessPresentation
/// </summary>
[DataContract]
public class ClientInitialAccessPresentation : IEquatable<ClientInitialAccessPresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ClientInitialAccessPresentation" /> class.
    /// </summary>
    /// <param name="count">count.</param>
    /// <param name="expiration">expiration.</param>
    /// <param name="id">id.</param>
    /// <param name="remainingCount">remainingCount.</param>
    /// <param name="timestamp">timestamp.</param>
    /// <param name="token">token.</param>
    public ClientInitialAccessPresentation(int? count = default, int? expiration = default, string id = default,
        int? remainingCount = default, int? timestamp = default, string token = default)
    {
        Count = count;
        Expiration = expiration;
        Id = id;
        RemainingCount = remainingCount;
        Timestamp = timestamp;
        Token = token;
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
    ///     Gets or Sets Id
    /// </summary>
    [DataMember(Name = "id", EmitDefaultValue = false)]
    public string Id { get; set; }

    /// <summary>
    ///     Gets or Sets RemainingCount
    /// </summary>
    [DataMember(Name = "remainingCount", EmitDefaultValue = false)]
    public int? RemainingCount { get; set; }

    /// <summary>
    ///     Gets or Sets Timestamp
    /// </summary>
    [DataMember(Name = "timestamp", EmitDefaultValue = false)]
    public int? Timestamp { get; set; }

    /// <summary>
    ///     Gets or Sets Token
    /// </summary>
    [DataMember(Name = "token", EmitDefaultValue = false)]
    public string Token { get; set; }

    /// <summary>
    ///     Returns true if ClientInitialAccessPresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of ClientInitialAccessPresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(ClientInitialAccessPresentation input)
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
            ) &&
            (
                Id == input.Id ||
                (Id != null &&
                 Id.Equals(input.Id))
            ) &&
            (
                RemainingCount == input.RemainingCount ||
                (RemainingCount != null &&
                 RemainingCount.Equals(input.RemainingCount))
            ) &&
            (
                Timestamp == input.Timestamp ||
                (Timestamp != null &&
                 Timestamp.Equals(input.Timestamp))
            ) &&
            (
                Token == input.Token ||
                (Token != null &&
                 Token.Equals(input.Token))
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
        sb.Append("class ClientInitialAccessPresentation {\n");
        sb.Append("  Count: ").Append(Count).Append("\n");
        sb.Append("  Expiration: ").Append(Expiration).Append("\n");
        sb.Append("  Id: ").Append(Id).Append("\n");
        sb.Append("  RemainingCount: ").Append(RemainingCount).Append("\n");
        sb.Append("  Timestamp: ").Append(Timestamp).Append("\n");
        sb.Append("  Token: ").Append(Token).Append("\n");
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
        return Equals(input as ClientInitialAccessPresentation);
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
            if (Id != null)
                hashCode = hashCode * 59 + Id.GetHashCode();
            if (RemainingCount != null)
                hashCode = hashCode * 59 + RemainingCount.GetHashCode();
            if (Timestamp != null)
                hashCode = hashCode * 59 + Timestamp.GetHashCode();
            if (Token != null)
                hashCode = hashCode * 59 + Token.GetHashCode();
            return hashCode;
        }
    }
}