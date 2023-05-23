#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     AuthenticationFlowRepresentation
/// </summary>
[DataContract]
public class AuthenticationFlowRepresentation : IEquatable<AuthenticationFlowRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AuthenticationFlowRepresentation" /> class.
    /// </summary>
    /// <param name="alias">alias.</param>
    /// <param name="authenticationExecutions">authenticationExecutions.</param>
    /// <param name="builtIn">builtIn.</param>
    /// <param name="description">description.</param>
    /// <param name="id">id.</param>
    /// <param name="providerId">providerId.</param>
    /// <param name="topLevel">topLevel.</param>
    public AuthenticationFlowRepresentation(string alias = default,
        List<AuthenticationExecutionExportRepresentation> authenticationExecutions = default, bool? builtIn = default,
        string description = default, string id = default, string providerId = default, bool? topLevel = default)
    {
        Alias = alias;
        AuthenticationExecutions = authenticationExecutions;
        BuiltIn = builtIn;
        Description = description;
        Id = id;
        ProviderId = providerId;
        TopLevel = topLevel;
    }

    /// <summary>
    ///     Gets or Sets Alias
    /// </summary>
    [DataMember(Name = "alias", EmitDefaultValue = false)]
    public string Alias { get; set; }

    /// <summary>
    ///     Gets or Sets AuthenticationExecutions
    /// </summary>
    [DataMember(Name = "authenticationExecutions", EmitDefaultValue = false)]
    public List<AuthenticationExecutionExportRepresentation> AuthenticationExecutions { get; set; }

    /// <summary>
    ///     Gets or Sets BuiltIn
    /// </summary>
    [DataMember(Name = "builtIn", EmitDefaultValue = false)]
    public bool? BuiltIn { get; set; }

    /// <summary>
    ///     Gets or Sets Description
    /// </summary>
    [DataMember(Name = "description", EmitDefaultValue = false)]
    public string Description { get; set; }

    /// <summary>
    ///     Gets or Sets Id
    /// </summary>
    [DataMember(Name = "id", EmitDefaultValue = false)]
    public string Id { get; set; }

    /// <summary>
    ///     Gets or Sets ProviderId
    /// </summary>
    [DataMember(Name = "providerId", EmitDefaultValue = false)]
    public string ProviderId { get; set; }

    /// <summary>
    ///     Gets or Sets TopLevel
    /// </summary>
    [DataMember(Name = "topLevel", EmitDefaultValue = false)]
    public bool? TopLevel { get; set; }

    /// <summary>
    ///     Returns true if AuthenticationFlowRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of AuthenticationFlowRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(AuthenticationFlowRepresentation input)
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
                AuthenticationExecutions == input.AuthenticationExecutions ||
                (AuthenticationExecutions != null &&
                 input.AuthenticationExecutions != null &&
                 AuthenticationExecutions.SequenceEqual(input.AuthenticationExecutions))
            ) &&
            (
                BuiltIn == input.BuiltIn ||
                (BuiltIn != null &&
                 BuiltIn.Equals(input.BuiltIn))
            ) &&
            (
                Description == input.Description ||
                (Description != null &&
                 Description.Equals(input.Description))
            ) &&
            (
                Id == input.Id ||
                (Id != null &&
                 Id.Equals(input.Id))
            ) &&
            (
                ProviderId == input.ProviderId ||
                (ProviderId != null &&
                 ProviderId.Equals(input.ProviderId))
            ) &&
            (
                TopLevel == input.TopLevel ||
                (TopLevel != null &&
                 TopLevel.Equals(input.TopLevel))
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
        sb.Append("class AuthenticationFlowRepresentation {\n");
        sb.Append("  Alias: ").Append(Alias).Append("\n");
        sb.Append("  AuthenticationExecutions: ").Append(AuthenticationExecutions).Append("\n");
        sb.Append("  BuiltIn: ").Append(BuiltIn).Append("\n");
        sb.Append("  Description: ").Append(Description).Append("\n");
        sb.Append("  Id: ").Append(Id).Append("\n");
        sb.Append("  ProviderId: ").Append(ProviderId).Append("\n");
        sb.Append("  TopLevel: ").Append(TopLevel).Append("\n");
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
        return Equals(input as AuthenticationFlowRepresentation);
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
            if (AuthenticationExecutions != null)
                hashCode = hashCode * 59 + AuthenticationExecutions.GetHashCode();
            if (BuiltIn != null)
                hashCode = hashCode * 59 + BuiltIn.GetHashCode();
            if (Description != null)
                hashCode = hashCode * 59 + Description.GetHashCode();
            if (Id != null)
                hashCode = hashCode * 59 + Id.GetHashCode();
            if (ProviderId != null)
                hashCode = hashCode * 59 + ProviderId.GetHashCode();
            if (TopLevel != null)
                hashCode = hashCode * 59 + TopLevel.GetHashCode();
            return hashCode;
        }
    }
}