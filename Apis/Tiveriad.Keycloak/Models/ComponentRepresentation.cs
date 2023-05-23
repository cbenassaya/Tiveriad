#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     ComponentRepresentation
/// </summary>
[DataContract]
public class ComponentRepresentation : IEquatable<ComponentRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ComponentRepresentation" /> class.
    /// </summary>
    /// <param name="config">config.</param>
    /// <param name="id">id.</param>
    /// <param name="name">name.</param>
    /// <param name="parentId">parentId.</param>
    /// <param name="providerId">providerId.</param>
    /// <param name="providerType">providerType.</param>
    /// <param name="subType">subType.</param>
    public ComponentRepresentation(MultivaluedHashMap config = default, string id = default, string name = default,
        string parentId = default, string providerId = default, string providerType = default, string subType = default)
    {
        Config = config;
        Id = id;
        Name = name;
        ParentId = parentId;
        ProviderId = providerId;
        ProviderType = providerType;
        SubType = subType;
    }

    /// <summary>
    ///     Gets or Sets Config
    /// </summary>
    [DataMember(Name = "config", EmitDefaultValue = false)]
    public MultivaluedHashMap Config { get; set; }

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
    ///     Gets or Sets ParentId
    /// </summary>
    [DataMember(Name = "parentId", EmitDefaultValue = false)]
    public string ParentId { get; set; }

    /// <summary>
    ///     Gets or Sets ProviderId
    /// </summary>
    [DataMember(Name = "providerId", EmitDefaultValue = false)]
    public string ProviderId { get; set; }

    /// <summary>
    ///     Gets or Sets ProviderType
    /// </summary>
    [DataMember(Name = "providerType", EmitDefaultValue = false)]
    public string ProviderType { get; set; }

    /// <summary>
    ///     Gets or Sets SubType
    /// </summary>
    [DataMember(Name = "subType", EmitDefaultValue = false)]
    public string SubType { get; set; }

    /// <summary>
    ///     Returns true if ComponentRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of ComponentRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(ComponentRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                Config == input.Config ||
                (Config != null &&
                 Config.Equals(input.Config))
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
                ParentId == input.ParentId ||
                (ParentId != null &&
                 ParentId.Equals(input.ParentId))
            ) &&
            (
                ProviderId == input.ProviderId ||
                (ProviderId != null &&
                 ProviderId.Equals(input.ProviderId))
            ) &&
            (
                ProviderType == input.ProviderType ||
                (ProviderType != null &&
                 ProviderType.Equals(input.ProviderType))
            ) &&
            (
                SubType == input.SubType ||
                (SubType != null &&
                 SubType.Equals(input.SubType))
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
        sb.Append("class ComponentRepresentation {\n");
        sb.Append("  Config: ").Append(Config).Append("\n");
        sb.Append("  Id: ").Append(Id).Append("\n");
        sb.Append("  Name: ").Append(Name).Append("\n");
        sb.Append("  ParentId: ").Append(ParentId).Append("\n");
        sb.Append("  ProviderId: ").Append(ProviderId).Append("\n");
        sb.Append("  ProviderType: ").Append(ProviderType).Append("\n");
        sb.Append("  SubType: ").Append(SubType).Append("\n");
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
        return Equals(input as ComponentRepresentation);
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
            if (ParentId != null)
                hashCode = hashCode * 59 + ParentId.GetHashCode();
            if (ProviderId != null)
                hashCode = hashCode * 59 + ProviderId.GetHashCode();
            if (ProviderType != null)
                hashCode = hashCode * 59 + ProviderType.GetHashCode();
            if (SubType != null)
                hashCode = hashCode * 59 + SubType.GetHashCode();
            return hashCode;
        }
    }
}