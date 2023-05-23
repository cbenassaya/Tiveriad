#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     AccessToken
/// </summary>
[DataContract]
public class AccessToken : IEquatable<AccessToken>, IValidatableObject
{
    /// <summary>
    ///     Defines Category
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CategoryEnum
    {
        /// <summary>
        ///     Enum INTERNAL for value: INTERNAL
        /// </summary>
        [EnumMember(Value = "INTERNAL")] INTERNAL = 1,

        /// <summary>
        ///     Enum ACCESS for value: ACCESS
        /// </summary>
        [EnumMember(Value = "ACCESS")] ACCESS = 2,

        /// <summary>
        ///     Enum ID for value: ID
        /// </summary>
        [EnumMember(Value = "ID")] ID = 3,

        /// <summary>
        ///     Enum ADMIN for value: ADMIN
        /// </summary>
        [EnumMember(Value = "ADMIN")] ADMIN = 4,

        /// <summary>
        ///     Enum USERINFO for value: USERINFO
        /// </summary>
        [EnumMember(Value = "USERINFO")] USERINFO = 5,

        /// <summary>
        ///     Enum LOGOUT for value: LOGOUT
        /// </summary>
        [EnumMember(Value = "LOGOUT")] LOGOUT = 6,

        /// <summary>
        ///     Enum AUTHORIZATIONRESPONSE for value: AUTHORIZATION_RESPONSE
        /// </summary>
        [EnumMember(Value = "AUTHORIZATION_RESPONSE")]
        AUTHORIZATIONRESPONSE = 7
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="AccessToken" /> class.
    /// </summary>
    /// <param name="acr">acr.</param>
    /// <param name="address">address.</param>
    /// <param name="allowedOrigins">allowedOrigins.</param>
    /// <param name="atHash">atHash.</param>
    /// <param name="authTime">authTime.</param>
    /// <param name="authorization">authorization.</param>
    /// <param name="azp">azp.</param>
    /// <param name="birthdate">birthdate.</param>
    /// <param name="cHash">cHash.</param>
    /// <param name="category">category.</param>
    /// <param name="claimsLocales">claimsLocales.</param>
    /// <param name="cnf">cnf.</param>
    /// <param name="email">email.</param>
    /// <param name="emailVerified">emailVerified.</param>
    /// <param name="exp">exp.</param>
    /// <param name="familyName">familyName.</param>
    /// <param name="gender">gender.</param>
    /// <param name="givenName">givenName.</param>
    /// <param name="iat">iat.</param>
    /// <param name="iss">iss.</param>
    /// <param name="jti">jti.</param>
    /// <param name="locale">locale.</param>
    /// <param name="middleName">middleName.</param>
    /// <param name="name">name.</param>
    /// <param name="nbf">nbf.</param>
    /// <param name="nickname">nickname.</param>
    /// <param name="nonce">nonce.</param>
    /// <param name="otherClaims">otherClaims.</param>
    /// <param name="phoneNumber">phoneNumber.</param>
    /// <param name="phoneNumberVerified">phoneNumberVerified.</param>
    /// <param name="picture">picture.</param>
    /// <param name="preferredUsername">preferredUsername.</param>
    /// <param name="profile">profile.</param>
    /// <param name="realmAccess">realmAccess.</param>
    /// <param name="sHash">sHash.</param>
    /// <param name="scope">scope.</param>
    /// <param name="sessionState">sessionState.</param>
    /// <param name="sid">sid.</param>
    /// <param name="sub">sub.</param>
    /// <param name="trustedCerts">trustedCerts.</param>
    /// <param name="typ">typ.</param>
    /// <param name="updatedAt">updatedAt.</param>
    /// <param name="website">website.</param>
    /// <param name="zoneinfo">zoneinfo.</param>
    public AccessToken(string acr = default, AddressClaimSet address = default, List<string> allowedOrigins = default,
        string atHash = default, long? authTime = default, AccessTokenAuthorization authorization = default,
        string azp = default, string birthdate = default, string cHash = default, CategoryEnum? category = default,
        string claimsLocales = default, AccessTokenCertConf cnf = default, string email = default,
        bool? emailVerified = default, long? exp = default, string familyName = default, string gender = default,
        string givenName = default, long? iat = default, string iss = default, string jti = default,
        string locale = default, string middleName = default, string name = default, long? nbf = default,
        string nickname = default, string nonce = default, Dictionary<string, object> otherClaims = default,
        string phoneNumber = default, bool? phoneNumberVerified = default, string picture = default,
        string preferredUsername = default, string profile = default, AccessTokenAccess realmAccess = default,
        string sHash = default, string scope = default, string sessionState = default, string sid = default,
        string sub = default, List<string> trustedCerts = default, string typ = default, long? updatedAt = default,
        string website = default, string zoneinfo = default)
    {
        Acr = acr;
        Address = address;
        AllowedOrigins = allowedOrigins;
        AtHash = atHash;
        AuthTime = authTime;
        Authorization = authorization;
        Azp = azp;
        Birthdate = birthdate;
        CHash = cHash;
        Category = category;
        ClaimsLocales = claimsLocales;
        Cnf = cnf;
        Email = email;
        EmailVerified = emailVerified;
        Exp = exp;
        FamilyName = familyName;
        Gender = gender;
        GivenName = givenName;
        Iat = iat;
        Iss = iss;
        Jti = jti;
        Locale = locale;
        MiddleName = middleName;
        Name = name;
        Nbf = nbf;
        Nickname = nickname;
        Nonce = nonce;
        OtherClaims = otherClaims;
        PhoneNumber = phoneNumber;
        PhoneNumberVerified = phoneNumberVerified;
        Picture = picture;
        PreferredUsername = preferredUsername;
        Profile = profile;
        RealmAccess = realmAccess;
        SHash = sHash;
        Scope = scope;
        SessionState = sessionState;
        Sid = sid;
        Sub = sub;
        TrustedCerts = trustedCerts;
        Typ = typ;
        UpdatedAt = updatedAt;
        Website = website;
        Zoneinfo = zoneinfo;
    }

    /// <summary>
    ///     Gets or Sets Category
    /// </summary>
    [DataMember(Name = "category", EmitDefaultValue = false)]
    public CategoryEnum? Category { get; set; }

    /// <summary>
    ///     Gets or Sets Acr
    /// </summary>
    [DataMember(Name = "acr", EmitDefaultValue = false)]
    public string Acr { get; set; }

    /// <summary>
    ///     Gets or Sets Address
    /// </summary>
    [DataMember(Name = "address", EmitDefaultValue = false)]
    public AddressClaimSet Address { get; set; }

    /// <summary>
    ///     Gets or Sets AllowedOrigins
    /// </summary>
    [DataMember(Name = "allowed-origins", EmitDefaultValue = false)]
    public List<string> AllowedOrigins { get; set; }

    /// <summary>
    ///     Gets or Sets AtHash
    /// </summary>
    [DataMember(Name = "at_hash", EmitDefaultValue = false)]
    public string AtHash { get; set; }

    /// <summary>
    ///     Gets or Sets AuthTime
    /// </summary>
    [DataMember(Name = "auth_time", EmitDefaultValue = false)]
    public long? AuthTime { get; set; }

    /// <summary>
    ///     Gets or Sets Authorization
    /// </summary>
    [DataMember(Name = "authorization", EmitDefaultValue = false)]
    public AccessTokenAuthorization Authorization { get; set; }

    /// <summary>
    ///     Gets or Sets Azp
    /// </summary>
    [DataMember(Name = "azp", EmitDefaultValue = false)]
    public string Azp { get; set; }

    /// <summary>
    ///     Gets or Sets Birthdate
    /// </summary>
    [DataMember(Name = "birthdate", EmitDefaultValue = false)]
    public string Birthdate { get; set; }

    /// <summary>
    ///     Gets or Sets CHash
    /// </summary>
    [DataMember(Name = "c_hash", EmitDefaultValue = false)]
    public string CHash { get; set; }


    /// <summary>
    ///     Gets or Sets ClaimsLocales
    /// </summary>
    [DataMember(Name = "claims_locales", EmitDefaultValue = false)]
    public string ClaimsLocales { get; set; }

    /// <summary>
    ///     Gets or Sets Cnf
    /// </summary>
    [DataMember(Name = "cnf", EmitDefaultValue = false)]
    public AccessTokenCertConf Cnf { get; set; }

    /// <summary>
    ///     Gets or Sets Email
    /// </summary>
    [DataMember(Name = "email", EmitDefaultValue = false)]
    public string Email { get; set; }

    /// <summary>
    ///     Gets or Sets EmailVerified
    /// </summary>
    [DataMember(Name = "email_verified", EmitDefaultValue = false)]
    public bool? EmailVerified { get; set; }

    /// <summary>
    ///     Gets or Sets Exp
    /// </summary>
    [DataMember(Name = "exp", EmitDefaultValue = false)]
    public long? Exp { get; set; }

    /// <summary>
    ///     Gets or Sets FamilyName
    /// </summary>
    [DataMember(Name = "family_name", EmitDefaultValue = false)]
    public string FamilyName { get; set; }

    /// <summary>
    ///     Gets or Sets Gender
    /// </summary>
    [DataMember(Name = "gender", EmitDefaultValue = false)]
    public string Gender { get; set; }

    /// <summary>
    ///     Gets or Sets GivenName
    /// </summary>
    [DataMember(Name = "given_name", EmitDefaultValue = false)]
    public string GivenName { get; set; }

    /// <summary>
    ///     Gets or Sets Iat
    /// </summary>
    [DataMember(Name = "iat", EmitDefaultValue = false)]
    public long? Iat { get; set; }

    /// <summary>
    ///     Gets or Sets Iss
    /// </summary>
    [DataMember(Name = "iss", EmitDefaultValue = false)]
    public string Iss { get; set; }

    /// <summary>
    ///     Gets or Sets Jti
    /// </summary>
    [DataMember(Name = "jti", EmitDefaultValue = false)]
    public string Jti { get; set; }

    /// <summary>
    ///     Gets or Sets Locale
    /// </summary>
    [DataMember(Name = "locale", EmitDefaultValue = false)]
    public string Locale { get; set; }

    /// <summary>
    ///     Gets or Sets MiddleName
    /// </summary>
    [DataMember(Name = "middle_name", EmitDefaultValue = false)]
    public string MiddleName { get; set; }

    /// <summary>
    ///     Gets or Sets Name
    /// </summary>
    [DataMember(Name = "name", EmitDefaultValue = false)]
    public string Name { get; set; }

    /// <summary>
    ///     Gets or Sets Nbf
    /// </summary>
    [DataMember(Name = "nbf", EmitDefaultValue = false)]
    public long? Nbf { get; set; }

    /// <summary>
    ///     Gets or Sets Nickname
    /// </summary>
    [DataMember(Name = "nickname", EmitDefaultValue = false)]
    public string Nickname { get; set; }

    /// <summary>
    ///     Gets or Sets Nonce
    /// </summary>
    [DataMember(Name = "nonce", EmitDefaultValue = false)]
    public string Nonce { get; set; }

    /// <summary>
    ///     Gets or Sets OtherClaims
    /// </summary>
    [DataMember(Name = "otherClaims", EmitDefaultValue = false)]
    public Dictionary<string, object> OtherClaims { get; set; }

    /// <summary>
    ///     Gets or Sets PhoneNumber
    /// </summary>
    [DataMember(Name = "phone_number", EmitDefaultValue = false)]
    public string PhoneNumber { get; set; }

    /// <summary>
    ///     Gets or Sets PhoneNumberVerified
    /// </summary>
    [DataMember(Name = "phone_number_verified", EmitDefaultValue = false)]
    public bool? PhoneNumberVerified { get; set; }

    /// <summary>
    ///     Gets or Sets Picture
    /// </summary>
    [DataMember(Name = "picture", EmitDefaultValue = false)]
    public string Picture { get; set; }

    /// <summary>
    ///     Gets or Sets PreferredUsername
    /// </summary>
    [DataMember(Name = "preferred_username", EmitDefaultValue = false)]
    public string PreferredUsername { get; set; }

    /// <summary>
    ///     Gets or Sets Profile
    /// </summary>
    [DataMember(Name = "profile", EmitDefaultValue = false)]
    public string Profile { get; set; }

    /// <summary>
    ///     Gets or Sets RealmAccess
    /// </summary>
    [DataMember(Name = "realm_access", EmitDefaultValue = false)]
    public AccessTokenAccess RealmAccess { get; set; }

    /// <summary>
    ///     Gets or Sets SHash
    /// </summary>
    [DataMember(Name = "s_hash", EmitDefaultValue = false)]
    public string SHash { get; set; }

    /// <summary>
    ///     Gets or Sets Scope
    /// </summary>
    [DataMember(Name = "scope", EmitDefaultValue = false)]
    public string Scope { get; set; }

    /// <summary>
    ///     Gets or Sets SessionState
    /// </summary>
    [DataMember(Name = "session_state", EmitDefaultValue = false)]
    public string SessionState { get; set; }

    /// <summary>
    ///     Gets or Sets Sid
    /// </summary>
    [DataMember(Name = "sid", EmitDefaultValue = false)]
    public string Sid { get; set; }

    /// <summary>
    ///     Gets or Sets Sub
    /// </summary>
    [DataMember(Name = "sub", EmitDefaultValue = false)]
    public string Sub { get; set; }

    /// <summary>
    ///     Gets or Sets TrustedCerts
    /// </summary>
    [DataMember(Name = "trusted-certs", EmitDefaultValue = false)]
    public List<string> TrustedCerts { get; set; }

    /// <summary>
    ///     Gets or Sets Typ
    /// </summary>
    [DataMember(Name = "typ", EmitDefaultValue = false)]
    public string Typ { get; set; }

    /// <summary>
    ///     Gets or Sets UpdatedAt
    /// </summary>
    [DataMember(Name = "updated_at", EmitDefaultValue = false)]
    public long? UpdatedAt { get; set; }

    /// <summary>
    ///     Gets or Sets Website
    /// </summary>
    [DataMember(Name = "website", EmitDefaultValue = false)]
    public string Website { get; set; }

    /// <summary>
    ///     Gets or Sets Zoneinfo
    /// </summary>
    [DataMember(Name = "zoneinfo", EmitDefaultValue = false)]
    public string Zoneinfo { get; set; }

    /// <summary>
    ///     Returns true if AccessToken instances are equal
    /// </summary>
    /// <param name="input">Instance of AccessToken to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(AccessToken input)
    {
        if (input == null)
            return false;

        return
            (
                Acr == input.Acr ||
                (Acr != null &&
                 Acr.Equals(input.Acr))
            ) &&
            (
                Address == input.Address ||
                (Address != null &&
                 Address.Equals(input.Address))
            ) &&
            (
                AllowedOrigins == input.AllowedOrigins ||
                (AllowedOrigins != null &&
                 input.AllowedOrigins != null &&
                 AllowedOrigins.SequenceEqual(input.AllowedOrigins))
            ) &&
            (
                AtHash == input.AtHash ||
                (AtHash != null &&
                 AtHash.Equals(input.AtHash))
            ) &&
            (
                AuthTime == input.AuthTime ||
                (AuthTime != null &&
                 AuthTime.Equals(input.AuthTime))
            ) &&
            (
                Authorization == input.Authorization ||
                (Authorization != null &&
                 Authorization.Equals(input.Authorization))
            ) &&
            (
                Azp == input.Azp ||
                (Azp != null &&
                 Azp.Equals(input.Azp))
            ) &&
            (
                Birthdate == input.Birthdate ||
                (Birthdate != null &&
                 Birthdate.Equals(input.Birthdate))
            ) &&
            (
                CHash == input.CHash ||
                (CHash != null &&
                 CHash.Equals(input.CHash))
            ) &&
            (
                Category == input.Category ||
                (Category != null &&
                 Category.Equals(input.Category))
            ) &&
            (
                ClaimsLocales == input.ClaimsLocales ||
                (ClaimsLocales != null &&
                 ClaimsLocales.Equals(input.ClaimsLocales))
            ) &&
            (
                Cnf == input.Cnf ||
                (Cnf != null &&
                 Cnf.Equals(input.Cnf))
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
                Exp == input.Exp ||
                (Exp != null &&
                 Exp.Equals(input.Exp))
            ) &&
            (
                FamilyName == input.FamilyName ||
                (FamilyName != null &&
                 FamilyName.Equals(input.FamilyName))
            ) &&
            (
                Gender == input.Gender ||
                (Gender != null &&
                 Gender.Equals(input.Gender))
            ) &&
            (
                GivenName == input.GivenName ||
                (GivenName != null &&
                 GivenName.Equals(input.GivenName))
            ) &&
            (
                Iat == input.Iat ||
                (Iat != null &&
                 Iat.Equals(input.Iat))
            ) &&
            (
                Iss == input.Iss ||
                (Iss != null &&
                 Iss.Equals(input.Iss))
            ) &&
            (
                Jti == input.Jti ||
                (Jti != null &&
                 Jti.Equals(input.Jti))
            ) &&
            (
                Locale == input.Locale ||
                (Locale != null &&
                 Locale.Equals(input.Locale))
            ) &&
            (
                MiddleName == input.MiddleName ||
                (MiddleName != null &&
                 MiddleName.Equals(input.MiddleName))
            ) &&
            (
                Name == input.Name ||
                (Name != null &&
                 Name.Equals(input.Name))
            ) &&
            (
                Nbf == input.Nbf ||
                (Nbf != null &&
                 Nbf.Equals(input.Nbf))
            ) &&
            (
                Nickname == input.Nickname ||
                (Nickname != null &&
                 Nickname.Equals(input.Nickname))
            ) &&
            (
                Nonce == input.Nonce ||
                (Nonce != null &&
                 Nonce.Equals(input.Nonce))
            ) &&
            (
                OtherClaims == input.OtherClaims ||
                (OtherClaims != null &&
                 input.OtherClaims != null &&
                 OtherClaims.SequenceEqual(input.OtherClaims))
            ) &&
            (
                PhoneNumber == input.PhoneNumber ||
                (PhoneNumber != null &&
                 PhoneNumber.Equals(input.PhoneNumber))
            ) &&
            (
                PhoneNumberVerified == input.PhoneNumberVerified ||
                (PhoneNumberVerified != null &&
                 PhoneNumberVerified.Equals(input.PhoneNumberVerified))
            ) &&
            (
                Picture == input.Picture ||
                (Picture != null &&
                 Picture.Equals(input.Picture))
            ) &&
            (
                PreferredUsername == input.PreferredUsername ||
                (PreferredUsername != null &&
                 PreferredUsername.Equals(input.PreferredUsername))
            ) &&
            (
                Profile == input.Profile ||
                (Profile != null &&
                 Profile.Equals(input.Profile))
            ) &&
            (
                RealmAccess == input.RealmAccess ||
                (RealmAccess != null &&
                 RealmAccess.Equals(input.RealmAccess))
            ) &&
            (
                SHash == input.SHash ||
                (SHash != null &&
                 SHash.Equals(input.SHash))
            ) &&
            (
                Scope == input.Scope ||
                (Scope != null &&
                 Scope.Equals(input.Scope))
            ) &&
            (
                SessionState == input.SessionState ||
                (SessionState != null &&
                 SessionState.Equals(input.SessionState))
            ) &&
            (
                Sid == input.Sid ||
                (Sid != null &&
                 Sid.Equals(input.Sid))
            ) &&
            (
                Sub == input.Sub ||
                (Sub != null &&
                 Sub.Equals(input.Sub))
            ) &&
            (
                TrustedCerts == input.TrustedCerts ||
                (TrustedCerts != null &&
                 input.TrustedCerts != null &&
                 TrustedCerts.SequenceEqual(input.TrustedCerts))
            ) &&
            (
                Typ == input.Typ ||
                (Typ != null &&
                 Typ.Equals(input.Typ))
            ) &&
            (
                UpdatedAt == input.UpdatedAt ||
                (UpdatedAt != null &&
                 UpdatedAt.Equals(input.UpdatedAt))
            ) &&
            (
                Website == input.Website ||
                (Website != null &&
                 Website.Equals(input.Website))
            ) &&
            (
                Zoneinfo == input.Zoneinfo ||
                (Zoneinfo != null &&
                 Zoneinfo.Equals(input.Zoneinfo))
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
        sb.Append("class AccessToken {\n");
        sb.Append("  Acr: ").Append(Acr).Append("\n");
        sb.Append("  Address: ").Append(Address).Append("\n");
        sb.Append("  AllowedOrigins: ").Append(AllowedOrigins).Append("\n");
        sb.Append("  AtHash: ").Append(AtHash).Append("\n");
        sb.Append("  AuthTime: ").Append(AuthTime).Append("\n");
        sb.Append("  Authorization: ").Append(Authorization).Append("\n");
        sb.Append("  Azp: ").Append(Azp).Append("\n");
        sb.Append("  Birthdate: ").Append(Birthdate).Append("\n");
        sb.Append("  CHash: ").Append(CHash).Append("\n");
        sb.Append("  Category: ").Append(Category).Append("\n");
        sb.Append("  ClaimsLocales: ").Append(ClaimsLocales).Append("\n");
        sb.Append("  Cnf: ").Append(Cnf).Append("\n");
        sb.Append("  Email: ").Append(Email).Append("\n");
        sb.Append("  EmailVerified: ").Append(EmailVerified).Append("\n");
        sb.Append("  Exp: ").Append(Exp).Append("\n");
        sb.Append("  FamilyName: ").Append(FamilyName).Append("\n");
        sb.Append("  Gender: ").Append(Gender).Append("\n");
        sb.Append("  GivenName: ").Append(GivenName).Append("\n");
        sb.Append("  Iat: ").Append(Iat).Append("\n");
        sb.Append("  Iss: ").Append(Iss).Append("\n");
        sb.Append("  Jti: ").Append(Jti).Append("\n");
        sb.Append("  Locale: ").Append(Locale).Append("\n");
        sb.Append("  MiddleName: ").Append(MiddleName).Append("\n");
        sb.Append("  Name: ").Append(Name).Append("\n");
        sb.Append("  Nbf: ").Append(Nbf).Append("\n");
        sb.Append("  Nickname: ").Append(Nickname).Append("\n");
        sb.Append("  Nonce: ").Append(Nonce).Append("\n");
        sb.Append("  OtherClaims: ").Append(OtherClaims).Append("\n");
        sb.Append("  PhoneNumber: ").Append(PhoneNumber).Append("\n");
        sb.Append("  PhoneNumberVerified: ").Append(PhoneNumberVerified).Append("\n");
        sb.Append("  Picture: ").Append(Picture).Append("\n");
        sb.Append("  PreferredUsername: ").Append(PreferredUsername).Append("\n");
        sb.Append("  Profile: ").Append(Profile).Append("\n");
        sb.Append("  RealmAccess: ").Append(RealmAccess).Append("\n");
        sb.Append("  SHash: ").Append(SHash).Append("\n");
        sb.Append("  Scope: ").Append(Scope).Append("\n");
        sb.Append("  SessionState: ").Append(SessionState).Append("\n");
        sb.Append("  Sid: ").Append(Sid).Append("\n");
        sb.Append("  Sub: ").Append(Sub).Append("\n");
        sb.Append("  TrustedCerts: ").Append(TrustedCerts).Append("\n");
        sb.Append("  Typ: ").Append(Typ).Append("\n");
        sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
        sb.Append("  Website: ").Append(Website).Append("\n");
        sb.Append("  Zoneinfo: ").Append(Zoneinfo).Append("\n");
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
        return Equals(input as AccessToken);
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
            if (Acr != null)
                hashCode = hashCode * 59 + Acr.GetHashCode();
            if (Address != null)
                hashCode = hashCode * 59 + Address.GetHashCode();
            if (AllowedOrigins != null)
                hashCode = hashCode * 59 + AllowedOrigins.GetHashCode();
            if (AtHash != null)
                hashCode = hashCode * 59 + AtHash.GetHashCode();
            if (AuthTime != null)
                hashCode = hashCode * 59 + AuthTime.GetHashCode();
            if (Authorization != null)
                hashCode = hashCode * 59 + Authorization.GetHashCode();
            if (Azp != null)
                hashCode = hashCode * 59 + Azp.GetHashCode();
            if (Birthdate != null)
                hashCode = hashCode * 59 + Birthdate.GetHashCode();
            if (CHash != null)
                hashCode = hashCode * 59 + CHash.GetHashCode();
            if (Category != null)
                hashCode = hashCode * 59 + Category.GetHashCode();
            if (ClaimsLocales != null)
                hashCode = hashCode * 59 + ClaimsLocales.GetHashCode();
            if (Cnf != null)
                hashCode = hashCode * 59 + Cnf.GetHashCode();
            if (Email != null)
                hashCode = hashCode * 59 + Email.GetHashCode();
            if (EmailVerified != null)
                hashCode = hashCode * 59 + EmailVerified.GetHashCode();
            if (Exp != null)
                hashCode = hashCode * 59 + Exp.GetHashCode();
            if (FamilyName != null)
                hashCode = hashCode * 59 + FamilyName.GetHashCode();
            if (Gender != null)
                hashCode = hashCode * 59 + Gender.GetHashCode();
            if (GivenName != null)
                hashCode = hashCode * 59 + GivenName.GetHashCode();
            if (Iat != null)
                hashCode = hashCode * 59 + Iat.GetHashCode();
            if (Iss != null)
                hashCode = hashCode * 59 + Iss.GetHashCode();
            if (Jti != null)
                hashCode = hashCode * 59 + Jti.GetHashCode();
            if (Locale != null)
                hashCode = hashCode * 59 + Locale.GetHashCode();
            if (MiddleName != null)
                hashCode = hashCode * 59 + MiddleName.GetHashCode();
            if (Name != null)
                hashCode = hashCode * 59 + Name.GetHashCode();
            if (Nbf != null)
                hashCode = hashCode * 59 + Nbf.GetHashCode();
            if (Nickname != null)
                hashCode = hashCode * 59 + Nickname.GetHashCode();
            if (Nonce != null)
                hashCode = hashCode * 59 + Nonce.GetHashCode();
            if (OtherClaims != null)
                hashCode = hashCode * 59 + OtherClaims.GetHashCode();
            if (PhoneNumber != null)
                hashCode = hashCode * 59 + PhoneNumber.GetHashCode();
            if (PhoneNumberVerified != null)
                hashCode = hashCode * 59 + PhoneNumberVerified.GetHashCode();
            if (Picture != null)
                hashCode = hashCode * 59 + Picture.GetHashCode();
            if (PreferredUsername != null)
                hashCode = hashCode * 59 + PreferredUsername.GetHashCode();
            if (Profile != null)
                hashCode = hashCode * 59 + Profile.GetHashCode();
            if (RealmAccess != null)
                hashCode = hashCode * 59 + RealmAccess.GetHashCode();
            if (SHash != null)
                hashCode = hashCode * 59 + SHash.GetHashCode();
            if (Scope != null)
                hashCode = hashCode * 59 + Scope.GetHashCode();
            if (SessionState != null)
                hashCode = hashCode * 59 + SessionState.GetHashCode();
            if (Sid != null)
                hashCode = hashCode * 59 + Sid.GetHashCode();
            if (Sub != null)
                hashCode = hashCode * 59 + Sub.GetHashCode();
            if (TrustedCerts != null)
                hashCode = hashCode * 59 + TrustedCerts.GetHashCode();
            if (Typ != null)
                hashCode = hashCode * 59 + Typ.GetHashCode();
            if (UpdatedAt != null)
                hashCode = hashCode * 59 + UpdatedAt.GetHashCode();
            if (Website != null)
                hashCode = hashCode * 59 + Website.GetHashCode();
            if (Zoneinfo != null)
                hashCode = hashCode * 59 + Zoneinfo.GetHashCode();
            return hashCode;
        }
    }
}