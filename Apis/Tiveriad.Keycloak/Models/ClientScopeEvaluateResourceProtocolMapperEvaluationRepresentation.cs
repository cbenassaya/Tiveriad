#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     ClientScopeEvaluateResourceProtocolMapperEvaluationRepresentation
/// </summary>
[DataContract]
public class ClientScopeEvaluateResourceProtocolMapperEvaluationRepresentation :
    IEquatable<ClientScopeEvaluateResourceProtocolMapperEvaluationRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ClientScopeEvaluateResourceProtocolMapperEvaluationRepresentation" />
    ///     class.
    /// </summary>
    /// <param name="containerId">containerId.</param>
    /// <param name="containerName">containerName.</param>
    /// <param name="containerType">containerType.</param>
    /// <param name="mapperId">mapperId.</param>
    /// <param name="mapperName">mapperName.</param>
    /// <param name="protocolMapper">protocolMapper.</param>
    public ClientScopeEvaluateResourceProtocolMapperEvaluationRepresentation(string containerId = default,
        string containerName = default, string containerType = default, string mapperId = default,
        string mapperName = default, string protocolMapper = default)
    {
        ContainerId = containerId;
        ContainerName = containerName;
        ContainerType = containerType;
        MapperId = mapperId;
        MapperName = mapperName;
        ProtocolMapper = protocolMapper;
    }

    /// <summary>
    ///     Gets or Sets ContainerId
    /// </summary>
    [DataMember(Name = "containerId", EmitDefaultValue = false)]
    public string ContainerId { get; set; }

    /// <summary>
    ///     Gets or Sets ContainerName
    /// </summary>
    [DataMember(Name = "containerName", EmitDefaultValue = false)]
    public string ContainerName { get; set; }

    /// <summary>
    ///     Gets or Sets ContainerType
    /// </summary>
    [DataMember(Name = "containerType", EmitDefaultValue = false)]
    public string ContainerType { get; set; }

    /// <summary>
    ///     Gets or Sets MapperId
    /// </summary>
    [DataMember(Name = "mapperId", EmitDefaultValue = false)]
    public string MapperId { get; set; }

    /// <summary>
    ///     Gets or Sets MapperName
    /// </summary>
    [DataMember(Name = "mapperName", EmitDefaultValue = false)]
    public string MapperName { get; set; }

    /// <summary>
    ///     Gets or Sets ProtocolMapper
    /// </summary>
    [DataMember(Name = "protocolMapper", EmitDefaultValue = false)]
    public string ProtocolMapper { get; set; }

    /// <summary>
    ///     Returns true if ClientScopeEvaluateResourceProtocolMapperEvaluationRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of ClientScopeEvaluateResourceProtocolMapperEvaluationRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(ClientScopeEvaluateResourceProtocolMapperEvaluationRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                ContainerId == input.ContainerId ||
                (ContainerId != null &&
                 ContainerId.Equals(input.ContainerId))
            ) &&
            (
                ContainerName == input.ContainerName ||
                (ContainerName != null &&
                 ContainerName.Equals(input.ContainerName))
            ) &&
            (
                ContainerType == input.ContainerType ||
                (ContainerType != null &&
                 ContainerType.Equals(input.ContainerType))
            ) &&
            (
                MapperId == input.MapperId ||
                (MapperId != null &&
                 MapperId.Equals(input.MapperId))
            ) &&
            (
                MapperName == input.MapperName ||
                (MapperName != null &&
                 MapperName.Equals(input.MapperName))
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
        sb.Append("class ClientScopeEvaluateResourceProtocolMapperEvaluationRepresentation {\n");
        sb.Append("  ContainerId: ").Append(ContainerId).Append("\n");
        sb.Append("  ContainerName: ").Append(ContainerName).Append("\n");
        sb.Append("  ContainerType: ").Append(ContainerType).Append("\n");
        sb.Append("  MapperId: ").Append(MapperId).Append("\n");
        sb.Append("  MapperName: ").Append(MapperName).Append("\n");
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
        return Equals(input as ClientScopeEvaluateResourceProtocolMapperEvaluationRepresentation);
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
            if (ContainerId != null)
                hashCode = hashCode * 59 + ContainerId.GetHashCode();
            if (ContainerName != null)
                hashCode = hashCode * 59 + ContainerName.GetHashCode();
            if (ContainerType != null)
                hashCode = hashCode * 59 + ContainerType.GetHashCode();
            if (MapperId != null)
                hashCode = hashCode * 59 + MapperId.GetHashCode();
            if (MapperName != null)
                hashCode = hashCode * 59 + MapperName.GetHashCode();
            if (ProtocolMapper != null)
                hashCode = hashCode * 59 + ProtocolMapper.GetHashCode();
            return hashCode;
        }
    }
}