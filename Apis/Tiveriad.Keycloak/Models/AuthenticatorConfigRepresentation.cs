#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     AuthenticatorConfigRepresentation
/// </summary>
[DataContract]
public class AuthenticatorConfigRepresentation : IEquatable<AuthenticatorConfigRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AuthenticatorConfigRepresentation" /> class.
    /// </summary>
    /// <param name="alias">alias.</param>
    /// <param name="config">config.</param>
    /// <param name="id">id.</param>
    public AuthenticatorConfigRepresentation(string alias = default, Dictionary<string, object> config = default,
        string id = default)
    {
        Alias = alias;
        Config = config;
        Id = id;
    }

    /// <summary>
    ///     Gets or Sets Alias
    /// </summary>
    [DataMember(Name = "alias", EmitDefaultValue = false)]
    public string Alias { get; set; }

    /// <summary>
    ///     Gets or Sets Config
    /// </summary>
    [DataMember(Name = "config", EmitDefaultValue = false)]
    public Dictionary<string, object> Config { get; set; }

    /// <summary>
    ///     Gets or Sets Id
    /// </summary>
    [DataMember(Name = "id", EmitDefaultValue = false)]
    public string Id { get; set; }

    /// <summary>
    ///     Returns true if AuthenticatorConfigRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of AuthenticatorConfigRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(AuthenticatorConfigRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                Alias == input.Alias ||
                (Alias != null &&
                 Alias.Equals(input.Alias))
            ) &&
            (
                Config == input.Config ||
                (Config != null &&
                 input.Config != null &&
                 Config.SequenceEqual(input.Config))
            ) &&
            (
                Id == input.Id ||
                (Id != null &&
                 Id.Equals(input.Id))
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
        sb.Append("class AuthenticatorConfigRepresentation {\n");
        sb.Append("  Alias: ").Append(Alias).Append("\n");
        sb.Append("  Config: ").Append(Config).Append("\n");
        sb.Append("  Id: ").Append(Id).Append("\n");
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
        return Equals(input as AuthenticatorConfigRepresentation);
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
            if (Alias != null)
                hashCode = hashCode * 59 + Alias.GetHashCode();
            if (Config != null)
                hashCode = hashCode * 59 + Config.GetHashCode();
            if (Id != null)
                hashCode = hashCode * 59 + Id.GetHashCode();
            return hashCode;
        }
    }
}