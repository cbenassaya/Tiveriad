#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     CertificateRepresentation
/// </summary>
[DataContract]
public class CertificateRepresentation : IEquatable<CertificateRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="CertificateRepresentation" /> class.
    /// </summary>
    /// <param name="certificate">certificate.</param>
    /// <param name="kid">kid.</param>
    /// <param name="privateKey">privateKey.</param>
    /// <param name="publicKey">publicKey.</param>
    public CertificateRepresentation(string certificate = default, string kid = default, string privateKey = default,
        string publicKey = default)
    {
        Certificate = certificate;
        Kid = kid;
        PrivateKey = privateKey;
        PublicKey = publicKey;
    }

    /// <summary>
    ///     Gets or Sets Certificate
    /// </summary>
    [DataMember(Name = "certificate", EmitDefaultValue = false)]
    public string Certificate { get; set; }

    /// <summary>
    ///     Gets or Sets Kid
    /// </summary>
    [DataMember(Name = "kid", EmitDefaultValue = false)]
    public string Kid { get; set; }

    /// <summary>
    ///     Gets or Sets PrivateKey
    /// </summary>
    [DataMember(Name = "privateKey", EmitDefaultValue = false)]
    public string PrivateKey { get; set; }

    /// <summary>
    ///     Gets or Sets PublicKey
    /// </summary>
    [DataMember(Name = "publicKey", EmitDefaultValue = false)]
    public string PublicKey { get; set; }

    /// <summary>
    ///     Returns true if CertificateRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of CertificateRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(CertificateRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                Certificate == input.Certificate ||
                (Certificate != null &&
                 Certificate.Equals(input.Certificate))
            ) &&
            (
                Kid == input.Kid ||
                (Kid != null &&
                 Kid.Equals(input.Kid))
            ) &&
            (
                PrivateKey == input.PrivateKey ||
                (PrivateKey != null &&
                 PrivateKey.Equals(input.PrivateKey))
            ) &&
            (
                PublicKey == input.PublicKey ||
                (PublicKey != null &&
                 PublicKey.Equals(input.PublicKey))
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
        sb.Append("class CertificateRepresentation {\n");
        sb.Append("  Certificate: ").Append(Certificate).Append("\n");
        sb.Append("  Kid: ").Append(Kid).Append("\n");
        sb.Append("  PrivateKey: ").Append(PrivateKey).Append("\n");
        sb.Append("  PublicKey: ").Append(PublicKey).Append("\n");
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
        return Equals(input as CertificateRepresentation);
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
            if (Certificate != null)
                hashCode = hashCode * 59 + Certificate.GetHashCode();
            if (Kid != null)
                hashCode = hashCode * 59 + Kid.GetHashCode();
            if (PrivateKey != null)
                hashCode = hashCode * 59 + PrivateKey.GetHashCode();
            if (PublicKey != null)
                hashCode = hashCode * 59 + PublicKey.GetHashCode();
            return hashCode;
        }
    }
}