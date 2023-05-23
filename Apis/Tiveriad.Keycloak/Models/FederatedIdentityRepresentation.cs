#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     FederatedIdentityRepresentation
/// </summary>
[DataContract]
public class FederatedIdentityRepresentation : IEquatable<FederatedIdentityRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="FederatedIdentityRepresentation" /> class.
    /// </summary>
    /// <param name="identityProvider">identityProvider.</param>
    /// <param name="userId">userId.</param>
    /// <param name="userName">userName.</param>
    public FederatedIdentityRepresentation(string identityProvider = default, string userId = default,
        string userName = default)
    {
        IdentityProvider = identityProvider;
        UserId = userId;
        UserName = userName;
    }

    /// <summary>
    ///     Gets or Sets IdentityProvider
    /// </summary>
    [DataMember(Name = "identityProvider", EmitDefaultValue = false)]
    public string IdentityProvider { get; set; }

    /// <summary>
    ///     Gets or Sets UserId
    /// </summary>
    [DataMember(Name = "userId", EmitDefaultValue = false)]
    public string UserId { get; set; }

    /// <summary>
    ///     Gets or Sets UserName
    /// </summary>
    [DataMember(Name = "userName", EmitDefaultValue = false)]
    public string UserName { get; set; }

    /// <summary>
    ///     Returns true if FederatedIdentityRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of FederatedIdentityRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(FederatedIdentityRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                IdentityProvider == input.IdentityProvider ||
                (IdentityProvider != null &&
                 IdentityProvider.Equals(input.IdentityProvider))
            ) &&
            (
                UserId == input.UserId ||
                (UserId != null &&
                 UserId.Equals(input.UserId))
            ) &&
            (
                UserName == input.UserName ||
                (UserName != null &&
                 UserName.Equals(input.UserName))
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
        sb.Append("class FederatedIdentityRepresentation {\n");
        sb.Append("  IdentityProvider: ").Append(IdentityProvider).Append("\n");
        sb.Append("  UserId: ").Append(UserId).Append("\n");
        sb.Append("  UserName: ").Append(UserName).Append("\n");
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
        return Equals(input as FederatedIdentityRepresentation);
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
            if (IdentityProvider != null)
                hashCode = hashCode * 59 + IdentityProvider.GetHashCode();
            if (UserId != null)
                hashCode = hashCode * 59 + UserId.GetHashCode();
            if (UserName != null)
                hashCode = hashCode * 59 + UserName.GetHashCode();
            return hashCode;
        }
    }
}