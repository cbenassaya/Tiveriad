#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     ConfigPropertyRepresentation
/// </summary>
[DataContract]
public class ConfigPropertyRepresentation : IEquatable<ConfigPropertyRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ConfigPropertyRepresentation" /> class.
    /// </summary>
    /// <param name="defaultValue">defaultValue.</param>
    /// <param name="helpText">helpText.</param>
    /// <param name="label">label.</param>
    /// <param name="name">name.</param>
    /// <param name="options">options.</param>
    /// <param name="secret">secret.</param>
    /// <param name="type">type.</param>
    public ConfigPropertyRepresentation(object defaultValue = default, string helpText = default,
        string label = default, string name = default, List<string> options = default, bool? secret = default,
        string type = default)
    {
        DefaultValue = defaultValue;
        HelpText = helpText;
        Label = label;
        Name = name;
        Options = options;
        Secret = secret;
        Type = type;
    }

    /// <summary>
    ///     Gets or Sets DefaultValue
    /// </summary>
    [DataMember(Name = "defaultValue", EmitDefaultValue = false)]
    public object DefaultValue { get; set; }

    /// <summary>
    ///     Gets or Sets HelpText
    /// </summary>
    [DataMember(Name = "helpText", EmitDefaultValue = false)]
    public string HelpText { get; set; }

    /// <summary>
    ///     Gets or Sets Label
    /// </summary>
    [DataMember(Name = "label", EmitDefaultValue = false)]
    public string Label { get; set; }

    /// <summary>
    ///     Gets or Sets Name
    /// </summary>
    [DataMember(Name = "name", EmitDefaultValue = false)]
    public string Name { get; set; }

    /// <summary>
    ///     Gets or Sets Options
    /// </summary>
    [DataMember(Name = "options", EmitDefaultValue = false)]
    public List<string> Options { get; set; }

    /// <summary>
    ///     Gets or Sets Secret
    /// </summary>
    [DataMember(Name = "secret", EmitDefaultValue = false)]
    public bool? Secret { get; set; }

    /// <summary>
    ///     Gets or Sets Type
    /// </summary>
    [DataMember(Name = "type", EmitDefaultValue = false)]
    public string Type { get; set; }

    /// <summary>
    ///     Returns true if ConfigPropertyRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of ConfigPropertyRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(ConfigPropertyRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                DefaultValue == input.DefaultValue ||
                (DefaultValue != null &&
                 DefaultValue.Equals(input.DefaultValue))
            ) &&
            (
                HelpText == input.HelpText ||
                (HelpText != null &&
                 HelpText.Equals(input.HelpText))
            ) &&
            (
                Label == input.Label ||
                (Label != null &&
                 Label.Equals(input.Label))
            ) &&
            (
                Name == input.Name ||
                (Name != null &&
                 Name.Equals(input.Name))
            ) &&
            (
                Options == input.Options ||
                (Options != null &&
                 input.Options != null &&
                 Options.SequenceEqual(input.Options))
            ) &&
            (
                Secret == input.Secret ||
                (Secret != null &&
                 Secret.Equals(input.Secret))
            ) &&
            (
                Type == input.Type ||
                (Type != null &&
                 Type.Equals(input.Type))
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
        sb.Append("class ConfigPropertyRepresentation {\n");
        sb.Append("  DefaultValue: ").Append(DefaultValue).Append("\n");
        sb.Append("  HelpText: ").Append(HelpText).Append("\n");
        sb.Append("  Label: ").Append(Label).Append("\n");
        sb.Append("  Name: ").Append(Name).Append("\n");
        sb.Append("  Options: ").Append(Options).Append("\n");
        sb.Append("  Secret: ").Append(Secret).Append("\n");
        sb.Append("  Type: ").Append(Type).Append("\n");
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
        return Equals(input as ConfigPropertyRepresentation);
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
            if (DefaultValue != null)
                hashCode = hashCode * 59 + DefaultValue.GetHashCode();
            if (HelpText != null)
                hashCode = hashCode * 59 + HelpText.GetHashCode();
            if (Label != null)
                hashCode = hashCode * 59 + Label.GetHashCode();
            if (Name != null)
                hashCode = hashCode * 59 + Name.GetHashCode();
            if (Options != null)
                hashCode = hashCode * 59 + Options.GetHashCode();
            if (Secret != null)
                hashCode = hashCode * 59 + Secret.GetHashCode();
            if (Type != null)
                hashCode = hashCode * 59 + Type.GetHashCode();
            return hashCode;
        }
    }
}