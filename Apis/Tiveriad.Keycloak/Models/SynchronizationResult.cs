#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     SynchronizationResult
/// </summary>
[DataContract]
public class SynchronizationResult : IEquatable<SynchronizationResult>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="SynchronizationResult" /> class.
    /// </summary>
    /// <param name="added">added.</param>
    /// <param name="failed">failed.</param>
    /// <param name="ignored">ignored.</param>
    /// <param name="removed">removed.</param>
    /// <param name="status">status.</param>
    /// <param name="updated">updated.</param>
    public SynchronizationResult(int? added = default, int? failed = default, bool? ignored = default,
        int? removed = default, string status = default, int? updated = default)
    {
        Added = added;
        Failed = failed;
        Ignored = ignored;
        Removed = removed;
        Status = status;
        Updated = updated;
    }

    /// <summary>
    ///     Gets or Sets Added
    /// </summary>
    [DataMember(Name = "added", EmitDefaultValue = false)]
    public int? Added { get; set; }

    /// <summary>
    ///     Gets or Sets Failed
    /// </summary>
    [DataMember(Name = "failed", EmitDefaultValue = false)]
    public int? Failed { get; set; }

    /// <summary>
    ///     Gets or Sets Ignored
    /// </summary>
    [DataMember(Name = "ignored", EmitDefaultValue = false)]
    public bool? Ignored { get; set; }

    /// <summary>
    ///     Gets or Sets Removed
    /// </summary>
    [DataMember(Name = "removed", EmitDefaultValue = false)]
    public int? Removed { get; set; }

    /// <summary>
    ///     Gets or Sets Status
    /// </summary>
    [DataMember(Name = "status", EmitDefaultValue = false)]
    public string Status { get; set; }

    /// <summary>
    ///     Gets or Sets Updated
    /// </summary>
    [DataMember(Name = "updated", EmitDefaultValue = false)]
    public int? Updated { get; set; }

    /// <summary>
    ///     Returns true if SynchronizationResult instances are equal
    /// </summary>
    /// <param name="input">Instance of SynchronizationResult to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(SynchronizationResult input)
    {
        if (input == null)
            return false;

        return
            (
                Added == input.Added ||
                (Added != null &&
                 Added.Equals(input.Added))
            ) &&
            (
                Failed == input.Failed ||
                (Failed != null &&
                 Failed.Equals(input.Failed))
            ) &&
            (
                Ignored == input.Ignored ||
                (Ignored != null &&
                 Ignored.Equals(input.Ignored))
            ) &&
            (
                Removed == input.Removed ||
                (Removed != null &&
                 Removed.Equals(input.Removed))
            ) &&
            (
                Status == input.Status ||
                (Status != null &&
                 Status.Equals(input.Status))
            ) &&
            (
                Updated == input.Updated ||
                (Updated != null &&
                 Updated.Equals(input.Updated))
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
        sb.Append("class SynchronizationResult {\n");
        sb.Append("  Added: ").Append(Added).Append("\n");
        sb.Append("  Failed: ").Append(Failed).Append("\n");
        sb.Append("  Ignored: ").Append(Ignored).Append("\n");
        sb.Append("  Removed: ").Append(Removed).Append("\n");
        sb.Append("  Status: ").Append(Status).Append("\n");
        sb.Append("  Updated: ").Append(Updated).Append("\n");
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
        return Equals(input as SynchronizationResult);
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
            if (Added != null)
                hashCode = hashCode * 59 + Added.GetHashCode();
            if (Failed != null)
                hashCode = hashCode * 59 + Failed.GetHashCode();
            if (Ignored != null)
                hashCode = hashCode * 59 + Ignored.GetHashCode();
            if (Removed != null)
                hashCode = hashCode * 59 + Removed.GetHashCode();
            if (Status != null)
                hashCode = hashCode * 59 + Status.GetHashCode();
            if (Updated != null)
                hashCode = hashCode * 59 + Updated.GetHashCode();
            return hashCode;
        }
    }
}