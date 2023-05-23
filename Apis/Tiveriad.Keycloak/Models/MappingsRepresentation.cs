#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     MappingsRepresentation
/// </summary>
[DataContract]
public class MappingsRepresentation : IEquatable<MappingsRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MappingsRepresentation" /> class.
    /// </summary>
    /// <param name="clientMappings">clientMappings.</param>
    /// <param name="realmMappings">realmMappings.</param>
    public MappingsRepresentation(Dictionary<string, object> clientMappings = default,
        List<RoleRepresentation> realmMappings = default)
    {
        ClientMappings = clientMappings;
        RealmMappings = realmMappings;
    }

    /// <summary>
    ///     Gets or Sets ClientMappings
    /// </summary>
    [DataMember(Name = "clientMappings", EmitDefaultValue = false)]
    public Dictionary<string, object> ClientMappings { get; set; }

    /// <summary>
    ///     Gets or Sets RealmMappings
    /// </summary>
    [DataMember(Name = "realmMappings", EmitDefaultValue = false)]
    public List<RoleRepresentation> RealmMappings { get; set; }

    /// <summary>
    ///     Returns true if MappingsRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of MappingsRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(MappingsRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                ClientMappings == input.ClientMappings ||
                (ClientMappings != null &&
                 input.ClientMappings != null &&
                 ClientMappings.SequenceEqual(input.ClientMappings))
            ) &&
            (
                RealmMappings == input.RealmMappings ||
                (RealmMappings != null &&
                 input.RealmMappings != null &&
                 RealmMappings.SequenceEqual(input.RealmMappings))
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
        sb.Append("class MappingsRepresentation {\n");
        sb.Append("  ClientMappings: ").Append(ClientMappings).Append("\n");
        sb.Append("  RealmMappings: ").Append(RealmMappings).Append("\n");
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
        return Equals(input as MappingsRepresentation);
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
            if (ClientMappings != null)
                hashCode = hashCode * 59 + ClientMappings.GetHashCode();
            if (RealmMappings != null)
                hashCode = hashCode * 59 + RealmMappings.GetHashCode();
            return hashCode;
        }
    }
}