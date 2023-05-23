#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     TestLdapConnectionRepresentation
/// </summary>
[DataContract]
public class TestLdapConnectionRepresentation : IEquatable<TestLdapConnectionRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="TestLdapConnectionRepresentation" /> class.
    /// </summary>
    /// <param name="action">action.</param>
    /// <param name="authType">authType.</param>
    /// <param name="bindCredential">bindCredential.</param>
    /// <param name="bindDn">bindDn.</param>
    /// <param name="componentId">componentId.</param>
    /// <param name="connectionTimeout">connectionTimeout.</param>
    /// <param name="connectionUrl">connectionUrl.</param>
    /// <param name="startTls">startTls.</param>
    /// <param name="useTruststoreSpi">useTruststoreSpi.</param>
    public TestLdapConnectionRepresentation(string action = default, string authType = default,
        string bindCredential = default, string bindDn = default, string componentId = default,
        string connectionTimeout = default, string connectionUrl = default, string startTls = default,
        string useTruststoreSpi = default)
    {
        Action = action;
        AuthType = authType;
        BindCredential = bindCredential;
        BindDn = bindDn;
        ComponentId = componentId;
        ConnectionTimeout = connectionTimeout;
        ConnectionUrl = connectionUrl;
        StartTls = startTls;
        UseTruststoreSpi = useTruststoreSpi;
    }

    /// <summary>
    ///     Gets or Sets Action
    /// </summary>
    [DataMember(Name = "action", EmitDefaultValue = false)]
    public string Action { get; set; }

    /// <summary>
    ///     Gets or Sets AuthType
    /// </summary>
    [DataMember(Name = "authType", EmitDefaultValue = false)]
    public string AuthType { get; set; }

    /// <summary>
    ///     Gets or Sets BindCredential
    /// </summary>
    [DataMember(Name = "bindCredential", EmitDefaultValue = false)]
    public string BindCredential { get; set; }

    /// <summary>
    ///     Gets or Sets BindDn
    /// </summary>
    [DataMember(Name = "bindDn", EmitDefaultValue = false)]
    public string BindDn { get; set; }

    /// <summary>
    ///     Gets or Sets ComponentId
    /// </summary>
    [DataMember(Name = "componentId", EmitDefaultValue = false)]
    public string ComponentId { get; set; }

    /// <summary>
    ///     Gets or Sets ConnectionTimeout
    /// </summary>
    [DataMember(Name = "connectionTimeout", EmitDefaultValue = false)]
    public string ConnectionTimeout { get; set; }

    /// <summary>
    ///     Gets or Sets ConnectionUrl
    /// </summary>
    [DataMember(Name = "connectionUrl", EmitDefaultValue = false)]
    public string ConnectionUrl { get; set; }

    /// <summary>
    ///     Gets or Sets StartTls
    /// </summary>
    [DataMember(Name = "startTls", EmitDefaultValue = false)]
    public string StartTls { get; set; }

    /// <summary>
    ///     Gets or Sets UseTruststoreSpi
    /// </summary>
    [DataMember(Name = "useTruststoreSpi", EmitDefaultValue = false)]
    public string UseTruststoreSpi { get; set; }

    /// <summary>
    ///     Returns true if TestLdapConnectionRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of TestLdapConnectionRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(TestLdapConnectionRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                Action == input.Action ||
                (Action != null &&
                 Action.Equals(input.Action))
            ) &&
            (
                AuthType == input.AuthType ||
                (AuthType != null &&
                 AuthType.Equals(input.AuthType))
            ) &&
            (
                BindCredential == input.BindCredential ||
                (BindCredential != null &&
                 BindCredential.Equals(input.BindCredential))
            ) &&
            (
                BindDn == input.BindDn ||
                (BindDn != null &&
                 BindDn.Equals(input.BindDn))
            ) &&
            (
                ComponentId == input.ComponentId ||
                (ComponentId != null &&
                 ComponentId.Equals(input.ComponentId))
            ) &&
            (
                ConnectionTimeout == input.ConnectionTimeout ||
                (ConnectionTimeout != null &&
                 ConnectionTimeout.Equals(input.ConnectionTimeout))
            ) &&
            (
                ConnectionUrl == input.ConnectionUrl ||
                (ConnectionUrl != null &&
                 ConnectionUrl.Equals(input.ConnectionUrl))
            ) &&
            (
                StartTls == input.StartTls ||
                (StartTls != null &&
                 StartTls.Equals(input.StartTls))
            ) &&
            (
                UseTruststoreSpi == input.UseTruststoreSpi ||
                (UseTruststoreSpi != null &&
                 UseTruststoreSpi.Equals(input.UseTruststoreSpi))
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
        sb.Append("class TestLdapConnectionRepresentation {\n");
        sb.Append("  Action: ").Append(Action).Append("\n");
        sb.Append("  AuthType: ").Append(AuthType).Append("\n");
        sb.Append("  BindCredential: ").Append(BindCredential).Append("\n");
        sb.Append("  BindDn: ").Append(BindDn).Append("\n");
        sb.Append("  ComponentId: ").Append(ComponentId).Append("\n");
        sb.Append("  ConnectionTimeout: ").Append(ConnectionTimeout).Append("\n");
        sb.Append("  ConnectionUrl: ").Append(ConnectionUrl).Append("\n");
        sb.Append("  StartTls: ").Append(StartTls).Append("\n");
        sb.Append("  UseTruststoreSpi: ").Append(UseTruststoreSpi).Append("\n");
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
        return Equals(input as TestLdapConnectionRepresentation);
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
            if (Action != null)
                hashCode = hashCode * 59 + Action.GetHashCode();
            if (AuthType != null)
                hashCode = hashCode * 59 + AuthType.GetHashCode();
            if (BindCredential != null)
                hashCode = hashCode * 59 + BindCredential.GetHashCode();
            if (BindDn != null)
                hashCode = hashCode * 59 + BindDn.GetHashCode();
            if (ComponentId != null)
                hashCode = hashCode * 59 + ComponentId.GetHashCode();
            if (ConnectionTimeout != null)
                hashCode = hashCode * 59 + ConnectionTimeout.GetHashCode();
            if (ConnectionUrl != null)
                hashCode = hashCode * 59 + ConnectionUrl.GetHashCode();
            if (StartTls != null)
                hashCode = hashCode * 59 + StartTls.GetHashCode();
            if (UseTruststoreSpi != null)
                hashCode = hashCode * 59 + UseTruststoreSpi.GetHashCode();
            return hashCode;
        }
    }
}