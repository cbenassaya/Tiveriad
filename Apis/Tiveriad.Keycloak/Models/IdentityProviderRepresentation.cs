#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     IdentityProviderRepresentation
/// </summary>
[DataContract]
public class IdentityProviderRepresentation : IEquatable<IdentityProviderRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="IdentityProviderRepresentation" /> class.
    /// </summary>
    /// <param name="addReadTokenRoleOnCreate">addReadTokenRoleOnCreate.</param>
    /// <param name="alias">alias.</param>
    /// <param name="config">config.</param>
    /// <param name="displayName">displayName.</param>
    /// <param name="enabled">enabled.</param>
    /// <param name="firstBrokerLoginFlowAlias">firstBrokerLoginFlowAlias.</param>
    /// <param name="internalId">internalId.</param>
    /// <param name="linkOnly">linkOnly.</param>
    /// <param name="postBrokerLoginFlowAlias">postBrokerLoginFlowAlias.</param>
    /// <param name="providerId">providerId.</param>
    /// <param name="storeToken">storeToken.</param>
    /// <param name="trustEmail">trustEmail.</param>
    public IdentityProviderRepresentation(bool? addReadTokenRoleOnCreate = default, string alias = default,
        Dictionary<string, object> config = default, string displayName = default, bool? enabled = default,
        string firstBrokerLoginFlowAlias = default, string internalId = default, bool? linkOnly = default,
        string postBrokerLoginFlowAlias = default, string providerId = default, bool? storeToken = default,
        bool? trustEmail = default)
    {
        AddReadTokenRoleOnCreate = addReadTokenRoleOnCreate;
        Alias = alias;
        Config = config;
        DisplayName = displayName;
        Enabled = enabled;
        FirstBrokerLoginFlowAlias = firstBrokerLoginFlowAlias;
        InternalId = internalId;
        LinkOnly = linkOnly;
        PostBrokerLoginFlowAlias = postBrokerLoginFlowAlias;
        ProviderId = providerId;
        StoreToken = storeToken;
        TrustEmail = trustEmail;
    }

    /// <summary>
    ///     Gets or Sets AddReadTokenRoleOnCreate
    /// </summary>
    [DataMember(Name = "addReadTokenRoleOnCreate", EmitDefaultValue = false)]
    public bool? AddReadTokenRoleOnCreate { get; set; }

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
    ///     Gets or Sets DisplayName
    /// </summary>
    [DataMember(Name = "displayName", EmitDefaultValue = false)]
    public string DisplayName { get; set; }

    /// <summary>
    ///     Gets or Sets Enabled
    /// </summary>
    [DataMember(Name = "enabled", EmitDefaultValue = false)]
    public bool? Enabled { get; set; }

    /// <summary>
    ///     Gets or Sets FirstBrokerLoginFlowAlias
    /// </summary>
    [DataMember(Name = "firstBrokerLoginFlowAlias", EmitDefaultValue = false)]
    public string FirstBrokerLoginFlowAlias { get; set; }

    /// <summary>
    ///     Gets or Sets InternalId
    /// </summary>
    [DataMember(Name = "internalId", EmitDefaultValue = false)]
    public string InternalId { get; set; }

    /// <summary>
    ///     Gets or Sets LinkOnly
    /// </summary>
    [DataMember(Name = "linkOnly", EmitDefaultValue = false)]
    public bool? LinkOnly { get; set; }

    /// <summary>
    ///     Gets or Sets PostBrokerLoginFlowAlias
    /// </summary>
    [DataMember(Name = "postBrokerLoginFlowAlias", EmitDefaultValue = false)]
    public string PostBrokerLoginFlowAlias { get; set; }

    /// <summary>
    ///     Gets or Sets ProviderId
    /// </summary>
    [DataMember(Name = "providerId", EmitDefaultValue = false)]
    public string ProviderId { get; set; }

    /// <summary>
    ///     Gets or Sets StoreToken
    /// </summary>
    [DataMember(Name = "storeToken", EmitDefaultValue = false)]
    public bool? StoreToken { get; set; }

    /// <summary>
    ///     Gets or Sets TrustEmail
    /// </summary>
    [DataMember(Name = "trustEmail", EmitDefaultValue = false)]
    public bool? TrustEmail { get; set; }

    /// <summary>
    ///     Returns true if IdentityProviderRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of IdentityProviderRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(IdentityProviderRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                AddReadTokenRoleOnCreate == input.AddReadTokenRoleOnCreate ||
                (AddReadTokenRoleOnCreate != null &&
                 AddReadTokenRoleOnCreate.Equals(input.AddReadTokenRoleOnCreate))
            ) &&
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
                DisplayName == input.DisplayName ||
                (DisplayName != null &&
                 DisplayName.Equals(input.DisplayName))
            ) &&
            (
                Enabled == input.Enabled ||
                (Enabled != null &&
                 Enabled.Equals(input.Enabled))
            ) &&
            (
                FirstBrokerLoginFlowAlias == input.FirstBrokerLoginFlowAlias ||
                (FirstBrokerLoginFlowAlias != null &&
                 FirstBrokerLoginFlowAlias.Equals(input.FirstBrokerLoginFlowAlias))
            ) &&
            (
                InternalId == input.InternalId ||
                (InternalId != null &&
                 InternalId.Equals(input.InternalId))
            ) &&
            (
                LinkOnly == input.LinkOnly ||
                (LinkOnly != null &&
                 LinkOnly.Equals(input.LinkOnly))
            ) &&
            (
                PostBrokerLoginFlowAlias == input.PostBrokerLoginFlowAlias ||
                (PostBrokerLoginFlowAlias != null &&
                 PostBrokerLoginFlowAlias.Equals(input.PostBrokerLoginFlowAlias))
            ) &&
            (
                ProviderId == input.ProviderId ||
                (ProviderId != null &&
                 ProviderId.Equals(input.ProviderId))
            ) &&
            (
                StoreToken == input.StoreToken ||
                (StoreToken != null &&
                 StoreToken.Equals(input.StoreToken))
            ) &&
            (
                TrustEmail == input.TrustEmail ||
                (TrustEmail != null &&
                 TrustEmail.Equals(input.TrustEmail))
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
        sb.Append("class IdentityProviderRepresentation {\n");
        sb.Append("  AddReadTokenRoleOnCreate: ").Append(AddReadTokenRoleOnCreate).Append("\n");
        sb.Append("  Alias: ").Append(Alias).Append("\n");
        sb.Append("  Config: ").Append(Config).Append("\n");
        sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
        sb.Append("  Enabled: ").Append(Enabled).Append("\n");
        sb.Append("  FirstBrokerLoginFlowAlias: ").Append(FirstBrokerLoginFlowAlias).Append("\n");
        sb.Append("  InternalId: ").Append(InternalId).Append("\n");
        sb.Append("  LinkOnly: ").Append(LinkOnly).Append("\n");
        sb.Append("  PostBrokerLoginFlowAlias: ").Append(PostBrokerLoginFlowAlias).Append("\n");
        sb.Append("  ProviderId: ").Append(ProviderId).Append("\n");
        sb.Append("  StoreToken: ").Append(StoreToken).Append("\n");
        sb.Append("  TrustEmail: ").Append(TrustEmail).Append("\n");
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
        return Equals(input as IdentityProviderRepresentation);
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
            if (AddReadTokenRoleOnCreate != null)
                hashCode = hashCode * 59 + AddReadTokenRoleOnCreate.GetHashCode();
            if (Alias != null)
                hashCode = hashCode * 59 + Alias.GetHashCode();
            if (Config != null)
                hashCode = hashCode * 59 + Config.GetHashCode();
            if (DisplayName != null)
                hashCode = hashCode * 59 + DisplayName.GetHashCode();
            if (Enabled != null)
                hashCode = hashCode * 59 + Enabled.GetHashCode();
            if (FirstBrokerLoginFlowAlias != null)
                hashCode = hashCode * 59 + FirstBrokerLoginFlowAlias.GetHashCode();
            if (InternalId != null)
                hashCode = hashCode * 59 + InternalId.GetHashCode();
            if (LinkOnly != null)
                hashCode = hashCode * 59 + LinkOnly.GetHashCode();
            if (PostBrokerLoginFlowAlias != null)
                hashCode = hashCode * 59 + PostBrokerLoginFlowAlias.GetHashCode();
            if (ProviderId != null)
                hashCode = hashCode * 59 + ProviderId.GetHashCode();
            if (StoreToken != null)
                hashCode = hashCode * 59 + StoreToken.GetHashCode();
            if (TrustEmail != null)
                hashCode = hashCode * 59 + TrustEmail.GetHashCode();
            return hashCode;
        }
    }
}