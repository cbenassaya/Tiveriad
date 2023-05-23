#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     IdentityProviderMapperRepresentation
/// </summary>
[DataContract]
public class IdentityProviderMapperRepresentation : IEquatable<IdentityProviderMapperRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="IdentityProviderMapperRepresentation" /> class.
    /// </summary>
    /// <param name="config">config.</param>
    /// <param name="id">id.</param>
    /// <param name="identityProviderAlias">identityProviderAlias.</param>
    /// <param name="identityProviderMapper">identityProviderMapper.</param>
    /// <param name="name">name.</param>
    public IdentityProviderMapperRepresentation(Dictionary<string, object> config = default, string id = default,
        string identityProviderAlias = default, string identityProviderMapper = default, string name = default)
    {
        Config = config;
        Id = id;
        IdentityProviderAlias = identityProviderAlias;
        IdentityProviderMapper = identityProviderMapper;
        Name = name;
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
    ///     Gets or Sets IdentityProviderAlias
    /// </summary>
    [DataMember(Name = "identityProviderAlias", EmitDefaultValue = false)]
    public string IdentityProviderAlias { get; set; }

    /// <summary>
    ///     Gets or Sets IdentityProviderMapper
    /// </summary>
    [DataMember(Name = "identityProviderMapper", EmitDefaultValue = false)]
    public string IdentityProviderMapper { get; set; }

    /// <summary>
    ///     Gets or Sets Name
    /// </summary>
    [DataMember(Name = "name", EmitDefaultValue = false)]
    public string Name { get; set; }

    /// <summary>
    ///     Returns true if IdentityProviderMapperRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of IdentityProviderMapperRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(IdentityProviderMapperRepresentation input)
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
                IdentityProviderAlias == input.IdentityProviderAlias ||
                (IdentityProviderAlias != null &&
                 IdentityProviderAlias.Equals(input.IdentityProviderAlias))
            ) &&
            (
                IdentityProviderMapper == input.IdentityProviderMapper ||
                (IdentityProviderMapper != null &&
                 IdentityProviderMapper.Equals(input.IdentityProviderMapper))
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
        sb.Append("class IdentityProviderMapperRepresentation {\n");
        sb.Append("  Config: ").Append(Config).Append("\n");
        sb.Append("  Id: ").Append(Id).Append("\n");
        sb.Append("  IdentityProviderAlias: ").Append(IdentityProviderAlias).Append("\n");
        sb.Append("  IdentityProviderMapper: ").Append(IdentityProviderMapper).Append("\n");
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
        return Equals(input as IdentityProviderMapperRepresentation);
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
            if (IdentityProviderAlias != null)
                hashCode = hashCode * 59 + IdentityProviderAlias.GetHashCode();
            if (IdentityProviderMapper != null)
                hashCode = hashCode * 59 + IdentityProviderMapper.GetHashCode();
            if (Name != null)
                hashCode = hashCode * 59 + Name.GetHashCode();
            return hashCode;
        }
    }
}