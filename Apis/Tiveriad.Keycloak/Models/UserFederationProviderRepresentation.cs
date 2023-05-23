#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     UserFederationProviderRepresentation
/// </summary>
[DataContract]
public class UserFederationProviderRepresentation : IEquatable<UserFederationProviderRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserFederationProviderRepresentation" /> class.
    /// </summary>
    /// <param name="changedSyncPeriod">changedSyncPeriod.</param>
    /// <param name="config">config.</param>
    /// <param name="displayName">displayName.</param>
    /// <param name="fullSyncPeriod">fullSyncPeriod.</param>
    /// <param name="id">id.</param>
    /// <param name="lastSync">lastSync.</param>
    /// <param name="priority">priority.</param>
    /// <param name="providerName">providerName.</param>
    public UserFederationProviderRepresentation(int? changedSyncPeriod = default,
        Dictionary<string, object> config = default, string displayName = default, int? fullSyncPeriod = default,
        string id = default, int? lastSync = default, int? priority = default, string providerName = default)
    {
        ChangedSyncPeriod = changedSyncPeriod;
        Config = config;
        DisplayName = displayName;
        FullSyncPeriod = fullSyncPeriod;
        Id = id;
        LastSync = lastSync;
        Priority = priority;
        ProviderName = providerName;
    }

    /// <summary>
    ///     Gets or Sets ChangedSyncPeriod
    /// </summary>
    [DataMember(Name = "changedSyncPeriod", EmitDefaultValue = false)]
    public int? ChangedSyncPeriod { get; set; }

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
    ///     Gets or Sets FullSyncPeriod
    /// </summary>
    [DataMember(Name = "fullSyncPeriod", EmitDefaultValue = false)]
    public int? FullSyncPeriod { get; set; }

    /// <summary>
    ///     Gets or Sets Id
    /// </summary>
    [DataMember(Name = "id", EmitDefaultValue = false)]
    public string Id { get; set; }

    /// <summary>
    ///     Gets or Sets LastSync
    /// </summary>
    [DataMember(Name = "lastSync", EmitDefaultValue = false)]
    public int? LastSync { get; set; }

    /// <summary>
    ///     Gets or Sets Priority
    /// </summary>
    [DataMember(Name = "priority", EmitDefaultValue = false)]
    public int? Priority { get; set; }

    /// <summary>
    ///     Gets or Sets ProviderName
    /// </summary>
    [DataMember(Name = "providerName", EmitDefaultValue = false)]
    public string ProviderName { get; set; }

    /// <summary>
    ///     Returns true if UserFederationProviderRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of UserFederationProviderRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(UserFederationProviderRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                ChangedSyncPeriod == input.ChangedSyncPeriod ||
                (ChangedSyncPeriod != null &&
                 ChangedSyncPeriod.Equals(input.ChangedSyncPeriod))
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
                FullSyncPeriod == input.FullSyncPeriod ||
                (FullSyncPeriod != null &&
                 FullSyncPeriod.Equals(input.FullSyncPeriod))
            ) &&
            (
                Id == input.Id ||
                (Id != null &&
                 Id.Equals(input.Id))
            ) &&
            (
                LastSync == input.LastSync ||
                (LastSync != null &&
                 LastSync.Equals(input.LastSync))
            ) &&
            (
                Priority == input.Priority ||
                (Priority != null &&
                 Priority.Equals(input.Priority))
            ) &&
            (
                ProviderName == input.ProviderName ||
                (ProviderName != null &&
                 ProviderName.Equals(input.ProviderName))
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
        sb.Append("class UserFederationProviderRepresentation {\n");
        sb.Append("  ChangedSyncPeriod: ").Append(ChangedSyncPeriod).Append("\n");
        sb.Append("  Config: ").Append(Config).Append("\n");
        sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
        sb.Append("  FullSyncPeriod: ").Append(FullSyncPeriod).Append("\n");
        sb.Append("  Id: ").Append(Id).Append("\n");
        sb.Append("  LastSync: ").Append(LastSync).Append("\n");
        sb.Append("  Priority: ").Append(Priority).Append("\n");
        sb.Append("  ProviderName: ").Append(ProviderName).Append("\n");
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
        return Equals(input as UserFederationProviderRepresentation);
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
            if (ChangedSyncPeriod != null)
                hashCode = hashCode * 59 + ChangedSyncPeriod.GetHashCode();
            if (Config != null)
                hashCode = hashCode * 59 + Config.GetHashCode();
            if (DisplayName != null)
                hashCode = hashCode * 59 + DisplayName.GetHashCode();
            if (FullSyncPeriod != null)
                hashCode = hashCode * 59 + FullSyncPeriod.GetHashCode();
            if (Id != null)
                hashCode = hashCode * 59 + Id.GetHashCode();
            if (LastSync != null)
                hashCode = hashCode * 59 + LastSync.GetHashCode();
            if (Priority != null)
                hashCode = hashCode * 59 + Priority.GetHashCode();
            if (ProviderName != null)
                hashCode = hashCode * 59 + ProviderName.GetHashCode();
            return hashCode;
        }
    }
}