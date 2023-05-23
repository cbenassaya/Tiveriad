#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     ResourceServerRepresentation
/// </summary>
[DataContract]
public class ResourceServerRepresentation : IEquatable<ResourceServerRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Defines DecisionStrategy
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DecisionStrategyEnum
    {
        /// <summary>
        ///     Enum AFFIRMATIVE for value: AFFIRMATIVE
        /// </summary>
        [EnumMember(Value = "AFFIRMATIVE")] AFFIRMATIVE = 1,

        /// <summary>
        ///     Enum UNANIMOUS for value: UNANIMOUS
        /// </summary>
        [EnumMember(Value = "UNANIMOUS")] UNANIMOUS = 2,

        /// <summary>
        ///     Enum CONSENSUS for value: CONSENSUS
        /// </summary>
        [EnumMember(Value = "CONSENSUS")] CONSENSUS = 3
    }

    /// <summary>
    ///     Defines PolicyEnforcementMode
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PolicyEnforcementModeEnum
    {
        /// <summary>
        ///     Enum ENFORCING for value: ENFORCING
        /// </summary>
        [EnumMember(Value = "ENFORCING")] ENFORCING = 1,

        /// <summary>
        ///     Enum PERMISSIVE for value: PERMISSIVE
        /// </summary>
        [EnumMember(Value = "PERMISSIVE")] PERMISSIVE = 2,

        /// <summary>
        ///     Enum DISABLED for value: DISABLED
        /// </summary>
        [EnumMember(Value = "DISABLED")] DISABLED = 3
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ResourceServerRepresentation" /> class.
    /// </summary>
    /// <param name="allowRemoteResourceManagement">allowRemoteResourceManagement.</param>
    /// <param name="clientId">clientId.</param>
    /// <param name="decisionStrategy">decisionStrategy.</param>
    /// <param name="id">id.</param>
    /// <param name="name">name.</param>
    /// <param name="policies">policies.</param>
    /// <param name="policyEnforcementMode">policyEnforcementMode.</param>
    /// <param name="resources">resources.</param>
    /// <param name="scopes">scopes.</param>
    public ResourceServerRepresentation(bool? allowRemoteResourceManagement = default, string clientId = default,
        DecisionStrategyEnum? decisionStrategy = default, string id = default, string name = default,
        List<PolicyRepresentation> policies = default, PolicyEnforcementModeEnum? policyEnforcementMode = default,
        List<ResourceRepresentation> resources = default, List<ScopeRepresentation> scopes = default)
    {
        AllowRemoteResourceManagement = allowRemoteResourceManagement;
        ClientId = clientId;
        DecisionStrategy = decisionStrategy;
        Id = id;
        Name = name;
        Policies = policies;
        PolicyEnforcementMode = policyEnforcementMode;
        Resources = resources;
        Scopes = scopes;
    }

    /// <summary>
    ///     Gets or Sets DecisionStrategy
    /// </summary>
    [DataMember(Name = "decisionStrategy", EmitDefaultValue = false)]
    public DecisionStrategyEnum? DecisionStrategy { get; set; }

    /// <summary>
    ///     Gets or Sets PolicyEnforcementMode
    /// </summary>
    [DataMember(Name = "policyEnforcementMode", EmitDefaultValue = false)]
    public PolicyEnforcementModeEnum? PolicyEnforcementMode { get; set; }

    /// <summary>
    ///     Gets or Sets AllowRemoteResourceManagement
    /// </summary>
    [DataMember(Name = "allowRemoteResourceManagement", EmitDefaultValue = false)]
    public bool? AllowRemoteResourceManagement { get; set; }

    /// <summary>
    ///     Gets or Sets ClientId
    /// </summary>
    [DataMember(Name = "clientId", EmitDefaultValue = false)]
    public string ClientId { get; set; }


    /// <summary>
    ///     Gets or Sets Id
    /// </summary>
    [DataMember(Name = "id", EmitDefaultValue = false)]
    public string Id { get; set; }

    /// <summary>
    ///     Gets or Sets Name
    /// </summary>
    [DataMember(Name = "name", EmitDefaultValue = false)]
    public string Name { get; set; }

    /// <summary>
    ///     Gets or Sets Policies
    /// </summary>
    [DataMember(Name = "policies", EmitDefaultValue = false)]
    public List<PolicyRepresentation> Policies { get; set; }


    /// <summary>
    ///     Gets or Sets Resources
    /// </summary>
    [DataMember(Name = "resources", EmitDefaultValue = false)]
    public List<ResourceRepresentation> Resources { get; set; }

    /// <summary>
    ///     Gets or Sets Scopes
    /// </summary>
    [DataMember(Name = "scopes", EmitDefaultValue = false)]
    public List<ScopeRepresentation> Scopes { get; set; }

    /// <summary>
    ///     Returns true if ResourceServerRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of ResourceServerRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(ResourceServerRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                AllowRemoteResourceManagement == input.AllowRemoteResourceManagement ||
                (AllowRemoteResourceManagement != null &&
                 AllowRemoteResourceManagement.Equals(input.AllowRemoteResourceManagement))
            ) &&
            (
                ClientId == input.ClientId ||
                (ClientId != null &&
                 ClientId.Equals(input.ClientId))
            ) &&
            (
                DecisionStrategy == input.DecisionStrategy ||
                (DecisionStrategy != null &&
                 DecisionStrategy.Equals(input.DecisionStrategy))
            ) &&
            (
                Id == input.Id ||
                (Id != null &&
                 Id.Equals(input.Id))
            ) &&
            (
                Name == input.Name ||
                (Name != null &&
                 Name.Equals(input.Name))
            ) &&
            (
                Policies == input.Policies ||
                (Policies != null &&
                 input.Policies != null &&
                 Policies.SequenceEqual(input.Policies))
            ) &&
            (
                PolicyEnforcementMode == input.PolicyEnforcementMode ||
                (PolicyEnforcementMode != null &&
                 PolicyEnforcementMode.Equals(input.PolicyEnforcementMode))
            ) &&
            (
                Resources == input.Resources ||
                (Resources != null &&
                 input.Resources != null &&
                 Resources.SequenceEqual(input.Resources))
            ) &&
            (
                Scopes == input.Scopes ||
                (Scopes != null &&
                 input.Scopes != null &&
                 Scopes.SequenceEqual(input.Scopes))
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
        sb.Append("class ResourceServerRepresentation {\n");
        sb.Append("  AllowRemoteResourceManagement: ").Append(AllowRemoteResourceManagement).Append("\n");
        sb.Append("  ClientId: ").Append(ClientId).Append("\n");
        sb.Append("  DecisionStrategy: ").Append(DecisionStrategy).Append("\n");
        sb.Append("  Id: ").Append(Id).Append("\n");
        sb.Append("  Name: ").Append(Name).Append("\n");
        sb.Append("  Policies: ").Append(Policies).Append("\n");
        sb.Append("  PolicyEnforcementMode: ").Append(PolicyEnforcementMode).Append("\n");
        sb.Append("  Resources: ").Append(Resources).Append("\n");
        sb.Append("  Scopes: ").Append(Scopes).Append("\n");
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
        return Equals(input as ResourceServerRepresentation);
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
            if (AllowRemoteResourceManagement != null)
                hashCode = hashCode * 59 + AllowRemoteResourceManagement.GetHashCode();
            if (ClientId != null)
                hashCode = hashCode * 59 + ClientId.GetHashCode();
            if (DecisionStrategy != null)
                hashCode = hashCode * 59 + DecisionStrategy.GetHashCode();
            if (Id != null)
                hashCode = hashCode * 59 + Id.GetHashCode();
            if (Name != null)
                hashCode = hashCode * 59 + Name.GetHashCode();
            if (Policies != null)
                hashCode = hashCode * 59 + Policies.GetHashCode();
            if (PolicyEnforcementMode != null)
                hashCode = hashCode * 59 + PolicyEnforcementMode.GetHashCode();
            if (Resources != null)
                hashCode = hashCode * 59 + Resources.GetHashCode();
            if (Scopes != null)
                hashCode = hashCode * 59 + Scopes.GetHashCode();
            return hashCode;
        }
    }
}