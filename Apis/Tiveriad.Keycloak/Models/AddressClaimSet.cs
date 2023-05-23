#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     AddressClaimSet
/// </summary>
[DataContract]
public class AddressClaimSet : IEquatable<AddressClaimSet>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AddressClaimSet" /> class.
    /// </summary>
    /// <param name="country">country.</param>
    /// <param name="formatted">formatted.</param>
    /// <param name="locality">locality.</param>
    /// <param name="postalCode">postalCode.</param>
    /// <param name="region">region.</param>
    /// <param name="streetAddress">streetAddress.</param>
    public AddressClaimSet(string country = default, string formatted = default, string locality = default,
        string postalCode = default, string region = default, string streetAddress = default)
    {
        Country = country;
        Formatted = formatted;
        Locality = locality;
        PostalCode = postalCode;
        Region = region;
        StreetAddress = streetAddress;
    }

    /// <summary>
    ///     Gets or Sets Country
    /// </summary>
    [DataMember(Name = "country", EmitDefaultValue = false)]
    public string Country { get; set; }

    /// <summary>
    ///     Gets or Sets Formatted
    /// </summary>
    [DataMember(Name = "formatted", EmitDefaultValue = false)]
    public string Formatted { get; set; }

    /// <summary>
    ///     Gets or Sets Locality
    /// </summary>
    [DataMember(Name = "locality", EmitDefaultValue = false)]
    public string Locality { get; set; }

    /// <summary>
    ///     Gets or Sets PostalCode
    /// </summary>
    [DataMember(Name = "postal_code", EmitDefaultValue = false)]
    public string PostalCode { get; set; }

    /// <summary>
    ///     Gets or Sets Region
    /// </summary>
    [DataMember(Name = "region", EmitDefaultValue = false)]
    public string Region { get; set; }

    /// <summary>
    ///     Gets or Sets StreetAddress
    /// </summary>
    [DataMember(Name = "street_address", EmitDefaultValue = false)]
    public string StreetAddress { get; set; }

    /// <summary>
    ///     Returns true if AddressClaimSet instances are equal
    /// </summary>
    /// <param name="input">Instance of AddressClaimSet to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(AddressClaimSet input)
    {
        if (input == null)
            return false;

        return
            (
                Country == input.Country ||
                (Country != null &&
                 Country.Equals(input.Country))
            ) &&
            (
                Formatted == input.Formatted ||
                (Formatted != null &&
                 Formatted.Equals(input.Formatted))
            ) &&
            (
                Locality == input.Locality ||
                (Locality != null &&
                 Locality.Equals(input.Locality))
            ) &&
            (
                PostalCode == input.PostalCode ||
                (PostalCode != null &&
                 PostalCode.Equals(input.PostalCode))
            ) &&
            (
                Region == input.Region ||
                (Region != null &&
                 Region.Equals(input.Region))
            ) &&
            (
                StreetAddress == input.StreetAddress ||
                (StreetAddress != null &&
                 StreetAddress.Equals(input.StreetAddress))
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
        sb.Append("class AddressClaimSet {\n");
        sb.Append("  Country: ").Append(Country).Append("\n");
        sb.Append("  Formatted: ").Append(Formatted).Append("\n");
        sb.Append("  Locality: ").Append(Locality).Append("\n");
        sb.Append("  PostalCode: ").Append(PostalCode).Append("\n");
        sb.Append("  Region: ").Append(Region).Append("\n");
        sb.Append("  StreetAddress: ").Append(StreetAddress).Append("\n");
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
        return Equals(input as AddressClaimSet);
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
            if (Country != null)
                hashCode = hashCode * 59 + Country.GetHashCode();
            if (Formatted != null)
                hashCode = hashCode * 59 + Formatted.GetHashCode();
            if (Locality != null)
                hashCode = hashCode * 59 + Locality.GetHashCode();
            if (PostalCode != null)
                hashCode = hashCode * 59 + PostalCode.GetHashCode();
            if (Region != null)
                hashCode = hashCode * 59 + Region.GetHashCode();
            if (StreetAddress != null)
                hashCode = hashCode * 59 + StreetAddress.GetHashCode();
            return hashCode;
        }
    }
}