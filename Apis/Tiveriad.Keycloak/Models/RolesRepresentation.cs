#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     RolesRepresentation
/// </summary>
[DataContract]
public class RolesRepresentation : IEquatable<RolesRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="RolesRepresentation" /> class.
    /// </summary>
    /// <param name="_client">_client.</param>
    /// <param name="realm">realm.</param>
    public RolesRepresentation(Dictionary<string, object> _client = default, List<RoleRepresentation> realm = default)
    {
        _Client = _client;
        Realm = realm;
    }

    /// <summary>
    ///     Gets or Sets _Client
    /// </summary>
    [DataMember(Name = "client", EmitDefaultValue = false)]
    public Dictionary<string, object> _Client { get; set; }

    /// <summary>
    ///     Gets or Sets Realm
    /// </summary>
    [DataMember(Name = "realm", EmitDefaultValue = false)]
    public List<RoleRepresentation> Realm { get; set; }

    /// <summary>
    ///     Returns true if RolesRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of RolesRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(RolesRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                _Client == input._Client ||
                (_Client != null &&
                 input._Client != null &&
                 _Client.SequenceEqual(input._Client))
            ) &&
            (
                Realm == input.Realm ||
                (Realm != null &&
                 input.Realm != null &&
                 Realm.SequenceEqual(input.Realm))
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
        sb.Append("class RolesRepresentation {\n");
        sb.Append("  _Client: ").Append(_Client).Append("\n");
        sb.Append("  Realm: ").Append(Realm).Append("\n");
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
        return Equals(input as RolesRepresentation);
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
            if (_Client != null)
                hashCode = hashCode * 59 + _Client.GetHashCode();
            if (Realm != null)
                hashCode = hashCode * 59 + Realm.GetHashCode();
            return hashCode;
        }
    }
}