#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     PasswordPolicyTypeRepresentation
/// </summary>
[DataContract]
public class PasswordPolicyTypeRepresentation : IEquatable<PasswordPolicyTypeRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PasswordPolicyTypeRepresentation" /> class.
    /// </summary>
    /// <param name="configType">configType.</param>
    /// <param name="defaultValue">defaultValue.</param>
    /// <param name="displayName">displayName.</param>
    /// <param name="id">id.</param>
    /// <param name="multipleSupported">multipleSupported.</param>
    public PasswordPolicyTypeRepresentation(string configType = default, string defaultValue = default,
        string displayName = default, string id = default, bool? multipleSupported = default)
    {
        ConfigType = configType;
        DefaultValue = defaultValue;
        DisplayName = displayName;
        Id = id;
        MultipleSupported = multipleSupported;
    }

    /// <summary>
    ///     Gets or Sets ConfigType
    /// </summary>
    [DataMember(Name = "configType", EmitDefaultValue = false)]
    public string ConfigType { get; set; }

    /// <summary>
    ///     Gets or Sets DefaultValue
    /// </summary>
    [DataMember(Name = "defaultValue", EmitDefaultValue = false)]
    public string DefaultValue { get; set; }

    /// <summary>
    ///     Gets or Sets DisplayName
    /// </summary>
    [DataMember(Name = "displayName", EmitDefaultValue = false)]
    public string DisplayName { get; set; }

    /// <summary>
    ///     Gets or Sets Id
    /// </summary>
    [DataMember(Name = "id", EmitDefaultValue = false)]
    public string Id { get; set; }

    /// <summary>
    ///     Gets or Sets MultipleSupported
    /// </summary>
    [DataMember(Name = "multipleSupported", EmitDefaultValue = false)]
    public bool? MultipleSupported { get; set; }

    /// <summary>
    ///     Returns true if PasswordPolicyTypeRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of PasswordPolicyTypeRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(PasswordPolicyTypeRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                ConfigType == input.ConfigType ||
                (ConfigType != null &&
                 ConfigType.Equals(input.ConfigType))
            ) &&
            (
                DefaultValue == input.DefaultValue ||
                (DefaultValue != null &&
                 DefaultValue.Equals(input.DefaultValue))
            ) &&
            (
                DisplayName == input.DisplayName ||
                (DisplayName != null &&
                 DisplayName.Equals(input.DisplayName))
            ) &&
            (
                Id == input.Id ||
                (Id != null &&
                 Id.Equals(input.Id))
            ) &&
            (
                MultipleSupported == input.MultipleSupported ||
                (MultipleSupported != null &&
                 MultipleSupported.Equals(input.MultipleSupported))
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
        sb.Append("class PasswordPolicyTypeRepresentation {\n");
        sb.Append("  ConfigType: ").Append(ConfigType).Append("\n");
        sb.Append("  DefaultValue: ").Append(DefaultValue).Append("\n");
        sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
        sb.Append("  Id: ").Append(Id).Append("\n");
        sb.Append("  MultipleSupported: ").Append(MultipleSupported).Append("\n");
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
        return Equals(input as PasswordPolicyTypeRepresentation);
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
            if (ConfigType != null)
                hashCode = hashCode * 59 + ConfigType.GetHashCode();
            if (DefaultValue != null)
                hashCode = hashCode * 59 + DefaultValue.GetHashCode();
            if (DisplayName != null)
                hashCode = hashCode * 59 + DisplayName.GetHashCode();
            if (Id != null)
                hashCode = hashCode * 59 + Id.GetHashCode();
            if (MultipleSupported != null)
                hashCode = hashCode * 59 + MultipleSupported.GetHashCode();
            return hashCode;
        }
    }
}