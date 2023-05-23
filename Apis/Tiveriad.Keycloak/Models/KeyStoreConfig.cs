#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     KeyStoreConfig
/// </summary>
[DataContract]
public class KeyStoreConfig : IEquatable<KeyStoreConfig>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="KeyStoreConfig" /> class.
    /// </summary>
    /// <param name="format">format.</param>
    /// <param name="keyAlias">keyAlias.</param>
    /// <param name="keyPassword">keyPassword.</param>
    /// <param name="realmAlias">realmAlias.</param>
    /// <param name="realmCertificate">realmCertificate.</param>
    /// <param name="storePassword">storePassword.</param>
    public KeyStoreConfig(string format = default, string keyAlias = default, string keyPassword = default,
        string realmAlias = default, bool? realmCertificate = default, string storePassword = default)
    {
        Format = format;
        KeyAlias = keyAlias;
        KeyPassword = keyPassword;
        RealmAlias = realmAlias;
        RealmCertificate = realmCertificate;
        StorePassword = storePassword;
    }

    /// <summary>
    ///     Gets or Sets Format
    /// </summary>
    [DataMember(Name = "format", EmitDefaultValue = false)]
    public string Format { get; set; }

    /// <summary>
    ///     Gets or Sets KeyAlias
    /// </summary>
    [DataMember(Name = "keyAlias", EmitDefaultValue = false)]
    public string KeyAlias { get; set; }

    /// <summary>
    ///     Gets or Sets KeyPassword
    /// </summary>
    [DataMember(Name = "keyPassword", EmitDefaultValue = false)]
    public string KeyPassword { get; set; }

    /// <summary>
    ///     Gets or Sets RealmAlias
    /// </summary>
    [DataMember(Name = "realmAlias", EmitDefaultValue = false)]
    public string RealmAlias { get; set; }

    /// <summary>
    ///     Gets or Sets RealmCertificate
    /// </summary>
    [DataMember(Name = "realmCertificate", EmitDefaultValue = false)]
    public bool? RealmCertificate { get; set; }

    /// <summary>
    ///     Gets or Sets StorePassword
    /// </summary>
    [DataMember(Name = "storePassword", EmitDefaultValue = false)]
    public string StorePassword { get; set; }

    /// <summary>
    ///     Returns true if KeyStoreConfig instances are equal
    /// </summary>
    /// <param name="input">Instance of KeyStoreConfig to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(KeyStoreConfig input)
    {
        if (input == null)
            return false;

        return
            (
                Format == input.Format ||
                (Format != null &&
                 Format.Equals(input.Format))
            ) &&
            (
                KeyAlias == input.KeyAlias ||
                (KeyAlias != null &&
                 KeyAlias.Equals(input.KeyAlias))
            ) &&
            (
                KeyPassword == input.KeyPassword ||
                (KeyPassword != null &&
                 KeyPassword.Equals(input.KeyPassword))
            ) &&
            (
                RealmAlias == input.RealmAlias ||
                (RealmAlias != null &&
                 RealmAlias.Equals(input.RealmAlias))
            ) &&
            (
                RealmCertificate == input.RealmCertificate ||
                (RealmCertificate != null &&
                 RealmCertificate.Equals(input.RealmCertificate))
            ) &&
            (
                StorePassword == input.StorePassword ||
                (StorePassword != null &&
                 StorePassword.Equals(input.StorePassword))
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
        sb.Append("class KeyStoreConfig {\n");
        sb.Append("  Format: ").Append(Format).Append("\n");
        sb.Append("  KeyAlias: ").Append(KeyAlias).Append("\n");
        sb.Append("  KeyPassword: ").Append(KeyPassword).Append("\n");
        sb.Append("  RealmAlias: ").Append(RealmAlias).Append("\n");
        sb.Append("  RealmCertificate: ").Append(RealmCertificate).Append("\n");
        sb.Append("  StorePassword: ").Append(StorePassword).Append("\n");
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
        return Equals(input as KeyStoreConfig);
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
            if (Format != null)
                hashCode = hashCode * 59 + Format.GetHashCode();
            if (KeyAlias != null)
                hashCode = hashCode * 59 + KeyAlias.GetHashCode();
            if (KeyPassword != null)
                hashCode = hashCode * 59 + KeyPassword.GetHashCode();
            if (RealmAlias != null)
                hashCode = hashCode * 59 + RealmAlias.GetHashCode();
            if (RealmCertificate != null)
                hashCode = hashCode * 59 + RealmCertificate.GetHashCode();
            if (StorePassword != null)
                hashCode = hashCode * 59 + StorePassword.GetHashCode();
            return hashCode;
        }
    }
}