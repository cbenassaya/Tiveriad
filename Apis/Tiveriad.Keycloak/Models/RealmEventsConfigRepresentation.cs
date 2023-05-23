#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     RealmEventsConfigRepresentation
/// </summary>
[DataContract]
public class RealmEventsConfigRepresentation : IEquatable<RealmEventsConfigRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="RealmEventsConfigRepresentation" /> class.
    /// </summary>
    /// <param name="adminEventsDetailsEnabled">adminEventsDetailsEnabled.</param>
    /// <param name="adminEventsEnabled">adminEventsEnabled.</param>
    /// <param name="enabledEventTypes">enabledEventTypes.</param>
    /// <param name="eventsEnabled">eventsEnabled.</param>
    /// <param name="eventsExpiration">eventsExpiration.</param>
    /// <param name="eventsListeners">eventsListeners.</param>
    public RealmEventsConfigRepresentation(bool? adminEventsDetailsEnabled = default,
        bool? adminEventsEnabled = default, List<string> enabledEventTypes = default, bool? eventsEnabled = default,
        long? eventsExpiration = default, List<string> eventsListeners = default)
    {
        AdminEventsDetailsEnabled = adminEventsDetailsEnabled;
        AdminEventsEnabled = adminEventsEnabled;
        EnabledEventTypes = enabledEventTypes;
        EventsEnabled = eventsEnabled;
        EventsExpiration = eventsExpiration;
        EventsListeners = eventsListeners;
    }

    /// <summary>
    ///     Gets or Sets AdminEventsDetailsEnabled
    /// </summary>
    [DataMember(Name = "adminEventsDetailsEnabled", EmitDefaultValue = false)]
    public bool? AdminEventsDetailsEnabled { get; set; }

    /// <summary>
    ///     Gets or Sets AdminEventsEnabled
    /// </summary>
    [DataMember(Name = "adminEventsEnabled", EmitDefaultValue = false)]
    public bool? AdminEventsEnabled { get; set; }

    /// <summary>
    ///     Gets or Sets EnabledEventTypes
    /// </summary>
    [DataMember(Name = "enabledEventTypes", EmitDefaultValue = false)]
    public List<string> EnabledEventTypes { get; set; }

    /// <summary>
    ///     Gets or Sets EventsEnabled
    /// </summary>
    [DataMember(Name = "eventsEnabled", EmitDefaultValue = false)]
    public bool? EventsEnabled { get; set; }

    /// <summary>
    ///     Gets or Sets EventsExpiration
    /// </summary>
    [DataMember(Name = "eventsExpiration", EmitDefaultValue = false)]
    public long? EventsExpiration { get; set; }

    /// <summary>
    ///     Gets or Sets EventsListeners
    /// </summary>
    [DataMember(Name = "eventsListeners", EmitDefaultValue = false)]
    public List<string> EventsListeners { get; set; }

    /// <summary>
    ///     Returns true if RealmEventsConfigRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of RealmEventsConfigRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(RealmEventsConfigRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                AdminEventsDetailsEnabled == input.AdminEventsDetailsEnabled ||
                (AdminEventsDetailsEnabled != null &&
                 AdminEventsDetailsEnabled.Equals(input.AdminEventsDetailsEnabled))
            ) &&
            (
                AdminEventsEnabled == input.AdminEventsEnabled ||
                (AdminEventsEnabled != null &&
                 AdminEventsEnabled.Equals(input.AdminEventsEnabled))
            ) &&
            (
                EnabledEventTypes == input.EnabledEventTypes ||
                (EnabledEventTypes != null &&
                 input.EnabledEventTypes != null &&
                 EnabledEventTypes.SequenceEqual(input.EnabledEventTypes))
            ) &&
            (
                EventsEnabled == input.EventsEnabled ||
                (EventsEnabled != null &&
                 EventsEnabled.Equals(input.EventsEnabled))
            ) &&
            (
                EventsExpiration == input.EventsExpiration ||
                (EventsExpiration != null &&
                 EventsExpiration.Equals(input.EventsExpiration))
            ) &&
            (
                EventsListeners == input.EventsListeners ||
                (EventsListeners != null &&
                 input.EventsListeners != null &&
                 EventsListeners.SequenceEqual(input.EventsListeners))
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
        sb.Append("class RealmEventsConfigRepresentation {\n");
        sb.Append("  AdminEventsDetailsEnabled: ").Append(AdminEventsDetailsEnabled).Append("\n");
        sb.Append("  AdminEventsEnabled: ").Append(AdminEventsEnabled).Append("\n");
        sb.Append("  EnabledEventTypes: ").Append(EnabledEventTypes).Append("\n");
        sb.Append("  EventsEnabled: ").Append(EventsEnabled).Append("\n");
        sb.Append("  EventsExpiration: ").Append(EventsExpiration).Append("\n");
        sb.Append("  EventsListeners: ").Append(EventsListeners).Append("\n");
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
        return Equals(input as RealmEventsConfigRepresentation);
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
            if (AdminEventsDetailsEnabled != null)
                hashCode = hashCode * 59 + AdminEventsDetailsEnabled.GetHashCode();
            if (AdminEventsEnabled != null)
                hashCode = hashCode * 59 + AdminEventsEnabled.GetHashCode();
            if (EnabledEventTypes != null)
                hashCode = hashCode * 59 + EnabledEventTypes.GetHashCode();
            if (EventsEnabled != null)
                hashCode = hashCode * 59 + EventsEnabled.GetHashCode();
            if (EventsExpiration != null)
                hashCode = hashCode * 59 + EventsExpiration.GetHashCode();
            if (EventsListeners != null)
                hashCode = hashCode * 59 + EventsListeners.GetHashCode();
            return hashCode;
        }
    }
}