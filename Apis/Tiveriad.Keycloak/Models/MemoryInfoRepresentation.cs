#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     MemoryInfoRepresentation
/// </summary>
[DataContract]
public class MemoryInfoRepresentation : IEquatable<MemoryInfoRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MemoryInfoRepresentation" /> class.
    /// </summary>
    /// <param name="free">free.</param>
    /// <param name="freeFormated">freeFormated.</param>
    /// <param name="freePercentage">freePercentage.</param>
    /// <param name="total">total.</param>
    /// <param name="totalFormated">totalFormated.</param>
    /// <param name="used">used.</param>
    /// <param name="usedFormated">usedFormated.</param>
    public MemoryInfoRepresentation(long? free = default, string freeFormated = default, long? freePercentage = default,
        long? total = default, string totalFormated = default, long? used = default, string usedFormated = default)
    {
        Free = free;
        FreeFormated = freeFormated;
        FreePercentage = freePercentage;
        Total = total;
        TotalFormated = totalFormated;
        Used = used;
        UsedFormated = usedFormated;
    }

    /// <summary>
    ///     Gets or Sets Free
    /// </summary>
    [DataMember(Name = "free", EmitDefaultValue = false)]
    public long? Free { get; set; }

    /// <summary>
    ///     Gets or Sets FreeFormated
    /// </summary>
    [DataMember(Name = "freeFormated", EmitDefaultValue = false)]
    public string FreeFormated { get; set; }

    /// <summary>
    ///     Gets or Sets FreePercentage
    /// </summary>
    [DataMember(Name = "freePercentage", EmitDefaultValue = false)]
    public long? FreePercentage { get; set; }

    /// <summary>
    ///     Gets or Sets Total
    /// </summary>
    [DataMember(Name = "total", EmitDefaultValue = false)]
    public long? Total { get; set; }

    /// <summary>
    ///     Gets or Sets TotalFormated
    /// </summary>
    [DataMember(Name = "totalFormated", EmitDefaultValue = false)]
    public string TotalFormated { get; set; }

    /// <summary>
    ///     Gets or Sets Used
    /// </summary>
    [DataMember(Name = "used", EmitDefaultValue = false)]
    public long? Used { get; set; }

    /// <summary>
    ///     Gets or Sets UsedFormated
    /// </summary>
    [DataMember(Name = "usedFormated", EmitDefaultValue = false)]
    public string UsedFormated { get; set; }

    /// <summary>
    ///     Returns true if MemoryInfoRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of MemoryInfoRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(MemoryInfoRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                Free == input.Free ||
                (Free != null &&
                 Free.Equals(input.Free))
            ) &&
            (
                FreeFormated == input.FreeFormated ||
                (FreeFormated != null &&
                 FreeFormated.Equals(input.FreeFormated))
            ) &&
            (
                FreePercentage == input.FreePercentage ||
                (FreePercentage != null &&
                 FreePercentage.Equals(input.FreePercentage))
            ) &&
            (
                Total == input.Total ||
                (Total != null &&
                 Total.Equals(input.Total))
            ) &&
            (
                TotalFormated == input.TotalFormated ||
                (TotalFormated != null &&
                 TotalFormated.Equals(input.TotalFormated))
            ) &&
            (
                Used == input.Used ||
                (Used != null &&
                 Used.Equals(input.Used))
            ) &&
            (
                UsedFormated == input.UsedFormated ||
                (UsedFormated != null &&
                 UsedFormated.Equals(input.UsedFormated))
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
        sb.Append("class MemoryInfoRepresentation {\n");
        sb.Append("  Free: ").Append(Free).Append("\n");
        sb.Append("  FreeFormated: ").Append(FreeFormated).Append("\n");
        sb.Append("  FreePercentage: ").Append(FreePercentage).Append("\n");
        sb.Append("  Total: ").Append(Total).Append("\n");
        sb.Append("  TotalFormated: ").Append(TotalFormated).Append("\n");
        sb.Append("  Used: ").Append(Used).Append("\n");
        sb.Append("  UsedFormated: ").Append(UsedFormated).Append("\n");
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
        return Equals(input as MemoryInfoRepresentation);
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
            if (Free != null)
                hashCode = hashCode * 59 + Free.GetHashCode();
            if (FreeFormated != null)
                hashCode = hashCode * 59 + FreeFormated.GetHashCode();
            if (FreePercentage != null)
                hashCode = hashCode * 59 + FreePercentage.GetHashCode();
            if (Total != null)
                hashCode = hashCode * 59 + Total.GetHashCode();
            if (TotalFormated != null)
                hashCode = hashCode * 59 + TotalFormated.GetHashCode();
            if (Used != null)
                hashCode = hashCode * 59 + Used.GetHashCode();
            if (UsedFormated != null)
                hashCode = hashCode * 59 + UsedFormated.GetHashCode();
            return hashCode;
        }
    }
}