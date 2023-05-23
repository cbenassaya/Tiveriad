#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     ProtocolMapperRepresentation
/// </summary>
[DataContract]
public class ProtocolMapperRepresentation : IEquatable<ProtocolMapperRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ProtocolMapperRepresentation" /> class.
    /// </summary>
    /// <param name="config">config.</param>
    /// <param name="id">id.</param>
    /// <param name="name">name.</param>
    /// <param name="protocol">protocol.</param>
    /// <param name="protocolMapper">protocolMapper.</param>
    public ProtocolMapperRepresentation(Dictionary<string, object> config = default, string id = default,
        string name = default, string protocol = default, string protocolMapper = default)
    {
        Config = config;
        Id = id;
        Name = name;
        Protocol = protocol;
        ProtocolMapper = protocolMapper;
    }

    /// <summary>
    ///     Gets or Sets Config
    /// </summary>
    [DataMember(Name = "config", EmitDefaultValue = false)]
    public Dictionary<string, object> Config { get; set; }

    /// <summary>
    ///     Gets or Sets Id
    /// </summary>
    [DataMember(Name = "id", EmitDefaultValue = false)]
    public string Id { get; set; }

    /// <summary>
    ///     Gets or Sets Name
    /// </summary>
    [DataMember(Name = "name", EmitDefaultValue = false)]
    public string Name { get; set; }

    /// <summary>
    ///     Gets or Sets Protocol
    /// </summary>
    [DataMember(Name = "protocol", EmitDefaultValue = false)]
    public string Protocol { get; set; }

    /// <summary>
    ///     Gets or Sets ProtocolMapper
    /// </summary>
    [DataMember(Name = "protocolMapper", EmitDefaultValue = false)]
    public string ProtocolMapper { get; set; }

    /// <summary>
    ///     Returns true if ProtocolMapperRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of ProtocolMapperRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(ProtocolMapperRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                Config == input.Config ||
                (Config != null &&
                 input.Config != null &&
                 Config.SequenceEqual(input.Config))
            ) &&
            (
                Id == input.Id ||
                (Id != null &&
                 Id.Equals(input.Id))
            ) &&
            (
                Name == input.Name ||
                (Name != null &&
                 Name.Equals(input.Name))
            ) &&
            (
                Protocol == input.Protocol ||
                (Protocol != null &&
                 Protocol.Equals(input.Protocol))
            ) &&
            (
                ProtocolMapper == input.ProtocolMapper ||
                (ProtocolMapper != null &&
                 ProtocolMapper.Equals(input.ProtocolMapper))
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
        sb.Append("class ProtocolMapperRepresentation {\n");
        sb.Append("  Config: ").Append(Config).Append("\n");
        sb.Append("  Id: ").Append(Id).Append("\n");
        sb.Append("  Name: ").Append(Name).Append("\n");
        sb.Append("  Protocol: ").Append(Protocol).Append("\n");
        sb.Append("  ProtocolMapper: ").Append(ProtocolMapper).Append("\n");
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
        return Equals(input as ProtocolMapperRepresentation);
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
            if (Config != null)
                hashCode = hashCode * 59 + Config.GetHashCode();
            if (Id != null)
                hashCode = hashCode * 59 + Id.GetHashCode();
            if (Name != null)
                hashCode = hashCode * 59 + Name.GetHashCode();
            if (Protocol != null)
                hashCode = hashCode * 59 + Protocol.GetHashCode();
            if (ProtocolMapper != null)
                hashCode = hashCode * 59 + ProtocolMapper.GetHashCode();
            return hashCode;
        }
    }
}