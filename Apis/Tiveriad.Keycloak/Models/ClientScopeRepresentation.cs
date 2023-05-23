#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     ClientScopeRepresentation
/// </summary>
[DataContract]
public class ClientScopeRepresentation : IEquatable<ClientScopeRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ClientScopeRepresentation" /> class.
    /// </summary>
    /// <param name="attributes">attributes.</param>
    /// <param name="description">description.</param>
    /// <param name="id">id.</param>
    /// <param name="name">name.</param>
    /// <param name="protocol">protocol.</param>
    /// <param name="protocolMappers">protocolMappers.</param>
    public ClientScopeRepresentation(Dictionary<string, object> attributes = default, string description = default,
        string id = default, string name = default, string protocol = default,
        List<ProtocolMapperRepresentation> protocolMappers = default)
    {
        Attributes = attributes;
        Description = description;
        Id = id;
        Name = name;
        Protocol = protocol;
        ProtocolMappers = protocolMappers;
    }

    /// <summary>
    ///     Gets or Sets Attributes
    /// </summary>
    [DataMember(Name = "attributes", EmitDefaultValue = false)]
    public Dictionary<string, object> Attributes { get; set; }

    /// <summary>
    ///     Gets or Sets Description
    /// </summary>
    [DataMember(Name = "description", EmitDefaultValue = false)]
    public string Description { get; set; }

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
    ///     Gets or Sets ProtocolMappers
    /// </summary>
    [DataMember(Name = "protocolMappers", EmitDefaultValue = false)]
    public List<ProtocolMapperRepresentation> ProtocolMappers { get; set; }

    /// <summary>
    ///     Returns true if ClientScopeRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of ClientScopeRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(ClientScopeRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                Attributes == input.Attributes ||
                (Attributes != null &&
                 input.Attributes != null &&
                 Attributes.SequenceEqual(input.Attributes))
            ) &&
            (
                Description == input.Description ||
                (Description != null &&
                 Description.Equals(input.Description))
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
                ProtocolMappers == input.ProtocolMappers ||
                (ProtocolMappers != null &&
                 input.ProtocolMappers != null &&
                 ProtocolMappers.SequenceEqual(input.ProtocolMappers))
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
        sb.Append("class ClientScopeRepresentation {\n");
        sb.Append("  Attributes: ").Append(Attributes).Append("\n");
        sb.Append("  Description: ").Append(Description).Append("\n");
        sb.Append("  Id: ").Append(Id).Append("\n");
        sb.Append("  Name: ").Append(Name).Append("\n");
        sb.Append("  Protocol: ").Append(Protocol).Append("\n");
        sb.Append("  ProtocolMappers: ").Append(ProtocolMappers).Append("\n");
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
        return Equals(input as ClientScopeRepresentation);
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
            if (Attributes != null)
                hashCode = hashCode * 59 + Attributes.GetHashCode();
            if (Description != null)
                hashCode = hashCode * 59 + Description.GetHashCode();
            if (Id != null)
                hashCode = hashCode * 59 + Id.GetHashCode();
            if (Name != null)
                hashCode = hashCode * 59 + Name.GetHashCode();
            if (Protocol != null)
                hashCode = hashCode * 59 + Protocol.GetHashCode();
            if (ProtocolMappers != null)
                hashCode = hashCode * 59 + ProtocolMappers.GetHashCode();
            return hashCode;
        }
    }
}