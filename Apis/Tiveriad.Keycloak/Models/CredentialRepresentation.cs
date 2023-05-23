#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     CredentialRepresentation
/// </summary>
[DataContract]
public class CredentialRepresentation : IEquatable<CredentialRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="CredentialRepresentation" /> class.
    /// </summary>
    /// <param name="createdDate">createdDate.</param>
    /// <param name="credentialData">credentialData.</param>
    /// <param name="id">id.</param>
    /// <param name="priority">priority.</param>
    /// <param name="secretData">secretData.</param>
    /// <param name="temporary">temporary.</param>
    /// <param name="type">type.</param>
    /// <param name="userLabel">userLabel.</param>
    /// <param name="value">value.</param>
    public CredentialRepresentation(long? createdDate = default, string credentialData = default, string id = default,
        int? priority = default, string secretData = default, bool? temporary = default, string type = default,
        string userLabel = default, string value = default)
    {
        CreatedDate = createdDate;
        CredentialData = credentialData;
        Id = id;
        Priority = priority;
        SecretData = secretData;
        Temporary = temporary;
        Type = type;
        UserLabel = userLabel;
        Value = value;
    }

    /// <summary>
    ///     Gets or Sets CreatedDate
    /// </summary>
    [DataMember(Name = "createdDate", EmitDefaultValue = false)]
    public long? CreatedDate { get; set; }

    /// <summary>
    ///     Gets or Sets CredentialData
    /// </summary>
    [DataMember(Name = "credentialData", EmitDefaultValue = false)]
    public string CredentialData { get; set; }

    /// <summary>
    ///     Gets or Sets Id
    /// </summary>
    [DataMember(Name = "id", EmitDefaultValue = false)]
    public string Id { get; set; }

    /// <summary>
    ///     Gets or Sets Priority
    /// </summary>
    [DataMember(Name = "priority", EmitDefaultValue = false)]
    public int? Priority { get; set; }

    /// <summary>
    ///     Gets or Sets SecretData
    /// </summary>
    [DataMember(Name = "secretData", EmitDefaultValue = false)]
    public string SecretData { get; set; }

    /// <summary>
    ///     Gets or Sets Temporary
    /// </summary>
    [DataMember(Name = "temporary", EmitDefaultValue = false)]
    public bool? Temporary { get; set; }

    /// <summary>
    ///     Gets or Sets Type
    /// </summary>
    [DataMember(Name = "type", EmitDefaultValue = false)]
    public string Type { get; set; }

    /// <summary>
    ///     Gets or Sets UserLabel
    /// </summary>
    [DataMember(Name = "userLabel", EmitDefaultValue = false)]
    public string UserLabel { get; set; }

    /// <summary>
    ///     Gets or Sets Value
    /// </summary>
    [DataMember(Name = "value", EmitDefaultValue = false)]
    public string Value { get; set; }

    /// <summary>
    ///     Returns true if CredentialRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of CredentialRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(CredentialRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                CreatedDate == input.CreatedDate ||
                (CreatedDate != null &&
                 CreatedDate.Equals(input.CreatedDate))
            ) &&
            (
                CredentialData == input.CredentialData ||
                (CredentialData != null &&
                 CredentialData.Equals(input.CredentialData))
            ) &&
            (
                Id == input.Id ||
                (Id != null &&
                 Id.Equals(input.Id))
            ) &&
            (
                Priority == input.Priority ||
                (Priority != null &&
                 Priority.Equals(input.Priority))
            ) &&
            (
                SecretData == input.SecretData ||
                (SecretData != null &&
                 SecretData.Equals(input.SecretData))
            ) &&
            (
                Temporary == input.Temporary ||
                (Temporary != null &&
                 Temporary.Equals(input.Temporary))
            ) &&
            (
                Type == input.Type ||
                (Type != null &&
                 Type.Equals(input.Type))
            ) &&
            (
                UserLabel == input.UserLabel ||
                (UserLabel != null &&
                 UserLabel.Equals(input.UserLabel))
            ) &&
            (
                Value == input.Value ||
                (Value != null &&
                 Value.Equals(input.Value))
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
        sb.Append("class CredentialRepresentation {\n");
        sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
        sb.Append("  CredentialData: ").Append(CredentialData).Append("\n");
        sb.Append("  Id: ").Append(Id).Append("\n");
        sb.Append("  Priority: ").Append(Priority).Append("\n");
        sb.Append("  SecretData: ").Append(SecretData).Append("\n");
        sb.Append("  Temporary: ").Append(Temporary).Append("\n");
        sb.Append("  Type: ").Append(Type).Append("\n");
        sb.Append("  UserLabel: ").Append(UserLabel).Append("\n");
        sb.Append("  Value: ").Append(Value).Append("\n");
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
        return Equals(input as CredentialRepresentation);
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
            if (CreatedDate != null)
                hashCode = hashCode * 59 + CreatedDate.GetHashCode();
            if (CredentialData != null)
                hashCode = hashCode * 59 + CredentialData.GetHashCode();
            if (Id != null)
                hashCode = hashCode * 59 + Id.GetHashCode();
            if (Priority != null)
                hashCode = hashCode * 59 + Priority.GetHashCode();
            if (SecretData != null)
                hashCode = hashCode * 59 + SecretData.GetHashCode();
            if (Temporary != null)
                hashCode = hashCode * 59 + Temporary.GetHashCode();
            if (Type != null)
                hashCode = hashCode * 59 + Type.GetHashCode();
            if (UserLabel != null)
                hashCode = hashCode * 59 + UserLabel.GetHashCode();
            if (Value != null)
                hashCode = hashCode * 59 + Value.GetHashCode();
            return hashCode;
        }
    }
}