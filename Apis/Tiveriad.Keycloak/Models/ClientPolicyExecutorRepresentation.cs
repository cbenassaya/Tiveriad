#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     ClientPolicyExecutorRepresentation
/// </summary>
[DataContract]
public class ClientPolicyExecutorRepresentation : IEquatable<ClientPolicyExecutorRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ClientPolicyExecutorRepresentation" /> class.
    /// </summary>
    /// <param name="configuration">configuration.</param>
    /// <param name="executor">executor.</param>
    public ClientPolicyExecutorRepresentation(JsonNode configuration = default, string executor = default)
    {
        Configuration = configuration;
        Executor = executor;
    }

    /// <summary>
    ///     Gets or Sets Configuration
    /// </summary>
    [DataMember(Name = "configuration", EmitDefaultValue = false)]
    public JsonNode Configuration { get; set; }

    /// <summary>
    ///     Gets or Sets Executor
    /// </summary>
    [DataMember(Name = "executor", EmitDefaultValue = false)]
    public string Executor { get; set; }

    /// <summary>
    ///     Returns true if ClientPolicyExecutorRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of ClientPolicyExecutorRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(ClientPolicyExecutorRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                Configuration == input.Configuration ||
                (Configuration != null &&
                 Configuration.Equals(input.Configuration))
            ) &&
            (
                Executor == input.Executor ||
                (Executor != null &&
                 Executor.Equals(input.Executor))
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
        sb.Append("class ClientPolicyExecutorRepresentation {\n");
        sb.Append("  Configuration: ").Append(Configuration).Append("\n");
        sb.Append("  Executor: ").Append(Executor).Append("\n");
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
        return Equals(input as ClientPolicyExecutorRepresentation);
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
            if (Configuration != null)
                hashCode = hashCode * 59 + Configuration.GetHashCode();
            if (Executor != null)
                hashCode = hashCode * 59 + Executor.GetHashCode();
            return hashCode;
        }
    }
}