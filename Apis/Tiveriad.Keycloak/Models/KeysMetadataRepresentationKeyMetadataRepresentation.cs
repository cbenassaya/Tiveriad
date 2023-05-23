#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     KeysMetadataRepresentationKeyMetadataRepresentation
/// </summary>
[DataContract]
public class
    KeysMetadataRepresentationKeyMetadataRepresentation :
        IEquatable<KeysMetadataRepresentationKeyMetadataRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Defines Use
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UseEnum
    {
        /// <summary>
        ///     Enum SIG for value: SIG
        /// </summary>
        [EnumMember(Value = "SIG")] SIG = 1,

        /// <summary>
        ///     Enum ENC for value: ENC
        /// </summary>
        [EnumMember(Value = "ENC")] ENC = 2
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="KeysMetadataRepresentationKeyMetadataRepresentation" /> class.
    /// </summary>
    /// <param name="algorithm">algorithm.</param>
    /// <param name="certificate">certificate.</param>
    /// <param name="kid">kid.</param>
    /// <param name="providerId">providerId.</param>
    /// <param name="providerPriority">providerPriority.</param>
    /// <param name="publicKey">publicKey.</param>
    /// <param name="status">status.</param>
    /// <param name="type">type.</param>
    /// <param name="use">use.</param>
    public KeysMetadataRepresentationKeyMetadataRepresentation(string algorithm = default, string certificate = default,
        string kid = default, string providerId = default, long? providerPriority = default, string publicKey = default,
        string status = default, string type = default, UseEnum? use = default)
    {
        Algorithm = algorithm;
        Certificate = certificate;
        Kid = kid;
        ProviderId = providerId;
        ProviderPriority = providerPriority;
        PublicKey = publicKey;
        Status = status;
        Type = type;
        Use = use;
    }

    /// <summary>
    ///     Gets or Sets Use
    /// </summary>
    [DataMember(Name = "use", EmitDefaultValue = false)]
    public UseEnum? Use { get; set; }

    /// <summary>
    ///     Gets or Sets Algorithm
    /// </summary>
    [DataMember(Name = "algorithm", EmitDefaultValue = false)]
    public string Algorithm { get; set; }

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
    ///     Gets or Sets ProviderId
    /// </summary>
    [DataMember(Name = "providerId", EmitDefaultValue = false)]
    public string ProviderId { get; set; }

    /// <summary>
    ///     Gets or Sets ProviderPriority
    /// </summary>
    [DataMember(Name = "providerPriority", EmitDefaultValue = false)]
    public long? ProviderPriority { get; set; }

    /// <summary>
    ///     Gets or Sets PublicKey
    /// </summary>
    [DataMember(Name = "publicKey", EmitDefaultValue = false)]
    public string PublicKey { get; set; }

    /// <summary>
    ///     Gets or Sets Status
    /// </summary>
    [DataMember(Name = "status", EmitDefaultValue = false)]
    public string Status { get; set; }

    /// <summary>
    ///     Gets or Sets Type
    /// </summary>
    [DataMember(Name = "type", EmitDefaultValue = false)]
    public string Type { get; set; }

    /// <summary>
    ///     Returns true if KeysMetadataRepresentationKeyMetadataRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of KeysMetadataRepresentationKeyMetadataRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(KeysMetadataRepresentationKeyMetadataRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                Algorithm == input.Algorithm ||
                (Algorithm != null &&
                 Algorithm.Equals(input.Algorithm))
            ) &&
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
                ProviderId == input.ProviderId ||
                (ProviderId != null &&
                 ProviderId.Equals(input.ProviderId))
            ) &&
            (
                ProviderPriority == input.ProviderPriority ||
                (ProviderPriority != null &&
                 ProviderPriority.Equals(input.ProviderPriority))
            ) &&
            (
                PublicKey == input.PublicKey ||
                (PublicKey != null &&
                 PublicKey.Equals(input.PublicKey))
            ) &&
            (
                Status == input.Status ||
                (Status != null &&
                 Status.Equals(input.Status))
            ) &&
            (
                Type == input.Type ||
                (Type != null &&
                 Type.Equals(input.Type))
            ) &&
            (
                Use == input.Use ||
                (Use != null &&
                 Use.Equals(input.Use))
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
        sb.Append("class KeysMetadataRepresentationKeyMetadataRepresentation {\n");
        sb.Append("  Algorithm: ").Append(Algorithm).Append("\n");
        sb.Append("  Certificate: ").Append(Certificate).Append("\n");
        sb.Append("  Kid: ").Append(Kid).Append("\n");
        sb.Append("  ProviderId: ").Append(ProviderId).Append("\n");
        sb.Append("  ProviderPriority: ").Append(ProviderPriority).Append("\n");
        sb.Append("  PublicKey: ").Append(PublicKey).Append("\n");
        sb.Append("  Status: ").Append(Status).Append("\n");
        sb.Append("  Type: ").Append(Type).Append("\n");
        sb.Append("  Use: ").Append(Use).Append("\n");
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
        return Equals(input as KeysMetadataRepresentationKeyMetadataRepresentation);
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
            if (Algorithm != null)
                hashCode = hashCode * 59 + Algorithm.GetHashCode();
            if (Certificate != null)
                hashCode = hashCode * 59 + Certificate.GetHashCode();
            if (Kid != null)
                hashCode = hashCode * 59 + Kid.GetHashCode();
            if (ProviderId != null)
                hashCode = hashCode * 59 + ProviderId.GetHashCode();
            if (ProviderPriority != null)
                hashCode = hashCode * 59 + ProviderPriority.GetHashCode();
            if (PublicKey != null)
                hashCode = hashCode * 59 + PublicKey.GetHashCode();
            if (Status != null)
                hashCode = hashCode * 59 + Status.GetHashCode();
            if (Type != null)
                hashCode = hashCode * 59 + Type.GetHashCode();
            if (Use != null)
                hashCode = hashCode * 59 + Use.GetHashCode();
            return hashCode;
        }
    }
}