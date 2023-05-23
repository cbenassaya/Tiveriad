#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     AuthenticatorConfigInfoRepresentation
/// </summary>
[DataContract]
public class AuthenticatorConfigInfoRepresentation : IEquatable<AuthenticatorConfigInfoRepresentation>,
    IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AuthenticatorConfigInfoRepresentation" /> class.
    /// </summary>
    /// <param name="helpText">helpText.</param>
    /// <param name="name">name.</param>
    /// <param name="properties">properties.</param>
    /// <param name="providerId">providerId.</param>
    public AuthenticatorConfigInfoRepresentation(string helpText = default, string name = default,
        List<ConfigPropertyRepresentation> properties = default, string providerId = default)
    {
        HelpText = helpText;
        Name = name;
        Properties = properties;
        ProviderId = providerId;
    }

    /// <summary>
    ///     Gets or Sets HelpText
    /// </summary>
    [DataMember(Name = "helpText", EmitDefaultValue = false)]
    public string HelpText { get; set; }

    /// <summary>
    ///     Gets or Sets Name
    /// </summary>
    [DataMember(Name = "name", EmitDefaultValue = false)]
    public string Name { get; set; }

    /// <summary>
    ///     Gets or Sets Properties
    /// </summary>
    [DataMember(Name = "properties", EmitDefaultValue = false)]
    public List<ConfigPropertyRepresentation> Properties { get; set; }

    /// <summary>
    ///     Gets or Sets ProviderId
    /// </summary>
    [DataMember(Name = "providerId", EmitDefaultValue = false)]
    public string ProviderId { get; set; }

    /// <summary>
    ///     Returns true if AuthenticatorConfigInfoRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of AuthenticatorConfigInfoRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(AuthenticatorConfigInfoRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                HelpText == input.HelpText ||
                (HelpText != null &&
                 HelpText.Equals(input.HelpText))
            ) &&
            (
                Name == input.Name ||
                (Name != null &&
                 Name.Equals(input.Name))
            ) &&
            (
                Properties == input.Properties ||
                (Properties != null &&
                 input.Properties != null &&
                 Properties.SequenceEqual(input.Properties))
            ) &&
            (
                ProviderId == input.ProviderId ||
                (ProviderId != null &&
                 ProviderId.Equals(input.ProviderId))
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
        sb.Append("class AuthenticatorConfigInfoRepresentation {\n");
        sb.Append("  HelpText: ").Append(HelpText).Append("\n");
        sb.Append("  Name: ").Append(Name).Append("\n");
        sb.Append("  Properties: ").Append(Properties).Append("\n");
        sb.Append("  ProviderId: ").Append(ProviderId).Append("\n");
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
        return Equals(input as AuthenticatorConfigInfoRepresentation);
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
            if (HelpText != null)
                hashCode = hashCode * 59 + HelpText.GetHashCode();
            if (Name != null)
                hashCode = hashCode * 59 + Name.GetHashCode();
            if (Properties != null)
                hashCode = hashCode * 59 + Properties.GetHashCode();
            if (ProviderId != null)
                hashCode = hashCode * 59 + ProviderId.GetHashCode();
            return hashCode;
        }
    }
}