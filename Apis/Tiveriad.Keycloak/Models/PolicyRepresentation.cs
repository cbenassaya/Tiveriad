#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     PolicyRepresentation
/// </summary>
[DataContract]
public class PolicyRepresentation : IEquatable<PolicyRepresentation>, IValidatableObject
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
    ///     Defines Logic
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LogicEnum
    {
        /// <summary>
        ///     Enum POSITIVE for value: POSITIVE
        /// </summary>
        [EnumMember(Value = "POSITIVE")] POSITIVE = 1,

        /// <summary>
        ///     Enum NEGATIVE for value: NEGATIVE
        /// </summary>
        [EnumMember(Value = "NEGATIVE")] NEGATIVE = 2
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="PolicyRepresentation" /> class.
    /// </summary>
    /// <param name="config">config.</param>
    /// <param name="decisionStrategy">decisionStrategy.</param>
    /// <param name="description">description.</param>
    /// <param name="id">id.</param>
    /// <param name="logic">logic.</param>
    /// <param name="name">name.</param>
    /// <param name="owner">owner.</param>
    /// <param name="policies">policies.</param>
    /// <param name="resources">resources.</param>
    /// <param name="resourcesData">resourcesData.</param>
    /// <param name="scopes">scopes.</param>
    /// <param name="scopesData">scopesData.</param>
    /// <param name="type">type.</param>
    public PolicyRepresentation(Dictionary<string, object> config = default,
        DecisionStrategyEnum? decisionStrategy = default, string description = default, string id = default,
        LogicEnum? logic = default, string name = default, string owner = default, List<string> policies = default,
        List<string> resources = default, List<ResourceRepresentation> resourcesData = default,
        List<string> scopes = default, List<ScopeRepresentation> scopesData = default, string type = default)
    {
        Config = config;
        DecisionStrategy = decisionStrategy;
        Description = description;
        Id = id;
        Logic = logic;
        Name = name;
        Owner = owner;
        Policies = policies;
        Resources = resources;
        ResourcesData = resourcesData;
        Scopes = scopes;
        ScopesData = scopesData;
        Type = type;
    }

    /// <summary>
    ///     Gets or Sets DecisionStrategy
    /// </summary>
    [DataMember(Name = "decisionStrategy", EmitDefaultValue = false)]
    public DecisionStrategyEnum? DecisionStrategy { get; set; }

    /// <summary>
    ///     Gets or Sets Logic
    /// </summary>
    [DataMember(Name = "logic", EmitDefaultValue = false)]
    public LogicEnum? Logic { get; set; }

    /// <summary>
    ///     Gets or Sets Config
    /// </summary>
    [DataMember(Name = "config", EmitDefaultValue = false)]
    public Dictionary<string, object> Config { get; set; }


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
    ///     Gets or Sets Name
    /// </summary>
    [DataMember(Name = "name", EmitDefaultValue = false)]
    public string Name { get; set; }

    /// <summary>
    ///     Gets or Sets Owner
    /// </summary>
    [DataMember(Name = "owner", EmitDefaultValue = false)]
    public string Owner { get; set; }

    /// <summary>
    ///     Gets or Sets Policies
    /// </summary>
    [DataMember(Name = "policies", EmitDefaultValue = false)]
    public List<string> Policies { get; set; }

    /// <summary>
    ///     Gets or Sets Resources
    /// </summary>
    [DataMember(Name = "resources", EmitDefaultValue = false)]
    public List<string> Resources { get; set; }

    /// <summary>
    ///     Gets or Sets ResourcesData
    /// </summary>
    [DataMember(Name = "resourcesData", EmitDefaultValue = false)]
    public List<ResourceRepresentation> ResourcesData { get; set; }

    /// <summary>
    ///     Gets or Sets Scopes
    /// </summary>
    [DataMember(Name = "scopes", EmitDefaultValue = false)]
    public List<string> Scopes { get; set; }

    /// <summary>
    ///     Gets or Sets ScopesData
    /// </summary>
    [DataMember(Name = "scopesData", EmitDefaultValue = false)]
    public List<ScopeRepresentation> ScopesData { get; set; }

    /// <summary>
    ///     Gets or Sets Type
    /// </summary>
    [DataMember(Name = "type", EmitDefaultValue = false)]
    public string Type { get; set; }

    /// <summary>
    ///     Returns true if PolicyRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of PolicyRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(PolicyRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                Config == input.Config ||
                (Config != null &&
                 input.Config != null &&
                 Config.SequenceEqual(input.Config))
            ) &&
            (
                DecisionStrategy == input.DecisionStrategy ||
                (DecisionStrategy != null &&
                 DecisionStrategy.Equals(input.DecisionStrategy))
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
                Logic == input.Logic ||
                (Logic != null &&
                 Logic.Equals(input.Logic))
            ) &&
            (
                Name == input.Name ||
                (Name != null &&
                 Name.Equals(input.Name))
            ) &&
            (
                Owner == input.Owner ||
                (Owner != null &&
                 Owner.Equals(input.Owner))
            ) &&
            (
                Policies == input.Policies ||
                (Policies != null &&
                 input.Policies != null &&
                 Policies.SequenceEqual(input.Policies))
            ) &&
            (
                Resources == input.Resources ||
                (Resources != null &&
                 input.Resources != null &&
                 Resources.SequenceEqual(input.Resources))
            ) &&
            (
                ResourcesData == input.ResourcesData ||
                (ResourcesData != null &&
                 input.ResourcesData != null &&
                 ResourcesData.SequenceEqual(input.ResourcesData))
            ) &&
            (
                Scopes == input.Scopes ||
                (Scopes != null &&
                 input.Scopes != null &&
                 Scopes.SequenceEqual(input.Scopes))
            ) &&
            (
                ScopesData == input.ScopesData ||
                (ScopesData != null &&
                 input.ScopesData != null &&
                 ScopesData.SequenceEqual(input.ScopesData))
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
        sb.Append("class PolicyRepresentation {\n");
        sb.Append("  Config: ").Append(Config).Append("\n");
        sb.Append("  DecisionStrategy: ").Append(DecisionStrategy).Append("\n");
        sb.Append("  Description: ").Append(Description).Append("\n");
        sb.Append("  Id: ").Append(Id).Append("\n");
        sb.Append("  Logic: ").Append(Logic).Append("\n");
        sb.Append("  Name: ").Append(Name).Append("\n");
        sb.Append("  Owner: ").Append(Owner).Append("\n");
        sb.Append("  Policies: ").Append(Policies).Append("\n");
        sb.Append("  Resources: ").Append(Resources).Append("\n");
        sb.Append("  ResourcesData: ").Append(ResourcesData).Append("\n");
        sb.Append("  Scopes: ").Append(Scopes).Append("\n");
        sb.Append("  ScopesData: ").Append(ScopesData).Append("\n");
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
        return Equals(input as PolicyRepresentation);
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
            if (Config != null)
                hashCode = hashCode * 59 + Config.GetHashCode();
            if (DecisionStrategy != null)
                hashCode = hashCode * 59 + DecisionStrategy.GetHashCode();
            if (Description != null)
                hashCode = hashCode * 59 + Description.GetHashCode();
            if (Id != null)
                hashCode = hashCode * 59 + Id.GetHashCode();
            if (Logic != null)
                hashCode = hashCode * 59 + Logic.GetHashCode();
            if (Name != null)
                hashCode = hashCode * 59 + Name.GetHashCode();
            if (Owner != null)
                hashCode = hashCode * 59 + Owner.GetHashCode();
            if (Policies != null)
                hashCode = hashCode * 59 + Policies.GetHashCode();
            if (Resources != null)
                hashCode = hashCode * 59 + Resources.GetHashCode();
            if (ResourcesData != null)
                hashCode = hashCode * 59 + ResourcesData.GetHashCode();
            if (Scopes != null)
                hashCode = hashCode * 59 + Scopes.GetHashCode();
            if (ScopesData != null)
                hashCode = hashCode * 59 + ScopesData.GetHashCode();
            if (Type != null)
                hashCode = hashCode * 59 + Type.GetHashCode();
            return hashCode;
        }
    }
}