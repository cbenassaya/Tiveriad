using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text.Json;

namespace Tiveriad.Repositories;

public sealed class Metadata : DynamicObject
{
    private IDictionary<string, object> _properties;

    public Metadata()
    {
        _properties = new Dictionary<string, object>();
    }

    public object this[string propertyName]
    {
        get
        {
            if (_properties.ContainsKey(propertyName)) return _properties[propertyName];

            return null;
        }
        set => _properties[propertyName] = value;
    }

    public static implicit operator Metadata(string b)
    {
        var value = new Metadata();
        value._properties = JsonSerializer.Deserialize<Dictionary<string, object>>(b);
        return value;
    }

    public static implicit operator string(Metadata b)
    {
        if (b == null) return string.Empty;
        return b.ToString();
    }
    
    public static implicit operator Metadata(Dictionary<string,object> b)
    {
        var value = new Metadata();
        value._properties = b;
        return value;
    }

    public static implicit operator Dictionary<string,object>(Metadata b)
    {
        if (b == null) return new Dictionary<string, object>();
        return b._properties.ToDictionary(x=>x.Key,x=>x.Value);
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(_properties);
    }

    public override bool TryGetMember(GetMemberBinder binder, out object result)
    {
        if (_properties.ContainsKey(binder.Name))
        {
            result = _properties[binder.Name];
            return true;
        }

        result = null;
        return true;
    }

    public override bool TrySetMember(SetMemberBinder binder, object value)
    {
        _properties[binder.Name] = value;
        return true;
    }
}