using System.ComponentModel.DataAnnotations.Schema;

namespace Tiveriad.Core.Abstractions.Entities;

[NotMapped]
public class Visibility
{
    private string _value;

    public Visibility()
    {
        _value = Private._value;
    }
    private Visibility(string value)
    {
        _value = value;
    }
    
    public static implicit operator Visibility(string valuesString)
    {
        if (string.IsNullOrEmpty(valuesString)) return Public;
        return ((ReadOnlySpan<string>)["Public","Private"]).Contains(valuesString) ? new Visibility(valuesString) : Public;
    }

    public static implicit operator string(Visibility? visibility)
    {
        if (visibility == null) return string.Empty;
        return visibility._value;
    }
    
    public static Visibility Public => new Visibility("Public");
    public static Visibility Private => new Visibility("Private");
    
}