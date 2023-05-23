#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     AuthenticationExecutionRepresentation
/// </summary>
[DataContract]
public class AuthenticationExecutionRepresentation : IEquatable<AuthenticationExecutionRepresentation>,
    IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AuthenticationExecutionRepresentation" /> class.
    /// </summary>
    /// <param name="authenticator">authenticator.</param>
    /// <param name="authenticatorConfig">authenticatorConfig.</param>
    /// <param name="authenticatorFlow">authenticatorFlow.</param>
    /// <param name="flowId">flowId.</param>
    /// <param name="id">id.</param>
    /// <param name="parentFlow">parentFlow.</param>
    /// <param name="priority">priority.</param>
    /// <param name="requirement">requirement.</param>
    public AuthenticationExecutionRepresentation(string authenticator = default, string authenticatorConfig = default,
        bool? authenticatorFlow = default, string flowId = default, string id = default, string parentFlow = default,
        int? priority = default, string requirement = default)
    {
        Authenticator = authenticator;
        AuthenticatorConfig = authenticatorConfig;
        AuthenticatorFlow = authenticatorFlow;
        FlowId = flowId;
        Id = id;
        ParentFlow = parentFlow;
        Priority = priority;
        Requirement = requirement;
    }

    /// <summary>
    ///     Gets or Sets Authenticator
    /// </summary>
    [DataMember(Name = "authenticator", EmitDefaultValue = false)]
    public string Authenticator { get; set; }

    /// <summary>
    ///     Gets or Sets AuthenticatorConfig
    /// </summary>
    [DataMember(Name = "authenticatorConfig", EmitDefaultValue = false)]
    public string AuthenticatorConfig { get; set; }

    /// <summary>
    ///     Gets or Sets AuthenticatorFlow
    /// </summary>
    [DataMember(Name = "authenticatorFlow", EmitDefaultValue = false)]
    public bool? AuthenticatorFlow { get; set; }

    /// <summary>
    ///     Gets or Sets FlowId
    /// </summary>
    [DataMember(Name = "flowId", EmitDefaultValue = false)]
    public string FlowId { get; set; }

    /// <summary>
    ///     Gets or Sets Id
    /// </summary>
    [DataMember(Name = "id", EmitDefaultValue = false)]
    public string Id { get; set; }

    /// <summary>
    ///     Gets or Sets ParentFlow
    /// </summary>
    [DataMember(Name = "parentFlow", EmitDefaultValue = false)]
    public string ParentFlow { get; set; }

    /// <summary>
    ///     Gets or Sets Priority
    /// </summary>
    [DataMember(Name = "priority", EmitDefaultValue = false)]
    public int? Priority { get; set; }

    /// <summary>
    ///     Gets or Sets Requirement
    /// </summary>
    [DataMember(Name = "requirement", EmitDefaultValue = false)]
    public string Requirement { get; set; }

    /// <summary>
    ///     Returns true if AuthenticationExecutionRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of AuthenticationExecutionRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(AuthenticationExecutionRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                Authenticator == input.Authenticator ||
                (Authenticator != null &&
                 Authenticator.Equals(input.Authenticator))
            ) &&
            (
                AuthenticatorConfig == input.AuthenticatorConfig ||
                (AuthenticatorConfig != null &&
                 AuthenticatorConfig.Equals(input.AuthenticatorConfig))
            ) &&
            (
                AuthenticatorFlow == input.AuthenticatorFlow ||
                (AuthenticatorFlow != null &&
                 AuthenticatorFlow.Equals(input.AuthenticatorFlow))
            ) &&
            (
                FlowId == input.FlowId ||
                (FlowId != null &&
                 FlowId.Equals(input.FlowId))
            ) &&
            (
                Id == input.Id ||
                (Id != null &&
                 Id.Equals(input.Id))
            ) &&
            (
                ParentFlow == input.ParentFlow ||
                (ParentFlow != null &&
                 ParentFlow.Equals(input.ParentFlow))
            ) &&
            (
                Priority == input.Priority ||
                (Priority != null &&
                 Priority.Equals(input.Priority))
            ) &&
            (
                Requirement == input.Requirement ||
                (Requirement != null &&
                 Requirement.Equals(input.Requirement))
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
        sb.Append("class AuthenticationExecutionRepresentation {\n");
        sb.Append("  Authenticator: ").Append(Authenticator).Append("\n");
        sb.Append("  AuthenticatorConfig: ").Append(AuthenticatorConfig).Append("\n");
        sb.Append("  AuthenticatorFlow: ").Append(AuthenticatorFlow).Append("\n");
        sb.Append("  FlowId: ").Append(FlowId).Append("\n");
        sb.Append("  Id: ").Append(Id).Append("\n");
        sb.Append("  ParentFlow: ").Append(ParentFlow).Append("\n");
        sb.Append("  Priority: ").Append(Priority).Append("\n");
        sb.Append("  Requirement: ").Append(Requirement).Append("\n");
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
        return Equals(input as AuthenticationExecutionRepresentation);
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
            if (Authenticator != null)
                hashCode = hashCode * 59 + Authenticator.GetHashCode();
            if (AuthenticatorConfig != null)
                hashCode = hashCode * 59 + AuthenticatorConfig.GetHashCode();
            if (AuthenticatorFlow != null)
                hashCode = hashCode * 59 + AuthenticatorFlow.GetHashCode();
            if (FlowId != null)
                hashCode = hashCode * 59 + FlowId.GetHashCode();
            if (Id != null)
                hashCode = hashCode * 59 + Id.GetHashCode();
            if (ParentFlow != null)
                hashCode = hashCode * 59 + ParentFlow.GetHashCode();
            if (Priority != null)
                hashCode = hashCode * 59 + Priority.GetHashCode();
            if (Requirement != null)
                hashCode = hashCode * 59 + Requirement.GetHashCode();
            return hashCode;
        }
    }
}