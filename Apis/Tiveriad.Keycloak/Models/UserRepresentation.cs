#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     UserRepresentation
/// </summary>
[DataContract]
public class UserRepresentation : IEquatable<UserRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserRepresentation" /> class.
    /// </summary>
    /// <param name="access">access.</param>
    /// <param name="attributes">attributes.</param>
    /// <param name="clientConsents">clientConsents.</param>
    /// <param name="clientRoles">clientRoles.</param>
    /// <param name="createdTimestamp">createdTimestamp.</param>
    /// <param name="credentials">credentials.</param>
    /// <param name="disableableCredentialTypes">disableableCredentialTypes.</param>
    /// <param name="email">email.</param>
    /// <param name="emailVerified">emailVerified.</param>
    /// <param name="enabled">enabled.</param>
    /// <param name="federatedIdentities">federatedIdentities.</param>
    /// <param name="federationLink">federationLink.</param>
    /// <param name="firstName">firstName.</param>
    /// <param name="groups">groups.</param>
    /// <param name="id">id.</param>
    /// <param name="lastName">lastName.</param>
    /// <param name="notBefore">notBefore.</param>
    /// <param name="origin">origin.</param>
    /// <param name="realmRoles">realmRoles.</param>
    /// <param name="requiredActions">requiredActions.</param>
    /// <param name="self">self.</param>
    /// <param name="serviceAccountClientId">serviceAccountClientId.</param>
    /// <param name="username">username.</param>
    public UserRepresentation(Dictionary<string, object> access = default,
        Dictionary<string, object> attributes = default, List<UserConsentRepresentation> clientConsents = default,
        Dictionary<string, object> clientRoles = default, long? createdTimestamp = default,
        List<CredentialRepresentation> credentials = default, List<string> disableableCredentialTypes = default,
        string email = default, bool? emailVerified = default, bool? enabled = default,
        List<FederatedIdentityRepresentation> federatedIdentities = default, string federationLink = default,
        string firstName = default, List<string> groups = default, string id = default, string lastName = default,
        int? notBefore = default, string origin = default, List<string> realmRoles = default,
        List<string> requiredActions = default, string self = default, string serviceAccountClientId = default,
        string username = default)
    {
        Access = access;
        Attributes = attributes;
        ClientConsents = clientConsents;
        ClientRoles = clientRoles;
        CreatedTimestamp = createdTimestamp;
        Credentials = credentials;
        DisableableCredentialTypes = disableableCredentialTypes;
        Email = email;
        EmailVerified = emailVerified;
        Enabled = enabled;
        FederatedIdentities = federatedIdentities;
        FederationLink = federationLink;
        FirstName = firstName;
        Groups = groups;
        Id = id;
        LastName = lastName;
        NotBefore = notBefore;
        Origin = origin;
        RealmRoles = realmRoles;
        RequiredActions = requiredActions;
        Self = self;
        ServiceAccountClientId = serviceAccountClientId;
        Username = username;
    }

    /// <summary>
    ///     Gets or Sets Access
    /// </summary>
    [DataMember(Name = "access", EmitDefaultValue = false)]
    public Dictionary<string, object> Access { get; set; }

    /// <summary>
    ///     Gets or Sets Attributes
    /// </summary>
    [DataMember(Name = "attributes", EmitDefaultValue = false)]
    public Dictionary<string, object> Attributes { get; set; }

    /// <summary>
    ///     Gets or Sets ClientConsents
    /// </summary>
    [DataMember(Name = "clientConsents", EmitDefaultValue = false)]
    public List<UserConsentRepresentation> ClientConsents { get; set; }

    /// <summary>
    ///     Gets or Sets ClientRoles
    /// </summary>
    [DataMember(Name = "clientRoles", EmitDefaultValue = false)]
    public Dictionary<string, object> ClientRoles { get; set; }

    /// <summary>
    ///     Gets or Sets CreatedTimestamp
    /// </summary>
    [DataMember(Name = "createdTimestamp", EmitDefaultValue = false)]
    public long? CreatedTimestamp { get; set; }

    /// <summary>
    ///     Gets or Sets Credentials
    /// </summary>
    [DataMember(Name = "credentials", EmitDefaultValue = false)]
    public List<CredentialRepresentation> Credentials { get; set; }

    /// <summary>
    ///     Gets or Sets DisableableCredentialTypes
    /// </summary>
    [DataMember(Name = "disableableCredentialTypes", EmitDefaultValue = false)]
    public List<string> DisableableCredentialTypes { get; set; }

    /// <summary>
    ///     Gets or Sets Email
    /// </summary>
    [DataMember(Name = "email", EmitDefaultValue = false)]
    public string Email { get; set; }

    /// <summary>
    ///     Gets or Sets EmailVerified
    /// </summary>
    [DataMember(Name = "emailVerified", EmitDefaultValue = false)]
    public bool? EmailVerified { get; set; }

    /// <summary>
    ///     Gets or Sets Enabled
    /// </summary>
    [DataMember(Name = "enabled", EmitDefaultValue = false)]
    public bool? Enabled { get; set; }

    /// <summary>
    ///     Gets or Sets FederatedIdentities
    /// </summary>
    [DataMember(Name = "federatedIdentities", EmitDefaultValue = false)]
    public List<FederatedIdentityRepresentation> FederatedIdentities { get; set; }

    /// <summary>
    ///     Gets or Sets FederationLink
    /// </summary>
    [DataMember(Name = "federationLink", EmitDefaultValue = false)]
    public string FederationLink { get; set; }

    /// <summary>
    ///     Gets or Sets FirstName
    /// </summary>
    [DataMember(Name = "firstName", EmitDefaultValue = false)]
    public string FirstName { get; set; }

    /// <summary>
    ///     Gets or Sets Groups
    /// </summary>
    [DataMember(Name = "groups", EmitDefaultValue = false)]
    public List<string> Groups { get; set; }

    /// <summary>
    ///     Gets or Sets Id
    /// </summary>
    [DataMember(Name = "id", EmitDefaultValue = false)]
    public string Id { get; set; }

    /// <summary>
    ///     Gets or Sets LastName
    /// </summary>
    [DataMember(Name = "lastName", EmitDefaultValue = false)]
    public string LastName { get; set; }

    /// <summary>
    ///     Gets or Sets NotBefore
    /// </summary>
    [DataMember(Name = "notBefore", EmitDefaultValue = false)]
    public int? NotBefore { get; set; }

    /// <summary>
    ///     Gets or Sets Origin
    /// </summary>
    [DataMember(Name = "origin", EmitDefaultValue = false)]
    public string Origin { get; set; }

    /// <summary>
    ///     Gets or Sets RealmRoles
    /// </summary>
    [DataMember(Name = "realmRoles", EmitDefaultValue = false)]
    public List<string> RealmRoles { get; set; }

    /// <summary>
    ///     Gets or Sets RequiredActions
    /// </summary>
    [DataMember(Name = "requiredActions", EmitDefaultValue = false)]
    public List<string> RequiredActions { get; set; }

    /// <summary>
    ///     Gets or Sets Self
    /// </summary>
    [DataMember(Name = "self", EmitDefaultValue = false)]
    public string Self { get; set; }

    /// <summary>
    ///     Gets or Sets ServiceAccountClientId
    /// </summary>
    [DataMember(Name = "serviceAccountClientId", EmitDefaultValue = false)]
    public string ServiceAccountClientId { get; set; }

    /// <summary>
    ///     Gets or Sets Username
    /// </summary>
    [DataMember(Name = "username", EmitDefaultValue = false)]
    public string Username { get; set; }

    /// <summary>
    ///     Returns true if UserRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of UserRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(UserRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                Access == input.Access ||
                (Access != null &&
                 input.Access != null &&
                 Access.SequenceEqual(input.Access))
            ) &&
            (
                Attributes == input.Attributes ||
                (Attributes != null &&
                 input.Attributes != null &&
                 Attributes.SequenceEqual(input.Attributes))
            ) &&
            (
                ClientConsents == input.ClientConsents ||
                (ClientConsents != null &&
                 input.ClientConsents != null &&
                 ClientConsents.SequenceEqual(input.ClientConsents))
            ) &&
            (
                ClientRoles == input.ClientRoles ||
                (ClientRoles != null &&
                 input.ClientRoles != null &&
                 ClientRoles.SequenceEqual(input.ClientRoles))
            ) &&
            (
                CreatedTimestamp == input.CreatedTimestamp ||
                (CreatedTimestamp != null &&
                 CreatedTimestamp.Equals(input.CreatedTimestamp))
            ) &&
            (
                Credentials == input.Credentials ||
                (Credentials != null &&
                 input.Credentials != null &&
                 Credentials.SequenceEqual(input.Credentials))
            ) &&
            (
                DisableableCredentialTypes == input.DisableableCredentialTypes ||
                (DisableableCredentialTypes != null &&
                 input.DisableableCredentialTypes != null &&
                 DisableableCredentialTypes.SequenceEqual(input.DisableableCredentialTypes))
            ) &&
            (
                Email == input.Email ||
                (Email != null &&
                 Email.Equals(input.Email))
            ) &&
            (
                EmailVerified == input.EmailVerified ||
                (EmailVerified != null &&
                 EmailVerified.Equals(input.EmailVerified))
            ) &&
            (
                Enabled == input.Enabled ||
                (Enabled != null &&
                 Enabled.Equals(input.Enabled))
            ) &&
            (
                FederatedIdentities == input.FederatedIdentities ||
                (FederatedIdentities != null &&
                 input.FederatedIdentities != null &&
                 FederatedIdentities.SequenceEqual(input.FederatedIdentities))
            ) &&
            (
                FederationLink == input.FederationLink ||
                (FederationLink != null &&
                 FederationLink.Equals(input.FederationLink))
            ) &&
            (
                FirstName == input.FirstName ||
                (FirstName != null &&
                 FirstName.Equals(input.FirstName))
            ) &&
            (
                Groups == input.Groups ||
                (Groups != null &&
                 input.Groups != null &&
                 Groups.SequenceEqual(input.Groups))
            ) &&
            (
                Id == input.Id ||
                (Id != null &&
                 Id.Equals(input.Id))
            ) &&
            (
                LastName == input.LastName ||
                (LastName != null &&
                 LastName.Equals(input.LastName))
            ) &&
            (
                NotBefore == input.NotBefore ||
                (NotBefore != null &&
                 NotBefore.Equals(input.NotBefore))
            ) &&
            (
                Origin == input.Origin ||
                (Origin != null &&
                 Origin.Equals(input.Origin))
            ) &&
            (
                RealmRoles == input.RealmRoles ||
                (RealmRoles != null &&
                 input.RealmRoles != null &&
                 RealmRoles.SequenceEqual(input.RealmRoles))
            ) &&
            (
                RequiredActions == input.RequiredActions ||
                (RequiredActions != null &&
                 input.RequiredActions != null &&
                 RequiredActions.SequenceEqual(input.RequiredActions))
            ) &&
            (
                Self == input.Self ||
                (Self != null &&
                 Self.Equals(input.Self))
            ) &&
            (
                ServiceAccountClientId == input.ServiceAccountClientId ||
                (ServiceAccountClientId != null &&
                 ServiceAccountClientId.Equals(input.ServiceAccountClientId))
            ) &&
            (
                Username == input.Username ||
                (Username != null &&
                 Username.Equals(input.Username))
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
        sb.Append("class UserRepresentation {\n");
        sb.Append("  Access: ").Append(Access).Append("\n");
        sb.Append("  Attributes: ").Append(Attributes).Append("\n");
        sb.Append("  ClientConsents: ").Append(ClientConsents).Append("\n");
        sb.Append("  ClientRoles: ").Append(ClientRoles).Append("\n");
        sb.Append("  CreatedTimestamp: ").Append(CreatedTimestamp).Append("\n");
        sb.Append("  Credentials: ").Append(Credentials).Append("\n");
        sb.Append("  DisableableCredentialTypes: ").Append(DisableableCredentialTypes).Append("\n");
        sb.Append("  Email: ").Append(Email).Append("\n");
        sb.Append("  EmailVerified: ").Append(EmailVerified).Append("\n");
        sb.Append("  Enabled: ").Append(Enabled).Append("\n");
        sb.Append("  FederatedIdentities: ").Append(FederatedIdentities).Append("\n");
        sb.Append("  FederationLink: ").Append(FederationLink).Append("\n");
        sb.Append("  FirstName: ").Append(FirstName).Append("\n");
        sb.Append("  Groups: ").Append(Groups).Append("\n");
        sb.Append("  Id: ").Append(Id).Append("\n");
        sb.Append("  LastName: ").Append(LastName).Append("\n");
        sb.Append("  NotBefore: ").Append(NotBefore).Append("\n");
        sb.Append("  Origin: ").Append(Origin).Append("\n");
        sb.Append("  RealmRoles: ").Append(RealmRoles).Append("\n");
        sb.Append("  RequiredActions: ").Append(RequiredActions).Append("\n");
        sb.Append("  Self: ").Append(Self).Append("\n");
        sb.Append("  ServiceAccountClientId: ").Append(ServiceAccountClientId).Append("\n");
        sb.Append("  Username: ").Append(Username).Append("\n");
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
        return Equals(input as UserRepresentation);
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
            if (Access != null)
                hashCode = hashCode * 59 + Access.GetHashCode();
            if (Attributes != null)
                hashCode = hashCode * 59 + Attributes.GetHashCode();
            if (ClientConsents != null)
                hashCode = hashCode * 59 + ClientConsents.GetHashCode();
            if (ClientRoles != null)
                hashCode = hashCode * 59 + ClientRoles.GetHashCode();
            if (CreatedTimestamp != null)
                hashCode = hashCode * 59 + CreatedTimestamp.GetHashCode();
            if (Credentials != null)
                hashCode = hashCode * 59 + Credentials.GetHashCode();
            if (DisableableCredentialTypes != null)
                hashCode = hashCode * 59 + DisableableCredentialTypes.GetHashCode();
            if (Email != null)
                hashCode = hashCode * 59 + Email.GetHashCode();
            if (EmailVerified != null)
                hashCode = hashCode * 59 + EmailVerified.GetHashCode();
            if (Enabled != null)
                hashCode = hashCode * 59 + Enabled.GetHashCode();
            if (FederatedIdentities != null)
                hashCode = hashCode * 59 + FederatedIdentities.GetHashCode();
            if (FederationLink != null)
                hashCode = hashCode * 59 + FederationLink.GetHashCode();
            if (FirstName != null)
                hashCode = hashCode * 59 + FirstName.GetHashCode();
            if (Groups != null)
                hashCode = hashCode * 59 + Groups.GetHashCode();
            if (Id != null)
                hashCode = hashCode * 59 + Id.GetHashCode();
            if (LastName != null)
                hashCode = hashCode * 59 + LastName.GetHashCode();
            if (NotBefore != null)
                hashCode = hashCode * 59 + NotBefore.GetHashCode();
            if (Origin != null)
                hashCode = hashCode * 59 + Origin.GetHashCode();
            if (RealmRoles != null)
                hashCode = hashCode * 59 + RealmRoles.GetHashCode();
            if (RequiredActions != null)
                hashCode = hashCode * 59 + RequiredActions.GetHashCode();
            if (Self != null)
                hashCode = hashCode * 59 + Self.GetHashCode();
            if (ServiceAccountClientId != null)
                hashCode = hashCode * 59 + ServiceAccountClientId.GetHashCode();
            if (Username != null)
                hashCode = hashCode * 59 + Username.GetHashCode();
            return hashCode;
        }
    }
}