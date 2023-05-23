#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     UserConsentRepresentation
/// </summary>
[DataContract]
public class UserConsentRepresentation : IEquatable<UserConsentRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserConsentRepresentation" /> class.
    /// </summary>
    /// <param name="clientId">clientId.</param>
    /// <param name="createdDate">createdDate.</param>
    /// <param name="grantedClientScopes">grantedClientScopes.</param>
    /// <param name="lastUpdatedDate">lastUpdatedDate.</param>
    public UserConsentRepresentation(string clientId = default, long? createdDate = default,
        List<string> grantedClientScopes = default, long? lastUpdatedDate = default)
    {
        ClientId = clientId;
        CreatedDate = createdDate;
        GrantedClientScopes = grantedClientScopes;
        LastUpdatedDate = lastUpdatedDate;
    }

    /// <summary>
    ///     Gets or Sets ClientId
    /// </summary>
    [DataMember(Name = "clientId", EmitDefaultValue = false)]
    public string ClientId { get; set; }

    /// <summary>
    ///     Gets or Sets CreatedDate
    /// </summary>
    [DataMember(Name = "createdDate", EmitDefaultValue = false)]
    public long? CreatedDate { get; set; }

    /// <summary>
    ///     Gets or Sets GrantedClientScopes
    /// </summary>
    [DataMember(Name = "grantedClientScopes", EmitDefaultValue = false)]
    public List<string> GrantedClientScopes { get; set; }

    /// <summary>
    ///     Gets or Sets LastUpdatedDate
    /// </summary>
    [DataMember(Name = "lastUpdatedDate", EmitDefaultValue = false)]
    public long? LastUpdatedDate { get; set; }

    /// <summary>
    ///     Returns true if UserConsentRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of UserConsentRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(UserConsentRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                ClientId == input.ClientId ||
                (ClientId != null &&
                 ClientId.Equals(input.ClientId))
            ) &&
            (
                CreatedDate == input.CreatedDate ||
                (CreatedDate != null &&
                 CreatedDate.Equals(input.CreatedDate))
            ) &&
            (
                GrantedClientScopes == input.GrantedClientScopes ||
                (GrantedClientScopes != null &&
                 input.GrantedClientScopes != null &&
                 GrantedClientScopes.SequenceEqual(input.GrantedClientScopes))
            ) &&
            (
                LastUpdatedDate == input.LastUpdatedDate ||
                (LastUpdatedDate != null &&
                 LastUpdatedDate.Equals(input.LastUpdatedDate))
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
        sb.Append("class UserConsentRepresentation {\n");
        sb.Append("  ClientId: ").Append(ClientId).Append("\n");
        sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
        sb.Append("  GrantedClientScopes: ").Append(GrantedClientScopes).Append("\n");
        sb.Append("  LastUpdatedDate: ").Append(LastUpdatedDate).Append("\n");
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
        return Equals(input as UserConsentRepresentation);
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
            if (ClientId != null)
                hashCode = hashCode * 59 + ClientId.GetHashCode();
            if (CreatedDate != null)
                hashCode = hashCode * 59 + CreatedDate.GetHashCode();
            if (GrantedClientScopes != null)
                hashCode = hashCode * 59 + GrantedClientScopes.GetHashCode();
            if (LastUpdatedDate != null)
                hashCode = hashCode * 59 + LastUpdatedDate.GetHashCode();
            return hashCode;
        }
    }
}