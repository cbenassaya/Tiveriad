using System.Collections.Concurrent;
using System.Globalization;
using System.Text.Json;

namespace Tiveriad.Core.Abstractions.Entities;

public sealed class InternationalizedString
{
        private CultureInfo _cultureInfo;
        private ConcurrentDictionary<string,string> _values = new ();

        
        public string Value => ToString();


        public CultureInfo CultureInfo
        {
            get => _cultureInfo ?? CultureInfo.CurrentCulture;
            set => _cultureInfo = value;
        }

        public static implicit operator InternationalizedString(string valuesString)
        {
            var internationalizedString = new InternationalizedString();
            if (string.IsNullOrEmpty(valuesString)) return internationalizedString;
            internationalizedString.SetValue(valuesString);
            return internationalizedString;
        }

        public static implicit operator string(InternationalizedString b)
        {
            if (b == null) return string.Empty;
            return b.GetValue() ?? string.Empty;
        }

        public void SetValue(string value)
        {
            try
            {
                if (IsJson(value))
                    _values = JsonSerializer.Deserialize<ConcurrentDictionary<string,string>>(value);
                else
                    _values.AddOrUpdate(CultureInfo.Name, value, (key, oldValue) => value);
            }
            catch
            {
                // ignored
            }
        }

        public string GetValue()
        {
            _values.TryGetValue(CultureInfo.Name, out var value);
            return value;
        }



        public override string ToString()
        {
            return JsonSerializer.Serialize(_values);
        }

        private static bool IsJson(string input)
        {
            input = input.Trim();
            return input.StartsWith("{") && input.EndsWith("}")
                   || input.StartsWith("[") && input.EndsWith("]");
        }
    }