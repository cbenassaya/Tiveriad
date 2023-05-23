#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     UserFederationMapperRepresentation
/// </summary>
[DataContract]
public class UserFederationMapperRepresentation : IEquatable<UserFederationMapperRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserFederationMapperRepresentation" /> class.
    /// </summary>
    /// <param name="config">config.</param>
    /// <param name="federationMapperType">federationMapperType.</param>
    /// <param name="federationProviderDisplayName">federationProviderDisplayName.</param>
    /// <param name="id">id.</param>
    /// <param name="name">name.</param>
    public UserFederationMapperRepresentation(Dictionary<string, object> config = default,
        string federationMapperType = default, string federationProviderDisplayName = default, string id = default,
        string name = default)
    {
        Config = config;
        FederationMapperType = federationMapperType;
        FederationProviderDisplayName = federationProviderDisplayName;
        Id = id;
        Name = name;
    }

    /// <summary>
    ///     Gets or Sets Config
    /// </summary>
    [DataMember(Name = "config", EmitDefaultValue = false)]
    public Dictionary<string, object> Config { get; set; }

    /// <summary>
    ///     Gets or Sets FederationMapperType
    /// </summary>
    [DataMember(Name = "federationMapperType", EmitDefaultValue = false)]
    public string FederationMapperType { get; set; }

    /// <summary>
    ///     Gets or Sets FederationProviderDisplayName
    /// </summary>
    [DataMember(Name = "federationProviderDisplayName", EmitDefaultValue = false)]
    public string FederationProviderDisplayName { get; set; }

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
    ///     Returns true if UserFederationMapperRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of UserFederationMapperRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(UserFederationMapperRepresentation input)
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
                FederationMapperType == input.FederationMapperType ||
                (FederationMapperType != null &&
                 FederationMapperType.Equals(input.FederationMapperType))
            ) &&
            (
                FederationProviderDisplayName == input.FederationProviderDisplayName ||
                (FederationProviderDisplayName != null &&
                 FederationProviderDisplayName.Equals(input.FederationProviderDisplayName))
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
        sb.Append("class UserFederationMapperRepresentation {\n");
        sb.Append("  Config: ").Append(Config).Append("\n");
        sb.Append("  FederationMapperType: ").Append(FederationMapperType).Append("\n");
        sb.Append("  FederationProviderDisplayName: ").Append(FederationProviderDisplayName).Append("\n");
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
        return Equals(input as UserFederationMapperRepresentation);
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
            if (FederationMapperType != null)
                hashCode = hashCode * 59 + FederationMapperType.GetHashCode();
            if (FederationProviderDisplayName != null)
                hashCode = hashCode * 59 + FederationProviderDisplayName.GetHashCode();
            if (Id != null)
                hashCode = hashCode * 59 + Id.GetHashCode();
            if (Name != null)
                hashCode = hashCode * 59 + Name.GetHashCode();
            return hashCode;
        }
    }
}