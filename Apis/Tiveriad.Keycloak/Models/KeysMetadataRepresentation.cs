#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     KeysMetadataRepresentation
/// </summary>
[DataContract]
public class KeysMetadataRepresentation : IEquatable<KeysMetadataRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="KeysMetadataRepresentation" /> class.
    /// </summary>
    /// <param name="active">active.</param>
    /// <param name="keys">keys.</param>
    public KeysMetadataRepresentation(Dictionary<string, object> active = default,
        List<KeysMetadataRepresentationKeyMetadataRepresentation> keys = default)
    {
        Active = active;
        Keys = keys;
    }

    /// <summary>
    ///     Gets or Sets Active
    /// </summary>
    [DataMember(Name = "active", EmitDefaultValue = false)]
    public Dictionary<string, object> Active { get; set; }

    /// <summary>
    ///     Gets or Sets Keys
    /// </summary>
    [DataMember(Name = "keys", EmitDefaultValue = false)]
    public List<KeysMetadataRepresentationKeyMetadataRepresentation> Keys { get; set; }

    /// <summary>
    ///     Returns true if KeysMetadataRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of KeysMetadataRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(KeysMetadataRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                Active == input.Active ||
                (Active != null &&
                 input.Active != null &&
                 Active.SequenceEqual(input.Active))
            ) &&
            (
                Keys == input.Keys ||
                (Keys != null &&
                 input.Keys != null &&
                 Keys.SequenceEqual(input.Keys))
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
        sb.Append("class KeysMetadataRepresentation {\n");
        sb.Append("  Active: ").Append(Active).Append("\n");
        sb.Append("  Keys: ").Append(Keys).Append("\n");
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
        return Equals(input as KeysMetadataRepresentation);
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
            if (Active != null)
                hashCode = hashCode * 59 + Active.GetHashCode();
            if (Keys != null)
                hashCode = hashCode * 59 + Keys.GetHashCode();
            return hashCode;
        }
    }
}