#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     ScopeMappingRepresentation
/// </summary>
[DataContract]
public class ScopeMappingRepresentation : IEquatable<ScopeMappingRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ScopeMappingRepresentation" /> class.
    /// </summary>
    /// <param name="_client">_client.</param>
    /// <param name="clientScope">clientScope.</param>
    /// <param name="roles">roles.</param>
    /// <param name="self">self.</param>
    public ScopeMappingRepresentation(string _client = default, string clientScope = default,
        List<string> roles = default, string self = default)
    {
        _Client = _client;
        ClientScope = clientScope;
        Roles = roles;
        Self = self;
    }

    /// <summary>
    ///     Gets or Sets _Client
    /// </summary>
    [DataMember(Name = "client", EmitDefaultValue = false)]
    public string _Client { get; set; }

    /// <summary>
    ///     Gets or Sets ClientScope
    /// </summary>
    [DataMember(Name = "clientScope", EmitDefaultValue = false)]
    public string ClientScope { get; set; }

    /// <summary>
    ///     Gets or Sets Roles
    /// </summary>
    [DataMember(Name = "roles", EmitDefaultValue = false)]
    public List<string> Roles { get; set; }

    /// <summary>
    ///     Gets or Sets Self
    /// </summary>
    [DataMember(Name = "self", EmitDefaultValue = false)]
    public string Self { get; set; }

    /// <summary>
    ///     Returns true if ScopeMappingRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of ScopeMappingRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(ScopeMappingRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                _Client == input._Client ||
                (_Client != null &&
                 _Client.Equals(input._Client))
            ) &&
            (
                ClientScope == input.ClientScope ||
                (ClientScope != null &&
                 ClientScope.Equals(input.ClientScope))
            ) &&
            (
                Roles == input.Roles ||
                (Roles != null &&
                 input.Roles != null &&
                 Roles.SequenceEqual(input.Roles))
            ) &&
            (
                Self == input.Self ||
                (Self != null &&
                 Self.Equals(input.Self))
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
        sb.Append("class ScopeMappingRepresentation {\n");
        sb.Append("  _Client: ").Append(_Client).Append("\n");
        sb.Append("  ClientScope: ").Append(ClientScope).Append("\n");
        sb.Append("  Roles: ").Append(Roles).Append("\n");
        sb.Append("  Self: ").Append(Self).Append("\n");
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
        return Equals(input as ScopeMappingRepresentation);
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
            if (ClientScope != null)
                hashCode = hashCode * 59 + ClientScope.GetHashCode();
            if (Roles != null)
                hashCode = hashCode * 59 + Roles.GetHashCode();
            if (Self != null)
                hashCode = hashCode * 59 + Self.GetHashCode();
            return hashCode;
        }
    }
}