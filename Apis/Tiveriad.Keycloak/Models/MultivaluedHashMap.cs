#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     MultivaluedHashMap
/// </summary>
[DataContract]
public class MultivaluedHashMap : IEquatable<MultivaluedHashMap>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MultivaluedHashMap" /> class.
    /// </summary>
    /// <param name="empty">empty.</param>
    /// <param name="loadFactor">loadFactor.</param>
    /// <param name="threshold">threshold.</param>
    public MultivaluedHashMap(bool? empty = default, float? loadFactor = default, int? threshold = default)
    {
        Empty = empty;
        LoadFactor = loadFactor;
        Threshold = threshold;
    }

    /// <summary>
    ///     Gets or Sets Empty
    /// </summary>
    [DataMember(Name = "empty", EmitDefaultValue = false)]
    public bool? Empty { get; set; }

    /// <summary>
    ///     Gets or Sets LoadFactor
    /// </summary>
    [DataMember(Name = "loadFactor", EmitDefaultValue = false)]
    public float? LoadFactor { get; set; }

    /// <summary>
    ///     Gets or Sets Threshold
    /// </summary>
    [DataMember(Name = "threshold", EmitDefaultValue = false)]
    public int? Threshold { get; set; }

    /// <summary>
    ///     Returns true if MultivaluedHashMap instances are equal
    /// </summary>
    /// <param name="input">Instance of MultivaluedHashMap to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(MultivaluedHashMap input)
    {
        if (input == null)
            return false;

        return
            (
                Empty == input.Empty ||
                (Empty != null &&
                 Empty.Equals(input.Empty))
            ) &&
            (
                LoadFactor == input.LoadFactor ||
                (LoadFactor != null &&
                 LoadFactor.Equals(input.LoadFactor))
            ) &&
            (
                Threshold == input.Threshold ||
                (Threshold != null &&
                 Threshold.Equals(input.Threshold))
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
        sb.Append("class MultivaluedHashMap {\n");
        sb.Append("  Empty: ").Append(Empty).Append("\n");
        sb.Append("  LoadFactor: ").Append(LoadFactor).Append("\n");
        sb.Append("  Threshold: ").Append(Threshold).Append("\n");
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
        return Equals(input as MultivaluedHashMap);
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
            if (Empty != null)
                hashCode = hashCode * 59 + Empty.GetHashCode();
            if (LoadFactor != null)
                hashCode = hashCode * 59 + LoadFactor.GetHashCode();
            if (Threshold != null)
                hashCode = hashCode * 59 + Threshold.GetHashCode();
            return hashCode;
        }
    }
}