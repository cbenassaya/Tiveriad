#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#endregion

namespace Tiveriad.Keycloak.Models;

/// <summary>
///     JsonNode
/// </summary>
[DataContract]
public class JsonNode : IEquatable<JsonNode>, IValidatableObject
{
    /// <summary>
    ///     Defines NodeType
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum NodeTypeEnum
    {
        /// <summary>
        ///     Enum ARRAY for value: ARRAY
        /// </summary>
        [EnumMember(Value = "ARRAY")] ARRAY = 1,

        /// <summary>
        ///     Enum BINARY for value: BINARY
        /// </summary>
        [EnumMember(Value = "BINARY")] BINARY = 2,

        /// <summary>
        ///     Enum BOOLEAN for value: BOOLEAN
        /// </summary>
        [EnumMember(Value = "BOOLEAN")] BOOLEAN = 3,

        /// <summary>
        ///     Enum MISSING for value: MISSING
        /// </summary>
        [EnumMember(Value = "MISSING")] MISSING = 4,

        /// <summary>
        ///     Enum NULL for value: NULL
        /// </summary>
        [EnumMember(Value = "NULL")] NULL = 5,

        /// <summary>
        ///     Enum NUMBER for value: NUMBER
        /// </summary>
        [EnumMember(Value = "NUMBER")] NUMBER = 6,

        /// <summary>
        ///     Enum OBJECT for value: OBJECT
        /// </summary>
        [EnumMember(Value = "OBJECT")] OBJECT = 7,

        /// <summary>
        ///     Enum POJO for value: POJO
        /// </summary>
        [EnumMember(Value = "POJO")] POJO = 8,

        /// <summary>
        ///     Enum STRING for value: STRING
        /// </summary>
        [EnumMember(Value = "STRING")] STRING = 9
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="JsonNode" /> class.
    /// </summary>
    /// <param name="array">array.</param>
    /// <param name="bigDecimal">bigDecimal.</param>
    /// <param name="bigInteger">bigInteger.</param>
    /// <param name="binary">binary.</param>
    /// <param name="boolean">boolean.</param>
    /// <param name="containerNode">containerNode.</param>
    /// <param name="_double">_double.</param>
    /// <param name="empty">empty.</param>
    /// <param name="_float">_float.</param>
    /// <param name="floatingPointNumber">floatingPointNumber.</param>
    /// <param name="_int">_int.</param>
    /// <param name="integralNumber">integralNumber.</param>
    /// <param name="_long">_long.</param>
    /// <param name="missingNode">missingNode.</param>
    /// <param name="nodeType">nodeType.</param>
    /// <param name="_null">_null.</param>
    /// <param name="number">number.</param>
    /// <param name="_object">_object.</param>
    /// <param name="pojo">pojo.</param>
    /// <param name="_short">_short.</param>
    /// <param name="textual">textual.</param>
    /// <param name="valueNode">valueNode.</param>
    public JsonNode(bool? array = default, bool? bigDecimal = default, bool? bigInteger = default,
        bool? binary = default, bool? boolean = default, bool? containerNode = default, bool? _double = default,
        bool? empty = default, bool? _float = default, bool? floatingPointNumber = default, bool? _int = default,
        bool? integralNumber = default, bool? _long = default, bool? missingNode = default,
        NodeTypeEnum? nodeType = default, bool? _null = default, bool? number = default, bool? _object = default,
        bool? pojo = default, bool? _short = default, bool? textual = default, bool? valueNode = default)
    {
        Array = array;
        BigDecimal = bigDecimal;
        BigInteger = bigInteger;
        Binary = binary;
        Boolean = boolean;
        ContainerNode = containerNode;
        _Double = _double;
        Empty = empty;
        _Float = _float;
        FloatingPointNumber = floatingPointNumber;
        _Int = _int;
        IntegralNumber = integralNumber;
        _Long = _long;
        MissingNode = missingNode;
        NodeType = nodeType;
        _Null = _null;
        Number = number;
        _Object = _object;
        Pojo = pojo;
        _Short = _short;
        Textual = textual;
        ValueNode = valueNode;
    }

    /// <summary>
    ///     Gets or Sets NodeType
    /// </summary>
    [DataMember(Name = "nodeType", EmitDefaultValue = false)]
    public NodeTypeEnum? NodeType { get; set; }

    /// <summary>
    ///     Gets or Sets Array
    /// </summary>
    [DataMember(Name = "array", EmitDefaultValue = false)]
    public bool? Array { get; set; }

    /// <summary>
    ///     Gets or Sets BigDecimal
    /// </summary>
    [DataMember(Name = "bigDecimal", EmitDefaultValue = false)]
    public bool? BigDecimal { get; set; }

    /// <summary>
    ///     Gets or Sets BigInteger
    /// </summary>
    [DataMember(Name = "bigInteger", EmitDefaultValue = false)]
    public bool? BigInteger { get; set; }

    /// <summary>
    ///     Gets or Sets Binary
    /// </summary>
    [DataMember(Name = "binary", EmitDefaultValue = false)]
    public bool? Binary { get; set; }

    /// <summary>
    ///     Gets or Sets Boolean
    /// </summary>
    [DataMember(Name = "boolean", EmitDefaultValue = false)]
    public bool? Boolean { get; set; }

    /// <summary>
    ///     Gets or Sets ContainerNode
    /// </summary>
    [DataMember(Name = "containerNode", EmitDefaultValue = false)]
    public bool? ContainerNode { get; set; }

    /// <summary>
    ///     Gets or Sets _Double
    /// </summary>
    [DataMember(Name = "double", EmitDefaultValue = false)]
    public bool? _Double { get; set; }

    /// <summary>
    ///     Gets or Sets Empty
    /// </summary>
    [DataMember(Name = "empty", EmitDefaultValue = false)]
    public bool? Empty { get; set; }

    /// <summary>
    ///     Gets or Sets _Float
    /// </summary>
    [DataMember(Name = "float", EmitDefaultValue = false)]
    public bool? _Float { get; set; }

    /// <summary>
    ///     Gets or Sets FloatingPointNumber
    /// </summary>
    [DataMember(Name = "floatingPointNumber", EmitDefaultValue = false)]
    public bool? FloatingPointNumber { get; set; }

    /// <summary>
    ///     Gets or Sets _Int
    /// </summary>
    [DataMember(Name = "int", EmitDefaultValue = false)]
    public bool? _Int { get; set; }

    /// <summary>
    ///     Gets or Sets IntegralNumber
    /// </summary>
    [DataMember(Name = "integralNumber", EmitDefaultValue = false)]
    public bool? IntegralNumber { get; set; }

    /// <summary>
    ///     Gets or Sets _Long
    /// </summary>
    [DataMember(Name = "long", EmitDefaultValue = false)]
    public bool? _Long { get; set; }

    /// <summary>
    ///     Gets or Sets MissingNode
    /// </summary>
    [DataMember(Name = "missingNode", EmitDefaultValue = false)]
    public bool? MissingNode { get; set; }


    /// <summary>
    ///     Gets or Sets _Null
    /// </summary>
    [DataMember(Name = "null", EmitDefaultValue = false)]
    public bool? _Null { get; set; }

    /// <summary>
    ///     Gets or Sets Number
    /// </summary>
    [DataMember(Name = "number", EmitDefaultValue = false)]
    public bool? Number { get; set; }

    /// <summary>
    ///     Gets or Sets _Object
    /// </summary>
    [DataMember(Name = "object", EmitDefaultValue = false)]
    public bool? _Object { get; set; }

    /// <summary>
    ///     Gets or Sets Pojo
    /// </summary>
    [DataMember(Name = "pojo", EmitDefaultValue = false)]
    public bool? Pojo { get; set; }

    /// <summary>
    ///     Gets or Sets _Short
    /// </summary>
    [DataMember(Name = "short", EmitDefaultValue = false)]
    public bool? _Short { get; set; }

    /// <summary>
    ///     Gets or Sets Textual
    /// </summary>
    [DataMember(Name = "textual", EmitDefaultValue = false)]
    public bool? Textual { get; set; }

    /// <summary>
    ///     Gets or Sets ValueNode
    /// </summary>
    [DataMember(Name = "valueNode", EmitDefaultValue = false)]
    public bool? ValueNode { get; set; }

    /// <summary>
    ///     Returns true if JsonNode instances are equal
    /// </summary>
    /// <param name="input">Instance of JsonNode to be compared</param>
    /// <returns>Boolean</returns>
    public bool Equals(JsonNode input)
    {
        if (input == null)
            return false;

        return
            (
                Array == input.Array ||
                (Array != null &&
                 Array.Equals(input.Array))
            ) &&
            (
                BigDecimal == input.BigDecimal ||
                (BigDecimal != null &&
                 BigDecimal.Equals(input.BigDecimal))
            ) &&
            (
                BigInteger == input.BigInteger ||
                (BigInteger != null &&
                 BigInteger.Equals(input.BigInteger))
            ) &&
            (
                Binary == input.Binary ||
                (Binary != null &&
                 Binary.Equals(input.Binary))
            ) &&
            (
                Boolean == input.Boolean ||
                (Boolean != null &&
                 Boolean.Equals(input.Boolean))
            ) &&
            (
                ContainerNode == input.ContainerNode ||
                (ContainerNode != null &&
                 ContainerNode.Equals(input.ContainerNode))
            ) &&
            (
                _Double == input._Double ||
                (_Double != null &&
                 _Double.Equals(input._Double))
            ) &&
            (
                Empty == input.Empty ||
                (Empty != null &&
                 Empty.Equals(input.Empty))
            ) &&
            (
                _Float == input._Float ||
                (_Float != null &&
                 _Float.Equals(input._Float))
            ) &&
            (
                FloatingPointNumber == input.FloatingPointNumber ||
                (FloatingPointNumber != null &&
                 FloatingPointNumber.Equals(input.FloatingPointNumber))
            ) &&
            (
                _Int == input._Int ||
                (_Int != null &&
                 _Int.Equals(input._Int))
            ) &&
            (
                IntegralNumber == input.IntegralNumber ||
                (IntegralNumber != null &&
                 IntegralNumber.Equals(input.IntegralNumber))
            ) &&
            (
                _Long == input._Long ||
                (_Long != null &&
                 _Long.Equals(input._Long))
            ) &&
            (
                MissingNode == input.MissingNode ||
                (MissingNode != null &&
                 MissingNode.Equals(input.MissingNode))
            ) &&
            (
                NodeType == input.NodeType ||
                (NodeType != null &&
                 NodeType.Equals(input.NodeType))
            ) &&
            (
                _Null == input._Null ||
                (_Null != null &&
                 _Null.Equals(input._Null))
            ) &&
            (
                Number == input.Number ||
                (Number != null &&
                 Number.Equals(input.Number))
            ) &&
            (
                _Object == input._Object ||
                (_Object != null &&
                 _Object.Equals(input._Object))
            ) &&
            (
                Pojo == input.Pojo ||
                (Pojo != null &&
                 Pojo.Equals(input.Pojo))
            ) &&
            (
                _Short == input._Short ||
                (_Short != null &&
                 _Short.Equals(input._Short))
            ) &&
            (
                Textual == input.Textual ||
                (Textual != null &&
                 Textual.Equals(input.Textual))
            ) &&
            (
                ValueNode == input.ValueNode ||
                (ValueNode != null &&
                 ValueNode.Equals(input.ValueNode))
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
        sb.Append("class JsonNode {\n");
        sb.Append("  Array: ").Append(Array).Append("\n");
        sb.Append("  BigDecimal: ").Append(BigDecimal).Append("\n");
        sb.Append("  BigInteger: ").Append(BigInteger).Append("\n");
        sb.Append("  Binary: ").Append(Binary).Append("\n");
        sb.Append("  Boolean: ").Append(Boolean).Append("\n");
        sb.Append("  ContainerNode: ").Append(ContainerNode).Append("\n");
        sb.Append("  _Double: ").Append(_Double).Append("\n");
        sb.Append("  Empty: ").Append(Empty).Append("\n");
        sb.Append("  _Float: ").Append(_Float).Append("\n");
        sb.Append("  FloatingPointNumber: ").Append(FloatingPointNumber).Append("\n");
        sb.Append("  _Int: ").Append(_Int).Append("\n");
        sb.Append("  IntegralNumber: ").Append(IntegralNumber).Append("\n");
        sb.Append("  _Long: ").Append(_Long).Append("\n");
        sb.Append("  MissingNode: ").Append(MissingNode).Append("\n");
        sb.Append("  NodeType: ").Append(NodeType).Append("\n");
        sb.Append("  _Null: ").Append(_Null).Append("\n");
        sb.Append("  Number: ").Append(Number).Append("\n");
        sb.Append("  _Object: ").Append(_Object).Append("\n");
        sb.Append("  Pojo: ").Append(Pojo).Append("\n");
        sb.Append("  _Short: ").Append(_Short).Append("\n");
        sb.Append("  Textual: ").Append(Textual).Append("\n");
        sb.Append("  ValueNode: ").Append(ValueNode).Append("\n");
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
        return Equals(input as JsonNode);
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
            if (Array != null)
                hashCode = hashCode * 59 + Array.GetHashCode();
            if (BigDecimal != null)
                hashCode = hashCode * 59 + BigDecimal.GetHashCode();
            if (BigInteger != null)
                hashCode = hashCode * 59 + BigInteger.GetHashCode();
            if (Binary != null)
                hashCode = hashCode * 59 + Binary.GetHashCode();
            if (Boolean != null)
                hashCode = hashCode * 59 + Boolean.GetHashCode();
            if (ContainerNode != null)
                hashCode = hashCode * 59 + ContainerNode.GetHashCode();
            if (_Double != null)
                hashCode = hashCode * 59 + _Double.GetHashCode();
            if (Empty != null)
                hashCode = hashCode * 59 + Empty.GetHashCode();
            if (_Float != null)
                hashCode = hashCode * 59 + _Float.GetHashCode();
            if (FloatingPointNumber != null)
                hashCode = hashCode * 59 + FloatingPointNumber.GetHashCode();
            if (_Int != null)
                hashCode = hashCode * 59 + _Int.GetHashCode();
            if (IntegralNumber != null)
                hashCode = hashCode * 59 + IntegralNumber.GetHashCode();
            if (_Long != null)
                hashCode = hashCode * 59 + _Long.GetHashCode();
            if (MissingNode != null)
                hashCode = hashCode * 59 + MissingNode.GetHashCode();
            if (NodeType != null)
                hashCode = hashCode * 59 + NodeType.GetHashCode();
            if (_Null != null)
                hashCode = hashCode * 59 + _Null.GetHashCode();
            if (Number != null)
                hashCode = hashCode * 59 + Number.GetHashCode();
            if (_Object != null)
                hashCode = hashCode * 59 + _Object.GetHashCode();
            if (Pojo != null)
                hashCode = hashCode * 59 + Pojo.GetHashCode();
            if (_Short != null)
                hashCode = hashCode * 59 + _Short.GetHashCode();
            if (Textual != null)
                hashCode = hashCode * 59 + Textual.GetHashCode();
            if (ValueNode != null)
                hashCode = hashCode * 59 + ValueNode.GetHashCode();
            return hashCode;
        }
    }
}