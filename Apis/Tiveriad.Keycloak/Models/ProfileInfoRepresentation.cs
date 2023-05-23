#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     ProfileInfoRepresentation
/// </summary>
[DataContract]
public class ProfileInfoRepresentation : IEquatable<ProfileInfoRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ProfileInfoRepresentation" /> class.
    /// </summary>
    /// <param name="disabledFeatures">disabledFeatures.</param>
    /// <param name="experimentalFeatures">experimentalFeatures.</param>
    /// <param name="name">name.</param>
    /// <param name="previewFeatures">previewFeatures.</param>
    public ProfileInfoRepresentation(List<string> disabledFeatures = default,
        List<string> experimentalFeatures = default, string name = default, List<string> previewFeatures = default)
    {
        DisabledFeatures = disabledFeatures;
        ExperimentalFeatures = experimentalFeatures;
        Name = name;
        PreviewFeatures = previewFeatures;
    }

    /// <summary>
    ///     Gets or Sets DisabledFeatures
    /// </summary>
    [DataMember(Name = "disabledFeatures", EmitDefaultValue = false)]
    public List<string> DisabledFeatures { get; set; }

    /// <summary>
    ///     Gets or Sets ExperimentalFeatures
    /// </summary>
    [DataMember(Name = "experimentalFeatures", EmitDefaultValue = false)]
    public List<string> ExperimentalFeatures { get; set; }

    /// <summary>
    ///     Gets or Sets Name
    /// </summary>
    [DataMember(Name = "name", EmitDefaultValue = false)]
    public string Name { get; set; }

    /// <summary>
    ///     Gets or Sets PreviewFeatures
    /// </summary>
    [DataMember(Name = "previewFeatures", EmitDefaultValue = false)]
    public List<string> PreviewFeatures { get; set; }

    /// <summary>
    ///     Returns true if ProfileInfoRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of ProfileInfoRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(ProfileInfoRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                DisabledFeatures == input.DisabledFeatures ||
                (DisabledFeatures != null &&
                 input.DisabledFeatures != null &&
                 DisabledFeatures.SequenceEqual(input.DisabledFeatures))
            ) &&
            (
                ExperimentalFeatures == input.ExperimentalFeatures ||
                (ExperimentalFeatures != null &&
                 input.ExperimentalFeatures != null &&
                 ExperimentalFeatures.SequenceEqual(input.ExperimentalFeatures))
            ) &&
            (
                Name == input.Name ||
                (Name != null &&
                 Name.Equals(input.Name))
            ) &&
            (
                PreviewFeatures == input.PreviewFeatures ||
                (PreviewFeatures != null &&
                 input.PreviewFeatures != null &&
                 PreviewFeatures.SequenceEqual(input.PreviewFeatures))
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
        sb.Append("class ProfileInfoRepresentation {\n");
        sb.Append("  DisabledFeatures: ").Append(DisabledFeatures).Append("\n");
        sb.Append("  ExperimentalFeatures: ").Append(ExperimentalFeatures).Append("\n");
        sb.Append("  Name: ").Append(Name).Append("\n");
        sb.Append("  PreviewFeatures: ").Append(PreviewFeatures).Append("\n");
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
        return Equals(input as ProfileInfoRepresentation);
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
            if (DisabledFeatures != null)
                hashCode = hashCode * 59 + DisabledFeatures.GetHashCode();
            if (ExperimentalFeatures != null)
                hashCode = hashCode * 59 + ExperimentalFeatures.GetHashCode();
            if (Name != null)
                hashCode = hashCode * 59 + Name.GetHashCode();
            if (PreviewFeatures != null)
                hashCode = hashCode * 59 + PreviewFeatures.GetHashCode();
            return hashCode;
        }
    }
}