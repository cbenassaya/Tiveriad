#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     RealmRepresentation
/// </summary>
[DataContract]
public class RealmRepresentation : IEquatable<RealmRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="RealmRepresentation" /> class.
    /// </summary>
    /// <param name="accessCodeLifespan">accessCodeLifespan.</param>
    /// <param name="accessCodeLifespanLogin">accessCodeLifespanLogin.</param>
    /// <param name="accessCodeLifespanUserAction">accessCodeLifespanUserAction.</param>
    /// <param name="accessTokenLifespan">accessTokenLifespan.</param>
    /// <param name="accessTokenLifespanForImplicitFlow">accessTokenLifespanForImplicitFlow.</param>
    /// <param name="accountTheme">accountTheme.</param>
    /// <param name="actionTokenGeneratedByAdminLifespan">actionTokenGeneratedByAdminLifespan.</param>
    /// <param name="actionTokenGeneratedByUserLifespan">actionTokenGeneratedByUserLifespan.</param>
    /// <param name="adminEventsDetailsEnabled">adminEventsDetailsEnabled.</param>
    /// <param name="adminEventsEnabled">adminEventsEnabled.</param>
    /// <param name="adminTheme">adminTheme.</param>
    /// <param name="attributes">attributes.</param>
    /// <param name="authenticationFlows">authenticationFlows.</param>
    /// <param name="authenticatorConfig">authenticatorConfig.</param>
    /// <param name="browserFlow">browserFlow.</param>
    /// <param name="browserSecurityHeaders">browserSecurityHeaders.</param>
    /// <param name="bruteForceProtected">bruteForceProtected.</param>
    /// <param name="clientAuthenticationFlow">clientAuthenticationFlow.</param>
    /// <param name="clientOfflineSessionIdleTimeout">clientOfflineSessionIdleTimeout.</param>
    /// <param name="clientOfflineSessionMaxLifespan">clientOfflineSessionMaxLifespan.</param>
    /// <param name="clientPolicies">clientPolicies.</param>
    /// <param name="clientProfiles">clientProfiles.</param>
    /// <param name="clientScopeMappings">clientScopeMappings.</param>
    /// <param name="clientScopes">clientScopes.</param>
    /// <param name="clientSessionIdleTimeout">clientSessionIdleTimeout.</param>
    /// <param name="clientSessionMaxLifespan">clientSessionMaxLifespan.</param>
    /// <param name="clients">clients.</param>
    /// <param name="components">components.</param>
    /// <param name="defaultDefaultClientScopes">defaultDefaultClientScopes.</param>
    /// <param name="defaultGroups">defaultGroups.</param>
    /// <param name="defaultLocale">defaultLocale.</param>
    /// <param name="defaultOptionalClientScopes">defaultOptionalClientScopes.</param>
    /// <param name="defaultRole">defaultRole.</param>
    /// <param name="defaultSignatureAlgorithm">defaultSignatureAlgorithm.</param>
    /// <param name="directGrantFlow">directGrantFlow.</param>
    /// <param name="displayName">displayName.</param>
    /// <param name="displayNameHtml">displayNameHtml.</param>
    /// <param name="dockerAuthenticationFlow">dockerAuthenticationFlow.</param>
    /// <param name="duplicateEmailsAllowed">duplicateEmailsAllowed.</param>
    /// <param name="editUsernameAllowed">editUsernameAllowed.</param>
    /// <param name="emailTheme">emailTheme.</param>
    /// <param name="enabled">enabled.</param>
    /// <param name="enabledEventTypes">enabledEventTypes.</param>
    /// <param name="eventsEnabled">eventsEnabled.</param>
    /// <param name="eventsExpiration">eventsExpiration.</param>
    /// <param name="eventsListeners">eventsListeners.</param>
    /// <param name="failureFactor">failureFactor.</param>
    /// <param name="federatedUsers">federatedUsers.</param>
    /// <param name="groups">groups.</param>
    /// <param name="id">id.</param>
    /// <param name="identityProviderMappers">identityProviderMappers.</param>
    /// <param name="identityProviders">identityProviders.</param>
    /// <param name="internationalizationEnabled">internationalizationEnabled.</param>
    /// <param name="keycloakVersion">keycloakVersion.</param>
    /// <param name="loginTheme">loginTheme.</param>
    /// <param name="loginWithEmailAllowed">loginWithEmailAllowed.</param>
    /// <param name="maxDeltaTimeSeconds">maxDeltaTimeSeconds.</param>
    /// <param name="maxFailureWaitSeconds">maxFailureWaitSeconds.</param>
    /// <param name="minimumQuickLoginWaitSeconds">minimumQuickLoginWaitSeconds.</param>
    /// <param name="notBefore">notBefore.</param>
    /// <param name="oAuth2DeviceCodeLifespan">oAuth2DeviceCodeLifespan.</param>
    /// <param name="oAuth2DevicePollingInterval">oAuth2DevicePollingInterval.</param>
    /// <param name="oauth2DeviceCodeLifespan">oauth2DeviceCodeLifespan.</param>
    /// <param name="oauth2DevicePollingInterval">oauth2DevicePollingInterval.</param>
    /// <param name="offlineSessionIdleTimeout">offlineSessionIdleTimeout.</param>
    /// <param name="offlineSessionMaxLifespan">offlineSessionMaxLifespan.</param>
    /// <param name="offlineSessionMaxLifespanEnabled">offlineSessionMaxLifespanEnabled.</param>
    /// <param name="otpPolicyAlgorithm">otpPolicyAlgorithm.</param>
    /// <param name="otpPolicyDigits">otpPolicyDigits.</param>
    /// <param name="otpPolicyInitialCounter">otpPolicyInitialCounter.</param>
    /// <param name="otpPolicyLookAheadWindow">otpPolicyLookAheadWindow.</param>
    /// <param name="otpPolicyPeriod">otpPolicyPeriod.</param>
    /// <param name="otpPolicyType">otpPolicyType.</param>
    /// <param name="otpSupportedApplications">otpSupportedApplications.</param>
    /// <param name="passwordPolicy">passwordPolicy.</param>
    /// <param name="permanentLockout">permanentLockout.</param>
    /// <param name="protocolMappers">protocolMappers.</param>
    /// <param name="quickLoginCheckMilliSeconds">quickLoginCheckMilliSeconds.</param>
    /// <param name="realm">realm.</param>
    /// <param name="refreshTokenMaxReuse">refreshTokenMaxReuse.</param>
    /// <param name="registrationAllowed">registrationAllowed.</param>
    /// <param name="registrationEmailAsUsername">registrationEmailAsUsername.</param>
    /// <param name="registrationFlow">registrationFlow.</param>
    /// <param name="rememberMe">rememberMe.</param>
    /// <param name="requiredActions">requiredActions.</param>
    /// <param name="resetCredentialsFlow">resetCredentialsFlow.</param>
    /// <param name="resetPasswordAllowed">resetPasswordAllowed.</param>
    /// <param name="revokeRefreshToken">revokeRefreshToken.</param>
    /// <param name="roles">roles.</param>
    /// <param name="scopeMappings">scopeMappings.</param>
    /// <param name="smtpServer">smtpServer.</param>
    /// <param name="sslRequired">sslRequired.</param>
    /// <param name="ssoSessionIdleTimeout">ssoSessionIdleTimeout.</param>
    /// <param name="ssoSessionIdleTimeoutRememberMe">ssoSessionIdleTimeoutRememberMe.</param>
    /// <param name="ssoSessionMaxLifespan">ssoSessionMaxLifespan.</param>
    /// <param name="ssoSessionMaxLifespanRememberMe">ssoSessionMaxLifespanRememberMe.</param>
    /// <param name="supportedLocales">supportedLocales.</param>
    /// <param name="userFederationMappers">userFederationMappers.</param>
    /// <param name="userFederationProviders">userFederationProviders.</param>
    /// <param name="userManagedAccessAllowed">userManagedAccessAllowed.</param>
    /// <param name="users">users.</param>
    /// <param name="verifyEmail">verifyEmail.</param>
    /// <param name="waitIncrementSeconds">waitIncrementSeconds.</param>
    /// <param name="webAuthnPolicyAcceptableAaguids">webAuthnPolicyAcceptableAaguids.</param>
    /// <param name="webAuthnPolicyAttestationConveyancePreference">webAuthnPolicyAttestationConveyancePreference.</param>
    /// <param name="webAuthnPolicyAuthenticatorAttachment">webAuthnPolicyAuthenticatorAttachment.</param>
    /// <param name="webAuthnPolicyAvoidSameAuthenticatorRegister">webAuthnPolicyAvoidSameAuthenticatorRegister.</param>
    /// <param name="webAuthnPolicyCreateTimeout">webAuthnPolicyCreateTimeout.</param>
    /// <param name="webAuthnPolicyPasswordlessAcceptableAaguids">webAuthnPolicyPasswordlessAcceptableAaguids.</param>
    /// <param name="webAuthnPolicyPasswordlessAttestationConveyancePreference">webAuthnPolicyPasswordlessAttestationConveyancePreference.</param>
    /// <param name="webAuthnPolicyPasswordlessAuthenticatorAttachment">webAuthnPolicyPasswordlessAuthenticatorAttachment.</param>
    /// <param name="webAuthnPolicyPasswordlessAvoidSameAuthenticatorRegister">webAuthnPolicyPasswordlessAvoidSameAuthenticatorRegister.</param>
    /// <param name="webAuthnPolicyPasswordlessCreateTimeout">webAuthnPolicyPasswordlessCreateTimeout.</param>
    /// <param name="webAuthnPolicyPasswordlessRequireResidentKey">webAuthnPolicyPasswordlessRequireResidentKey.</param>
    /// <param name="webAuthnPolicyPasswordlessRpEntityName">webAuthnPolicyPasswordlessRpEntityName.</param>
    /// <param name="webAuthnPolicyPasswordlessRpId">webAuthnPolicyPasswordlessRpId.</param>
    /// <param name="webAuthnPolicyPasswordlessSignatureAlgorithms">webAuthnPolicyPasswordlessSignatureAlgorithms.</param>
    /// <param name="webAuthnPolicyPasswordlessUserVerificationRequirement">webAuthnPolicyPasswordlessUserVerificationRequirement.</param>
    /// <param name="webAuthnPolicyRequireResidentKey">webAuthnPolicyRequireResidentKey.</param>
    /// <param name="webAuthnPolicyRpEntityName">webAuthnPolicyRpEntityName.</param>
    /// <param name="webAuthnPolicyRpId">webAuthnPolicyRpId.</param>
    /// <param name="webAuthnPolicySignatureAlgorithms">webAuthnPolicySignatureAlgorithms.</param>
    /// <param name="webAuthnPolicyUserVerificationRequirement">webAuthnPolicyUserVerificationRequirement.</param>
    public RealmRepresentation(int? accessCodeLifespan = default, int? accessCodeLifespanLogin = default,
        int? accessCodeLifespanUserAction = default, int? accessTokenLifespan = default,
        int? accessTokenLifespanForImplicitFlow = default, string accountTheme = default,
        int? actionTokenGeneratedByAdminLifespan = default, int? actionTokenGeneratedByUserLifespan = default,
        bool? adminEventsDetailsEnabled = default, bool? adminEventsEnabled = default, string adminTheme = default,
        Dictionary<string, object> attributes = default,
        List<AuthenticationFlowRepresentation> authenticationFlows = default,
        List<AuthenticatorConfigRepresentation> authenticatorConfig = default, string browserFlow = default,
        Dictionary<string, object> browserSecurityHeaders = default, bool? bruteForceProtected = default,
        string clientAuthenticationFlow = default, int? clientOfflineSessionIdleTimeout = default,
        int? clientOfflineSessionMaxLifespan = default, JsonNode clientPolicies = default,
        JsonNode clientProfiles = default, Dictionary<string, object> clientScopeMappings = default,
        List<ClientScopeRepresentation> clientScopes = default, int? clientSessionIdleTimeout = default,
        int? clientSessionMaxLifespan = default, List<ClientRepresentation> clients = default,
        MultivaluedHashMap components = default, List<string> defaultDefaultClientScopes = default,
        List<string> defaultGroups = default, string defaultLocale = default,
        List<string> defaultOptionalClientScopes = default, RoleRepresentation defaultRole = default,
        string defaultSignatureAlgorithm = default, string directGrantFlow = default, string displayName = default,
        string displayNameHtml = default, string dockerAuthenticationFlow = default,
        bool? duplicateEmailsAllowed = default, bool? editUsernameAllowed = default, string emailTheme = default,
        bool? enabled = default, List<string> enabledEventTypes = default, bool? eventsEnabled = default,
        long? eventsExpiration = default, List<string> eventsListeners = default, int? failureFactor = default,
        List<UserRepresentation> federatedUsers = default, List<GroupRepresentation> groups = default,
        string id = default, List<IdentityProviderMapperRepresentation> identityProviderMappers = default,
        List<IdentityProviderRepresentation> identityProviders = default, bool? internationalizationEnabled = default,
        string keycloakVersion = default, string loginTheme = default, bool? loginWithEmailAllowed = default,
        int? maxDeltaTimeSeconds = default, int? maxFailureWaitSeconds = default,
        int? minimumQuickLoginWaitSeconds = default, int? notBefore = default, int? oAuth2DeviceCodeLifespan = default,
        int? oAuth2DevicePollingInterval = default, int? oauth2DeviceCodeLifespan = default,
        int? oauth2DevicePollingInterval = default, int? offlineSessionIdleTimeout = default,
        int? offlineSessionMaxLifespan = default, bool? offlineSessionMaxLifespanEnabled = default,
        string otpPolicyAlgorithm = default, int? otpPolicyDigits = default, int? otpPolicyInitialCounter = default,
        int? otpPolicyLookAheadWindow = default, int? otpPolicyPeriod = default, string otpPolicyType = default,
        List<string> otpSupportedApplications = default, string passwordPolicy = default,
        bool? permanentLockout = default, List<ProtocolMapperRepresentation> protocolMappers = default,
        long? quickLoginCheckMilliSeconds = default, string realm = default, int? refreshTokenMaxReuse = default,
        bool? registrationAllowed = default, bool? registrationEmailAsUsername = default,
        string registrationFlow = default, bool? rememberMe = default,
        List<RequiredActionProviderRepresentation> requiredActions = default, string resetCredentialsFlow = default,
        bool? resetPasswordAllowed = default, bool? revokeRefreshToken = default, RolesRepresentation roles = default,
        List<ScopeMappingRepresentation> scopeMappings = default, Dictionary<string, object> smtpServer = default,
        string sslRequired = default, int? ssoSessionIdleTimeout = default,
        int? ssoSessionIdleTimeoutRememberMe = default, int? ssoSessionMaxLifespan = default,
        int? ssoSessionMaxLifespanRememberMe = default, List<string> supportedLocales = default,
        List<UserFederationMapperRepresentation> userFederationMappers = default,
        List<UserFederationProviderRepresentation> userFederationProviders = default,
        bool? userManagedAccessAllowed = default, List<UserRepresentation> users = default, bool? verifyEmail = default,
        int? waitIncrementSeconds = default, List<string> webAuthnPolicyAcceptableAaguids = default,
        string webAuthnPolicyAttestationConveyancePreference = default,
        string webAuthnPolicyAuthenticatorAttachment = default,
        bool? webAuthnPolicyAvoidSameAuthenticatorRegister = default, int? webAuthnPolicyCreateTimeout = default,
        List<string> webAuthnPolicyPasswordlessAcceptableAaguids = default,
        string webAuthnPolicyPasswordlessAttestationConveyancePreference = default,
        string webAuthnPolicyPasswordlessAuthenticatorAttachment = default,
        bool? webAuthnPolicyPasswordlessAvoidSameAuthenticatorRegister = default,
        int? webAuthnPolicyPasswordlessCreateTimeout = default,
        string webAuthnPolicyPasswordlessRequireResidentKey = default,
        string webAuthnPolicyPasswordlessRpEntityName = default, string webAuthnPolicyPasswordlessRpId = default,
        List<string> webAuthnPolicyPasswordlessSignatureAlgorithms = default,
        string webAuthnPolicyPasswordlessUserVerificationRequirement = default,
        string webAuthnPolicyRequireResidentKey = default, string webAuthnPolicyRpEntityName = default,
        string webAuthnPolicyRpId = default, List<string> webAuthnPolicySignatureAlgorithms = default,
        string webAuthnPolicyUserVerificationRequirement = default)
    {
        AccessCodeLifespan = accessCodeLifespan;
        AccessCodeLifespanLogin = accessCodeLifespanLogin;
        AccessCodeLifespanUserAction = accessCodeLifespanUserAction;
        AccessTokenLifespan = accessTokenLifespan;
        AccessTokenLifespanForImplicitFlow = accessTokenLifespanForImplicitFlow;
        AccountTheme = accountTheme;
        ActionTokenGeneratedByAdminLifespan = actionTokenGeneratedByAdminLifespan;
        ActionTokenGeneratedByUserLifespan = actionTokenGeneratedByUserLifespan;
        AdminEventsDetailsEnabled = adminEventsDetailsEnabled;
        AdminEventsEnabled = adminEventsEnabled;
        AdminTheme = adminTheme;
        Attributes = attributes;
        AuthenticationFlows = authenticationFlows;
        AuthenticatorConfig = authenticatorConfig;
        BrowserFlow = browserFlow;
        BrowserSecurityHeaders = browserSecurityHeaders;
        BruteForceProtected = bruteForceProtected;
        ClientAuthenticationFlow = clientAuthenticationFlow;
        ClientOfflineSessionIdleTimeout = clientOfflineSessionIdleTimeout;
        ClientOfflineSessionMaxLifespan = clientOfflineSessionMaxLifespan;
        ClientPolicies = clientPolicies;
        ClientProfiles = clientProfiles;
        ClientScopeMappings = clientScopeMappings;
        ClientScopes = clientScopes;
        ClientSessionIdleTimeout = clientSessionIdleTimeout;
        ClientSessionMaxLifespan = clientSessionMaxLifespan;
        Clients = clients;
        Components = components;
        DefaultDefaultClientScopes = defaultDefaultClientScopes;
        DefaultGroups = defaultGroups;
        DefaultLocale = defaultLocale;
        DefaultOptionalClientScopes = defaultOptionalClientScopes;
        DefaultRole = defaultRole;
        DefaultSignatureAlgorithm = defaultSignatureAlgorithm;
        DirectGrantFlow = directGrantFlow;
        DisplayName = displayName;
        DisplayNameHtml = displayNameHtml;
        DockerAuthenticationFlow = dockerAuthenticationFlow;
        DuplicateEmailsAllowed = duplicateEmailsAllowed;
        EditUsernameAllowed = editUsernameAllowed;
        EmailTheme = emailTheme;
        Enabled = enabled;
        EnabledEventTypes = enabledEventTypes;
        EventsEnabled = eventsEnabled;
        EventsExpiration = eventsExpiration;
        EventsListeners = eventsListeners;
        FailureFactor = failureFactor;
        FederatedUsers = federatedUsers;
        Groups = groups;
        Id = id;
        IdentityProviderMappers = identityProviderMappers;
        IdentityProviders = identityProviders;
        InternationalizationEnabled = internationalizationEnabled;
        KeycloakVersion = keycloakVersion;
        LoginTheme = loginTheme;
        LoginWithEmailAllowed = loginWithEmailAllowed;
        MaxDeltaTimeSeconds = maxDeltaTimeSeconds;
        MaxFailureWaitSeconds = maxFailureWaitSeconds;
        MinimumQuickLoginWaitSeconds = minimumQuickLoginWaitSeconds;
        NotBefore = notBefore;
        OAuth2DeviceCodeLifespan = oAuth2DeviceCodeLifespan;
        OAuth2DevicePollingInterval = oAuth2DevicePollingInterval;
        Oauth2DeviceCodeLifespan = oauth2DeviceCodeLifespan;
        Oauth2DevicePollingInterval = oauth2DevicePollingInterval;
        OfflineSessionIdleTimeout = offlineSessionIdleTimeout;
        OfflineSessionMaxLifespan = offlineSessionMaxLifespan;
        OfflineSessionMaxLifespanEnabled = offlineSessionMaxLifespanEnabled;
        OtpPolicyAlgorithm = otpPolicyAlgorithm;
        OtpPolicyDigits = otpPolicyDigits;
        OtpPolicyInitialCounter = otpPolicyInitialCounter;
        OtpPolicyLookAheadWindow = otpPolicyLookAheadWindow;
        OtpPolicyPeriod = otpPolicyPeriod;
        OtpPolicyType = otpPolicyType;
        OtpSupportedApplications = otpSupportedApplications;
        PasswordPolicy = passwordPolicy;
        PermanentLockout = permanentLockout;
        ProtocolMappers = protocolMappers;
        QuickLoginCheckMilliSeconds = quickLoginCheckMilliSeconds;
        Realm = realm;
        RefreshTokenMaxReuse = refreshTokenMaxReuse;
        RegistrationAllowed = registrationAllowed;
        RegistrationEmailAsUsername = registrationEmailAsUsername;
        RegistrationFlow = registrationFlow;
        RememberMe = rememberMe;
        RequiredActions = requiredActions;
        ResetCredentialsFlow = resetCredentialsFlow;
        ResetPasswordAllowed = resetPasswordAllowed;
        RevokeRefreshToken = revokeRefreshToken;
        Roles = roles;
        ScopeMappings = scopeMappings;
        SmtpServer = smtpServer;
        SslRequired = sslRequired;
        SsoSessionIdleTimeout = ssoSessionIdleTimeout;
        SsoSessionIdleTimeoutRememberMe = ssoSessionIdleTimeoutRememberMe;
        SsoSessionMaxLifespan = ssoSessionMaxLifespan;
        SsoSessionMaxLifespanRememberMe = ssoSessionMaxLifespanRememberMe;
        SupportedLocales = supportedLocales;
        UserFederationMappers = userFederationMappers;
        UserFederationProviders = userFederationProviders;
        UserManagedAccessAllowed = userManagedAccessAllowed;
        Users = users;
        VerifyEmail = verifyEmail;
        WaitIncrementSeconds = waitIncrementSeconds;
        WebAuthnPolicyAcceptableAaguids = webAuthnPolicyAcceptableAaguids;
        WebAuthnPolicyAttestationConveyancePreference = webAuthnPolicyAttestationConveyancePreference;
        WebAuthnPolicyAuthenticatorAttachment = webAuthnPolicyAuthenticatorAttachment;
        WebAuthnPolicyAvoidSameAuthenticatorRegister = webAuthnPolicyAvoidSameAuthenticatorRegister;
        WebAuthnPolicyCreateTimeout = webAuthnPolicyCreateTimeout;
        WebAuthnPolicyPasswordlessAcceptableAaguids = webAuthnPolicyPasswordlessAcceptableAaguids;
        WebAuthnPolicyPasswordlessAttestationConveyancePreference =
            webAuthnPolicyPasswordlessAttestationConveyancePreference;
        WebAuthnPolicyPasswordlessAuthenticatorAttachment = webAuthnPolicyPasswordlessAuthenticatorAttachment;
        WebAuthnPolicyPasswordlessAvoidSameAuthenticatorRegister =
            webAuthnPolicyPasswordlessAvoidSameAuthenticatorRegister;
        WebAuthnPolicyPasswordlessCreateTimeout = webAuthnPolicyPasswordlessCreateTimeout;
        WebAuthnPolicyPasswordlessRequireResidentKey = webAuthnPolicyPasswordlessRequireResidentKey;
        WebAuthnPolicyPasswordlessRpEntityName = webAuthnPolicyPasswordlessRpEntityName;
        WebAuthnPolicyPasswordlessRpId = webAuthnPolicyPasswordlessRpId;
        WebAuthnPolicyPasswordlessSignatureAlgorithms = webAuthnPolicyPasswordlessSignatureAlgorithms;
        WebAuthnPolicyPasswordlessUserVerificationRequirement = webAuthnPolicyPasswordlessUserVerificationRequirement;
        WebAuthnPolicyRequireResidentKey = webAuthnPolicyRequireResidentKey;
        WebAuthnPolicyRpEntityName = webAuthnPolicyRpEntityName;
        WebAuthnPolicyRpId = webAuthnPolicyRpId;
        WebAuthnPolicySignatureAlgorithms = webAuthnPolicySignatureAlgorithms;
        WebAuthnPolicyUserVerificationRequirement = webAuthnPolicyUserVerificationRequirement;
    }

    /// <summary>
    ///     Gets or Sets AccessCodeLifespan
    /// </summary>
    [DataMember(Name = "accessCodeLifespan", EmitDefaultValue = false)]
    public int? AccessCodeLifespan { get; set; }

    /// <summary>
    ///     Gets or Sets AccessCodeLifespanLogin
    /// </summary>
    [DataMember(Name = "accessCodeLifespanLogin", EmitDefaultValue = false)]
    public int? AccessCodeLifespanLogin { get; set; }

    /// <summary>
    ///     Gets or Sets AccessCodeLifespanUserAction
    /// </summary>
    [DataMember(Name = "accessCodeLifespanUserAction", EmitDefaultValue = false)]
    public int? AccessCodeLifespanUserAction { get; set; }

    /// <summary>
    ///     Gets or Sets AccessTokenLifespan
    /// </summary>
    [DataMember(Name = "accessTokenLifespan", EmitDefaultValue = false)]
    public int? AccessTokenLifespan { get; set; }

    /// <summary>
    ///     Gets or Sets AccessTokenLifespanForImplicitFlow
    /// </summary>
    [DataMember(Name = "accessTokenLifespanForImplicitFlow", EmitDefaultValue = false)]
    public int? AccessTokenLifespanForImplicitFlow { get; set; }

    /// <summary>
    ///     Gets or Sets AccountTheme
    /// </summary>
    [DataMember(Name = "accountTheme", EmitDefaultValue = false)]
    public string AccountTheme { get; set; }

    /// <summary>
    ///     Gets or Sets ActionTokenGeneratedByAdminLifespan
    /// </summary>
    [DataMember(Name = "actionTokenGeneratedByAdminLifespan", EmitDefaultValue = false)]
    public int? ActionTokenGeneratedByAdminLifespan { get; set; }

    /// <summary>
    ///     Gets or Sets ActionTokenGeneratedByUserLifespan
    /// </summary>
    [DataMember(Name = "actionTokenGeneratedByUserLifespan", EmitDefaultValue = false)]
    public int? ActionTokenGeneratedByUserLifespan { get; set; }

    /// <summary>
    ///     Gets or Sets AdminEventsDetailsEnabled
    /// </summary>
    [DataMember(Name = "adminEventsDetailsEnabled", EmitDefaultValue = false)]
    public bool? AdminEventsDetailsEnabled { get; set; }

    /// <summary>
    ///     Gets or Sets AdminEventsEnabled
    /// </summary>
    [DataMember(Name = "adminEventsEnabled", EmitDefaultValue = false)]
    public bool? AdminEventsEnabled { get; set; }

    /// <summary>
    ///     Gets or Sets AdminTheme
    /// </summary>
    [DataMember(Name = "adminTheme", EmitDefaultValue = false)]
    public string AdminTheme { get; set; }

    /// <summary>
    ///     Gets or Sets Attributes
    /// </summary>
    [DataMember(Name = "attributes", EmitDefaultValue = false)]
    public Dictionary<string, object> Attributes { get; set; }

    /// <summary>
    ///     Gets or Sets AuthenticationFlows
    /// </summary>
    [DataMember(Name = "authenticationFlows", EmitDefaultValue = false)]
    public List<AuthenticationFlowRepresentation> AuthenticationFlows { get; set; }

    /// <summary>
    ///     Gets or Sets AuthenticatorConfig
    /// </summary>
    [DataMember(Name = "authenticatorConfig", EmitDefaultValue = false)]
    public List<AuthenticatorConfigRepresentation> AuthenticatorConfig { get; set; }

    /// <summary>
    ///     Gets or Sets BrowserFlow
    /// </summary>
    [DataMember(Name = "browserFlow", EmitDefaultValue = false)]
    public string BrowserFlow { get; set; }

    /// <summary>
    ///     Gets or Sets BrowserSecurityHeaders
    /// </summary>
    [DataMember(Name = "browserSecurityHeaders", EmitDefaultValue = false)]
    public Dictionary<string, object> BrowserSecurityHeaders { get; set; }

    /// <summary>
    ///     Gets or Sets BruteForceProtected
    /// </summary>
    [DataMember(Name = "bruteForceProtected", EmitDefaultValue = false)]
    public bool? BruteForceProtected { get; set; }

    /// <summary>
    ///     Gets or Sets ClientAuthenticationFlow
    /// </summary>
    [DataMember(Name = "clientAuthenticationFlow", EmitDefaultValue = false)]
    public string ClientAuthenticationFlow { get; set; }

    /// <summary>
    ///     Gets or Sets ClientOfflineSessionIdleTimeout
    /// </summary>
    [DataMember(Name = "clientOfflineSessionIdleTimeout", EmitDefaultValue = false)]
    public int? ClientOfflineSessionIdleTimeout { get; set; }

    /// <summary>
    ///     Gets or Sets ClientOfflineSessionMaxLifespan
    /// </summary>
    [DataMember(Name = "clientOfflineSessionMaxLifespan", EmitDefaultValue = false)]
    public int? ClientOfflineSessionMaxLifespan { get; set; }

    /// <summary>
    ///     Gets or Sets ClientPolicies
    /// </summary>
    [DataMember(Name = "clientPolicies", EmitDefaultValue = false)]
    public JsonNode ClientPolicies { get; set; }

    /// <summary>
    ///     Gets or Sets ClientProfiles
    /// </summary>
    [DataMember(Name = "clientProfiles", EmitDefaultValue = false)]
    public JsonNode ClientProfiles { get; set; }

    /// <summary>
    ///     Gets or Sets ClientScopeMappings
    /// </summary>
    [DataMember(Name = "clientScopeMappings", EmitDefaultValue = false)]
    public Dictionary<string, object> ClientScopeMappings { get; set; }

    /// <summary>
    ///     Gets or Sets ClientScopes
    /// </summary>
    [DataMember(Name = "clientScopes", EmitDefaultValue = false)]
    public List<ClientScopeRepresentation> ClientScopes { get; set; }

    /// <summary>
    ///     Gets or Sets ClientSessionIdleTimeout
    /// </summary>
    [DataMember(Name = "clientSessionIdleTimeout", EmitDefaultValue = false)]
    public int? ClientSessionIdleTimeout { get; set; }

    /// <summary>
    ///     Gets or Sets ClientSessionMaxLifespan
    /// </summary>
    [DataMember(Name = "clientSessionMaxLifespan", EmitDefaultValue = false)]
    public int? ClientSessionMaxLifespan { get; set; }

    /// <summary>
    ///     Gets or Sets Clients
    /// </summary>
    [DataMember(Name = "clients", EmitDefaultValue = false)]
    public List<ClientRepresentation> Clients { get; set; }

    /// <summary>
    ///     Gets or Sets Components
    /// </summary>
    [DataMember(Name = "components", EmitDefaultValue = false)]
    public MultivaluedHashMap Components { get; set; }

    /// <summary>
    ///     Gets or Sets DefaultDefaultClientScopes
    /// </summary>
    [DataMember(Name = "defaultDefaultClientScopes", EmitDefaultValue = false)]
    public List<string> DefaultDefaultClientScopes { get; set; }

    /// <summary>
    ///     Gets or Sets DefaultGroups
    /// </summary>
    [DataMember(Name = "defaultGroups", EmitDefaultValue = false)]
    public List<string> DefaultGroups { get; set; }

    /// <summary>
    ///     Gets or Sets DefaultLocale
    /// </summary>
    [DataMember(Name = "defaultLocale", EmitDefaultValue = false)]
    public string DefaultLocale { get; set; }

    /// <summary>
    ///     Gets or Sets DefaultOptionalClientScopes
    /// </summary>
    [DataMember(Name = "defaultOptionalClientScopes", EmitDefaultValue = false)]
    public List<string> DefaultOptionalClientScopes { get; set; }

    /// <summary>
    ///     Gets or Sets DefaultRole
    /// </summary>
    [DataMember(Name = "defaultRole", EmitDefaultValue = false)]
    public RoleRepresentation DefaultRole { get; set; }

    /// <summary>
    ///     Gets or Sets DefaultSignatureAlgorithm
    /// </summary>
    [DataMember(Name = "defaultSignatureAlgorithm", EmitDefaultValue = false)]
    public string DefaultSignatureAlgorithm { get; set; }

    /// <summary>
    ///     Gets or Sets DirectGrantFlow
    /// </summary>
    [DataMember(Name = "directGrantFlow", EmitDefaultValue = false)]
    public string DirectGrantFlow { get; set; }

    /// <summary>
    ///     Gets or Sets DisplayName
    /// </summary>
    [DataMember(Name = "displayName", EmitDefaultValue = false)]
    public string DisplayName { get; set; }

    /// <summary>
    ///     Gets or Sets DisplayNameHtml
    /// </summary>
    [DataMember(Name = "displayNameHtml", EmitDefaultValue = false)]
    public string DisplayNameHtml { get; set; }

    /// <summary>
    ///     Gets or Sets DockerAuthenticationFlow
    /// </summary>
    [DataMember(Name = "dockerAuthenticationFlow", EmitDefaultValue = false)]
    public string DockerAuthenticationFlow { get; set; }

    /// <summary>
    ///     Gets or Sets DuplicateEmailsAllowed
    /// </summary>
    [DataMember(Name = "duplicateEmailsAllowed", EmitDefaultValue = false)]
    public bool? DuplicateEmailsAllowed { get; set; }

    /// <summary>
    ///     Gets or Sets EditUsernameAllowed
    /// </summary>
    [DataMember(Name = "editUsernameAllowed", EmitDefaultValue = false)]
    public bool? EditUsernameAllowed { get; set; }

    /// <summary>
    ///     Gets or Sets EmailTheme
    /// </summary>
    [DataMember(Name = "emailTheme", EmitDefaultValue = false)]
    public string EmailTheme { get; set; }

    /// <summary>
    ///     Gets or Sets Enabled
    /// </summary>
    [DataMember(Name = "enabled", EmitDefaultValue = false)]
    public bool? Enabled { get; set; }

    /// <summary>
    ///     Gets or Sets EnabledEventTypes
    /// </summary>
    [DataMember(Name = "enabledEventTypes", EmitDefaultValue = false)]
    public List<string> EnabledEventTypes { get; set; }

    /// <summary>
    ///     Gets or Sets EventsEnabled
    /// </summary>
    [DataMember(Name = "eventsEnabled", EmitDefaultValue = false)]
    public bool? EventsEnabled { get; set; }

    /// <summary>
    ///     Gets or Sets EventsExpiration
    /// </summary>
    [DataMember(Name = "eventsExpiration", EmitDefaultValue = false)]
    public long? EventsExpiration { get; set; }

    /// <summary>
    ///     Gets or Sets EventsListeners
    /// </summary>
    [DataMember(Name = "eventsListeners", EmitDefaultValue = false)]
    public List<string> EventsListeners { get; set; }

    /// <summary>
    ///     Gets or Sets FailureFactor
    /// </summary>
    [DataMember(Name = "failureFactor", EmitDefaultValue = false)]
    public int? FailureFactor { get; set; }

    /// <summary>
    ///     Gets or Sets FederatedUsers
    /// </summary>
    [DataMember(Name = "federatedUsers", EmitDefaultValue = false)]
    public List<UserRepresentation> FederatedUsers { get; set; }

    /// <summary>
    ///     Gets or Sets Groups
    /// </summary>
    [DataMember(Name = "groups", EmitDefaultValue = false)]
    public List<GroupRepresentation> Groups { get; set; }

    /// <summary>
    ///     Gets or Sets Id
    /// </summary>
    [DataMember(Name = "id", EmitDefaultValue = false)]
    public string Id { get; set; }

    /// <summary>
    ///     Gets or Sets IdentityProviderMappers
    /// </summary>
    [DataMember(Name = "identityProviderMappers", EmitDefaultValue = false)]
    public List<IdentityProviderMapperRepresentation> IdentityProviderMappers { get; set; }

    /// <summary>
    ///     Gets or Sets IdentityProviders
    /// </summary>
    [DataMember(Name = "identityProviders", EmitDefaultValue = false)]
    public List<IdentityProviderRepresentation> IdentityProviders { get; set; }

    /// <summary>
    ///     Gets or Sets InternationalizationEnabled
    /// </summary>
    [DataMember(Name = "internationalizationEnabled", EmitDefaultValue = false)]
    public bool? InternationalizationEnabled { get; set; }

    /// <summary>
    ///     Gets or Sets KeycloakVersion
    /// </summary>
    [DataMember(Name = "keycloakVersion", EmitDefaultValue = false)]
    public string KeycloakVersion { get; set; }

    /// <summary>
    ///     Gets or Sets LoginTheme
    /// </summary>
    [DataMember(Name = "loginTheme", EmitDefaultValue = false)]
    public string LoginTheme { get; set; }

    /// <summary>
    ///     Gets or Sets LoginWithEmailAllowed
    /// </summary>
    [DataMember(Name = "loginWithEmailAllowed", EmitDefaultValue = false)]
    public bool? LoginWithEmailAllowed { get; set; }

    /// <summary>
    ///     Gets or Sets MaxDeltaTimeSeconds
    /// </summary>
    [DataMember(Name = "maxDeltaTimeSeconds", EmitDefaultValue = false)]
    public int? MaxDeltaTimeSeconds { get; set; }

    /// <summary>
    ///     Gets or Sets MaxFailureWaitSeconds
    /// </summary>
    [DataMember(Name = "maxFailureWaitSeconds", EmitDefaultValue = false)]
    public int? MaxFailureWaitSeconds { get; set; }

    /// <summary>
    ///     Gets or Sets MinimumQuickLoginWaitSeconds
    /// </summary>
    [DataMember(Name = "minimumQuickLoginWaitSeconds", EmitDefaultValue = false)]
    public int? MinimumQuickLoginWaitSeconds { get; set; }

    /// <summary>
    ///     Gets or Sets NotBefore
    /// </summary>
    [DataMember(Name = "notBefore", EmitDefaultValue = false)]
    public int? NotBefore { get; set; }

    /// <summary>
    ///     Gets or Sets OAuth2DeviceCodeLifespan
    /// </summary>
    [DataMember(Name = "oAuth2DeviceCodeLifespan", EmitDefaultValue = false)]
    public int? OAuth2DeviceCodeLifespan { get; set; }

    /// <summary>
    ///     Gets or Sets OAuth2DevicePollingInterval
    /// </summary>
    [DataMember(Name = "oAuth2DevicePollingInterval", EmitDefaultValue = false)]
    public int? OAuth2DevicePollingInterval { get; set; }

    /// <summary>
    ///     Gets or Sets Oauth2DeviceCodeLifespan
    /// </summary>
    [DataMember(Name = "oauth2DeviceCodeLifespan", EmitDefaultValue = false)]
    public int? Oauth2DeviceCodeLifespan { get; set; }

    /// <summary>
    ///     Gets or Sets Oauth2DevicePollingInterval
    /// </summary>
    [DataMember(Name = "oauth2DevicePollingInterval", EmitDefaultValue = false)]
    public int? Oauth2DevicePollingInterval { get; set; }

    /// <summary>
    ///     Gets or Sets OfflineSessionIdleTimeout
    /// </summary>
    [DataMember(Name = "offlineSessionIdleTimeout", EmitDefaultValue = false)]
    public int? OfflineSessionIdleTimeout { get; set; }

    /// <summary>
    ///     Gets or Sets OfflineSessionMaxLifespan
    /// </summary>
    [DataMember(Name = "offlineSessionMaxLifespan", EmitDefaultValue = false)]
    public int? OfflineSessionMaxLifespan { get; set; }

    /// <summary>
    ///     Gets or Sets OfflineSessionMaxLifespanEnabled
    /// </summary>
    [DataMember(Name = "offlineSessionMaxLifespanEnabled", EmitDefaultValue = false)]
    public bool? OfflineSessionMaxLifespanEnabled { get; set; }

    /// <summary>
    ///     Gets or Sets OtpPolicyAlgorithm
    /// </summary>
    [DataMember(Name = "otpPolicyAlgorithm", EmitDefaultValue = false)]
    public string OtpPolicyAlgorithm { get; set; }

    /// <summary>
    ///     Gets or Sets OtpPolicyDigits
    /// </summary>
    [DataMember(Name = "otpPolicyDigits", EmitDefaultValue = false)]
    public int? OtpPolicyDigits { get; set; }

    /// <summary>
    ///     Gets or Sets OtpPolicyInitialCounter
    /// </summary>
    [DataMember(Name = "otpPolicyInitialCounter", EmitDefaultValue = false)]
    public int? OtpPolicyInitialCounter { get; set; }

    /// <summary>
    ///     Gets or Sets OtpPolicyLookAheadWindow
    /// </summary>
    [DataMember(Name = "otpPolicyLookAheadWindow", EmitDefaultValue = false)]
    public int? OtpPolicyLookAheadWindow { get; set; }

    /// <summary>
    ///     Gets or Sets OtpPolicyPeriod
    /// </summary>
    [DataMember(Name = "otpPolicyPeriod", EmitDefaultValue = false)]
    public int? OtpPolicyPeriod { get; set; }

    /// <summary>
    ///     Gets or Sets OtpPolicyType
    /// </summary>
    [DataMember(Name = "otpPolicyType", EmitDefaultValue = false)]
    public string OtpPolicyType { get; set; }

    /// <summary>
    ///     Gets or Sets OtpSupportedApplications
    /// </summary>
    [DataMember(Name = "otpSupportedApplications", EmitDefaultValue = false)]
    public List<string> OtpSupportedApplications { get; set; }

    /// <summary>
    ///     Gets or Sets PasswordPolicy
    /// </summary>
    [DataMember(Name = "passwordPolicy", EmitDefaultValue = false)]
    public string PasswordPolicy { get; set; }

    /// <summary>
    ///     Gets or Sets PermanentLockout
    /// </summary>
    [DataMember(Name = "permanentLockout", EmitDefaultValue = false)]
    public bool? PermanentLockout { get; set; }

    /// <summary>
    ///     Gets or Sets ProtocolMappers
    /// </summary>
    [DataMember(Name = "protocolMappers", EmitDefaultValue = false)]
    public List<ProtocolMapperRepresentation> ProtocolMappers { get; set; }

    /// <summary>
    ///     Gets or Sets QuickLoginCheckMilliSeconds
    /// </summary>
    [DataMember(Name = "quickLoginCheckMilliSeconds", EmitDefaultValue = false)]
    public long? QuickLoginCheckMilliSeconds { get; set; }

    /// <summary>
    ///     Gets or Sets Realm
    /// </summary>
    [DataMember(Name = "realm", EmitDefaultValue = false)]
    public string Realm { get; set; }

    /// <summary>
    ///     Gets or Sets RefreshTokenMaxReuse
    /// </summary>
    [DataMember(Name = "refreshTokenMaxReuse", EmitDefaultValue = false)]
    public int? RefreshTokenMaxReuse { get; set; }

    /// <summary>
    ///     Gets or Sets RegistrationAllowed
    /// </summary>
    [DataMember(Name = "registrationAllowed", EmitDefaultValue = false)]
    public bool? RegistrationAllowed { get; set; }

    /// <summary>
    ///     Gets or Sets RegistrationEmailAsUsername
    /// </summary>
    [DataMember(Name = "registrationEmailAsUsername", EmitDefaultValue = false)]
    public bool? RegistrationEmailAsUsername { get; set; }

    /// <summary>
    ///     Gets or Sets RegistrationFlow
    /// </summary>
    [DataMember(Name = "registrationFlow", EmitDefaultValue = false)]
    public string RegistrationFlow { get; set; }

    /// <summary>
    ///     Gets or Sets RememberMe
    /// </summary>
    [DataMember(Name = "rememberMe", EmitDefaultValue = false)]
    public bool? RememberMe { get; set; }

    /// <summary>
    ///     Gets or Sets RequiredActions
    /// </summary>
    [DataMember(Name = "requiredActions", EmitDefaultValue = false)]
    public List<RequiredActionProviderRepresentation> RequiredActions { get; set; }

    /// <summary>
    ///     Gets or Sets ResetCredentialsFlow
    /// </summary>
    [DataMember(Name = "resetCredentialsFlow", EmitDefaultValue = false)]
    public string ResetCredentialsFlow { get; set; }

    /// <summary>
    ///     Gets or Sets ResetPasswordAllowed
    /// </summary>
    [DataMember(Name = "resetPasswordAllowed", EmitDefaultValue = false)]
    public bool? ResetPasswordAllowed { get; set; }

    /// <summary>
    ///     Gets or Sets RevokeRefreshToken
    /// </summary>
    [DataMember(Name = "revokeRefreshToken", EmitDefaultValue = false)]
    public bool? RevokeRefreshToken { get; set; }

    /// <summary>
    ///     Gets or Sets Roles
    /// </summary>
    [DataMember(Name = "roles", EmitDefaultValue = false)]
    public RolesRepresentation Roles { get; set; }

    /// <summary>
    ///     Gets or Sets ScopeMappings
    /// </summary>
    [DataMember(Name = "scopeMappings", EmitDefaultValue = false)]
    public List<ScopeMappingRepresentation> ScopeMappings { get; set; }

    /// <summary>
    ///     Gets or Sets SmtpServer
    /// </summary>
    [DataMember(Name = "smtpServer", EmitDefaultValue = false)]
    public Dictionary<string, object> SmtpServer { get; set; }

    /// <summary>
    ///     Gets or Sets SslRequired
    /// </summary>
    [DataMember(Name = "sslRequired", EmitDefaultValue = false)]
    public string SslRequired { get; set; }

    /// <summary>
    ///     Gets or Sets SsoSessionIdleTimeout
    /// </summary>
    [DataMember(Name = "ssoSessionIdleTimeout", EmitDefaultValue = false)]
    public int? SsoSessionIdleTimeout { get; set; }

    /// <summary>
    ///     Gets or Sets SsoSessionIdleTimeoutRememberMe
    /// </summary>
    [DataMember(Name = "ssoSessionIdleTimeoutRememberMe", EmitDefaultValue = false)]
    public int? SsoSessionIdleTimeoutRememberMe { get; set; }

    /// <summary>
    ///     Gets or Sets SsoSessionMaxLifespan
    /// </summary>
    [DataMember(Name = "ssoSessionMaxLifespan", EmitDefaultValue = false)]
    public int? SsoSessionMaxLifespan { get; set; }

    /// <summary>
    ///     Gets or Sets SsoSessionMaxLifespanRememberMe
    /// </summary>
    [DataMember(Name = "ssoSessionMaxLifespanRememberMe", EmitDefaultValue = false)]
    public int? SsoSessionMaxLifespanRememberMe { get; set; }

    /// <summary>
    ///     Gets or Sets SupportedLocales
    /// </summary>
    [DataMember(Name = "supportedLocales", EmitDefaultValue = false)]
    public List<string> SupportedLocales { get; set; }

    /// <summary>
    ///     Gets or Sets UserFederationMappers
    /// </summary>
    [DataMember(Name = "userFederationMappers", EmitDefaultValue = false)]
    public List<UserFederationMapperRepresentation> UserFederationMappers { get; set; }

    /// <summary>
    ///     Gets or Sets UserFederationProviders
    /// </summary>
    [DataMember(Name = "userFederationProviders", EmitDefaultValue = false)]
    public List<UserFederationProviderRepresentation> UserFederationProviders { get; set; }

    /// <summary>
    ///     Gets or Sets UserManagedAccessAllowed
    /// </summary>
    [DataMember(Name = "userManagedAccessAllowed", EmitDefaultValue = false)]
    public bool? UserManagedAccessAllowed { get; set; }

    /// <summary>
    ///     Gets or Sets Users
    /// </summary>
    [DataMember(Name = "users", EmitDefaultValue = false)]
    public List<UserRepresentation> Users { get; set; }

    /// <summary>
    ///     Gets or Sets VerifyEmail
    /// </summary>
    [DataMember(Name = "verifyEmail", EmitDefaultValue = false)]
    public bool? VerifyEmail { get; set; }

    /// <summary>
    ///     Gets or Sets WaitIncrementSeconds
    /// </summary>
    [DataMember(Name = "waitIncrementSeconds", EmitDefaultValue = false)]
    public int? WaitIncrementSeconds { get; set; }

    /// <summary>
    ///     Gets or Sets WebAuthnPolicyAcceptableAaguids
    /// </summary>
    [DataMember(Name = "webAuthnPolicyAcceptableAaguids", EmitDefaultValue = false)]
    public List<string> WebAuthnPolicyAcceptableAaguids { get; set; }

    /// <summary>
    ///     Gets or Sets WebAuthnPolicyAttestationConveyancePreference
    /// </summary>
    [DataMember(Name = "webAuthnPolicyAttestationConveyancePreference", EmitDefaultValue = false)]
    public string WebAuthnPolicyAttestationConveyancePreference { get; set; }

    /// <summary>
    ///     Gets or Sets WebAuthnPolicyAuthenticatorAttachment
    /// </summary>
    [DataMember(Name = "webAuthnPolicyAuthenticatorAttachment", EmitDefaultValue = false)]
    public string WebAuthnPolicyAuthenticatorAttachment { get; set; }

    /// <summary>
    ///     Gets or Sets WebAuthnPolicyAvoidSameAuthenticatorRegister
    /// </summary>
    [DataMember(Name = "webAuthnPolicyAvoidSameAuthenticatorRegister", EmitDefaultValue = false)]
    public bool? WebAuthnPolicyAvoidSameAuthenticatorRegister { get; set; }

    /// <summary>
    ///     Gets or Sets WebAuthnPolicyCreateTimeout
    /// </summary>
    [DataMember(Name = "webAuthnPolicyCreateTimeout", EmitDefaultValue = false)]
    public int? WebAuthnPolicyCreateTimeout { get; set; }

    /// <summary>
    ///     Gets or Sets WebAuthnPolicyPasswordlessAcceptableAaguids
    /// </summary>
    [DataMember(Name = "webAuthnPolicyPasswordlessAcceptableAaguids", EmitDefaultValue = false)]
    public List<string> WebAuthnPolicyPasswordlessAcceptableAaguids { get; set; }

    /// <summary>
    ///     Gets or Sets WebAuthnPolicyPasswordlessAttestationConveyancePreference
    /// </summary>
    [DataMember(Name = "webAuthnPolicyPasswordlessAttestationConveyancePreference", EmitDefaultValue = false)]
    public string WebAuthnPolicyPasswordlessAttestationConveyancePreference { get; set; }

    /// <summary>
    ///     Gets or Sets WebAuthnPolicyPasswordlessAuthenticatorAttachment
    /// </summary>
    [DataMember(Name = "webAuthnPolicyPasswordlessAuthenticatorAttachment", EmitDefaultValue = false)]
    public string WebAuthnPolicyPasswordlessAuthenticatorAttachment { get; set; }

    /// <summary>
    ///     Gets or Sets WebAuthnPolicyPasswordlessAvoidSameAuthenticatorRegister
    /// </summary>
    [DataMember(Name = "webAuthnPolicyPasswordlessAvoidSameAuthenticatorRegister", EmitDefaultValue = false)]
    public bool? WebAuthnPolicyPasswordlessAvoidSameAuthenticatorRegister { get; set; }

    /// <summary>
    ///     Gets or Sets WebAuthnPolicyPasswordlessCreateTimeout
    /// </summary>
    [DataMember(Name = "webAuthnPolicyPasswordlessCreateTimeout", EmitDefaultValue = false)]
    public int? WebAuthnPolicyPasswordlessCreateTimeout { get; set; }

    /// <summary>
    ///     Gets or Sets WebAuthnPolicyPasswordlessRequireResidentKey
    /// </summary>
    [DataMember(Name = "webAuthnPolicyPasswordlessRequireResidentKey", EmitDefaultValue = false)]
    public string WebAuthnPolicyPasswordlessRequireResidentKey { get; set; }

    /// <summary>
    ///     Gets or Sets WebAuthnPolicyPasswordlessRpEntityName
    /// </summary>
    [DataMember(Name = "webAuthnPolicyPasswordlessRpEntityName", EmitDefaultValue = false)]
    public string WebAuthnPolicyPasswordlessRpEntityName { get; set; }

    /// <summary>
    ///     Gets or Sets WebAuthnPolicyPasswordlessRpId
    /// </summary>
    [DataMember(Name = "webAuthnPolicyPasswordlessRpId", EmitDefaultValue = false)]
    public string WebAuthnPolicyPasswordlessRpId { get; set; }

    /// <summary>
    ///     Gets or Sets WebAuthnPolicyPasswordlessSignatureAlgorithms
    /// </summary>
    [DataMember(Name = "webAuthnPolicyPasswordlessSignatureAlgorithms", EmitDefaultValue = false)]
    public List<string> WebAuthnPolicyPasswordlessSignatureAlgorithms { get; set; }

    /// <summary>
    ///     Gets or Sets WebAuthnPolicyPasswordlessUserVerificationRequirement
    /// </summary>
    [DataMember(Name = "webAuthnPolicyPasswordlessUserVerificationRequirement", EmitDefaultValue = false)]
    public string WebAuthnPolicyPasswordlessUserVerificationRequirement { get; set; }

    /// <summary>
    ///     Gets or Sets WebAuthnPolicyRequireResidentKey
    /// </summary>
    [DataMember(Name = "webAuthnPolicyRequireResidentKey", EmitDefaultValue = false)]
    public string WebAuthnPolicyRequireResidentKey { get; set; }

    /// <summary>
    ///     Gets or Sets WebAuthnPolicyRpEntityName
    /// </summary>
    [DataMember(Name = "webAuthnPolicyRpEntityName", EmitDefaultValue = false)]
    public string WebAuthnPolicyRpEntityName { get; set; }

    /// <summary>
    ///     Gets or Sets WebAuthnPolicyRpId
    /// </summary>
    [DataMember(Name = "webAuthnPolicyRpId", EmitDefaultValue = false)]
    public string WebAuthnPolicyRpId { get; set; }

    /// <summary>
    ///     Gets or Sets WebAuthnPolicySignatureAlgorithms
    /// </summary>
    [DataMember(Name = "webAuthnPolicySignatureAlgorithms", EmitDefaultValue = false)]
    public List<string> WebAuthnPolicySignatureAlgorithms { get; set; }

    /// <summary>
    ///     Gets or Sets WebAuthnPolicyUserVerificationRequirement
    /// </summary>
    [DataMember(Name = "webAuthnPolicyUserVerificationRequirement", EmitDefaultValue = false)]
    public string WebAuthnPolicyUserVerificationRequirement { get; set; }

    /// <summary>
    ///     Returns true if RealmRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of RealmRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(RealmRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                AccessCodeLifespan == input.AccessCodeLifespan ||
                (AccessCodeLifespan != null &&
                 AccessCodeLifespan.Equals(input.AccessCodeLifespan))
            ) &&
            (
                AccessCodeLifespanLogin == input.AccessCodeLifespanLogin ||
                (AccessCodeLifespanLogin != null &&
                 AccessCodeLifespanLogin.Equals(input.AccessCodeLifespanLogin))
            ) &&
            (
                AccessCodeLifespanUserAction == input.AccessCodeLifespanUserAction ||
                (AccessCodeLifespanUserAction != null &&
                 AccessCodeLifespanUserAction.Equals(input.AccessCodeLifespanUserAction))
            ) &&
            (
                AccessTokenLifespan == input.AccessTokenLifespan ||
                (AccessTokenLifespan != null &&
                 AccessTokenLifespan.Equals(input.AccessTokenLifespan))
            ) &&
            (
                AccessTokenLifespanForImplicitFlow == input.AccessTokenLifespanForImplicitFlow ||
                (AccessTokenLifespanForImplicitFlow != null &&
                 AccessTokenLifespanForImplicitFlow.Equals(input.AccessTokenLifespanForImplicitFlow))
            ) &&
            (
                AccountTheme == input.AccountTheme ||
                (AccountTheme != null &&
                 AccountTheme.Equals(input.AccountTheme))
            ) &&
            (
                ActionTokenGeneratedByAdminLifespan == input.ActionTokenGeneratedByAdminLifespan ||
                (ActionTokenGeneratedByAdminLifespan != null &&
                 ActionTokenGeneratedByAdminLifespan.Equals(input.ActionTokenGeneratedByAdminLifespan))
            ) &&
            (
                ActionTokenGeneratedByUserLifespan == input.ActionTokenGeneratedByUserLifespan ||
                (ActionTokenGeneratedByUserLifespan != null &&
                 ActionTokenGeneratedByUserLifespan.Equals(input.ActionTokenGeneratedByUserLifespan))
            ) &&
            (
                AdminEventsDetailsEnabled == input.AdminEventsDetailsEnabled ||
                (AdminEventsDetailsEnabled != null &&
                 AdminEventsDetailsEnabled.Equals(input.AdminEventsDetailsEnabled))
            ) &&
            (
                AdminEventsEnabled == input.AdminEventsEnabled ||
                (AdminEventsEnabled != null &&
                 AdminEventsEnabled.Equals(input.AdminEventsEnabled))
            ) &&
            (
                AdminTheme == input.AdminTheme ||
                (AdminTheme != null &&
                 AdminTheme.Equals(input.AdminTheme))
            ) &&
            (
                Attributes == input.Attributes ||
                (Attributes != null &&
                 input.Attributes != null &&
                 Attributes.SequenceEqual(input.Attributes))
            ) &&
            (
                AuthenticationFlows == input.AuthenticationFlows ||
                (AuthenticationFlows != null &&
                 input.AuthenticationFlows != null &&
                 AuthenticationFlows.SequenceEqual(input.AuthenticationFlows))
            ) &&
            (
                AuthenticatorConfig == input.AuthenticatorConfig ||
                (AuthenticatorConfig != null &&
                 input.AuthenticatorConfig != null &&
                 AuthenticatorConfig.SequenceEqual(input.AuthenticatorConfig))
            ) &&
            (
                BrowserFlow == input.BrowserFlow ||
                (BrowserFlow != null &&
                 BrowserFlow.Equals(input.BrowserFlow))
            ) &&
            (
                BrowserSecurityHeaders == input.BrowserSecurityHeaders ||
                (BrowserSecurityHeaders != null &&
                 input.BrowserSecurityHeaders != null &&
                 BrowserSecurityHeaders.SequenceEqual(input.BrowserSecurityHeaders))
            ) &&
            (
                BruteForceProtected == input.BruteForceProtected ||
                (BruteForceProtected != null &&
                 BruteForceProtected.Equals(input.BruteForceProtected))
            ) &&
            (
                ClientAuthenticationFlow == input.ClientAuthenticationFlow ||
                (ClientAuthenticationFlow != null &&
                 ClientAuthenticationFlow.Equals(input.ClientAuthenticationFlow))
            ) &&
            (
                ClientOfflineSessionIdleTimeout == input.ClientOfflineSessionIdleTimeout ||
                (ClientOfflineSessionIdleTimeout != null &&
                 ClientOfflineSessionIdleTimeout.Equals(input.ClientOfflineSessionIdleTimeout))
            ) &&
            (
                ClientOfflineSessionMaxLifespan == input.ClientOfflineSessionMaxLifespan ||
                (ClientOfflineSessionMaxLifespan != null &&
                 ClientOfflineSessionMaxLifespan.Equals(input.ClientOfflineSessionMaxLifespan))
            ) &&
            (
                ClientPolicies == input.ClientPolicies ||
                (ClientPolicies != null &&
                 ClientPolicies.Equals(input.ClientPolicies))
            ) &&
            (
                ClientProfiles == input.ClientProfiles ||
                (ClientProfiles != null &&
                 ClientProfiles.Equals(input.ClientProfiles))
            ) &&
            (
                ClientScopeMappings == input.ClientScopeMappings ||
                (ClientScopeMappings != null &&
                 input.ClientScopeMappings != null &&
                 ClientScopeMappings.SequenceEqual(input.ClientScopeMappings))
            ) &&
            (
                ClientScopes == input.ClientScopes ||
                (ClientScopes != null &&
                 input.ClientScopes != null &&
                 ClientScopes.SequenceEqual(input.ClientScopes))
            ) &&
            (
                ClientSessionIdleTimeout == input.ClientSessionIdleTimeout ||
                (ClientSessionIdleTimeout != null &&
                 ClientSessionIdleTimeout.Equals(input.ClientSessionIdleTimeout))
            ) &&
            (
                ClientSessionMaxLifespan == input.ClientSessionMaxLifespan ||
                (ClientSessionMaxLifespan != null &&
                 ClientSessionMaxLifespan.Equals(input.ClientSessionMaxLifespan))
            ) &&
            (
                Clients == input.Clients ||
                (Clients != null &&
                 input.Clients != null &&
                 Clients.SequenceEqual(input.Clients))
            ) &&
            (
                Components == input.Components ||
                (Components != null &&
                 Components.Equals(input.Components))
            ) &&
            (
                DefaultDefaultClientScopes == input.DefaultDefaultClientScopes ||
                (DefaultDefaultClientScopes != null &&
                 input.DefaultDefaultClientScopes != null &&
                 DefaultDefaultClientScopes.SequenceEqual(input.DefaultDefaultClientScopes))
            ) &&
            (
                DefaultGroups == input.DefaultGroups ||
                (DefaultGroups != null &&
                 input.DefaultGroups != null &&
                 DefaultGroups.SequenceEqual(input.DefaultGroups))
            ) &&
            (
                DefaultLocale == input.DefaultLocale ||
                (DefaultLocale != null &&
                 DefaultLocale.Equals(input.DefaultLocale))
            ) &&
            (
                DefaultOptionalClientScopes == input.DefaultOptionalClientScopes ||
                (DefaultOptionalClientScopes != null &&
                 input.DefaultOptionalClientScopes != null &&
                 DefaultOptionalClientScopes.SequenceEqual(input.DefaultOptionalClientScopes))
            ) &&
            (
                DefaultRole == input.DefaultRole ||
                (DefaultRole != null &&
                 DefaultRole.Equals(input.DefaultRole))
            ) &&
            (
                DefaultSignatureAlgorithm == input.DefaultSignatureAlgorithm ||
                (DefaultSignatureAlgorithm != null &&
                 DefaultSignatureAlgorithm.Equals(input.DefaultSignatureAlgorithm))
            ) &&
            (
                DirectGrantFlow == input.DirectGrantFlow ||
                (DirectGrantFlow != null &&
                 DirectGrantFlow.Equals(input.DirectGrantFlow))
            ) &&
            (
                DisplayName == input.DisplayName ||
                (DisplayName != null &&
                 DisplayName.Equals(input.DisplayName))
            ) &&
            (
                DisplayNameHtml == input.DisplayNameHtml ||
                (DisplayNameHtml != null &&
                 DisplayNameHtml.Equals(input.DisplayNameHtml))
            ) &&
            (
                DockerAuthenticationFlow == input.DockerAuthenticationFlow ||
                (DockerAuthenticationFlow != null &&
                 DockerAuthenticationFlow.Equals(input.DockerAuthenticationFlow))
            ) &&
            (
                DuplicateEmailsAllowed == input.DuplicateEmailsAllowed ||
                (DuplicateEmailsAllowed != null &&
                 DuplicateEmailsAllowed.Equals(input.DuplicateEmailsAllowed))
            ) &&
            (
                EditUsernameAllowed == input.EditUsernameAllowed ||
                (EditUsernameAllowed != null &&
                 EditUsernameAllowed.Equals(input.EditUsernameAllowed))
            ) &&
            (
                EmailTheme == input.EmailTheme ||
                (EmailTheme != null &&
                 EmailTheme.Equals(input.EmailTheme))
            ) &&
            (
                Enabled == input.Enabled ||
                (Enabled != null &&
                 Enabled.Equals(input.Enabled))
            ) &&
            (
                EnabledEventTypes == input.EnabledEventTypes ||
                (EnabledEventTypes != null &&
                 input.EnabledEventTypes != null &&
                 EnabledEventTypes.SequenceEqual(input.EnabledEventTypes))
            ) &&
            (
                EventsEnabled == input.EventsEnabled ||
                (EventsEnabled != null &&
                 EventsEnabled.Equals(input.EventsEnabled))
            ) &&
            (
                EventsExpiration == input.EventsExpiration ||
                (EventsExpiration != null &&
                 EventsExpiration.Equals(input.EventsExpiration))
            ) &&
            (
                EventsListeners == input.EventsListeners ||
                (EventsListeners != null &&
                 input.EventsListeners != null &&
                 EventsListeners.SequenceEqual(input.EventsListeners))
            ) &&
            (
                FailureFactor == input.FailureFactor ||
                (FailureFactor != null &&
                 FailureFactor.Equals(input.FailureFactor))
            ) &&
            (
                FederatedUsers == input.FederatedUsers ||
                (FederatedUsers != null &&
                 input.FederatedUsers != null &&
                 FederatedUsers.SequenceEqual(input.FederatedUsers))
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
                IdentityProviderMappers == input.IdentityProviderMappers ||
                (IdentityProviderMappers != null &&
                 input.IdentityProviderMappers != null &&
                 IdentityProviderMappers.SequenceEqual(input.IdentityProviderMappers))
            ) &&
            (
                IdentityProviders == input.IdentityProviders ||
                (IdentityProviders != null &&
                 input.IdentityProviders != null &&
                 IdentityProviders.SequenceEqual(input.IdentityProviders))
            ) &&
            (
                InternationalizationEnabled == input.InternationalizationEnabled ||
                (InternationalizationEnabled != null &&
                 InternationalizationEnabled.Equals(input.InternationalizationEnabled))
            ) &&
            (
                KeycloakVersion == input.KeycloakVersion ||
                (KeycloakVersion != null &&
                 KeycloakVersion.Equals(input.KeycloakVersion))
            ) &&
            (
                LoginTheme == input.LoginTheme ||
                (LoginTheme != null &&
                 LoginTheme.Equals(input.LoginTheme))
            ) &&
            (
                LoginWithEmailAllowed == input.LoginWithEmailAllowed ||
                (LoginWithEmailAllowed != null &&
                 LoginWithEmailAllowed.Equals(input.LoginWithEmailAllowed))
            ) &&
            (
                MaxDeltaTimeSeconds == input.MaxDeltaTimeSeconds ||
                (MaxDeltaTimeSeconds != null &&
                 MaxDeltaTimeSeconds.Equals(input.MaxDeltaTimeSeconds))
            ) &&
            (
                MaxFailureWaitSeconds == input.MaxFailureWaitSeconds ||
                (MaxFailureWaitSeconds != null &&
                 MaxFailureWaitSeconds.Equals(input.MaxFailureWaitSeconds))
            ) &&
            (
                MinimumQuickLoginWaitSeconds == input.MinimumQuickLoginWaitSeconds ||
                (MinimumQuickLoginWaitSeconds != null &&
                 MinimumQuickLoginWaitSeconds.Equals(input.MinimumQuickLoginWaitSeconds))
            ) &&
            (
                NotBefore == input.NotBefore ||
                (NotBefore != null &&
                 NotBefore.Equals(input.NotBefore))
            ) &&
            (
                OAuth2DeviceCodeLifespan == input.OAuth2DeviceCodeLifespan ||
                (OAuth2DeviceCodeLifespan != null &&
                 OAuth2DeviceCodeLifespan.Equals(input.OAuth2DeviceCodeLifespan))
            ) &&
            (
                OAuth2DevicePollingInterval == input.OAuth2DevicePollingInterval ||
                (OAuth2DevicePollingInterval != null &&
                 OAuth2DevicePollingInterval.Equals(input.OAuth2DevicePollingInterval))
            ) &&
            (
                Oauth2DeviceCodeLifespan == input.Oauth2DeviceCodeLifespan ||
                (Oauth2DeviceCodeLifespan != null &&
                 Oauth2DeviceCodeLifespan.Equals(input.Oauth2DeviceCodeLifespan))
            ) &&
            (
                Oauth2DevicePollingInterval == input.Oauth2DevicePollingInterval ||
                (Oauth2DevicePollingInterval != null &&
                 Oauth2DevicePollingInterval.Equals(input.Oauth2DevicePollingInterval))
            ) &&
            (
                OfflineSessionIdleTimeout == input.OfflineSessionIdleTimeout ||
                (OfflineSessionIdleTimeout != null &&
                 OfflineSessionIdleTimeout.Equals(input.OfflineSessionIdleTimeout))
            ) &&
            (
                OfflineSessionMaxLifespan == input.OfflineSessionMaxLifespan ||
                (OfflineSessionMaxLifespan != null &&
                 OfflineSessionMaxLifespan.Equals(input.OfflineSessionMaxLifespan))
            ) &&
            (
                OfflineSessionMaxLifespanEnabled == input.OfflineSessionMaxLifespanEnabled ||
                (OfflineSessionMaxLifespanEnabled != null &&
                 OfflineSessionMaxLifespanEnabled.Equals(input.OfflineSessionMaxLifespanEnabled))
            ) &&
            (
                OtpPolicyAlgorithm == input.OtpPolicyAlgorithm ||
                (OtpPolicyAlgorithm != null &&
                 OtpPolicyAlgorithm.Equals(input.OtpPolicyAlgorithm))
            ) &&
            (
                OtpPolicyDigits == input.OtpPolicyDigits ||
                (OtpPolicyDigits != null &&
                 OtpPolicyDigits.Equals(input.OtpPolicyDigits))
            ) &&
            (
                OtpPolicyInitialCounter == input.OtpPolicyInitialCounter ||
                (OtpPolicyInitialCounter != null &&
                 OtpPolicyInitialCounter.Equals(input.OtpPolicyInitialCounter))
            ) &&
            (
                OtpPolicyLookAheadWindow == input.OtpPolicyLookAheadWindow ||
                (OtpPolicyLookAheadWindow != null &&
                 OtpPolicyLookAheadWindow.Equals(input.OtpPolicyLookAheadWindow))
            ) &&
            (
                OtpPolicyPeriod == input.OtpPolicyPeriod ||
                (OtpPolicyPeriod != null &&
                 OtpPolicyPeriod.Equals(input.OtpPolicyPeriod))
            ) &&
            (
                OtpPolicyType == input.OtpPolicyType ||
                (OtpPolicyType != null &&
                 OtpPolicyType.Equals(input.OtpPolicyType))
            ) &&
            (
                OtpSupportedApplications == input.OtpSupportedApplications ||
                (OtpSupportedApplications != null &&
                 input.OtpSupportedApplications != null &&
                 OtpSupportedApplications.SequenceEqual(input.OtpSupportedApplications))
            ) &&
            (
                PasswordPolicy == input.PasswordPolicy ||
                (PasswordPolicy != null &&
                 PasswordPolicy.Equals(input.PasswordPolicy))
            ) &&
            (
                PermanentLockout == input.PermanentLockout ||
                (PermanentLockout != null &&
                 PermanentLockout.Equals(input.PermanentLockout))
            ) &&
            (
                ProtocolMappers == input.ProtocolMappers ||
                (ProtocolMappers != null &&
                 input.ProtocolMappers != null &&
                 ProtocolMappers.SequenceEqual(input.ProtocolMappers))
            ) &&
            (
                QuickLoginCheckMilliSeconds == input.QuickLoginCheckMilliSeconds ||
                (QuickLoginCheckMilliSeconds != null &&
                 QuickLoginCheckMilliSeconds.Equals(input.QuickLoginCheckMilliSeconds))
            ) &&
            (
                Realm == input.Realm ||
                (Realm != null &&
                 Realm.Equals(input.Realm))
            ) &&
            (
                RefreshTokenMaxReuse == input.RefreshTokenMaxReuse ||
                (RefreshTokenMaxReuse != null &&
                 RefreshTokenMaxReuse.Equals(input.RefreshTokenMaxReuse))
            ) &&
            (
                RegistrationAllowed == input.RegistrationAllowed ||
                (RegistrationAllowed != null &&
                 RegistrationAllowed.Equals(input.RegistrationAllowed))
            ) &&
            (
                RegistrationEmailAsUsername == input.RegistrationEmailAsUsername ||
                (RegistrationEmailAsUsername != null &&
                 RegistrationEmailAsUsername.Equals(input.RegistrationEmailAsUsername))
            ) &&
            (
                RegistrationFlow == input.RegistrationFlow ||
                (RegistrationFlow != null &&
                 RegistrationFlow.Equals(input.RegistrationFlow))
            ) &&
            (
                RememberMe == input.RememberMe ||
                (RememberMe != null &&
                 RememberMe.Equals(input.RememberMe))
            ) &&
            (
                RequiredActions == input.RequiredActions ||
                (RequiredActions != null &&
                 input.RequiredActions != null &&
                 RequiredActions.SequenceEqual(input.RequiredActions))
            ) &&
            (
                ResetCredentialsFlow == input.ResetCredentialsFlow ||
                (ResetCredentialsFlow != null &&
                 ResetCredentialsFlow.Equals(input.ResetCredentialsFlow))
            ) &&
            (
                ResetPasswordAllowed == input.ResetPasswordAllowed ||
                (ResetPasswordAllowed != null &&
                 ResetPasswordAllowed.Equals(input.ResetPasswordAllowed))
            ) &&
            (
                RevokeRefreshToken == input.RevokeRefreshToken ||
                (RevokeRefreshToken != null &&
                 RevokeRefreshToken.Equals(input.RevokeRefreshToken))
            ) &&
            (
                Roles == input.Roles ||
                (Roles != null &&
                 Roles.Equals(input.Roles))
            ) &&
            (
                ScopeMappings == input.ScopeMappings ||
                (ScopeMappings != null &&
                 input.ScopeMappings != null &&
                 ScopeMappings.SequenceEqual(input.ScopeMappings))
            ) &&
            (
                SmtpServer == input.SmtpServer ||
                (SmtpServer != null &&
                 input.SmtpServer != null &&
                 SmtpServer.SequenceEqual(input.SmtpServer))
            ) &&
            (
                SslRequired == input.SslRequired ||
                (SslRequired != null &&
                 SslRequired.Equals(input.SslRequired))
            ) &&
            (
                SsoSessionIdleTimeout == input.SsoSessionIdleTimeout ||
                (SsoSessionIdleTimeout != null &&
                 SsoSessionIdleTimeout.Equals(input.SsoSessionIdleTimeout))
            ) &&
            (
                SsoSessionIdleTimeoutRememberMe == input.SsoSessionIdleTimeoutRememberMe ||
                (SsoSessionIdleTimeoutRememberMe != null &&
                 SsoSessionIdleTimeoutRememberMe.Equals(input.SsoSessionIdleTimeoutRememberMe))
            ) &&
            (
                SsoSessionMaxLifespan == input.SsoSessionMaxLifespan ||
                (SsoSessionMaxLifespan != null &&
                 SsoSessionMaxLifespan.Equals(input.SsoSessionMaxLifespan))
            ) &&
            (
                SsoSessionMaxLifespanRememberMe == input.SsoSessionMaxLifespanRememberMe ||
                (SsoSessionMaxLifespanRememberMe != null &&
                 SsoSessionMaxLifespanRememberMe.Equals(input.SsoSessionMaxLifespanRememberMe))
            ) &&
            (
                SupportedLocales == input.SupportedLocales ||
                (SupportedLocales != null &&
                 input.SupportedLocales != null &&
                 SupportedLocales.SequenceEqual(input.SupportedLocales))
            ) &&
            (
                UserFederationMappers == input.UserFederationMappers ||
                (UserFederationMappers != null &&
                 input.UserFederationMappers != null &&
                 UserFederationMappers.SequenceEqual(input.UserFederationMappers))
            ) &&
            (
                UserFederationProviders == input.UserFederationProviders ||
                (UserFederationProviders != null &&
                 input.UserFederationProviders != null &&
                 UserFederationProviders.SequenceEqual(input.UserFederationProviders))
            ) &&
            (
                UserManagedAccessAllowed == input.UserManagedAccessAllowed ||
                (UserManagedAccessAllowed != null &&
                 UserManagedAccessAllowed.Equals(input.UserManagedAccessAllowed))
            ) &&
            (
                Users == input.Users ||
                (Users != null &&
                 input.Users != null &&
                 Users.SequenceEqual(input.Users))
            ) &&
            (
                VerifyEmail == input.VerifyEmail ||
                (VerifyEmail != null &&
                 VerifyEmail.Equals(input.VerifyEmail))
            ) &&
            (
                WaitIncrementSeconds == input.WaitIncrementSeconds ||
                (WaitIncrementSeconds != null &&
                 WaitIncrementSeconds.Equals(input.WaitIncrementSeconds))
            ) &&
            (
                WebAuthnPolicyAcceptableAaguids == input.WebAuthnPolicyAcceptableAaguids ||
                (WebAuthnPolicyAcceptableAaguids != null &&
                 input.WebAuthnPolicyAcceptableAaguids != null &&
                 WebAuthnPolicyAcceptableAaguids.SequenceEqual(input.WebAuthnPolicyAcceptableAaguids))
            ) &&
            (
                WebAuthnPolicyAttestationConveyancePreference == input.WebAuthnPolicyAttestationConveyancePreference ||
                (WebAuthnPolicyAttestationConveyancePreference != null &&
                 WebAuthnPolicyAttestationConveyancePreference.Equals(input
                     .WebAuthnPolicyAttestationConveyancePreference))
            ) &&
            (
                WebAuthnPolicyAuthenticatorAttachment == input.WebAuthnPolicyAuthenticatorAttachment ||
                (WebAuthnPolicyAuthenticatorAttachment != null &&
                 WebAuthnPolicyAuthenticatorAttachment.Equals(input.WebAuthnPolicyAuthenticatorAttachment))
            ) &&
            (
                WebAuthnPolicyAvoidSameAuthenticatorRegister == input.WebAuthnPolicyAvoidSameAuthenticatorRegister ||
                (WebAuthnPolicyAvoidSameAuthenticatorRegister != null &&
                 WebAuthnPolicyAvoidSameAuthenticatorRegister.Equals(input
                     .WebAuthnPolicyAvoidSameAuthenticatorRegister))
            ) &&
            (
                WebAuthnPolicyCreateTimeout == input.WebAuthnPolicyCreateTimeout ||
                (WebAuthnPolicyCreateTimeout != null &&
                 WebAuthnPolicyCreateTimeout.Equals(input.WebAuthnPolicyCreateTimeout))
            ) &&
            (
                WebAuthnPolicyPasswordlessAcceptableAaguids == input.WebAuthnPolicyPasswordlessAcceptableAaguids ||
                (WebAuthnPolicyPasswordlessAcceptableAaguids != null &&
                 input.WebAuthnPolicyPasswordlessAcceptableAaguids != null &&
                 WebAuthnPolicyPasswordlessAcceptableAaguids.SequenceEqual(input
                     .WebAuthnPolicyPasswordlessAcceptableAaguids))
            ) &&
            (
                WebAuthnPolicyPasswordlessAttestationConveyancePreference ==
                input.WebAuthnPolicyPasswordlessAttestationConveyancePreference ||
                (WebAuthnPolicyPasswordlessAttestationConveyancePreference != null &&
                 WebAuthnPolicyPasswordlessAttestationConveyancePreference.Equals(input
                     .WebAuthnPolicyPasswordlessAttestationConveyancePreference))
            ) &&
            (
                WebAuthnPolicyPasswordlessAuthenticatorAttachment ==
                input.WebAuthnPolicyPasswordlessAuthenticatorAttachment ||
                (WebAuthnPolicyPasswordlessAuthenticatorAttachment != null &&
                 WebAuthnPolicyPasswordlessAuthenticatorAttachment.Equals(input
                     .WebAuthnPolicyPasswordlessAuthenticatorAttachment))
            ) &&
            (
                WebAuthnPolicyPasswordlessAvoidSameAuthenticatorRegister ==
                input.WebAuthnPolicyPasswordlessAvoidSameAuthenticatorRegister ||
                (WebAuthnPolicyPasswordlessAvoidSameAuthenticatorRegister != null &&
                 WebAuthnPolicyPasswordlessAvoidSameAuthenticatorRegister.Equals(input
                     .WebAuthnPolicyPasswordlessAvoidSameAuthenticatorRegister))
            ) &&
            (
                WebAuthnPolicyPasswordlessCreateTimeout == input.WebAuthnPolicyPasswordlessCreateTimeout ||
                (WebAuthnPolicyPasswordlessCreateTimeout != null &&
                 WebAuthnPolicyPasswordlessCreateTimeout.Equals(input.WebAuthnPolicyPasswordlessCreateTimeout))
            ) &&
            (
                WebAuthnPolicyPasswordlessRequireResidentKey == input.WebAuthnPolicyPasswordlessRequireResidentKey ||
                (WebAuthnPolicyPasswordlessRequireResidentKey != null &&
                 WebAuthnPolicyPasswordlessRequireResidentKey.Equals(input
                     .WebAuthnPolicyPasswordlessRequireResidentKey))
            ) &&
            (
                WebAuthnPolicyPasswordlessRpEntityName == input.WebAuthnPolicyPasswordlessRpEntityName ||
                (WebAuthnPolicyPasswordlessRpEntityName != null &&
                 WebAuthnPolicyPasswordlessRpEntityName.Equals(input.WebAuthnPolicyPasswordlessRpEntityName))
            ) &&
            (
                WebAuthnPolicyPasswordlessRpId == input.WebAuthnPolicyPasswordlessRpId ||
                (WebAuthnPolicyPasswordlessRpId != null &&
                 WebAuthnPolicyPasswordlessRpId.Equals(input.WebAuthnPolicyPasswordlessRpId))
            ) &&
            (
                WebAuthnPolicyPasswordlessSignatureAlgorithms == input.WebAuthnPolicyPasswordlessSignatureAlgorithms ||
                (WebAuthnPolicyPasswordlessSignatureAlgorithms != null &&
                 input.WebAuthnPolicyPasswordlessSignatureAlgorithms != null &&
                 WebAuthnPolicyPasswordlessSignatureAlgorithms.SequenceEqual(input
                     .WebAuthnPolicyPasswordlessSignatureAlgorithms))
            ) &&
            (
                WebAuthnPolicyPasswordlessUserVerificationRequirement ==
                input.WebAuthnPolicyPasswordlessUserVerificationRequirement ||
                (WebAuthnPolicyPasswordlessUserVerificationRequirement != null &&
                 WebAuthnPolicyPasswordlessUserVerificationRequirement.Equals(input
                     .WebAuthnPolicyPasswordlessUserVerificationRequirement))
            ) &&
            (
                WebAuthnPolicyRequireResidentKey == input.WebAuthnPolicyRequireResidentKey ||
                (WebAuthnPolicyRequireResidentKey != null &&
                 WebAuthnPolicyRequireResidentKey.Equals(input.WebAuthnPolicyRequireResidentKey))
            ) &&
            (
                WebAuthnPolicyRpEntityName == input.WebAuthnPolicyRpEntityName ||
                (WebAuthnPolicyRpEntityName != null &&
                 WebAuthnPolicyRpEntityName.Equals(input.WebAuthnPolicyRpEntityName))
            ) &&
            (
                WebAuthnPolicyRpId == input.WebAuthnPolicyRpId ||
                (WebAuthnPolicyRpId != null &&
                 WebAuthnPolicyRpId.Equals(input.WebAuthnPolicyRpId))
            ) &&
            (
                WebAuthnPolicySignatureAlgorithms == input.WebAuthnPolicySignatureAlgorithms ||
                (WebAuthnPolicySignatureAlgorithms != null &&
                 input.WebAuthnPolicySignatureAlgorithms != null &&
                 WebAuthnPolicySignatureAlgorithms.SequenceEqual(input.WebAuthnPolicySignatureAlgorithms))
            ) &&
            (
                WebAuthnPolicyUserVerificationRequirement == input.WebAuthnPolicyUserVerificationRequirement ||
                (WebAuthnPolicyUserVerificationRequirement != null &&
                 WebAuthnPolicyUserVerificationRequirement.Equals(input.WebAuthnPolicyUserVerificationRequirement))
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
        sb.Append("class RealmRepresentation {\n");
        sb.Append("  AccessCodeLifespan: ").Append(AccessCodeLifespan).Append("\n");
        sb.Append("  AccessCodeLifespanLogin: ").Append(AccessCodeLifespanLogin).Append("\n");
        sb.Append("  AccessCodeLifespanUserAction: ").Append(AccessCodeLifespanUserAction).Append("\n");
        sb.Append("  AccessTokenLifespan: ").Append(AccessTokenLifespan).Append("\n");
        sb.Append("  AccessTokenLifespanForImplicitFlow: ").Append(AccessTokenLifespanForImplicitFlow).Append("\n");
        sb.Append("  AccountTheme: ").Append(AccountTheme).Append("\n");
        sb.Append("  ActionTokenGeneratedByAdminLifespan: ").Append(ActionTokenGeneratedByAdminLifespan).Append("\n");
        sb.Append("  ActionTokenGeneratedByUserLifespan: ").Append(ActionTokenGeneratedByUserLifespan).Append("\n");
        sb.Append("  AdminEventsDetailsEnabled: ").Append(AdminEventsDetailsEnabled).Append("\n");
        sb.Append("  AdminEventsEnabled: ").Append(AdminEventsEnabled).Append("\n");
        sb.Append("  AdminTheme: ").Append(AdminTheme).Append("\n");
        sb.Append("  Attributes: ").Append(Attributes).Append("\n");
        sb.Append("  AuthenticationFlows: ").Append(AuthenticationFlows).Append("\n");
        sb.Append("  AuthenticatorConfig: ").Append(AuthenticatorConfig).Append("\n");
        sb.Append("  BrowserFlow: ").Append(BrowserFlow).Append("\n");
        sb.Append("  BrowserSecurityHeaders: ").Append(BrowserSecurityHeaders).Append("\n");
        sb.Append("  BruteForceProtected: ").Append(BruteForceProtected).Append("\n");
        sb.Append("  ClientAuthenticationFlow: ").Append(ClientAuthenticationFlow).Append("\n");
        sb.Append("  ClientOfflineSessionIdleTimeout: ").Append(ClientOfflineSessionIdleTimeout).Append("\n");
        sb.Append("  ClientOfflineSessionMaxLifespan: ").Append(ClientOfflineSessionMaxLifespan).Append("\n");
        sb.Append("  ClientPolicies: ").Append(ClientPolicies).Append("\n");
        sb.Append("  ClientProfiles: ").Append(ClientProfiles).Append("\n");
        sb.Append("  ClientScopeMappings: ").Append(ClientScopeMappings).Append("\n");
        sb.Append("  ClientScopes: ").Append(ClientScopes).Append("\n");
        sb.Append("  ClientSessionIdleTimeout: ").Append(ClientSessionIdleTimeout).Append("\n");
        sb.Append("  ClientSessionMaxLifespan: ").Append(ClientSessionMaxLifespan).Append("\n");
        sb.Append("  Clients: ").Append(Clients).Append("\n");
        sb.Append("  Components: ").Append(Components).Append("\n");
        sb.Append("  DefaultDefaultClientScopes: ").Append(DefaultDefaultClientScopes).Append("\n");
        sb.Append("  DefaultGroups: ").Append(DefaultGroups).Append("\n");
        sb.Append("  DefaultLocale: ").Append(DefaultLocale).Append("\n");
        sb.Append("  DefaultOptionalClientScopes: ").Append(DefaultOptionalClientScopes).Append("\n");
        sb.Append("  DefaultRole: ").Append(DefaultRole).Append("\n");
        sb.Append("  DefaultSignatureAlgorithm: ").Append(DefaultSignatureAlgorithm).Append("\n");
        sb.Append("  DirectGrantFlow: ").Append(DirectGrantFlow).Append("\n");
        sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
        sb.Append("  DisplayNameHtml: ").Append(DisplayNameHtml).Append("\n");
        sb.Append("  DockerAuthenticationFlow: ").Append(DockerAuthenticationFlow).Append("\n");
        sb.Append("  DuplicateEmailsAllowed: ").Append(DuplicateEmailsAllowed).Append("\n");
        sb.Append("  EditUsernameAllowed: ").Append(EditUsernameAllowed).Append("\n");
        sb.Append("  EmailTheme: ").Append(EmailTheme).Append("\n");
        sb.Append("  Enabled: ").Append(Enabled).Append("\n");
        sb.Append("  EnabledEventTypes: ").Append(EnabledEventTypes).Append("\n");
        sb.Append("  EventsEnabled: ").Append(EventsEnabled).Append("\n");
        sb.Append("  EventsExpiration: ").Append(EventsExpiration).Append("\n");
        sb.Append("  EventsListeners: ").Append(EventsListeners).Append("\n");
        sb.Append("  FailureFactor: ").Append(FailureFactor).Append("\n");
        sb.Append("  FederatedUsers: ").Append(FederatedUsers).Append("\n");
        sb.Append("  Groups: ").Append(Groups).Append("\n");
        sb.Append("  Id: ").Append(Id).Append("\n");
        sb.Append("  IdentityProviderMappers: ").Append(IdentityProviderMappers).Append("\n");
        sb.Append("  IdentityProviders: ").Append(IdentityProviders).Append("\n");
        sb.Append("  InternationalizationEnabled: ").Append(InternationalizationEnabled).Append("\n");
        sb.Append("  KeycloakVersion: ").Append(KeycloakVersion).Append("\n");
        sb.Append("  LoginTheme: ").Append(LoginTheme).Append("\n");
        sb.Append("  LoginWithEmailAllowed: ").Append(LoginWithEmailAllowed).Append("\n");
        sb.Append("  MaxDeltaTimeSeconds: ").Append(MaxDeltaTimeSeconds).Append("\n");
        sb.Append("  MaxFailureWaitSeconds: ").Append(MaxFailureWaitSeconds).Append("\n");
        sb.Append("  MinimumQuickLoginWaitSeconds: ").Append(MinimumQuickLoginWaitSeconds).Append("\n");
        sb.Append("  NotBefore: ").Append(NotBefore).Append("\n");
        sb.Append("  OAuth2DeviceCodeLifespan: ").Append(OAuth2DeviceCodeLifespan).Append("\n");
        sb.Append("  OAuth2DevicePollingInterval: ").Append(OAuth2DevicePollingInterval).Append("\n");
        sb.Append("  Oauth2DeviceCodeLifespan: ").Append(Oauth2DeviceCodeLifespan).Append("\n");
        sb.Append("  Oauth2DevicePollingInterval: ").Append(Oauth2DevicePollingInterval).Append("\n");
        sb.Append("  OfflineSessionIdleTimeout: ").Append(OfflineSessionIdleTimeout).Append("\n");
        sb.Append("  OfflineSessionMaxLifespan: ").Append(OfflineSessionMaxLifespan).Append("\n");
        sb.Append("  OfflineSessionMaxLifespanEnabled: ").Append(OfflineSessionMaxLifespanEnabled).Append("\n");
        sb.Append("  OtpPolicyAlgorithm: ").Append(OtpPolicyAlgorithm).Append("\n");
        sb.Append("  OtpPolicyDigits: ").Append(OtpPolicyDigits).Append("\n");
        sb.Append("  OtpPolicyInitialCounter: ").Append(OtpPolicyInitialCounter).Append("\n");
        sb.Append("  OtpPolicyLookAheadWindow: ").Append(OtpPolicyLookAheadWindow).Append("\n");
        sb.Append("  OtpPolicyPeriod: ").Append(OtpPolicyPeriod).Append("\n");
        sb.Append("  OtpPolicyType: ").Append(OtpPolicyType).Append("\n");
        sb.Append("  OtpSupportedApplications: ").Append(OtpSupportedApplications).Append("\n");
        sb.Append("  PasswordPolicy: ").Append(PasswordPolicy).Append("\n");
        sb.Append("  PermanentLockout: ").Append(PermanentLockout).Append("\n");
        sb.Append("  ProtocolMappers: ").Append(ProtocolMappers).Append("\n");
        sb.Append("  QuickLoginCheckMilliSeconds: ").Append(QuickLoginCheckMilliSeconds).Append("\n");
        sb.Append("  Realm: ").Append(Realm).Append("\n");
        sb.Append("  RefreshTokenMaxReuse: ").Append(RefreshTokenMaxReuse).Append("\n");
        sb.Append("  RegistrationAllowed: ").Append(RegistrationAllowed).Append("\n");
        sb.Append("  RegistrationEmailAsUsername: ").Append(RegistrationEmailAsUsername).Append("\n");
        sb.Append("  RegistrationFlow: ").Append(RegistrationFlow).Append("\n");
        sb.Append("  RememberMe: ").Append(RememberMe).Append("\n");
        sb.Append("  RequiredActions: ").Append(RequiredActions).Append("\n");
        sb.Append("  ResetCredentialsFlow: ").Append(ResetCredentialsFlow).Append("\n");
        sb.Append("  ResetPasswordAllowed: ").Append(ResetPasswordAllowed).Append("\n");
        sb.Append("  RevokeRefreshToken: ").Append(RevokeRefreshToken).Append("\n");
        sb.Append("  Roles: ").Append(Roles).Append("\n");
        sb.Append("  ScopeMappings: ").Append(ScopeMappings).Append("\n");
        sb.Append("  SmtpServer: ").Append(SmtpServer).Append("\n");
        sb.Append("  SslRequired: ").Append(SslRequired).Append("\n");
        sb.Append("  SsoSessionIdleTimeout: ").Append(SsoSessionIdleTimeout).Append("\n");
        sb.Append("  SsoSessionIdleTimeoutRememberMe: ").Append(SsoSessionIdleTimeoutRememberMe).Append("\n");
        sb.Append("  SsoSessionMaxLifespan: ").Append(SsoSessionMaxLifespan).Append("\n");
        sb.Append("  SsoSessionMaxLifespanRememberMe: ").Append(SsoSessionMaxLifespanRememberMe).Append("\n");
        sb.Append("  SupportedLocales: ").Append(SupportedLocales).Append("\n");
        sb.Append("  UserFederationMappers: ").Append(UserFederationMappers).Append("\n");
        sb.Append("  UserFederationProviders: ").Append(UserFederationProviders).Append("\n");
        sb.Append("  UserManagedAccessAllowed: ").Append(UserManagedAccessAllowed).Append("\n");
        sb.Append("  Users: ").Append(Users).Append("\n");
        sb.Append("  VerifyEmail: ").Append(VerifyEmail).Append("\n");
        sb.Append("  WaitIncrementSeconds: ").Append(WaitIncrementSeconds).Append("\n");
        sb.Append("  WebAuthnPolicyAcceptableAaguids: ").Append(WebAuthnPolicyAcceptableAaguids).Append("\n");
        sb.Append("  WebAuthnPolicyAttestationConveyancePreference: ")
            .Append(WebAuthnPolicyAttestationConveyancePreference).Append("\n");
        sb.Append("  WebAuthnPolicyAuthenticatorAttachment: ").Append(WebAuthnPolicyAuthenticatorAttachment)
            .Append("\n");
        sb.Append("  WebAuthnPolicyAvoidSameAuthenticatorRegister: ")
            .Append(WebAuthnPolicyAvoidSameAuthenticatorRegister).Append("\n");
        sb.Append("  WebAuthnPolicyCreateTimeout: ").Append(WebAuthnPolicyCreateTimeout).Append("\n");
        sb.Append("  WebAuthnPolicyPasswordlessAcceptableAaguids: ").Append(WebAuthnPolicyPasswordlessAcceptableAaguids)
            .Append("\n");
        sb.Append("  WebAuthnPolicyPasswordlessAttestationConveyancePreference: ")
            .Append(WebAuthnPolicyPasswordlessAttestationConveyancePreference).Append("\n");
        sb.Append("  WebAuthnPolicyPasswordlessAuthenticatorAttachment: ")
            .Append(WebAuthnPolicyPasswordlessAuthenticatorAttachment).Append("\n");
        sb.Append("  WebAuthnPolicyPasswordlessAvoidSameAuthenticatorRegister: ")
            .Append(WebAuthnPolicyPasswordlessAvoidSameAuthenticatorRegister).Append("\n");
        sb.Append("  WebAuthnPolicyPasswordlessCreateTimeout: ").Append(WebAuthnPolicyPasswordlessCreateTimeout)
            .Append("\n");
        sb.Append("  WebAuthnPolicyPasswordlessRequireResidentKey: ")
            .Append(WebAuthnPolicyPasswordlessRequireResidentKey).Append("\n");
        sb.Append("  WebAuthnPolicyPasswordlessRpEntityName: ").Append(WebAuthnPolicyPasswordlessRpEntityName)
            .Append("\n");
        sb.Append("  WebAuthnPolicyPasswordlessRpId: ").Append(WebAuthnPolicyPasswordlessRpId).Append("\n");
        sb.Append("  WebAuthnPolicyPasswordlessSignatureAlgorithms: ")
            .Append(WebAuthnPolicyPasswordlessSignatureAlgorithms).Append("\n");
        sb.Append("  WebAuthnPolicyPasswordlessUserVerificationRequirement: ")
            .Append(WebAuthnPolicyPasswordlessUserVerificationRequirement).Append("\n");
        sb.Append("  WebAuthnPolicyRequireResidentKey: ").Append(WebAuthnPolicyRequireResidentKey).Append("\n");
        sb.Append("  WebAuthnPolicyRpEntityName: ").Append(WebAuthnPolicyRpEntityName).Append("\n");
        sb.Append("  WebAuthnPolicyRpId: ").Append(WebAuthnPolicyRpId).Append("\n");
        sb.Append("  WebAuthnPolicySignatureAlgorithms: ").Append(WebAuthnPolicySignatureAlgorithms).Append("\n");
        sb.Append("  WebAuthnPolicyUserVerificationRequirement: ").Append(WebAuthnPolicyUserVerificationRequirement)
            .Append("\n");
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
        return Equals(input as RealmRepresentation);
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
            if (AccessCodeLifespan != null)
                hashCode = hashCode * 59 + AccessCodeLifespan.GetHashCode();
            if (AccessCodeLifespanLogin != null)
                hashCode = hashCode * 59 + AccessCodeLifespanLogin.GetHashCode();
            if (AccessCodeLifespanUserAction != null)
                hashCode = hashCode * 59 + AccessCodeLifespanUserAction.GetHashCode();
            if (AccessTokenLifespan != null)
                hashCode = hashCode * 59 + AccessTokenLifespan.GetHashCode();
            if (AccessTokenLifespanForImplicitFlow != null)
                hashCode = hashCode * 59 + AccessTokenLifespanForImplicitFlow.GetHashCode();
            if (AccountTheme != null)
                hashCode = hashCode * 59 + AccountTheme.GetHashCode();
            if (ActionTokenGeneratedByAdminLifespan != null)
                hashCode = hashCode * 59 + ActionTokenGeneratedByAdminLifespan.GetHashCode();
            if (ActionTokenGeneratedByUserLifespan != null)
                hashCode = hashCode * 59 + ActionTokenGeneratedByUserLifespan.GetHashCode();
            if (AdminEventsDetailsEnabled != null)
                hashCode = hashCode * 59 + AdminEventsDetailsEnabled.GetHashCode();
            if (AdminEventsEnabled != null)
                hashCode = hashCode * 59 + AdminEventsEnabled.GetHashCode();
            if (AdminTheme != null)
                hashCode = hashCode * 59 + AdminTheme.GetHashCode();
            if (Attributes != null)
                hashCode = hashCode * 59 + Attributes.GetHashCode();
            if (AuthenticationFlows != null)
                hashCode = hashCode * 59 + AuthenticationFlows.GetHashCode();
            if (AuthenticatorConfig != null)
                hashCode = hashCode * 59 + AuthenticatorConfig.GetHashCode();
            if (BrowserFlow != null)
                hashCode = hashCode * 59 + BrowserFlow.GetHashCode();
            if (BrowserSecurityHeaders != null)
                hashCode = hashCode * 59 + BrowserSecurityHeaders.GetHashCode();
            if (BruteForceProtected != null)
                hashCode = hashCode * 59 + BruteForceProtected.GetHashCode();
            if (ClientAuthenticationFlow != null)
                hashCode = hashCode * 59 + ClientAuthenticationFlow.GetHashCode();
            if (ClientOfflineSessionIdleTimeout != null)
                hashCode = hashCode * 59 + ClientOfflineSessionIdleTimeout.GetHashCode();
            if (ClientOfflineSessionMaxLifespan != null)
                hashCode = hashCode * 59 + ClientOfflineSessionMaxLifespan.GetHashCode();
            if (ClientPolicies != null)
                hashCode = hashCode * 59 + ClientPolicies.GetHashCode();
            if (ClientProfiles != null)
                hashCode = hashCode * 59 + ClientProfiles.GetHashCode();
            if (ClientScopeMappings != null)
                hashCode = hashCode * 59 + ClientScopeMappings.GetHashCode();
            if (ClientScopes != null)
                hashCode = hashCode * 59 + ClientScopes.GetHashCode();
            if (ClientSessionIdleTimeout != null)
                hashCode = hashCode * 59 + ClientSessionIdleTimeout.GetHashCode();
            if (ClientSessionMaxLifespan != null)
                hashCode = hashCode * 59 + ClientSessionMaxLifespan.GetHashCode();
            if (Clients != null)
                hashCode = hashCode * 59 + Clients.GetHashCode();
            if (Components != null)
                hashCode = hashCode * 59 + Components.GetHashCode();
            if (DefaultDefaultClientScopes != null)
                hashCode = hashCode * 59 + DefaultDefaultClientScopes.GetHashCode();
            if (DefaultGroups != null)
                hashCode = hashCode * 59 + DefaultGroups.GetHashCode();
            if (DefaultLocale != null)
                hashCode = hashCode * 59 + DefaultLocale.GetHashCode();
            if (DefaultOptionalClientScopes != null)
                hashCode = hashCode * 59 + DefaultOptionalClientScopes.GetHashCode();
            if (DefaultRole != null)
                hashCode = hashCode * 59 + DefaultRole.GetHashCode();
            if (DefaultSignatureAlgorithm != null)
                hashCode = hashCode * 59 + DefaultSignatureAlgorithm.GetHashCode();
            if (DirectGrantFlow != null)
                hashCode = hashCode * 59 + DirectGrantFlow.GetHashCode();
            if (DisplayName != null)
                hashCode = hashCode * 59 + DisplayName.GetHashCode();
            if (DisplayNameHtml != null)
                hashCode = hashCode * 59 + DisplayNameHtml.GetHashCode();
            if (DockerAuthenticationFlow != null)
                hashCode = hashCode * 59 + DockerAuthenticationFlow.GetHashCode();
            if (DuplicateEmailsAllowed != null)
                hashCode = hashCode * 59 + DuplicateEmailsAllowed.GetHashCode();
            if (EditUsernameAllowed != null)
                hashCode = hashCode * 59 + EditUsernameAllowed.GetHashCode();
            if (EmailTheme != null)
                hashCode = hashCode * 59 + EmailTheme.GetHashCode();
            if (Enabled != null)
                hashCode = hashCode * 59 + Enabled.GetHashCode();
            if (EnabledEventTypes != null)
                hashCode = hashCode * 59 + EnabledEventTypes.GetHashCode();
            if (EventsEnabled != null)
                hashCode = hashCode * 59 + EventsEnabled.GetHashCode();
            if (EventsExpiration != null)
                hashCode = hashCode * 59 + EventsExpiration.GetHashCode();
            if (EventsListeners != null)
                hashCode = hashCode * 59 + EventsListeners.GetHashCode();
            if (FailureFactor != null)
                hashCode = hashCode * 59 + FailureFactor.GetHashCode();
            if (FederatedUsers != null)
                hashCode = hashCode * 59 + FederatedUsers.GetHashCode();
            if (Groups != null)
                hashCode = hashCode * 59 + Groups.GetHashCode();
            if (Id != null)
                hashCode = hashCode * 59 + Id.GetHashCode();
            if (IdentityProviderMappers != null)
                hashCode = hashCode * 59 + IdentityProviderMappers.GetHashCode();
            if (IdentityProviders != null)
                hashCode = hashCode * 59 + IdentityProviders.GetHashCode();
            if (InternationalizationEnabled != null)
                hashCode = hashCode * 59 + InternationalizationEnabled.GetHashCode();
            if (KeycloakVersion != null)
                hashCode = hashCode * 59 + KeycloakVersion.GetHashCode();
            if (LoginTheme != null)
                hashCode = hashCode * 59 + LoginTheme.GetHashCode();
            if (LoginWithEmailAllowed != null)
                hashCode = hashCode * 59 + LoginWithEmailAllowed.GetHashCode();
            if (MaxDeltaTimeSeconds != null)
                hashCode = hashCode * 59 + MaxDeltaTimeSeconds.GetHashCode();
            if (MaxFailureWaitSeconds != null)
                hashCode = hashCode * 59 + MaxFailureWaitSeconds.GetHashCode();
            if (MinimumQuickLoginWaitSeconds != null)
                hashCode = hashCode * 59 + MinimumQuickLoginWaitSeconds.GetHashCode();
            if (NotBefore != null)
                hashCode = hashCode * 59 + NotBefore.GetHashCode();
            if (OAuth2DeviceCodeLifespan != null)
                hashCode = hashCode * 59 + OAuth2DeviceCodeLifespan.GetHashCode();
            if (OAuth2DevicePollingInterval != null)
                hashCode = hashCode * 59 + OAuth2DevicePollingInterval.GetHashCode();
            if (Oauth2DeviceCodeLifespan != null)
                hashCode = hashCode * 59 + Oauth2DeviceCodeLifespan.GetHashCode();
            if (Oauth2DevicePollingInterval != null)
                hashCode = hashCode * 59 + Oauth2DevicePollingInterval.GetHashCode();
            if (OfflineSessionIdleTimeout != null)
                hashCode = hashCode * 59 + OfflineSessionIdleTimeout.GetHashCode();
            if (OfflineSessionMaxLifespan != null)
                hashCode = hashCode * 59 + OfflineSessionMaxLifespan.GetHashCode();
            if (OfflineSessionMaxLifespanEnabled != null)
                hashCode = hashCode * 59 + OfflineSessionMaxLifespanEnabled.GetHashCode();
            if (OtpPolicyAlgorithm != null)
                hashCode = hashCode * 59 + OtpPolicyAlgorithm.GetHashCode();
            if (OtpPolicyDigits != null)
                hashCode = hashCode * 59 + OtpPolicyDigits.GetHashCode();
            if (OtpPolicyInitialCounter != null)
                hashCode = hashCode * 59 + OtpPolicyInitialCounter.GetHashCode();
            if (OtpPolicyLookAheadWindow != null)
                hashCode = hashCode * 59 + OtpPolicyLookAheadWindow.GetHashCode();
            if (OtpPolicyPeriod != null)
                hashCode = hashCode * 59 + OtpPolicyPeriod.GetHashCode();
            if (OtpPolicyType != null)
                hashCode = hashCode * 59 + OtpPolicyType.GetHashCode();
            if (OtpSupportedApplications != null)
                hashCode = hashCode * 59 + OtpSupportedApplications.GetHashCode();
            if (PasswordPolicy != null)
                hashCode = hashCode * 59 + PasswordPolicy.GetHashCode();
            if (PermanentLockout != null)
                hashCode = hashCode * 59 + PermanentLockout.GetHashCode();
            if (ProtocolMappers != null)
                hashCode = hashCode * 59 + ProtocolMappers.GetHashCode();
            if (QuickLoginCheckMilliSeconds != null)
                hashCode = hashCode * 59 + QuickLoginCheckMilliSeconds.GetHashCode();
            if (Realm != null)
                hashCode = hashCode * 59 + Realm.GetHashCode();
            if (RefreshTokenMaxReuse != null)
                hashCode = hashCode * 59 + RefreshTokenMaxReuse.GetHashCode();
            if (RegistrationAllowed != null)
                hashCode = hashCode * 59 + RegistrationAllowed.GetHashCode();
            if (RegistrationEmailAsUsername != null)
                hashCode = hashCode * 59 + RegistrationEmailAsUsername.GetHashCode();
            if (RegistrationFlow != null)
                hashCode = hashCode * 59 + RegistrationFlow.GetHashCode();
            if (RememberMe != null)
                hashCode = hashCode * 59 + RememberMe.GetHashCode();
            if (RequiredActions != null)
                hashCode = hashCode * 59 + RequiredActions.GetHashCode();
            if (ResetCredentialsFlow != null)
                hashCode = hashCode * 59 + ResetCredentialsFlow.GetHashCode();
            if (ResetPasswordAllowed != null)
                hashCode = hashCode * 59 + ResetPasswordAllowed.GetHashCode();
            if (RevokeRefreshToken != null)
                hashCode = hashCode * 59 + RevokeRefreshToken.GetHashCode();
            if (Roles != null)
                hashCode = hashCode * 59 + Roles.GetHashCode();
            if (ScopeMappings != null)
                hashCode = hashCode * 59 + ScopeMappings.GetHashCode();
            if (SmtpServer != null)
                hashCode = hashCode * 59 + SmtpServer.GetHashCode();
            if (SslRequired != null)
                hashCode = hashCode * 59 + SslRequired.GetHashCode();
            if (SsoSessionIdleTimeout != null)
                hashCode = hashCode * 59 + SsoSessionIdleTimeout.GetHashCode();
            if (SsoSessionIdleTimeoutRememberMe != null)
                hashCode = hashCode * 59 + SsoSessionIdleTimeoutRememberMe.GetHashCode();
            if (SsoSessionMaxLifespan != null)
                hashCode = hashCode * 59 + SsoSessionMaxLifespan.GetHashCode();
            if (SsoSessionMaxLifespanRememberMe != null)
                hashCode = hashCode * 59 + SsoSessionMaxLifespanRememberMe.GetHashCode();
            if (SupportedLocales != null)
                hashCode = hashCode * 59 + SupportedLocales.GetHashCode();
            if (UserFederationMappers != null)
                hashCode = hashCode * 59 + UserFederationMappers.GetHashCode();
            if (UserFederationProviders != null)
                hashCode = hashCode * 59 + UserFederationProviders.GetHashCode();
            if (UserManagedAccessAllowed != null)
                hashCode = hashCode * 59 + UserManagedAccessAllowed.GetHashCode();
            if (Users != null)
                hashCode = hashCode * 59 + Users.GetHashCode();
            if (VerifyEmail != null)
                hashCode = hashCode * 59 + VerifyEmail.GetHashCode();
            if (WaitIncrementSeconds != null)
                hashCode = hashCode * 59 + WaitIncrementSeconds.GetHashCode();
            if (WebAuthnPolicyAcceptableAaguids != null)
                hashCode = hashCode * 59 + WebAuthnPolicyAcceptableAaguids.GetHashCode();
            if (WebAuthnPolicyAttestationConveyancePreference != null)
                hashCode = hashCode * 59 + WebAuthnPolicyAttestationConveyancePreference.GetHashCode();
            if (WebAuthnPolicyAuthenticatorAttachment != null)
                hashCode = hashCode * 59 + WebAuthnPolicyAuthenticatorAttachment.GetHashCode();
            if (WebAuthnPolicyAvoidSameAuthenticatorRegister != null)
                hashCode = hashCode * 59 + WebAuthnPolicyAvoidSameAuthenticatorRegister.GetHashCode();
            if (WebAuthnPolicyCreateTimeout != null)
                hashCode = hashCode * 59 + WebAuthnPolicyCreateTimeout.GetHashCode();
            if (WebAuthnPolicyPasswordlessAcceptableAaguids != null)
                hashCode = hashCode * 59 + WebAuthnPolicyPasswordlessAcceptableAaguids.GetHashCode();
            if (WebAuthnPolicyPasswordlessAttestationConveyancePreference != null)
                hashCode = hashCode * 59 + WebAuthnPolicyPasswordlessAttestationConveyancePreference.GetHashCode();
            if (WebAuthnPolicyPasswordlessAuthenticatorAttachment != null)
                hashCode = hashCode * 59 + WebAuthnPolicyPasswordlessAuthenticatorAttachment.GetHashCode();
            if (WebAuthnPolicyPasswordlessAvoidSameAuthenticatorRegister != null)
                hashCode = hashCode * 59 + WebAuthnPolicyPasswordlessAvoidSameAuthenticatorRegister.GetHashCode();
            if (WebAuthnPolicyPasswordlessCreateTimeout != null)
                hashCode = hashCode * 59 + WebAuthnPolicyPasswordlessCreateTimeout.GetHashCode();
            if (WebAuthnPolicyPasswordlessRequireResidentKey != null)
                hashCode = hashCode * 59 + WebAuthnPolicyPasswordlessRequireResidentKey.GetHashCode();
            if (WebAuthnPolicyPasswordlessRpEntityName != null)
                hashCode = hashCode * 59 + WebAuthnPolicyPasswordlessRpEntityName.GetHashCode();
            if (WebAuthnPolicyPasswordlessRpId != null)
                hashCode = hashCode * 59 + WebAuthnPolicyPasswordlessRpId.GetHashCode();
            if (WebAuthnPolicyPasswordlessSignatureAlgorithms != null)
                hashCode = hashCode * 59 + WebAuthnPolicyPasswordlessSignatureAlgorithms.GetHashCode();
            if (WebAuthnPolicyPasswordlessUserVerificationRequirement != null)
                hashCode = hashCode * 59 + WebAuthnPolicyPasswordlessUserVerificationRequirement.GetHashCode();
            if (WebAuthnPolicyRequireResidentKey != null)
                hashCode = hashCode * 59 + WebAuthnPolicyRequireResidentKey.GetHashCode();
            if (WebAuthnPolicyRpEntityName != null)
                hashCode = hashCode * 59 + WebAuthnPolicyRpEntityName.GetHashCode();
            if (WebAuthnPolicyRpId != null)
                hashCode = hashCode * 59 + WebAuthnPolicyRpId.GetHashCode();
            if (WebAuthnPolicySignatureAlgorithms != null)
                hashCode = hashCode * 59 + WebAuthnPolicySignatureAlgorithms.GetHashCode();
            if (WebAuthnPolicyUserVerificationRequirement != null)
                hashCode = hashCode * 59 + WebAuthnPolicyUserVerificationRequirement.GetHashCode();
            return hashCode;
        }
    }
}