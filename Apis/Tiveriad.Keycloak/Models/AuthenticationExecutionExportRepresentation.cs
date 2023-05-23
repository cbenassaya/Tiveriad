#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     AuthenticationExecutionExportRepresentation
/// </summary>
[DataContract]
public class AuthenticationExecutionExportRepresentation : IEquatable<AuthenticationExecutionExportRepresentation>,
    IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AuthenticationExecutionExportRepresentation" /> class.
    /// </summary>
    /// <param name="authenticator">authenticator.</param>
    /// <param name="authenticatorConfig">authenticatorConfig.</param>
    /// <param name="authenticatorFlow">authenticatorFlow.</param>
    /// <param name="flowAlias">flowAlias.</param>
    /// <param name="priority">priority.</param>
    /// <param name="requirement">requirement.</param>
    /// <param name="userSetupAllowed">userSetupAllowed.</param>
    public AuthenticationExecutionExportRepresentation(string authenticator = default,
        string authenticatorConfig = default, bool? authenticatorFlow = default, string flowAlias = default,
        int? priority = default, string requirement = default, bool? userSetupAllowed = default)
    {
        Authenticator = authenticator;
        AuthenticatorConfig = authenticatorConfig;
        AuthenticatorFlow = authenticatorFlow;
        FlowAlias = flowAlias;
        Priority = priority;
        Requirement = requirement;
        UserSetupAllowed = userSetupAllowed;
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
    ///     Gets or Sets FlowAlias
    /// </summary>
    [DataMember(Name = "flowAlias", EmitDefaultValue = false)]
    public string FlowAlias { get; set; }

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
    ///     Gets or Sets UserSetupAllowed
    /// </summary>
    [DataMember(Name = "userSetupAllowed", EmitDefaultValue = false)]
    public bool? UserSetupAllowed { get; set; }

    /// <summary>
    ///     Returns true if AuthenticationExecutionExportRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of AuthenticationExecutionExportRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(AuthenticationExecutionExportRepresentation input)
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
                FlowAlias == input.FlowAlias ||
                (FlowAlias != null &&
                 FlowAlias.Equals(input.FlowAlias))
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
            ) &&
            (
                UserSetupAllowed == input.UserSetupAllowed ||
                (UserSetupAllowed != null &&
                 UserSetupAllowed.Equals(input.UserSetupAllowed))
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
        sb.Append("class AuthenticationExecutionExportRepresentation {\n");
        sb.Append("  Authenticator: ").Append(Authenticator).Append("\n");
        sb.Append("  AuthenticatorConfig: ").Append(AuthenticatorConfig).Append("\n");
        sb.Append("  AuthenticatorFlow: ").Append(AuthenticatorFlow).Append("\n");
        sb.Append("  FlowAlias: ").Append(FlowAlias).Append("\n");
        sb.Append("  Priority: ").Append(Priority).Append("\n");
        sb.Append("  Requirement: ").Append(Requirement).Append("\n");
        sb.Append("  UserSetupAllowed: ").Append(UserSetupAllowed).Append("\n");
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
        return Equals(input as AuthenticationExecutionExportRepresentation);
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
            if (FlowAlias != null)
                hashCode = hashCode * 59 + FlowAlias.GetHashCode();
            if (Priority != null)
                hashCode = hashCode * 59 + Priority.GetHashCode();
            if (Requirement != null)
                hashCode = hashCode * 59 + Requirement.GetHashCode();
            if (UserSetupAllowed != null)
                hashCode = hashCode * 59 + UserSetupAllowed.GetHashCode();
            return hashCode;
        }
    }
}