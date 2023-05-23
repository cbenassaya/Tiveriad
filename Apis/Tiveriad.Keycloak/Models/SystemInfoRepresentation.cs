#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     SystemInfoRepresentation
/// </summary>
[DataContract]
public class SystemInfoRepresentation : IEquatable<SystemInfoRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="SystemInfoRepresentation" /> class.
    /// </summary>
    /// <param name="fileEncoding">fileEncoding.</param>
    /// <param name="javaHome">javaHome.</param>
    /// <param name="javaRuntime">javaRuntime.</param>
    /// <param name="javaVendor">javaVendor.</param>
    /// <param name="javaVersion">javaVersion.</param>
    /// <param name="javaVm">javaVm.</param>
    /// <param name="javaVmVersion">javaVmVersion.</param>
    /// <param name="osArchitecture">osArchitecture.</param>
    /// <param name="osName">osName.</param>
    /// <param name="osVersion">osVersion.</param>
    /// <param name="serverTime">serverTime.</param>
    /// <param name="uptime">uptime.</param>
    /// <param name="uptimeMillis">uptimeMillis.</param>
    /// <param name="userDir">userDir.</param>
    /// <param name="userLocale">userLocale.</param>
    /// <param name="userName">userName.</param>
    /// <param name="userTimezone">userTimezone.</param>
    /// <param name="version">version.</param>
    public SystemInfoRepresentation(string fileEncoding = default, string javaHome = default,
        string javaRuntime = default, string javaVendor = default, string javaVersion = default,
        string javaVm = default, string javaVmVersion = default, string osArchitecture = default,
        string osName = default, string osVersion = default, string serverTime = default, string uptime = default,
        long? uptimeMillis = default, string userDir = default, string userLocale = default, string userName = default,
        string userTimezone = default, string version = default)
    {
        FileEncoding = fileEncoding;
        JavaHome = javaHome;
        JavaRuntime = javaRuntime;
        JavaVendor = javaVendor;
        JavaVersion = javaVersion;
        JavaVm = javaVm;
        JavaVmVersion = javaVmVersion;
        OsArchitecture = osArchitecture;
        OsName = osName;
        OsVersion = osVersion;
        ServerTime = serverTime;
        Uptime = uptime;
        UptimeMillis = uptimeMillis;
        UserDir = userDir;
        UserLocale = userLocale;
        UserName = userName;
        UserTimezone = userTimezone;
        Version = version;
    }

    /// <summary>
    ///     Gets or Sets FileEncoding
    /// </summary>
    [DataMember(Name = "fileEncoding", EmitDefaultValue = false)]
    public string FileEncoding { get; set; }

    /// <summary>
    ///     Gets or Sets JavaHome
    /// </summary>
    [DataMember(Name = "javaHome", EmitDefaultValue = false)]
    public string JavaHome { get; set; }

    /// <summary>
    ///     Gets or Sets JavaRuntime
    /// </summary>
    [DataMember(Name = "javaRuntime", EmitDefaultValue = false)]
    public string JavaRuntime { get; set; }

    /// <summary>
    ///     Gets or Sets JavaVendor
    /// </summary>
    [DataMember(Name = "javaVendor", EmitDefaultValue = false)]
    public string JavaVendor { get; set; }

    /// <summary>
    ///     Gets or Sets JavaVersion
    /// </summary>
    [DataMember(Name = "javaVersion", EmitDefaultValue = false)]
    public string JavaVersion { get; set; }

    /// <summary>
    ///     Gets or Sets JavaVm
    /// </summary>
    [DataMember(Name = "javaVm", EmitDefaultValue = false)]
    public string JavaVm { get; set; }

    /// <summary>
    ///     Gets or Sets JavaVmVersion
    /// </summary>
    [DataMember(Name = "javaVmVersion", EmitDefaultValue = false)]
    public string JavaVmVersion { get; set; }

    /// <summary>
    ///     Gets or Sets OsArchitecture
    /// </summary>
    [DataMember(Name = "osArchitecture", EmitDefaultValue = false)]
    public string OsArchitecture { get; set; }

    /// <summary>
    ///     Gets or Sets OsName
    /// </summary>
    [DataMember(Name = "osName", EmitDefaultValue = false)]
    public string OsName { get; set; }

    /// <summary>
    ///     Gets or Sets OsVersion
    /// </summary>
    [DataMember(Name = "osVersion", EmitDefaultValue = false)]
    public string OsVersion { get; set; }

    /// <summary>
    ///     Gets or Sets ServerTime
    /// </summary>
    [DataMember(Name = "serverTime", EmitDefaultValue = false)]
    public string ServerTime { get; set; }

    /// <summary>
    ///     Gets or Sets Uptime
    /// </summary>
    [DataMember(Name = "uptime", EmitDefaultValue = false)]
    public string Uptime { get; set; }

    /// <summary>
    ///     Gets or Sets UptimeMillis
    /// </summary>
    [DataMember(Name = "uptimeMillis", EmitDefaultValue = false)]
    public long? UptimeMillis { get; set; }

    /// <summary>
    ///     Gets or Sets UserDir
    /// </summary>
    [DataMember(Name = "userDir", EmitDefaultValue = false)]
    public string UserDir { get; set; }

    /// <summary>
    ///     Gets or Sets UserLocale
    /// </summary>
    [DataMember(Name = "userLocale", EmitDefaultValue = false)]
    public string UserLocale { get; set; }

    /// <summary>
    ///     Gets or Sets UserName
    /// </summary>
    [DataMember(Name = "userName", EmitDefaultValue = false)]
    public string UserName { get; set; }

    /// <summary>
    ///     Gets or Sets UserTimezone
    /// </summary>
    [DataMember(Name = "userTimezone", EmitDefaultValue = false)]
    public string UserTimezone { get; set; }

    /// <summary>
    ///     Gets or Sets Version
    /// </summary>
    [DataMember(Name = "version", EmitDefaultValue = false)]
    public string Version { get; set; }

    /// <summary>
    ///     Returns true if SystemInfoRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of SystemInfoRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(SystemInfoRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                FileEncoding == input.FileEncoding ||
                (FileEncoding != null &&
                 FileEncoding.Equals(input.FileEncoding))
            ) &&
            (
                JavaHome == input.JavaHome ||
                (JavaHome != null &&
                 JavaHome.Equals(input.JavaHome))
            ) &&
            (
                JavaRuntime == input.JavaRuntime ||
                (JavaRuntime != null &&
                 JavaRuntime.Equals(input.JavaRuntime))
            ) &&
            (
                JavaVendor == input.JavaVendor ||
                (JavaVendor != null &&
                 JavaVendor.Equals(input.JavaVendor))
            ) &&
            (
                JavaVersion == input.JavaVersion ||
                (JavaVersion != null &&
                 JavaVersion.Equals(input.JavaVersion))
            ) &&
            (
                JavaVm == input.JavaVm ||
                (JavaVm != null &&
                 JavaVm.Equals(input.JavaVm))
            ) &&
            (
                JavaVmVersion == input.JavaVmVersion ||
                (JavaVmVersion != null &&
                 JavaVmVersion.Equals(input.JavaVmVersion))
            ) &&
            (
                OsArchitecture == input.OsArchitecture ||
                (OsArchitecture != null &&
                 OsArchitecture.Equals(input.OsArchitecture))
            ) &&
            (
                OsName == input.OsName ||
                (OsName != null &&
                 OsName.Equals(input.OsName))
            ) &&
            (
                OsVersion == input.OsVersion ||
                (OsVersion != null &&
                 OsVersion.Equals(input.OsVersion))
            ) &&
            (
                ServerTime == input.ServerTime ||
                (ServerTime != null &&
                 ServerTime.Equals(input.ServerTime))
            ) &&
            (
                Uptime == input.Uptime ||
                (Uptime != null &&
                 Uptime.Equals(input.Uptime))
            ) &&
            (
                UptimeMillis == input.UptimeMillis ||
                (UptimeMillis != null &&
                 UptimeMillis.Equals(input.UptimeMillis))
            ) &&
            (
                UserDir == input.UserDir ||
                (UserDir != null &&
                 UserDir.Equals(input.UserDir))
            ) &&
            (
                UserLocale == input.UserLocale ||
                (UserLocale != null &&
                 UserLocale.Equals(input.UserLocale))
            ) &&
            (
                UserName == input.UserName ||
                (UserName != null &&
                 UserName.Equals(input.UserName))
            ) &&
            (
                UserTimezone == input.UserTimezone ||
                (UserTimezone != null &&
                 UserTimezone.Equals(input.UserTimezone))
            ) &&
            (
                Version == input.Version ||
                (Version != null &&
                 Version.Equals(input.Version))
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
        sb.Append("class SystemInfoRepresentation {\n");
        sb.Append("  FileEncoding: ").Append(FileEncoding).Append("\n");
        sb.Append("  JavaHome: ").Append(JavaHome).Append("\n");
        sb.Append("  JavaRuntime: ").Append(JavaRuntime).Append("\n");
        sb.Append("  JavaVendor: ").Append(JavaVendor).Append("\n");
        sb.Append("  JavaVersion: ").Append(JavaVersion).Append("\n");
        sb.Append("  JavaVm: ").Append(JavaVm).Append("\n");
        sb.Append("  JavaVmVersion: ").Append(JavaVmVersion).Append("\n");
        sb.Append("  OsArchitecture: ").Append(OsArchitecture).Append("\n");
        sb.Append("  OsName: ").Append(OsName).Append("\n");
        sb.Append("  OsVersion: ").Append(OsVersion).Append("\n");
        sb.Append("  ServerTime: ").Append(ServerTime).Append("\n");
        sb.Append("  Uptime: ").Append(Uptime).Append("\n");
        sb.Append("  UptimeMillis: ").Append(UptimeMillis).Append("\n");
        sb.Append("  UserDir: ").Append(UserDir).Append("\n");
        sb.Append("  UserLocale: ").Append(UserLocale).Append("\n");
        sb.Append("  UserName: ").Append(UserName).Append("\n");
        sb.Append("  UserTimezone: ").Append(UserTimezone).Append("\n");
        sb.Append("  Version: ").Append(Version).Append("\n");
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
        return Equals(input as SystemInfoRepresentation);
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
            if (FileEncoding != null)
                hashCode = hashCode * 59 + FileEncoding.GetHashCode();
            if (JavaHome != null)
                hashCode = hashCode * 59 + JavaHome.GetHashCode();
            if (JavaRuntime != null)
                hashCode = hashCode * 59 + JavaRuntime.GetHashCode();
            if (JavaVendor != null)
                hashCode = hashCode * 59 + JavaVendor.GetHashCode();
            if (JavaVersion != null)
                hashCode = hashCode * 59 + JavaVersion.GetHashCode();
            if (JavaVm != null)
                hashCode = hashCode * 59 + JavaVm.GetHashCode();
            if (JavaVmVersion != null)
                hashCode = hashCode * 59 + JavaVmVersion.GetHashCode();
            if (OsArchitecture != null)
                hashCode = hashCode * 59 + OsArchitecture.GetHashCode();
            if (OsName != null)
                hashCode = hashCode * 59 + OsName.GetHashCode();
            if (OsVersion != null)
                hashCode = hashCode * 59 + OsVersion.GetHashCode();
            if (ServerTime != null)
                hashCode = hashCode * 59 + ServerTime.GetHashCode();
            if (Uptime != null)
                hashCode = hashCode * 59 + Uptime.GetHashCode();
            if (UptimeMillis != null)
                hashCode = hashCode * 59 + UptimeMillis.GetHashCode();
            if (UserDir != null)
                hashCode = hashCode * 59 + UserDir.GetHashCode();
            if (UserLocale != null)
                hashCode = hashCode * 59 + UserLocale.GetHashCode();
            if (UserName != null)
                hashCode = hashCode * 59 + UserName.GetHashCode();
            if (UserTimezone != null)
                hashCode = hashCode * 59 + UserTimezone.GetHashCode();
            if (Version != null)
                hashCode = hashCode * 59 + Version.GetHashCode();
            return hashCode;
        }
    }
}