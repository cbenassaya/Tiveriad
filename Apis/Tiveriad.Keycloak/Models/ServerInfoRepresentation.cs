#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     ServerInfoRepresentation
/// </summary>
[DataContract]
public class ServerInfoRepresentation : IEquatable<ServerInfoRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ServerInfoRepresentation" /> class.
    /// </summary>
    /// <param name="builtinProtocolMappers">builtinProtocolMappers.</param>
    /// <param name="clientImporters">clientImporters.</param>
    /// <param name="clientInstallations">clientInstallations.</param>
    /// <param name="componentTypes">componentTypes.</param>
    /// <param name="enums">enums.</param>
    /// <param name="identityProviders">identityProviders.</param>
    /// <param name="memoryInfo">memoryInfo.</param>
    /// <param name="passwordPolicies">passwordPolicies.</param>
    /// <param name="profileInfo">profileInfo.</param>
    /// <param name="protocolMapperTypes">protocolMapperTypes.</param>
    /// <param name="providers">providers.</param>
    /// <param name="socialProviders">socialProviders.</param>
    /// <param name="systemInfo">systemInfo.</param>
    /// <param name="themes">themes.</param>
    public ServerInfoRepresentation(Dictionary<string, object> builtinProtocolMappers = default,
        List<Dictionary<string, object>> clientImporters = default,
        Dictionary<string, object> clientInstallations = default, Dictionary<string, object> componentTypes = default,
        Dictionary<string, object> enums = default, List<Dictionary<string, object>> identityProviders = default,
        MemoryInfoRepresentation memoryInfo = default,
        List<PasswordPolicyTypeRepresentation> passwordPolicies = default,
        ProfileInfoRepresentation profileInfo = default, Dictionary<string, object> protocolMapperTypes = default,
        Dictionary<string, object> providers = default, List<Dictionary<string, object>> socialProviders = default,
        SystemInfoRepresentation systemInfo = default, Dictionary<string, object> themes = default)
    {
        BuiltinProtocolMappers = builtinProtocolMappers;
        ClientImporters = clientImporters;
        ClientInstallations = clientInstallations;
        ComponentTypes = componentTypes;
        Enums = enums;
        IdentityProviders = identityProviders;
        MemoryInfo = memoryInfo;
        PasswordPolicies = passwordPolicies;
        ProfileInfo = profileInfo;
        ProtocolMapperTypes = protocolMapperTypes;
        Providers = providers;
        SocialProviders = socialProviders;
        SystemInfo = systemInfo;
        Themes = themes;
    }

    /// <summary>
    ///     Gets or Sets BuiltinProtocolMappers
    /// </summary>
    [DataMember(Name = "builtinProtocolMappers", EmitDefaultValue = false)]
    public Dictionary<string, object> BuiltinProtocolMappers { get; set; }

    /// <summary>
    ///     Gets or Sets ClientImporters
    /// </summary>
    [DataMember(Name = "clientImporters", EmitDefaultValue = false)]
    public List<Dictionary<string, object>> ClientImporters { get; set; }

    /// <summary>
    ///     Gets or Sets ClientInstallations
    /// </summary>
    [DataMember(Name = "clientInstallations", EmitDefaultValue = false)]
    public Dictionary<string, object> ClientInstallations { get; set; }

    /// <summary>
    ///     Gets or Sets ComponentTypes
    /// </summary>
    [DataMember(Name = "componentTypes", EmitDefaultValue = false)]
    public Dictionary<string, object> ComponentTypes { get; set; }

    /// <summary>
    ///     Gets or Sets Enums
    /// </summary>
    [DataMember(Name = "enums", EmitDefaultValue = false)]
    public Dictionary<string, object> Enums { get; set; }

    /// <summary>
    ///     Gets or Sets IdentityProviders
    /// </summary>
    [DataMember(Name = "identityProviders", EmitDefaultValue = false)]
    public List<Dictionary<string, object>> IdentityProviders { get; set; }

    /// <summary>
    ///     Gets or Sets MemoryInfo
    /// </summary>
    [DataMember(Name = "memoryInfo", EmitDefaultValue = false)]
    public MemoryInfoRepresentation MemoryInfo { get; set; }

    /// <summary>
    ///     Gets or Sets PasswordPolicies
    /// </summary>
    [DataMember(Name = "passwordPolicies", EmitDefaultValue = false)]
    public List<PasswordPolicyTypeRepresentation> PasswordPolicies { get; set; }

    /// <summary>
    ///     Gets or Sets ProfileInfo
    /// </summary>
    [DataMember(Name = "profileInfo", EmitDefaultValue = false)]
    public ProfileInfoRepresentation ProfileInfo { get; set; }

    /// <summary>
    ///     Gets or Sets ProtocolMapperTypes
    /// </summary>
    [DataMember(Name = "protocolMapperTypes", EmitDefaultValue = false)]
    public Dictionary<string, object> ProtocolMapperTypes { get; set; }

    /// <summary>
    ///     Gets or Sets Providers
    /// </summary>
    [DataMember(Name = "providers", EmitDefaultValue = false)]
    public Dictionary<string, object> Providers { get; set; }

    /// <summary>
    ///     Gets or Sets SocialProviders
    /// </summary>
    [DataMember(Name = "socialProviders", EmitDefaultValue = false)]
    public List<Dictionary<string, object>> SocialProviders { get; set; }

    /// <summary>
    ///     Gets or Sets SystemInfo
    /// </summary>
    [DataMember(Name = "systemInfo", EmitDefaultValue = false)]
    public SystemInfoRepresentation SystemInfo { get; set; }

    /// <summary>
    ///     Gets or Sets Themes
    /// </summary>
    [DataMember(Name = "themes", EmitDefaultValue = false)]
    public Dictionary<string, object> Themes { get; set; }

    /// <summary>
    ///     Returns true if ServerInfoRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of ServerInfoRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(ServerInfoRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                BuiltinProtocolMappers == input.BuiltinProtocolMappers ||
                (BuiltinProtocolMappers != null &&
                 input.BuiltinProtocolMappers != null &&
                 BuiltinProtocolMappers.SequenceEqual(input.BuiltinProtocolMappers))
            ) &&
            (
                ClientImporters == input.ClientImporters ||
                (ClientImporters != null &&
                 input.ClientImporters != null &&
                 ClientImporters.SequenceEqual(input.ClientImporters))
            ) &&
            (
                ClientInstallations == input.ClientInstallations ||
                (ClientInstallations != null &&
                 input.ClientInstallations != null &&
                 ClientInstallations.SequenceEqual(input.ClientInstallations))
            ) &&
            (
                ComponentTypes == input.ComponentTypes ||
                (ComponentTypes != null &&
                 input.ComponentTypes != null &&
                 ComponentTypes.SequenceEqual(input.ComponentTypes))
            ) &&
            (
                Enums == input.Enums ||
                (Enums != null &&
                 input.Enums != null &&
                 Enums.SequenceEqual(input.Enums))
            ) &&
            (
                IdentityProviders == input.IdentityProviders ||
                (IdentityProviders != null &&
                 input.IdentityProviders != null &&
                 IdentityProviders.SequenceEqual(input.IdentityProviders))
            ) &&
            (
                MemoryInfo == input.MemoryInfo ||
                (MemoryInfo != null &&
                 MemoryInfo.Equals(input.MemoryInfo))
            ) &&
            (
                PasswordPolicies == input.PasswordPolicies ||
                (PasswordPolicies != null &&
                 input.PasswordPolicies != null &&
                 PasswordPolicies.SequenceEqual(input.PasswordPolicies))
            ) &&
            (
                ProfileInfo == input.ProfileInfo ||
                (ProfileInfo != null &&
                 ProfileInfo.Equals(input.ProfileInfo))
            ) &&
            (
                ProtocolMapperTypes == input.ProtocolMapperTypes ||
                (ProtocolMapperTypes != null &&
                 input.ProtocolMapperTypes != null &&
                 ProtocolMapperTypes.SequenceEqual(input.ProtocolMapperTypes))
            ) &&
            (
                Providers == input.Providers ||
                (Providers != null &&
                 input.Providers != null &&
                 Providers.SequenceEqual(input.Providers))
            ) &&
            (
                SocialProviders == input.SocialProviders ||
                (SocialProviders != null &&
                 input.SocialProviders != null &&
                 SocialProviders.SequenceEqual(input.SocialProviders))
            ) &&
            (
                SystemInfo == input.SystemInfo ||
                (SystemInfo != null &&
                 SystemInfo.Equals(input.SystemInfo))
            ) &&
            (
                Themes == input.Themes ||
                (Themes != null &&
                 input.Themes != null &&
                 Themes.SequenceEqual(input.Themes))
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
        sb.Append("class ServerInfoRepresentation {\n");
        sb.Append("  BuiltinProtocolMappers: ").Append(BuiltinProtocolMappers).Append("\n");
        sb.Append("  ClientImporters: ").Append(ClientImporters).Append("\n");
        sb.Append("  ClientInstallations: ").Append(ClientInstallations).Append("\n");
        sb.Append("  ComponentTypes: ").Append(ComponentTypes).Append("\n");
        sb.Append("  Enums: ").Append(Enums).Append("\n");
        sb.Append("  IdentityProviders: ").Append(IdentityProviders).Append("\n");
        sb.Append("  MemoryInfo: ").Append(MemoryInfo).Append("\n");
        sb.Append("  PasswordPolicies: ").Append(PasswordPolicies).Append("\n");
        sb.Append("  ProfileInfo: ").Append(ProfileInfo).Append("\n");
        sb.Append("  ProtocolMapperTypes: ").Append(ProtocolMapperTypes).Append("\n");
        sb.Append("  Providers: ").Append(Providers).Append("\n");
        sb.Append("  SocialProviders: ").Append(SocialProviders).Append("\n");
        sb.Append("  SystemInfo: ").Append(SystemInfo).Append("\n");
        sb.Append("  Themes: ").Append(Themes).Append("\n");
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
        return Equals(input as ServerInfoRepresentation);
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
            if (BuiltinProtocolMappers != null)
                hashCode = hashCode * 59 + BuiltinProtocolMappers.GetHashCode();
            if (ClientImporters != null)
                hashCode = hashCode * 59 + ClientImporters.GetHashCode();
            if (ClientInstallations != null)
                hashCode = hashCode * 59 + ClientInstallations.GetHashCode();
            if (ComponentTypes != null)
                hashCode = hashCode * 59 + ComponentTypes.GetHashCode();
            if (Enums != null)
                hashCode = hashCode * 59 + Enums.GetHashCode();
            if (IdentityProviders != null)
                hashCode = hashCode * 59 + IdentityProviders.GetHashCode();
            if (MemoryInfo != null)
                hashCode = hashCode * 59 + MemoryInfo.GetHashCode();
            if (PasswordPolicies != null)
                hashCode = hashCode * 59 + PasswordPolicies.GetHashCode();
            if (ProfileInfo != null)
                hashCode = hashCode * 59 + ProfileInfo.GetHashCode();
            if (ProtocolMapperTypes != null)
                hashCode = hashCode * 59 + ProtocolMapperTypes.GetHashCode();
            if (Providers != null)
                hashCode = hashCode * 59 + Providers.GetHashCode();
            if (SocialProviders != null)
                hashCode = hashCode * 59 + SocialProviders.GetHashCode();
            if (SystemInfo != null)
                hashCode = hashCode * 59 + SystemInfo.GetHashCode();
            if (Themes != null)
                hashCode = hashCode * 59 + Themes.GetHashCode();
            return hashCode;
        }
    }
}