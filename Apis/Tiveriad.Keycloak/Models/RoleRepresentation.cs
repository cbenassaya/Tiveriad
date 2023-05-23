#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     RoleRepresentation
/// </summary>
[DataContract]
public class RoleRepresentation : IEquatable<RoleRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="RoleRepresentation" /> class.
    /// </summary>
    /// <param name="attributes">attributes.</param>
    /// <param name="clientRole">clientRole.</param>
    /// <param name="composite">composite.</param>
    /// <param name="composites">composites.</param>
    /// <param name="containerId">containerId.</param>
    /// <param name="description">description.</param>
    /// <param name="id">id.</param>
    /// <param name="name">name.</param>
    public RoleRepresentation(Dictionary<string, object> attributes = default, bool? clientRole = default,
        bool? composite = default, RoleRepresentationComposites composites = default, string containerId = default,
        string description = default, string id = default, string name = default)
    {
        Attributes = attributes;
        ClientRole = clientRole;
        Composite = composite;
        Composites = composites;
        ContainerId = containerId;
        Description = description;
        Id = id;
        Name = name;
    }

    /// <summary>
    ///     Gets or Sets Attributes
    /// </summary>
    [DataMember(Name = "attributes", EmitDefaultValue = false)]
    public Dictionary<string, object> Attributes { get; set; }

    /// <summary>
    ///     Gets or Sets ClientRole
    /// </summary>
    [DataMember(Name = "clientRole", EmitDefaultValue = false)]
    public bool? ClientRole { get; set; }

    /// <summary>
    ///     Gets or Sets Composite
    /// </summary>
    [DataMember(Name = "composite", EmitDefaultValue = false)]
    public bool? Composite { get; set; }

    /// <summary>
    ///     Gets or Sets Composites
    /// </summary>
    [DataMember(Name = "composites", EmitDefaultValue = false)]
    public RoleRepresentationComposites Composites { get; set; }

    /// <summary>
    ///     Gets or Sets ContainerId
    /// </summary>
    [DataMember(Name = "containerId", EmitDefaultValue = false)]
    public string ContainerId { get; set; }

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
    ///     Returns true if RoleRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of RoleRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(RoleRepresentation input)
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
                ClientRole == input.ClientRole ||
                (ClientRole != null &&
                 ClientRole.Equals(input.ClientRole))
            ) &&
            (
                Composite == input.Composite ||
                (Composite != null &&
                 Composite.Equals(input.Composite))
            ) &&
            (
                Composites == input.Composites ||
                (Composites != null &&
                 Composites.Equals(input.Composites))
            ) &&
            (
                ContainerId == input.ContainerId ||
                (ContainerId != null &&
                 ContainerId.Equals(input.ContainerId))
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
        sb.Append("class RoleRepresentation {\n");
        sb.Append("  Attributes: ").Append(Attributes).Append("\n");
        sb.Append("  ClientRole: ").Append(ClientRole).Append("\n");
        sb.Append("  Composite: ").Append(Composite).Append("\n");
        sb.Append("  Composites: ").Append(Composites).Append("\n");
        sb.Append("  ContainerId: ").Append(ContainerId).Append("\n");
        sb.Append("  Description: ").Append(Description).Append("\n");
        sb.Append("  Id: ").Append(Id).Append("\n");
        sb.Append("  Name: ").Append(Name).Append("\n");
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
        return Equals(input as RoleRepresentation);
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
            if (ClientRole != null)
                hashCode = hashCode * 59 + ClientRole.GetHashCode();
            if (Composite != null)
                hashCode = hashCode * 59 + Composite.GetHashCode();
            if (Composites != null)
                hashCode = hashCode * 59 + Composites.GetHashCode();
            if (ContainerId != null)
                hashCode = hashCode * 59 + ContainerId.GetHashCode();
            if (Description != null)
                hashCode = hashCode * 59 + Description.GetHashCode();
            if (Id != null)
                hashCode = hashCode * 59 + Id.GetHashCode();
            if (Name != null)
                hashCode = hashCode * 59 + Name.GetHashCode();
            return hashCode;
        }
    }
}