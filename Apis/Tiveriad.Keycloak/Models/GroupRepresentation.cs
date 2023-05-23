#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     GroupRepresentation
/// </summary>
[DataContract]
public class GroupRepresentation : IEquatable<GroupRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="GroupRepresentation" /> class.
    /// </summary>
    /// <param name="access">access.</param>
    /// <param name="attributes">attributes.</param>
    /// <param name="clientRoles">clientRoles.</param>
    /// <param name="id">id.</param>
    /// <param name="name">name.</param>
    /// <param name="path">path.</param>
    /// <param name="realmRoles">realmRoles.</param>
    /// <param name="subGroups">subGroups.</param>
    public GroupRepresentation(Dictionary<string, object> access = default,
        Dictionary<string, object> attributes = default, Dictionary<string, object> clientRoles = default,
        string id = default, string name = default, string path = default, List<string> realmRoles = default,
        List<GroupRepresentation> subGroups = default)
    {
        Access = access;
        Attributes = attributes;
        ClientRoles = clientRoles;
        Id = id;
        Name = name;
        Path = path;
        RealmRoles = realmRoles;
        SubGroups = subGroups;
    }

    /// <summary>
    ///     Gets or Sets Access
    /// </summary>
    [DataMember(Name = "access", EmitDefaultValue = false)]
    public Dictionary<string, object> Access { get; set; }

    /// <summary>
    ///     Gets or Sets Attributes
    /// </summary>
    [DataMember(Name = "attributes", EmitDefaultValue = false)]
    public Dictionary<string, object> Attributes { get; set; }

    /// <summary>
    ///     Gets or Sets ClientRoles
    /// </summary>
    [DataMember(Name = "clientRoles", EmitDefaultValue = false)]
    public Dictionary<string, object> ClientRoles { get; set; }

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
    ///     Gets or Sets Path
    /// </summary>
    [DataMember(Name = "path", EmitDefaultValue = false)]
    public string Path { get; set; }

    /// <summary>
    ///     Gets or Sets RealmRoles
    /// </summary>
    [DataMember(Name = "realmRoles", EmitDefaultValue = false)]
    public List<string> RealmRoles { get; set; }

    /// <summary>
    ///     Gets or Sets SubGroups
    /// </summary>
    [DataMember(Name = "subGroups", EmitDefaultValue = false)]
    public List<GroupRepresentation> SubGroups { get; set; }

    /// <summary>
    ///     Returns true if GroupRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of GroupRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(GroupRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                Access == input.Access ||
                (Access != null &&
                 input.Access != null &&
                 Access.SequenceEqual(input.Access))
            ) &&
            (
                Attributes == input.Attributes ||
                (Attributes != null &&
                 input.Attributes != null &&
                 Attributes.SequenceEqual(input.Attributes))
            ) &&
            (
                ClientRoles == input.ClientRoles ||
                (ClientRoles != null &&
                 input.ClientRoles != null &&
                 ClientRoles.SequenceEqual(input.ClientRoles))
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
                Path == input.Path ||
                (Path != null &&
                 Path.Equals(input.Path))
            ) &&
            (
                RealmRoles == input.RealmRoles ||
                (RealmRoles != null &&
                 input.RealmRoles != null &&
                 RealmRoles.SequenceEqual(input.RealmRoles))
            ) &&
            (
                SubGroups == input.SubGroups ||
                (SubGroups != null &&
                 input.SubGroups != null &&
                 SubGroups.SequenceEqual(input.SubGroups))
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
        sb.Append("class GroupRepresentation {\n");
        sb.Append("  Access: ").Append(Access).Append("\n");
        sb.Append("  Attributes: ").Append(Attributes).Append("\n");
        sb.Append("  ClientRoles: ").Append(ClientRoles).Append("\n");
        sb.Append("  Id: ").Append(Id).Append("\n");
        sb.Append("  Name: ").Append(Name).Append("\n");
        sb.Append("  Path: ").Append(Path).Append("\n");
        sb.Append("  RealmRoles: ").Append(RealmRoles).Append("\n");
        sb.Append("  SubGroups: ").Append(SubGroups).Append("\n");
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
        return Equals(input as GroupRepresentation);
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
            if (Access != null)
                hashCode = hashCode * 59 + Access.GetHashCode();
            if (Attributes != null)
                hashCode = hashCode * 59 + Attributes.GetHashCode();
            if (ClientRoles != null)
                hashCode = hashCode * 59 + ClientRoles.GetHashCode();
            if (Id != null)
                hashCode = hashCode * 59 + Id.GetHashCode();
            if (Name != null)
                hashCode = hashCode * 59 + Name.GetHashCode();
            if (Path != null)
                hashCode = hashCode * 59 + Path.GetHashCode();
            if (RealmRoles != null)
                hashCode = hashCode * 59 + RealmRoles.GetHashCode();
            if (SubGroups != null)
                hashCode = hashCode * 59 + SubGroups.GetHashCode();
            return hashCode;
        }
    }
}