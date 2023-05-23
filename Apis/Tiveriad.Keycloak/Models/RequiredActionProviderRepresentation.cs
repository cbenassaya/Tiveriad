#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     RequiredActionProviderRepresentation
/// </summary>
[DataContract]
public class RequiredActionProviderRepresentation : IEquatable<RequiredActionProviderRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="RequiredActionProviderRepresentation" /> class.
    /// </summary>
    /// <param name="alias">alias.</param>
    /// <param name="config">config.</param>
    /// <param name="defaultAction">defaultAction.</param>
    /// <param name="enabled">enabled.</param>
    /// <param name="name">name.</param>
    /// <param name="priority">priority.</param>
    /// <param name="providerId">providerId.</param>
    public RequiredActionProviderRepresentation(string alias = default, Dictionary<string, object> config = default,
        bool? defaultAction = default, bool? enabled = default, string name = default, int? priority = default,
        string providerId = default)
    {
        Alias = alias;
        Config = config;
        DefaultAction = defaultAction;
        Enabled = enabled;
        Name = name;
        Priority = priority;
        ProviderId = providerId;
    }

    /// <summary>
    ///     Gets or Sets Alias
    /// </summary>
    [DataMember(Name = "alias", EmitDefaultValue = false)]
    public string Alias { get; set; }

    /// <summary>
    ///     Gets or Sets Config
    /// </summary>
    [DataMember(Name = "config", EmitDefaultValue = false)]
    public Dictionary<string, object> Config { get; set; }

    /// <summary>
    ///     Gets or Sets DefaultAction
    /// </summary>
    [DataMember(Name = "defaultAction", EmitDefaultValue = false)]
    public bool? DefaultAction { get; set; }

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
    ///     Gets or Sets Priority
    /// </summary>
    [DataMember(Name = "priority", EmitDefaultValue = false)]
    public int? Priority { get; set; }

    /// <summary>
    ///     Gets or Sets ProviderId
    /// </summary>
    [DataMember(Name = "providerId", EmitDefaultValue = false)]
    public string ProviderId { get; set; }

    /// <summary>
    ///     Returns true if RequiredActionProviderRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of RequiredActionProviderRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(RequiredActionProviderRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                Alias == input.Alias ||
                (Alias != null &&
                 Alias.Equals(input.Alias))
            ) &&
            (
                Config == input.Config ||
                (Config != null &&
                 input.Config != null &&
                 Config.SequenceEqual(input.Config))
            ) &&
            (
                DefaultAction == input.DefaultAction ||
                (DefaultAction != null &&
                 DefaultAction.Equals(input.DefaultAction))
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
                Priority == input.Priority ||
                (Priority != null &&
                 Priority.Equals(input.Priority))
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
        sb.Append("class RequiredActionProviderRepresentation {\n");
        sb.Append("  Alias: ").Append(Alias).Append("\n");
        sb.Append("  Config: ").Append(Config).Append("\n");
        sb.Append("  DefaultAction: ").Append(DefaultAction).Append("\n");
        sb.Append("  Enabled: ").Append(Enabled).Append("\n");
        sb.Append("  Name: ").Append(Name).Append("\n");
        sb.Append("  Priority: ").Append(Priority).Append("\n");
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
        return Equals(input as RequiredActionProviderRepresentation);
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
            if (Alias != null)
                hashCode = hashCode * 59 + Alias.GetHashCode();
            if (Config != null)
                hashCode = hashCode * 59 + Config.GetHashCode();
            if (DefaultAction != null)
                hashCode = hashCode * 59 + DefaultAction.GetHashCode();
            if (Enabled != null)
                hashCode = hashCode * 59 + Enabled.GetHashCode();
            if (Name != null)
                hashCode = hashCode * 59 + Name.GetHashCode();
            if (Priority != null)
                hashCode = hashCode * 59 + Priority.GetHashCode();
            if (ProviderId != null)
                hashCode = hashCode * 59 + ProviderId.GetHashCode();
            return hashCode;
        }
    }
}