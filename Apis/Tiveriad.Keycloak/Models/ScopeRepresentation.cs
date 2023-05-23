#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     ScopeRepresentation
/// </summary>
[DataContract]
public class ScopeRepresentation : IEquatable<ScopeRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ScopeRepresentation" /> class.
    /// </summary>
    /// <param name="displayName">displayName.</param>
    /// <param name="iconUri">iconUri.</param>
    /// <param name="id">id.</param>
    /// <param name="name">name.</param>
    /// <param name="policies">policies.</param>
    /// <param name="resources">resources.</param>
    public ScopeRepresentation(string displayName = default, string iconUri = default, string id = default,
        string name = default, List<PolicyRepresentation> policies = default,
        List<ResourceRepresentation> resources = default)
    {
        DisplayName = displayName;
        IconUri = iconUri;
        Id = id;
        Name = name;
        Policies = policies;
        Resources = resources;
    }

    /// <summary>
    ///     Gets or Sets DisplayName
    /// </summary>
    [DataMember(Name = "displayName", EmitDefaultValue = false)]
    public string DisplayName { get; set; }

    /// <summary>
    ///     Gets or Sets IconUri
    /// </summary>
    [DataMember(Name = "iconUri", EmitDefaultValue = false)]
    public string IconUri { get; set; }

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
    ///     Gets or Sets Policies
    /// </summary>
    [DataMember(Name = "policies", EmitDefaultValue = false)]
    public List<PolicyRepresentation> Policies { get; set; }

    /// <summary>
    ///     Gets or Sets Resources
    /// </summary>
    [DataMember(Name = "resources", EmitDefaultValue = false)]
    public List<ResourceRepresentation> Resources { get; set; }

    /// <summary>
    ///     Returns true if ScopeRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of ScopeRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(ScopeRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                DisplayName == input.DisplayName ||
                (DisplayName != null &&
                 DisplayName.Equals(input.DisplayName))
            ) &&
            (
                IconUri == input.IconUri ||
                (IconUri != null &&
                 IconUri.Equals(input.IconUri))
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
                Policies == input.Policies ||
                (Policies != null &&
                 input.Policies != null &&
                 Policies.SequenceEqual(input.Policies))
            ) &&
            (
                Resources == input.Resources ||
                (Resources != null &&
                 input.Resources != null &&
                 Resources.SequenceEqual(input.Resources))
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
        sb.Append("class ScopeRepresentation {\n");
        sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
        sb.Append("  IconUri: ").Append(IconUri).Append("\n");
        sb.Append("  Id: ").Append(Id).Append("\n");
        sb.Append("  Name: ").Append(Name).Append("\n");
        sb.Append("  Policies: ").Append(Policies).Append("\n");
        sb.Append("  Resources: ").Append(Resources).Append("\n");
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
        return Equals(input as ScopeRepresentation);
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
            if (DisplayName != null)
                hashCode = hashCode * 59 + DisplayName.GetHashCode();
            if (IconUri != null)
                hashCode = hashCode * 59 + IconUri.GetHashCode();
            if (Id != null)
                hashCode = hashCode * 59 + Id.GetHashCode();
            if (Name != null)
                hashCode = hashCode * 59 + Name.GetHashCode();
            if (Policies != null)
                hashCode = hashCode * 59 + Policies.GetHashCode();
            if (Resources != null)
                hashCode = hashCode * 59 + Resources.GetHashCode();
            return hashCode;
        }
    }
}