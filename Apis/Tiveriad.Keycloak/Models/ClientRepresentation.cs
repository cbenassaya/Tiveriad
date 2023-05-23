#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     ClientRepresentation
/// </summary>
[DataContract]
public class ClientRepresentation : IEquatable<ClientRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ClientRepresentation" /> class.
    /// </summary>
    /// <param name="access">access.</param>
    /// <param name="adminUrl">adminUrl.</param>
    /// <param name="alwaysDisplayInConsole">alwaysDisplayInConsole.</param>
    /// <param name="attributes">attributes.</param>
    /// <param name="authenticationFlowBindingOverrides">authenticationFlowBindingOverrides.</param>
    /// <param name="authorizationServicesEnabled">authorizationServicesEnabled.</param>
    /// <param name="authorizationSettings">authorizationSettings.</param>
    /// <param name="baseUrl">baseUrl.</param>
    /// <param name="bearerOnly">bearerOnly.</param>
    /// <param name="clientAuthenticatorType">clientAuthenticatorType.</param>
    /// <param name="clientId">clientId.</param>
    /// <param name="consentRequired">consentRequired.</param>
    /// <param name="defaultClientScopes">defaultClientScopes.</param>
    /// <param name="description">description.</param>
    /// <param name="directAccessGrantsEnabled">directAccessGrantsEnabled.</param>
    /// <param name="enabled">enabled.</param>
    /// <param name="frontchannelLogout">frontchannelLogout.</param>
    /// <param name="fullScopeAllowed">fullScopeAllowed.</param>
    /// <param name="id">id.</param>
    /// <param name="implicitFlowEnabled">implicitFlowEnabled.</param>
    /// <param name="name">name.</param>
    /// <param name="nodeReRegistrationTimeout">nodeReRegistrationTimeout.</param>
    /// <param name="notBefore">notBefore.</param>
    /// <param name="oauth2DeviceAuthorizationGrantEnabled">oauth2DeviceAuthorizationGrantEnabled.</param>
    /// <param name="optionalClientScopes">optionalClientScopes.</param>
    /// <param name="origin">origin.</param>
    /// <param name="protocol">protocol.</param>
    /// <param name="protocolMappers">protocolMappers.</param>
    /// <param name="publicClient">publicClient.</param>
    /// <param name="redirectUris">redirectUris.</param>
    /// <param name="registeredNodes">registeredNodes.</param>
    /// <param name="registrationAccessToken">registrationAccessToken.</param>
    /// <param name="rootUrl">rootUrl.</param>
    /// <param name="secret">secret.</param>
    /// <param name="serviceAccountsEnabled">serviceAccountsEnabled.</param>
    /// <param name="standardFlowEnabled">standardFlowEnabled.</param>
    /// <param name="surrogateAuthRequired">surrogateAuthRequired.</param>
    /// <param name="webOrigins">webOrigins.</param>
    public ClientRepresentation(Dictionary<string, object> access = default, string adminUrl = default,
        bool? alwaysDisplayInConsole = default, Dictionary<string, object> attributes = default,
        Dictionary<string, object> authenticationFlowBindingOverrides = default,
        bool? authorizationServicesEnabled = default, ResourceServerRepresentation authorizationSettings = default,
        string baseUrl = default, bool? bearerOnly = default, string clientAuthenticatorType = default,
        string clientId = default, bool? consentRequired = default, List<string> defaultClientScopes = default,
        string description = default, bool? directAccessGrantsEnabled = default, bool? enabled = default,
        bool? frontchannelLogout = default, bool? fullScopeAllowed = default, string id = default,
        bool? implicitFlowEnabled = default, string name = default, int? nodeReRegistrationTimeout = default,
        int? notBefore = default, bool? oauth2DeviceAuthorizationGrantEnabled = default,
        List<string> optionalClientScopes = default, string origin = default, string protocol = default,
        List<ProtocolMapperRepresentation> protocolMappers = default, bool? publicClient = default,
        List<string> redirectUris = default, Dictionary<string, object> registeredNodes = default,
        string registrationAccessToken = default, string rootUrl = default, string secret = default,
        bool? serviceAccountsEnabled = default, bool? standardFlowEnabled = default,
        bool? surrogateAuthRequired = default, List<string> webOrigins = default)
    {
        Access = access;
        AdminUrl = adminUrl;
        AlwaysDisplayInConsole = alwaysDisplayInConsole;
        Attributes = attributes;
        AuthenticationFlowBindingOverrides = authenticationFlowBindingOverrides;
        AuthorizationServicesEnabled = authorizationServicesEnabled;
        AuthorizationSettings = authorizationSettings;
        BaseUrl = baseUrl;
        BearerOnly = bearerOnly;
        ClientAuthenticatorType = clientAuthenticatorType;
        ClientId = clientId;
        ConsentRequired = consentRequired;
        DefaultClientScopes = defaultClientScopes;
        Description = description;
        DirectAccessGrantsEnabled = directAccessGrantsEnabled;
        Enabled = enabled;
        FrontchannelLogout = frontchannelLogout;
        FullScopeAllowed = fullScopeAllowed;
        Id = id;
        ImplicitFlowEnabled = implicitFlowEnabled;
        Name = name;
        NodeReRegistrationTimeout = nodeReRegistrationTimeout;
        NotBefore = notBefore;
        Oauth2DeviceAuthorizationGrantEnabled = oauth2DeviceAuthorizationGrantEnabled;
        OptionalClientScopes = optionalClientScopes;
        Origin = origin;
        Protocol = protocol;
        ProtocolMappers = protocolMappers;
        PublicClient = publicClient;
        RedirectUris = redirectUris;
        RegisteredNodes = registeredNodes;
        RegistrationAccessToken = registrationAccessToken;
        RootUrl = rootUrl;
        Secret = secret;
        ServiceAccountsEnabled = serviceAccountsEnabled;
        StandardFlowEnabled = standardFlowEnabled;
        SurrogateAuthRequired = surrogateAuthRequired;
        WebOrigins = webOrigins;
    }

    /// <summary>
    ///     Gets or Sets Access
    /// </summary>
    [DataMember(Name = "access", EmitDefaultValue = false)]
    public Dictionary<string, object> Access { get; set; }

    /// <summary>
    ///     Gets or Sets AdminUrl
    /// </summary>
    [DataMember(Name = "adminUrl", EmitDefaultValue = false)]
    public string AdminUrl { get; set; }

    /// <summary>
    ///     Gets or Sets AlwaysDisplayInConsole
    /// </summary>
    [DataMember(Name = "alwaysDisplayInConsole", EmitDefaultValue = false)]
    public bool? AlwaysDisplayInConsole { get; set; }

    /// <summary>
    ///     Gets or Sets Attributes
    /// </summary>
    [DataMember(Name = "attributes", EmitDefaultValue = false)]
    public Dictionary<string, object> Attributes { get; set; }

    /// <summary>
    ///     Gets or Sets AuthenticationFlowBindingOverrides
    /// </summary>
    [DataMember(Name = "authenticationFlowBindingOverrides", EmitDefaultValue = false)]
    public Dictionary<string, object> AuthenticationFlowBindingOverrides { get; set; }

    /// <summary>
    ///     Gets or Sets AuthorizationServicesEnabled
    /// </summary>
    [DataMember(Name = "authorizationServicesEnabled", EmitDefaultValue = false)]
    public bool? AuthorizationServicesEnabled { get; set; }

    /// <summary>
    ///     Gets or Sets AuthorizationSettings
    /// </summary>
    [DataMember(Name = "authorizationSettings", EmitDefaultValue = false)]
    public ResourceServerRepresentation AuthorizationSettings { get; set; }

    /// <summary>
    ///     Gets or Sets BaseUrl
    /// </summary>
    [DataMember(Name = "baseUrl", EmitDefaultValue = false)]
    public string BaseUrl { get; set; }

    /// <summary>
    ///     Gets or Sets BearerOnly
    /// </summary>
    [DataMember(Name = "bearerOnly", EmitDefaultValue = false)]
    public bool? BearerOnly { get; set; }

    /// <summary>
    ///     Gets or Sets ClientAuthenticatorType
    /// </summary>
    [DataMember(Name = "clientAuthenticatorType", EmitDefaultValue = false)]
    public string ClientAuthenticatorType { get; set; }

    /// <summary>
    ///     Gets or Sets ClientId
    /// </summary>
    [DataMember(Name = "clientId", EmitDefaultValue = false)]
    public string ClientId { get; set; }

    /// <summary>
    ///     Gets or Sets ConsentRequired
    /// </summary>
    [DataMember(Name = "consentRequired", EmitDefaultValue = false)]
    public bool? ConsentRequired { get; set; }

    /// <summary>
    ///     Gets or Sets DefaultClientScopes
    /// </summary>
    [DataMember(Name = "defaultClientScopes", EmitDefaultValue = false)]
    public List<string> DefaultClientScopes { get; set; }

    /// <summary>
    ///     Gets or Sets Description
    /// </summary>
    [DataMember(Name = "description", EmitDefaultValue = false)]
    public string Description { get; set; }

    /// <summary>
    ///     Gets or Sets DirectAccessGrantsEnabled
    /// </summary>
    [DataMember(Name = "directAccessGrantsEnabled", EmitDefaultValue = false)]
    public bool? DirectAccessGrantsEnabled { get; set; }

    /// <summary>
    ///     Gets or Sets Enabled
    /// </summary>
    [DataMember(Name = "enabled", EmitDefaultValue = false)]
    public bool? Enabled { get; set; }

    /// <summary>
    ///     Gets or Sets FrontchannelLogout
    /// </summary>
    [DataMember(Name = "frontchannelLogout", EmitDefaultValue = false)]
    public bool? FrontchannelLogout { get; set; }

    /// <summary>
    ///     Gets or Sets FullScopeAllowed
    /// </summary>
    [DataMember(Name = "fullScopeAllowed", EmitDefaultValue = false)]
    public bool? FullScopeAllowed { get; set; }

    /// <summary>
    ///     Gets or Sets Id
    /// </summary>
    [DataMember(Name = "id", EmitDefaultValue = false)]
    public string Id { get; set; }

    /// <summary>
    ///     Gets or Sets ImplicitFlowEnabled
    /// </summary>
    [DataMember(Name = "implicitFlowEnabled", EmitDefaultValue = false)]
    public bool? ImplicitFlowEnabled { get; set; }

    /// <summary>
    ///     Gets or Sets Name
    /// </summary>
    [DataMember(Name = "name", EmitDefaultValue = false)]
    public string Name { get; set; }

    /// <summary>
    ///     Gets or Sets NodeReRegistrationTimeout
    /// </summary>
    [DataMember(Name = "nodeReRegistrationTimeout", EmitDefaultValue = false)]
    public int? NodeReRegistrationTimeout { get; set; }

    /// <summary>
    ///     Gets or Sets NotBefore
    /// </summary>
    [DataMember(Name = "notBefore", EmitDefaultValue = false)]
    public int? NotBefore { get; set; }

    /// <summary>
    ///     Gets or Sets Oauth2DeviceAuthorizationGrantEnabled
    /// </summary>
    [DataMember(Name = "oauth2DeviceAuthorizationGrantEnabled", EmitDefaultValue = false)]
    public bool? Oauth2DeviceAuthorizationGrantEnabled { get; set; }

    /// <summary>
    ///     Gets or Sets OptionalClientScopes
    /// </summary>
    [DataMember(Name = "optionalClientScopes", EmitDefaultValue = false)]
    public List<string> OptionalClientScopes { get; set; }

    /// <summary>
    ///     Gets or Sets Origin
    /// </summary>
    [DataMember(Name = "origin", EmitDefaultValue = false)]
    public string Origin { get; set; }

    /// <summary>
    ///     Gets or Sets Protocol
    /// </summary>
    [DataMember(Name = "protocol", EmitDefaultValue = false)]
    public string Protocol { get; set; }

    /// <summary>
    ///     Gets or Sets ProtocolMappers
    /// </summary>
    [DataMember(Name = "protocolMappers", EmitDefaultValue = false)]
    public List<ProtocolMapperRepresentation> ProtocolMappers { get; set; }

    /// <summary>
    ///     Gets or Sets PublicClient
    /// </summary>
    [DataMember(Name = "publicClient", EmitDefaultValue = false)]
    public bool? PublicClient { get; set; }

    /// <summary>
    ///     Gets or Sets RedirectUris
    /// </summary>
    [DataMember(Name = "redirectUris", EmitDefaultValue = false)]
    public List<string> RedirectUris { get; set; }

    /// <summary>
    ///     Gets or Sets RegisteredNodes
    /// </summary>
    [DataMember(Name = "registeredNodes", EmitDefaultValue = false)]
    public Dictionary<string, object> RegisteredNodes { get; set; }

    /// <summary>
    ///     Gets or Sets RegistrationAccessToken
    /// </summary>
    [DataMember(Name = "registrationAccessToken", EmitDefaultValue = false)]
    public string RegistrationAccessToken { get; set; }

    /// <summary>
    ///     Gets or Sets RootUrl
    /// </summary>
    [DataMember(Name = "rootUrl", EmitDefaultValue = false)]
    public string RootUrl { get; set; }

    /// <summary>
    ///     Gets or Sets Secret
    /// </summary>
    [DataMember(Name = "secret", EmitDefaultValue = false)]
    public string Secret { get; set; }

    /// <summary>
    ///     Gets or Sets ServiceAccountsEnabled
    /// </summary>
    [DataMember(Name = "serviceAccountsEnabled", EmitDefaultValue = false)]
    public bool? ServiceAccountsEnabled { get; set; }

    /// <summary>
    ///     Gets or Sets StandardFlowEnabled
    /// </summary>
    [DataMember(Name = "standardFlowEnabled", EmitDefaultValue = false)]
    public bool? StandardFlowEnabled { get; set; }

    /// <summary>
    ///     Gets or Sets SurrogateAuthRequired
    /// </summary>
    [DataMember(Name = "surrogateAuthRequired", EmitDefaultValue = false)]
    public bool? SurrogateAuthRequired { get; set; }

    /// <summary>
    ///     Gets or Sets WebOrigins
    /// </summary>
    [DataMember(Name = "webOrigins", EmitDefaultValue = false)]
    public List<string> WebOrigins { get; set; }

    /// <summary>
    ///     Returns true if ClientRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of ClientRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(ClientRepresentation input)
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
                AdminUrl == input.AdminUrl ||
                (AdminUrl != null &&
                 AdminUrl.Equals(input.AdminUrl))
            ) &&
            (
                AlwaysDisplayInConsole == input.AlwaysDisplayInConsole ||
                (AlwaysDisplayInConsole != null &&
                 AlwaysDisplayInConsole.Equals(input.AlwaysDisplayInConsole))
            ) &&
            (
                Attributes == input.Attributes ||
                (Attributes != null &&
                 input.Attributes != null &&
                 Attributes.SequenceEqual(input.Attributes))
            ) &&
            (
                AuthenticationFlowBindingOverrides == input.AuthenticationFlowBindingOverrides ||
                (AuthenticationFlowBindingOverrides != null &&
                 input.AuthenticationFlowBindingOverrides != null &&
                 AuthenticationFlowBindingOverrides.SequenceEqual(input.AuthenticationFlowBindingOverrides))
            ) &&
            (
                AuthorizationServicesEnabled == input.AuthorizationServicesEnabled ||
                (AuthorizationServicesEnabled != null &&
                 AuthorizationServicesEnabled.Equals(input.AuthorizationServicesEnabled))
            ) &&
            (
                AuthorizationSettings == input.AuthorizationSettings ||
                (AuthorizationSettings != null &&
                 AuthorizationSettings.Equals(input.AuthorizationSettings))
            ) &&
            (
                BaseUrl == input.BaseUrl ||
                (BaseUrl != null &&
                 BaseUrl.Equals(input.BaseUrl))
            ) &&
            (
                BearerOnly == input.BearerOnly ||
                (BearerOnly != null &&
                 BearerOnly.Equals(input.BearerOnly))
            ) &&
            (
                ClientAuthenticatorType == input.ClientAuthenticatorType ||
                (ClientAuthenticatorType != null &&
                 ClientAuthenticatorType.Equals(input.ClientAuthenticatorType))
            ) &&
            (
                ClientId == input.ClientId ||
                (ClientId != null &&
                 ClientId.Equals(input.ClientId))
            ) &&
            (
                ConsentRequired == input.ConsentRequired ||
                (ConsentRequired != null &&
                 ConsentRequired.Equals(input.ConsentRequired))
            ) &&
            (
                DefaultClientScopes == input.DefaultClientScopes ||
                (DefaultClientScopes != null &&
                 input.DefaultClientScopes != null &&
                 DefaultClientScopes.SequenceEqual(input.DefaultClientScopes))
            ) &&
            (
                Description == input.Description ||
                (Description != null &&
                 Description.Equals(input.Description))
            ) &&
            (
                DirectAccessGrantsEnabled == input.DirectAccessGrantsEnabled ||
                (DirectAccessGrantsEnabled != null &&
                 DirectAccessGrantsEnabled.Equals(input.DirectAccessGrantsEnabled))
            ) &&
            (
                Enabled == input.Enabled ||
                (Enabled != null &&
                 Enabled.Equals(input.Enabled))
            ) &&
            (
                FrontchannelLogout == input.FrontchannelLogout ||
                (FrontchannelLogout != null &&
                 FrontchannelLogout.Equals(input.FrontchannelLogout))
            ) &&
            (
                FullScopeAllowed == input.FullScopeAllowed ||
                (FullScopeAllowed != null &&
                 FullScopeAllowed.Equals(input.FullScopeAllowed))
            ) &&
            (
                Id == input.Id ||
                (Id != null &&
                 Id.Equals(input.Id))
            ) &&
            (
                ImplicitFlowEnabled == input.ImplicitFlowEnabled ||
                (ImplicitFlowEnabled != null &&
                 ImplicitFlowEnabled.Equals(input.ImplicitFlowEnabled))
            ) &&
            (
                Name == input.Name ||
                (Name != null &&
                 Name.Equals(input.Name))
            ) &&
            (
                NodeReRegistrationTimeout == input.NodeReRegistrationTimeout ||
                (NodeReRegistrationTimeout != null &&
                 NodeReRegistrationTimeout.Equals(input.NodeReRegistrationTimeout))
            ) &&
            (
                NotBefore == input.NotBefore ||
                (NotBefore != null &&
                 NotBefore.Equals(input.NotBefore))
            ) &&
            (
                Oauth2DeviceAuthorizationGrantEnabled == input.Oauth2DeviceAuthorizationGrantEnabled ||
                (Oauth2DeviceAuthorizationGrantEnabled != null &&
                 Oauth2DeviceAuthorizationGrantEnabled.Equals(input.Oauth2DeviceAuthorizationGrantEnabled))
            ) &&
            (
                OptionalClientScopes == input.OptionalClientScopes ||
                (OptionalClientScopes != null &&
                 input.OptionalClientScopes != null &&
                 OptionalClientScopes.SequenceEqual(input.OptionalClientScopes))
            ) &&
            (
                Origin == input.Origin ||
                (Origin != null &&
                 Origin.Equals(input.Origin))
            ) &&
            (
                Protocol == input.Protocol ||
                (Protocol != null &&
                 Protocol.Equals(input.Protocol))
            ) &&
            (
                ProtocolMappers == input.ProtocolMappers ||
                (ProtocolMappers != null &&
                 input.ProtocolMappers != null &&
                 ProtocolMappers.SequenceEqual(input.ProtocolMappers))
            ) &&
            (
                PublicClient == input.PublicClient ||
                (PublicClient != null &&
                 PublicClient.Equals(input.PublicClient))
            ) &&
            (
                RedirectUris == input.RedirectUris ||
                (RedirectUris != null &&
                 input.RedirectUris != null &&
                 RedirectUris.SequenceEqual(input.RedirectUris))
            ) &&
            (
                RegisteredNodes == input.RegisteredNodes ||
                (RegisteredNodes != null &&
                 input.RegisteredNodes != null &&
                 RegisteredNodes.SequenceEqual(input.RegisteredNodes))
            ) &&
            (
                RegistrationAccessToken == input.RegistrationAccessToken ||
                (RegistrationAccessToken != null &&
                 RegistrationAccessToken.Equals(input.RegistrationAccessToken))
            ) &&
            (
                RootUrl == input.RootUrl ||
                (RootUrl != null &&
                 RootUrl.Equals(input.RootUrl))
            ) &&
            (
                Secret == input.Secret ||
                (Secret != null &&
                 Secret.Equals(input.Secret))
            ) &&
            (
                ServiceAccountsEnabled == input.ServiceAccountsEnabled ||
                (ServiceAccountsEnabled != null &&
                 ServiceAccountsEnabled.Equals(input.ServiceAccountsEnabled))
            ) &&
            (
                StandardFlowEnabled == input.StandardFlowEnabled ||
                (StandardFlowEnabled != null &&
                 StandardFlowEnabled.Equals(input.StandardFlowEnabled))
            ) &&
            (
                SurrogateAuthRequired == input.SurrogateAuthRequired ||
                (SurrogateAuthRequired != null &&
                 SurrogateAuthRequired.Equals(input.SurrogateAuthRequired))
            ) &&
            (
                WebOrigins == input.WebOrigins ||
                (WebOrigins != null &&
                 input.WebOrigins != null &&
                 WebOrigins.SequenceEqual(input.WebOrigins))
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
        sb.Append("class ClientRepresentation {\n");
        sb.Append("  Access: ").Append(Access).Append("\n");
        sb.Append("  AdminUrl: ").Append(AdminUrl).Append("\n");
        sb.Append("  AlwaysDisplayInConsole: ").Append(AlwaysDisplayInConsole).Append("\n");
        sb.Append("  Attributes: ").Append(Attributes).Append("\n");
        sb.Append("  AuthenticationFlowBindingOverrides: ").Append(AuthenticationFlowBindingOverrides).Append("\n");
        sb.Append("  AuthorizationServicesEnabled: ").Append(AuthorizationServicesEnabled).Append("\n");
        sb.Append("  AuthorizationSettings: ").Append(AuthorizationSettings).Append("\n");
        sb.Append("  BaseUrl: ").Append(BaseUrl).Append("\n");
        sb.Append("  BearerOnly: ").Append(BearerOnly).Append("\n");
        sb.Append("  ClientAuthenticatorType: ").Append(ClientAuthenticatorType).Append("\n");
        sb.Append("  ClientId: ").Append(ClientId).Append("\n");
        sb.Append("  ConsentRequired: ").Append(ConsentRequired).Append("\n");
        sb.Append("  DefaultClientScopes: ").Append(DefaultClientScopes).Append("\n");
        sb.Append("  Description: ").Append(Description).Append("\n");
        sb.Append("  DirectAccessGrantsEnabled: ").Append(DirectAccessGrantsEnabled).Append("\n");
        sb.Append("  Enabled: ").Append(Enabled).Append("\n");
        sb.Append("  FrontchannelLogout: ").Append(FrontchannelLogout).Append("\n");
        sb.Append("  FullScopeAllowed: ").Append(FullScopeAllowed).Append("\n");
        sb.Append("  Id: ").Append(Id).Append("\n");
        sb.Append("  ImplicitFlowEnabled: ").Append(ImplicitFlowEnabled).Append("\n");
        sb.Append("  Name: ").Append(Name).Append("\n");
        sb.Append("  NodeReRegistrationTimeout: ").Append(NodeReRegistrationTimeout).Append("\n");
        sb.Append("  NotBefore: ").Append(NotBefore).Append("\n");
        sb.Append("  Oauth2DeviceAuthorizationGrantEnabled: ").Append(Oauth2DeviceAuthorizationGrantEnabled)
            .Append("\n");
        sb.Append("  OptionalClientScopes: ").Append(OptionalClientScopes).Append("\n");
        sb.Append("  Origin: ").Append(Origin).Append("\n");
        sb.Append("  Protocol: ").Append(Protocol).Append("\n");
        sb.Append("  ProtocolMappers: ").Append(ProtocolMappers).Append("\n");
        sb.Append("  PublicClient: ").Append(PublicClient).Append("\n");
        sb.Append("  RedirectUris: ").Append(RedirectUris).Append("\n");
        sb.Append("  RegisteredNodes: ").Append(RegisteredNodes).Append("\n");
        sb.Append("  RegistrationAccessToken: ").Append(RegistrationAccessToken).Append("\n");
        sb.Append("  RootUrl: ").Append(RootUrl).Append("\n");
        sb.Append("  Secret: ").Append(Secret).Append("\n");
        sb.Append("  ServiceAccountsEnabled: ").Append(ServiceAccountsEnabled).Append("\n");
        sb.Append("  StandardFlowEnabled: ").Append(StandardFlowEnabled).Append("\n");
        sb.Append("  SurrogateAuthRequired: ").Append(SurrogateAuthRequired).Append("\n");
        sb.Append("  WebOrigins: ").Append(WebOrigins).Append("\n");
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
        return Equals(input as ClientRepresentation);
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
            if (AdminUrl != null)
                hashCode = hashCode * 59 + AdminUrl.GetHashCode();
            if (AlwaysDisplayInConsole != null)
                hashCode = hashCode * 59 + AlwaysDisplayInConsole.GetHashCode();
            if (Attributes != null)
                hashCode = hashCode * 59 + Attributes.GetHashCode();
            if (AuthenticationFlowBindingOverrides != null)
                hashCode = hashCode * 59 + AuthenticationFlowBindingOverrides.GetHashCode();
            if (AuthorizationServicesEnabled != null)
                hashCode = hashCode * 59 + AuthorizationServicesEnabled.GetHashCode();
            if (AuthorizationSettings != null)
                hashCode = hashCode * 59 + AuthorizationSettings.GetHashCode();
            if (BaseUrl != null)
                hashCode = hashCode * 59 + BaseUrl.GetHashCode();
            if (BearerOnly != null)
                hashCode = hashCode * 59 + BearerOnly.GetHashCode();
            if (ClientAuthenticatorType != null)
                hashCode = hashCode * 59 + ClientAuthenticatorType.GetHashCode();
            if (ClientId != null)
                hashCode = hashCode * 59 + ClientId.GetHashCode();
            if (ConsentRequired != null)
                hashCode = hashCode * 59 + ConsentRequired.GetHashCode();
            if (DefaultClientScopes != null)
                hashCode = hashCode * 59 + DefaultClientScopes.GetHashCode();
            if (Description != null)
                hashCode = hashCode * 59 + Description.GetHashCode();
            if (DirectAccessGrantsEnabled != null)
                hashCode = hashCode * 59 + DirectAccessGrantsEnabled.GetHashCode();
            if (Enabled != null)
                hashCode = hashCode * 59 + Enabled.GetHashCode();
            if (FrontchannelLogout != null)
                hashCode = hashCode * 59 + FrontchannelLogout.GetHashCode();
            if (FullScopeAllowed != null)
                hashCode = hashCode * 59 + FullScopeAllowed.GetHashCode();
            if (Id != null)
                hashCode = hashCode * 59 + Id.GetHashCode();
            if (ImplicitFlowEnabled != null)
                hashCode = hashCode * 59 + ImplicitFlowEnabled.GetHashCode();
            if (Name != null)
                hashCode = hashCode * 59 + Name.GetHashCode();
            if (NodeReRegistrationTimeout != null)
                hashCode = hashCode * 59 + NodeReRegistrationTimeout.GetHashCode();
            if (NotBefore != null)
                hashCode = hashCode * 59 + NotBefore.GetHashCode();
            if (Oauth2DeviceAuthorizationGrantEnabled != null)
                hashCode = hashCode * 59 + Oauth2DeviceAuthorizationGrantEnabled.GetHashCode();
            if (OptionalClientScopes != null)
                hashCode = hashCode * 59 + OptionalClientScopes.GetHashCode();
            if (Origin != null)
                hashCode = hashCode * 59 + Origin.GetHashCode();
            if (Protocol != null)
                hashCode = hashCode * 59 + Protocol.GetHashCode();
            if (ProtocolMappers != null)
                hashCode = hashCode * 59 + ProtocolMappers.GetHashCode();
            if (PublicClient != null)
                hashCode = hashCode * 59 + PublicClient.GetHashCode();
            if (RedirectUris != null)
                hashCode = hashCode * 59 + RedirectUris.GetHashCode();
            if (RegisteredNodes != null)
                hashCode = hashCode * 59 + RegisteredNodes.GetHashCode();
            if (RegistrationAccessToken != null)
                hashCode = hashCode * 59 + RegistrationAccessToken.GetHashCode();
            if (RootUrl != null)
                hashCode = hashCode * 59 + RootUrl.GetHashCode();
            if (Secret != null)
                hashCode = hashCode * 59 + Secret.GetHashCode();
            if (ServiceAccountsEnabled != null)
                hashCode = hashCode * 59 + ServiceAccountsEnabled.GetHashCode();
            if (StandardFlowEnabled != null)
                hashCode = hashCode * 59 + StandardFlowEnabled.GetHashCode();
            if (SurrogateAuthRequired != null)
                hashCode = hashCode * 59 + SurrogateAuthRequired.GetHashCode();
            if (WebOrigins != null)
                hashCode = hashCode * 59 + WebOrigins.GetHashCode();
            return hashCode;
        }
    }
}