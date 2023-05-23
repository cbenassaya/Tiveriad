#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     ClientProfileRepresentation
/// </summary>
[DataContract]
public class ClientProfileRepresentation : IEquatable<ClientProfileRepresentation>, IValidatableObject
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ClientProfileRepresentation" /> class.
    /// </summary>
    /// <param name="description">description.</param>
    /// <param name="executors">executors.</param>
    /// <param name="name">name.</param>
    public ClientProfileRepresentation(string description = default,
        List<ClientPolicyExecutorRepresentation> executors = default, string name = default)
    {
        Description = description;
        Executors = executors;
        Name = name;
    }

    /// <summary>
    ///     Gets or Sets Description
    /// </summary>
    [DataMember(Name = "description", EmitDefaultValue = false)]
    public string Description { get; set; }

    /// <summary>
    ///     Gets or Sets Executors
    /// </summary>
    [DataMember(Name = "executors", EmitDefaultValue = false)]
    public List<ClientPolicyExecutorRepresentation> Executors { get; set; }

    /// <summary>
    ///     Gets or Sets Name
    /// </summary>
    [DataMember(Name = "name", EmitDefaultValue = false)]
    public string Name { get; set; }

    /// <summary>
    ///     Returns true if ClientProfileRepresentation instances are equal
    /// </summary>
    /// <param name="input">Instance of ClientProfileRepresentation to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(ClientProfileRepresentation input)
    {
        if (input == null)
            return false;

        return
            (
                Description == input.Description ||
                (Description != null &&
                 Description.Equals(input.Description))
            ) &&
            (
                Executors == input.Executors ||
                (Executors != null &&
                 input.Executors != null &&
                 Executors.SequenceEqual(input.Executors))
            ) &&
            (
                Name == input.Name ||
                (Name != null &&
                 Name.Equals(input.Name))
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
        sb.Append("class ClientProfileRepresentation {\n");
        sb.Append("  Description: ").Append(Description).Append("\n");
        sb.Append("  Executors: ").Append(Executors).Append("\n");
        sb.Append("  Name: ").Append(Name).Append("\n");
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
        return Equals(input as ClientProfileRepresentation);
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
            if (Description != null)
                hashCode = hashCode * 59 + Description.GetHashCode();
            if (Executors != null)
                hashCode = hashCode * 59 + Executors.GetHashCode();
            if (Name != null)
                hashCode = hashCode * 59 + Name.GetHashCode();
            return hashCode;
        }
    }
}