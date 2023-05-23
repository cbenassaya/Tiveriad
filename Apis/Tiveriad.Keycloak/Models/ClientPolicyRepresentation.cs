#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     ClientPolicyRepresentation
/// </summary>
[DataContract]
public class ClientPolicyRepresentation : IEquatable<ClientPolicyRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ClientPolicyRepresentation" /> class.
    /// </summary>
    /// <param name="conditions">conditions.</param>
    /// <param name="description">description.</param>
    /// <param name="enabled">enabled.</param>
    /// <param name="name">name.</param>
    /// <param name="profiles">profiles.</param>
    public ClientPolicyRepresentation(List<ClientPolicyConditionRepresentation> conditions = default,
        string description = default, bool? enabled = default, string name = default, List<string> profiles = default)
    {
        Conditions = conditions;
        Description = description;
        Enabled = enabled;
        Name = name;
        Profiles = profiles;
    }

    /// <summary>
    ///     Gets or Sets Conditions
    /// </summary>
    [DataMember(Name = "conditions", EmitDefaultValue = false)]
    public List<ClientPolicyConditionRepresentation> Conditions { get; set; }

    /// <summary>
    ///     Gets or Sets Description
    /// </summary>
    [DataMember(Name = "description", EmitDefaultValue = false)]
    public string Description { get; set; }

    /// <summary>
    ///     Gets or Sets Enabled
    /// </summary>
    [DataMember(Name = "enabled", EmitDefaultValue = false)]
    public bool? Enabled { get; set; }

    /// <summary>
    ///     Gets or Sets Name
    /// </summary>
    [DataMember(Name = "name", EmitDefaultValue = false)]
    public string Name { get; set; }

    /// <summary>
    ///     Gets or Sets Profiles
    /// </summary>
    [DataMember(Name = "profiles", EmitDefaultValue = false)]
    public List<string> Profiles { get; set; }

    /// <summary>
    ///     Returns true if ClientPolicyRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of ClientPolicyRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(ClientPolicyRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                Conditions == input.Conditions ||
                (Conditions != null &&
                 input.Conditions != null &&
                 Conditions.SequenceEqual(input.Conditions))
            ) &&
            (
                Description == input.Description ||
                (Description != null &&
                 Description.Equals(input.Description))
            ) &&
            (
                Enabled == input.Enabled ||
                (Enabled != null &&
                 Enabled.Equals(input.Enabled))
            ) &&
            (
                Name == input.Name ||
                (Name != null &&
                 Name.Equals(input.Name))
            ) &&
            (
                Profiles == input.Profiles ||
                (Profiles != null &&
                 input.Profiles != null &&
                 Profiles.SequenceEqual(input.Profiles))
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
        sb.Append("class ClientPolicyRepresentation {\n");
        sb.Append("  Conditions: ").Append(Conditions).Append("\n");
        sb.Append("  Description: ").Append(Description).Append("\n");
        sb.Append("  Enabled: ").Append(Enabled).Append("\n");
        sb.Append("  Name: ").Append(Name).Append("\n");
        sb.Append("  Profiles: ").Append(Profiles).Append("\n");
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
        return Equals(input as ClientPolicyRepresentation);
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
            if (Conditions != null)
                hashCode = hashCode * 59 + Conditions.GetHashCode();
            if (Description != null)
                hashCode = hashCode * 59 + Description.GetHashCode();
            if (Enabled != null)
                hashCode = hashCode * 59 + Enabled.GetHashCode();
            if (Name != null)
                hashCode = hashCode * 59 + Name.GetHashCode();
            if (Profiles != null)
                hashCode = hashCode * 59 + Profiles.GetHashCode();
            return hashCode;
        }
    }
}