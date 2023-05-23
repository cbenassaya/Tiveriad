#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     GlobalRequestResult
/// </summary>
[DataContract]
public class GlobalRequestResult : IEquatable<GlobalRequestResult>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="GlobalRequestResult" /> class.
    /// </summary>
    /// <param name="failedRequests">failedRequests.</param>
    /// <param name="successRequests">successRequests.</param>
    public GlobalRequestResult(List<string> failedRequests = default, List<string> successRequests = default)
    {
        FailedRequests = failedRequests;
        SuccessRequests = successRequests;
    }

    /// <summary>
    ///     Gets or Sets FailedRequests
    /// </summary>
    [DataMember(Name = "failedRequests", EmitDefaultValue = false)]
    public List<string> FailedRequests { get; set; }

    /// <summary>
    ///     Gets or Sets SuccessRequests
    /// </summary>
    [DataMember(Name = "successRequests", EmitDefaultValue = false)]
    public List<string> SuccessRequests { get; set; }

    /// <summary>
    ///     Returns true if GlobalRequestResult instances are equal
    /// </summary>
    /// <param name="input">Instance of GlobalRequestResult to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(GlobalRequestResult input)
    {
        if (input == null)
            return false;

        return
            (
                FailedRequests == input.FailedRequests ||
                (FailedRequests != null &&
                 input.FailedRequests != null &&
                 FailedRequests.SequenceEqual(input.FailedRequests))
            ) &&
            (
                SuccessRequests == input.SuccessRequests ||
                (SuccessRequests != null &&
                 input.SuccessRequests != null &&
                 SuccessRequests.SequenceEqual(input.SuccessRequests))
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
        sb.Append("class GlobalRequestResult {\n");
        sb.Append("  FailedRequests: ").Append(FailedRequests).Append("\n");
        sb.Append("  SuccessRequests: ").Append(SuccessRequests).Append("\n");
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
        return Equals(input as GlobalRequestResult);
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
            if (FailedRequests != null)
                hashCode = hashCode * 59 + FailedRequests.GetHashCode();
            if (SuccessRequests != null)
                hashCode = hashCode * 59 + SuccessRequests.GetHashCode();
            return hashCode;
        }
    }
}