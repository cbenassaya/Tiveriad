#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     ClientMappingsRepresentation
/// </summary>
[DataContract]
public class ClientMappingsRepresentation : IEquatable<ClientMappingsRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ClientMappingsRepresentation" /> class.
    /// </summary>
    /// <param name="_client">_client.</param>
    /// <param name="id">id.</param>
    /// <param name="mappings">mappings.</param>
    public ClientMappingsRepresentation(string _client = default, string id = default,
        List<RoleRepresentation> mappings = default)
    {
        _Client = _client;
        Id = id;
        Mappings = mappings;
    }

    /// <summary>
    ///     Gets or Sets _Client
    /// </summary>
    [DataMember(Name = "client", EmitDefaultValue = false)]
    public string _Client { get; set; }

    /// <summary>
    ///     Gets or Sets Id
    /// </summary>
    [DataMember(Name = "id", EmitDefaultValue = false)]
    public string Id { get; set; }

    /// <summary>
    ///     Gets or Sets Mappings
    /// </summary>
    [DataMember(Name = "mappings", EmitDefaultValue = false)]
    public List<RoleRepresentation> Mappings { get; set; }

    /// <summary>
    ///     Returns true if ClientMappingsRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of ClientMappingsRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(ClientMappingsRepresentation input)
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
                Id == input.Id ||
                (Id != null &&
                 Id.Equals(input.Id))
            ) &&
            (
                Mappings == input.Mappings ||
                (Mappings != null &&
                 input.Mappings != null &&
                 Mappings.SequenceEqual(input.Mappings))
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
        sb.Append("class ClientMappingsRepresentation {\n");
        sb.Append("  _Client: ").Append(_Client).Append("\n");
        sb.Append("  Id: ").Append(Id).Append("\n");
        sb.Append("  Mappings: ").Append(Mappings).Append("\n");
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
        return Equals(input as ClientMappingsRepresentation);
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
            if (Id != null)
                hashCode = hashCode * 59 + Id.GetHashCode();
            if (Mappings != null)
                hashCode = hashCode * 59 + Mappings.GetHashCode();
            return hashCode;
        }
    }
}