#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     ResourceRepresentation
/// </summary>
[DataContract]
public class ResourceRepresentation : IEquatable<ResourceRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ResourceRepresentation" /> class.
    /// </summary>
    /// <param name="id">id.</param>
    /// <param name="attributes">attributes.</param>
    /// <param name="displayName">displayName.</param>
    /// <param name="iconUri">iconUri.</param>
    /// <param name="name">name.</param>
    /// <param name="ownerManagedAccess">ownerManagedAccess.</param>
    /// <param name="scopes">scopes.</param>
    /// <param name="type">type.</param>
    /// <param name="uris">uris.</param>
    public ResourceRepresentation(string id = default, Dictionary<string, object> attributes = default,
        string displayName = default, string iconUri = default, string name = default,
        bool? ownerManagedAccess = default, List<ScopeRepresentation> scopes = default, string type = default,
        List<string> uris = default)
    {
        Id = id;
        Attributes = attributes;
        DisplayName = displayName;
        IconUri = iconUri;
        Name = name;
        OwnerManagedAccess = ownerManagedAccess;
        Scopes = scopes;
        Type = type;
        Uris = uris;
    }

    /// <summary>
    ///     Gets or Sets Id
    /// </summary>
    [DataMember(Name = "id", EmitDefaultValue = false)]
    public string Id { get; set; }

    /// <summary>
    ///     Gets or Sets Attributes
    /// </summary>
    [DataMember(Name = "attributes", EmitDefaultValue = false)]
    public Dictionary<string, object> Attributes { get; set; }

    /// <summary>
    ///     Gets or Sets DisplayName
    /// </summary>
    [DataMember(Name = "displayName", EmitDefaultValue = false)]
    public string DisplayName { get; set; }

    /// <summary>
    ///     Gets or Sets IconUri
    /// </summary>
    [DataMember(Name = "icon_uri", EmitDefaultValue = false)]
    public string IconUri { get; set; }

    /// <summary>
    ///     Gets or Sets Name
    /// </summary>
    [DataMember(Name = "name", EmitDefaultValue = false)]
    public string Name { get; set; }

    /// <summary>
    ///     Gets or Sets OwnerManagedAccess
    /// </summary>
    [DataMember(Name = "ownerManagedAccess", EmitDefaultValue = false)]
    public bool? OwnerManagedAccess { get; set; }

    /// <summary>
    ///     Gets or Sets Scopes
    /// </summary>
    [DataMember(Name = "scopes", EmitDefaultValue = false)]
    public List<ScopeRepresentation> Scopes { get; set; }

    /// <summary>
    ///     Gets or Sets Type
    /// </summary>
    [DataMember(Name = "type", EmitDefaultValue = false)]
    public string Type { get; set; }

    /// <summary>
    ///     Gets or Sets Uris
    /// </summary>
    [DataMember(Name = "uris", EmitDefaultValue = false)]
    public List<string> Uris { get; set; }

    /// <summary>
    ///     Returns true if ResourceRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of ResourceRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(ResourceRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                Id == input.Id ||
                (Id != null &&
                 Id.Equals(input.Id))
            ) &&
            (
                Attributes == input.Attributes ||
                (Attributes != null &&
                 input.Attributes != null &&
                 Attributes.SequenceEqual(input.Attributes))
            ) &&
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
                Name == input.Name ||
                (Name != null &&
                 Name.Equals(input.Name))
            ) &&
            (
                OwnerManagedAccess == input.OwnerManagedAccess ||
                (OwnerManagedAccess != null &&
                 OwnerManagedAccess.Equals(input.OwnerManagedAccess))
            ) &&
            (
                Scopes == input.Scopes ||
                (Scopes != null &&
                 input.Scopes != null &&
                 Scopes.SequenceEqual(input.Scopes))
            ) &&
            (
                Type == input.Type ||
                (Type != null &&
                 Type.Equals(input.Type))
            ) &&
            (
                Uris == input.Uris ||
                (Uris != null &&
                 input.Uris != null &&
                 Uris.SequenceEqual(input.Uris))
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
        sb.Append("class ResourceRepresentation {\n");
        sb.Append("  Id: ").Append(Id).Append("\n");
        sb.Append("  Attributes: ").Append(Attributes).Append("\n");
        sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
        sb.Append("  IconUri: ").Append(IconUri).Append("\n");
        sb.Append("  Name: ").Append(Name).Append("\n");
        sb.Append("  OwnerManagedAccess: ").Append(OwnerManagedAccess).Append("\n");
        sb.Append("  Scopes: ").Append(Scopes).Append("\n");
        sb.Append("  Type: ").Append(Type).Append("\n");
        sb.Append("  Uris: ").Append(Uris).Append("\n");
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
        return Equals(input as ResourceRepresentation);
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
            if (Id != null)
                hashCode = hashCode * 59 + Id.GetHashCode();
            if (Attributes != null)
                hashCode = hashCode * 59 + Attributes.GetHashCode();
            if (DisplayName != null)
                hashCode = hashCode * 59 + DisplayName.GetHashCode();
            if (IconUri != null)
                hashCode = hashCode * 59 + IconUri.GetHashCode();
            if (Name != null)
                hashCode = hashCode * 59 + Name.GetHashCode();
            if (OwnerManagedAccess != null)
                hashCode = hashCode * 59 + OwnerManagedAccess.GetHashCode();
            if (Scopes != null)
                hashCode = hashCode * 59 + Scopes.GetHashCode();
            if (Type != null)
                hashCode = hashCode * 59 + Type.GetHashCode();
            if (Uris != null)
                hashCode = hashCode * 59 + Uris.GetHashCode();
            return hashCode;
        }
    }
}