#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     PartialImportRepresentation
/// </summary>
[DataContract]
public class PartialImportRepresentation : IEquatable<PartialImportRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Defines Policy
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PolicyEnum
    {
        /// <summary>
        ///     Enum SKIP for value: SKIP
        /// </summary>
        [EnumMember(Value = "SKIP")] SKIP = 1,

        /// <summary>
        ///     Enum OVERWRITE for value: OVERWRITE
        /// </summary>
        [EnumMember(Value = "OVERWRITE")] OVERWRITE = 2,

        /// <summary>
        ///     Enum FAIL for value: FAIL
        /// </summary>
        [EnumMember(Value = "FAIL")] FAIL = 3
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="PartialImportRepresentation" /> class.
    /// </summary>
    /// <param name="clients">clients.</param>
    /// <param name="groups">groups.</param>
    /// <param name="identityProviders">identityProviders.</param>
    /// <param name="ifResourceExists">ifResourceExists.</param>
    /// <param name="policy">policy.</param>
    /// <param name="roles">roles.</param>
    /// <param name="users">users.</param>
    public PartialImportRepresentation(List<ClientRepresentation> clients = default,
        List<GroupRepresentation> groups = default, List<IdentityProviderRepresentation> identityProviders = default,
        string ifResourceExists = default, PolicyEnum? policy = default, RolesRepresentation roles = default,
        List<UserRepresentation> users = default)
    {
        Clients = clients;
        Groups = groups;
        IdentityProviders = identityProviders;
        IfResourceExists = ifResourceExists;
        Policy = policy;
        Roles = roles;
        Users = users;
    }

    /// <summary>
    ///     Gets or Sets Policy
    /// </summary>
    [DataMember(Name = "policy", EmitDefaultValue = false)]
    public PolicyEnum? Policy { get; set; }

    /// <summary>
    ///     Gets or Sets Clients
    /// </summary>
    [DataMember(Name = "clients", EmitDefaultValue = false)]
    public List<ClientRepresentation> Clients { get; set; }

    /// <summary>
    ///     Gets or Sets Groups
    /// </summary>
    [DataMember(Name = "groups", EmitDefaultValue = false)]
    public List<GroupRepresentation> Groups { get; set; }

    /// <summary>
    ///     Gets or Sets IdentityProviders
    /// </summary>
    [DataMember(Name = "identityProviders", EmitDefaultValue = false)]
    public List<IdentityProviderRepresentation> IdentityProviders { get; set; }

    /// <summary>
    ///     Gets or Sets IfResourceExists
    /// </summary>
    [DataMember(Name = "ifResourceExists", EmitDefaultValue = false)]
    public string IfResourceExists { get; set; }


    /// <summary>
    ///     Gets or Sets Roles
    /// </summary>
    [DataMember(Name = "roles", EmitDefaultValue = false)]
    public RolesRepresentation Roles { get; set; }

    /// <summary>
    ///     Gets or Sets Users
    /// </summary>
    [DataMember(Name = "users", EmitDefaultValue = false)]
    public List<UserRepresentation> Users { get; set; }

    /// <summary>
    ///     Returns true if PartialImportRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of PartialImportRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(PartialImportRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                Clients == input.Clients ||
                (Clients != null &&
                 input.Clients != null &&
                 Clients.SequenceEqual(input.Clients))
            ) &&
            (
                Groups == input.Groups ||
                (Groups != null &&
                 input.Groups != null &&
                 Groups.SequenceEqual(input.Groups))
            ) &&
            (
                IdentityProviders == input.IdentityProviders ||
                (IdentityProviders != null &&
                 input.IdentityProviders != null &&
                 IdentityProviders.SequenceEqual(input.IdentityProviders))
            ) &&
            (
                IfResourceExists == input.IfResourceExists ||
                (IfResourceExists != null &&
                 IfResourceExists.Equals(input.IfResourceExists))
            ) &&
            (
                Policy == input.Policy ||
                (Policy != null &&
                 Policy.Equals(input.Policy))
            ) &&
            (
                Roles == input.Roles ||
                (Roles != null &&
                 Roles.Equals(input.Roles))
            ) &&
            (
                Users == input.Users ||
                (Users != null &&
                 input.Users != null &&
                 Users.SequenceEqual(input.Users))
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
        sb.Append("class PartialImportRepresentation {\n");
        sb.Append("  Clients: ").Append(Clients).Append("\n");
        sb.Append("  Groups: ").Append(Groups).Append("\n");
        sb.Append("  IdentityProviders: ").Append(IdentityProviders).Append("\n");
        sb.Append("  IfResourceExists: ").Append(IfResourceExists).Append("\n");
        sb.Append("  Policy: ").Append(Policy).Append("\n");
        sb.Append("  Roles: ").Append(Roles).Append("\n");
        sb.Append("  Users: ").Append(Users).Append("\n");
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
        return Equals(input as PartialImportRepresentation);
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
            if (Clients != null)
                hashCode = hashCode * 59 + Clients.GetHashCode();
            if (Groups != null)
                hashCode = hashCode * 59 + Groups.GetHashCode();
            if (IdentityProviders != null)
                hashCode = hashCode * 59 + IdentityProviders.GetHashCode();
            if (IfResourceExists != null)
                hashCode = hashCode * 59 + IfResourceExists.GetHashCode();
            if (Policy != null)
                hashCode = hashCode * 59 + Policy.GetHashCode();
            if (Roles != null)
                hashCode = hashCode * 59 + Roles.GetHashCode();
            if (Users != null)
                hashCode = hashCode * 59 + Users.GetHashCode();
            return hashCode;
        }
    }
}