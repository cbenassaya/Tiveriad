using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tiveriad.Repositories;

public sealed class InternationalizedString
{
        private CultureInfo _cultureInfo;
        private IList<KeyValuePair<string, string>> _values;

        public InternationalizedString()
        {
            _values = new List<KeyValuePair<string, string>>();
        }


        public CultureInfo CultureInfo
        {
            get => _cultureInfo ?? CultureInfo.CurrentCulture;
            set => _cultureInfo = value;
        }

        public static implicit operator InternationalizedString(string valuesString)
        {
            var internationalizedString = new InternationalizedString();
            if (string.IsNullOrEmpty(valuesString)) return internationalizedString;
            try
            {
                if (IsJson(valuesString))
                    internationalizedString._values =
                        JsonSerializer.Deserialize<IList<KeyValuePair<string, string>>>(valuesString);
                else
                    internationalizedString.SetValue(valuesString);
            }
            catch
            {
                // ignored
            }

            return internationalizedString;
        }

        public static implicit operator string(InternationalizedString b)
        {
            if (b == null) return string.Empty;
            return b.ToString();
        }

        public void SetValue(string value)
        {
            var count = _values.Count(item => item.Key == CultureInfo.Name);
            if (count > 0)
            {
                var keyValue = _values.FirstOrDefault(item => item.Key == CultureInfo.Name);
                _values.Remove(keyValue);
            }

            _values.Add(new KeyValuePair<string, string>(CultureInfo.Name, value));
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