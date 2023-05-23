#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     AuthenticationExecutionInfoRepresentation
/// </summary>
[DataContract]
public class AuthenticationExecutionInfoRepresentation : IEquatable<AuthenticationExecutionInfoRepresentation>,
    IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AuthenticationExecutionInfoRepresentation" /> class.
    /// </summary>
    /// <param name="alias">alias.</param>
    /// <param name="authenticationConfig">authenticationConfig.</param>
    /// <param name="authenticationFlow">authenticationFlow.</param>
    /// <param name="configurable">configurable.</param>
    /// <param name="description">description.</param>
    /// <param name="displayName">displayName.</param>
    /// <param name="flowId">flowId.</param>
    /// <param name="id">id.</param>
    /// <param name="index">index.</param>
    /// <param name="level">level.</param>
    /// <param name="providerId">providerId.</param>
    /// <param name="requirement">requirement.</param>
    /// <param name="requirementChoices">requirementChoices.</param>
    public AuthenticationExecutionInfoRepresentation(string alias = default, string authenticationConfig = default,
        bool? authenticationFlow = default, bool? configurable = default, string description = default,
        string displayName = default, string flowId = default, string id = default, int? index = default,
        int? level = default, string providerId = default, string requirement = default,
        List<string> requirementChoices = default)
    {
        Alias = alias;
        AuthenticationConfig = authenticationConfig;
        AuthenticationFlow = authenticationFlow;
        Configurable = configurable;
        Description = description;
        DisplayName = displayName;
        FlowId = flowId;
        Id = id;
        Index = index;
        Level = level;
        ProviderId = providerId;
        Requirement = requirement;
        RequirementChoices = requirementChoices;
    }

    /// <summary>
    ///     Gets or Sets Alias
    /// </summary>
    [DataMember(Name = "alias", EmitDefaultValue = false)]
    public string Alias { get; set; }

    /// <summary>
    ///     Gets or Sets AuthenticationConfig
    /// </summary>
    [DataMember(Name = "authenticationConfig", EmitDefaultValue = false)]
    public string AuthenticationConfig { get; set; }

    /// <summary>
    ///     Gets or Sets AuthenticationFlow
    /// </summary>
    [DataMember(Name = "authenticationFlow", EmitDefaultValue = false)]
    public bool? AuthenticationFlow { get; set; }

    /// <summary>
    ///     Gets or Sets Configurable
    /// </summary>
    [DataMember(Name = "configurable", EmitDefaultValue = false)]
    public bool? Configurable { get; set; }

    /// <summary>
    ///     Gets or Sets Description
    /// </summary>
    [DataMember(Name = "description", EmitDefaultValue = false)]
    public string Description { get; set; }

    /// <summary>
    ///     Gets or Sets DisplayName
    /// </summary>
    [DataMember(Name = "displayName", EmitDefaultValue = false)]
    public string DisplayName { get; set; }

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
    ///     Gets or Sets Index
    /// </summary>
    [DataMember(Name = "index", EmitDefaultValue = false)]
    public int? Index { get; set; }

    /// <summary>
    ///     Gets or Sets Level
    /// </summary>
    [DataMember(Name = "level", EmitDefaultValue = false)]
    public int? Level { get; set; }

    /// <summary>
    ///     Gets or Sets ProviderId
    /// </summary>
    [DataMember(Name = "providerId", EmitDefaultValue = false)]
    public string ProviderId { get; set; }

    /// <summary>
    ///     Gets or Sets Requirement
    /// </summary>
    [DataMember(Name = "requirement", EmitDefaultValue = false)]
    public string Requirement { get; set; }

    /// <summary>
    ///     Gets or Sets RequirementChoices
    /// </summary>
    [DataMember(Name = "requirementChoices", EmitDefaultValue = false)]
    public List<string> RequirementChoices { get; set; }

    /// <summary>
    ///     Returns true if AuthenticationExecutionInfoRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of AuthenticationExecutionInfoRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(AuthenticationExecutionInfoRepresentation input)
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
                AuthenticationConfig == input.AuthenticationConfig ||
                (AuthenticationConfig != null &&
                 AuthenticationConfig.Equals(input.AuthenticationConfig))
            ) &&
            (
                AuthenticationFlow == input.AuthenticationFlow ||
                (AuthenticationFlow != null &&
                 AuthenticationFlow.Equals(input.AuthenticationFlow))
            ) &&
            (
                Configurable == input.Configurable ||
                (Configurable != null &&
                 Configurable.Equals(input.Configurable))
            ) &&
            (
                Description == input.Description ||
                (Description != null &&
                 Description.Equals(input.Description))
            ) &&
            (
                DisplayName == input.DisplayName ||
                (DisplayName != null &&
                 DisplayName.Equals(input.DisplayName))
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
                Index == input.Index ||
                (Index != null &&
                 Index.Equals(input.Index))
            ) &&
            (
                Level == input.Level ||
                (Level != null &&
                 Level.Equals(input.Level))
            ) &&
            (
                ProviderId == input.ProviderId ||
                (ProviderId != null &&
                 ProviderId.Equals(input.ProviderId))
            ) &&
            (
                Requirement == input.Requirement ||
                (Requirement != null &&
                 Requirement.Equals(input.Requirement))
            ) &&
            (
                RequirementChoices == input.RequirementChoices ||
                (RequirementChoices != null &&
                 input.RequirementChoices != null &&
                 RequirementChoices.SequenceEqual(input.RequirementChoices))
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
        sb.Append("class AuthenticationExecutionInfoRepresentation {\n");
        sb.Append("  Alias: ").Append(Alias).Append("\n");
        sb.Append("  AuthenticationConfig: ").Append(AuthenticationConfig).Append("\n");
        sb.Append("  AuthenticationFlow: ").Append(AuthenticationFlow).Append("\n");
        sb.Append("  Configurable: ").Append(Configurable).Append("\n");
        sb.Append("  Description: ").Append(Description).Append("\n");
        sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
        sb.Append("  FlowId: ").Append(FlowId).Append("\n");
        sb.Append("  Id: ").Append(Id).Append("\n");
        sb.Append("  Index: ").Append(Index).Append("\n");
        sb.Append("  Level: ").Append(Level).Append("\n");
        sb.Append("  ProviderId: ").Append(ProviderId).Append("\n");
        sb.Append("  Requirement: ").Append(Requirement).Append("\n");
        sb.Append("  RequirementChoices: ").Append(RequirementChoices).Append("\n");
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
        return Equals(input as AuthenticationExecutionInfoRepresentation);
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
            if (AuthenticationConfig != null)
                hashCode = hashCode * 59 + AuthenticationConfig.GetHashCode();
            if (AuthenticationFlow != null)
                hashCode = hashCode * 59 + AuthenticationFlow.GetHashCode();
            if (Configurable != null)
                hashCode = hashCode * 59 + Configurable.GetHashCode();
            if (Description != null)
                hashCode = hashCode * 59 + Description.GetHashCode();
            if (DisplayName != null)
                hashCode = hashCode * 59 + DisplayName.GetHashCode();
            if (FlowId != null)
                hashCode = hashCode * 59 + FlowId.GetHashCode();
            if (Id != null)
                hashCode = hashCode * 59 + Id.GetHashCode();
            if (Index != null)
                hashCode = hashCode * 59 + Index.GetHashCode();
            if (Level != null)
                hashCode = hashCode * 59 + Level.GetHashCode();
            if (ProviderId != null)
                hashCode = hashCode * 59 + ProviderId.GetHashCode();
            if (Requirement != null)
                hashCode = hashCode * 59 + Requirement.GetHashCode();
            if (RequirementChoices != null)
                hashCode = hashCode * 59 + RequirementChoices.GetHashCode();
            return hashCode;
        }
    }
}