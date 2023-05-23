#region

using System.Globalization;
using Tiveriad.Commons.Extensions;

#endregion

namespace Tiveriad.TextTemplating;

public class TemplateDefinition
{
    private TemplateDefinition(string name, string layout, CultureInfo? cultureInfo)
    {
        Properties = new Dictionary<string, object>();
        Layout = layout;
        CultureInfo = cultureInfo;
        Name = name;
    }

    public CultureInfo? CultureInfo { get; }
    public Dictionary<string, object> Properties { get; }

    public object this[string name]
    {
        get => Properties.GetOrDefault(name);
        set => Properties[name] = value;
    }

    public string Layout { get; }

    public string Name { get; }

    public static TemplateDefinition With(string name, string layout, CultureInfo? cultureInfo = default)
    {
        return new TemplateDefinition(
            name,
            layout,
            cultureInfo
        );
    }
}