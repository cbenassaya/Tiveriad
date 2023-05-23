#region

using System.Text;
using Tiveriad.Commons.Extensions;

#endregion

namespace Tiveriad.Commons.HttpApis;

/// <summary>
///     Build and modify uniform resource locator (URL)
/// </summary>
public class UrlBuilder
{
    //scheme:[//[user[:password]@]host[:port]][/path][?query][#fragment]

    private static readonly Dictionary<string, int?> _schemePorts = new(StringComparer.OrdinalIgnoreCase)
    {
        { "acap", 674 },
        { "afp", 548 },
        { "dict", 2628 },
        { "dns", 53 },
        { "file", null },
        { "ftp", 21 },
        { "git", 9418 },
        { "gopher", 70 },
        { "http", 80 },
        { "https", 443 },
        { "imap", 143 },
        { "ipp", 631 },
        { "ipps", 631 },
        { "irc", 194 },
        { "ircs", 6697 },
        { "ldap", 389 },
        { "ldaps", 636 },
        { "mms", 1755 },
        { "msrp", 2855 },
        { "msrps", null },
        { "mtqp", 1038 },
        { "nfs", 111 },
        { "nntp", 119 },
        { "nntps", 563 },
        { "pop", 110 },
        { "prospero", 1525 },
        { "redis", 6379 },
        { "rsync", 873 },
        { "rtsp", 554 },
        { "rtsps", 322 },
        { "rtspu", 5005 },
        { "sftp", 22 },
        { "smb", 445 },
        { "snmp", 161 },
        { "ssh", 22 },
        { "steam", null },
        { "svn", 3690 },
        { "telnet", 23 },
        { "ventrilo", 3784 },
        { "vnc", 5900 },
        { "wais", 210 },
        { "ws", 80 },
        { "wss", 443 },
        { "xmpp", null }
    };

    private readonly string _schemeDelimiter;

    private int? _port;

    /// <summary>
    ///     Initializes a new instance of the <see cref="UrlBuilder" /> class.
    /// </summary>
    public UrlBuilder()
    {
        Query = new Dictionary<string, ICollection<string>>();
        Path = new List<string>();
        Fragment = string.Empty;
        Host = "localhost";
        Password = string.Empty;
        Scheme = "http";
        _schemeDelimiter = "://";
        UserName = string.Empty;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="UrlBuilder" /> with the specified <paramref name="uri" />.
    /// </summary>
    /// <param name="uri">A URI string.</param>
    /// <exception cref="ArgumentNullException">uri is null</exception>
    public UrlBuilder(string uri) : this()
    {
        if (uri == null)
            throw new ArgumentNullException(nameof(uri));

        // setting allowRelative=true for a string like www.acme.org
        var tryUri = new Uri(uri, UriKind.RelativeOrAbsolute);

        if (tryUri.IsAbsoluteUri)
        {
            SetFieldsFromUri(tryUri);
        }
        else
        {
            uri = "http://" + uri;
            SetFieldsFromUri(new Uri(uri));
        }
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="UrlBuilder" /> with the specified <paramref name="uri" />.
    /// </summary>
    /// <param name="uri">An instance of the <see cref="Uri" /> class</param>
    /// <exception cref="ArgumentNullException">uri is null</exception>
    public UrlBuilder(Uri uri) : this()
    {
        if (uri == null)
            throw new ArgumentNullException(nameof(uri));

        SetFieldsFromUri(uri);
    }


    /// <summary>
    ///     Gets the scheme name of the Url.
    /// </summary>
    /// <value>
    ///     The scheme name of the Url.
    /// </value>
    public string Scheme { get; private set; }

    /// <summary>
    ///     Gets the user name associated with the user that accesses the Url.
    /// </summary>
    /// <value>
    ///     The user name associated with the user that accesses the Url.
    /// </value>
    public string UserName { get; private set; }

    /// <summary>
    ///     Gets the password associated with the user that accesses the Url.
    /// </summary>
    /// <value>
    ///     The password associated with the user that accesses the Url.
    /// </value>
    public string Password { get; private set; }

    /// <summary>
    ///     Gets the Domain Name System (DNS) host name or IP address of a server.
    /// </summary>
    /// <value>
    ///     The Domain Name System (DNS) host name or IP address of a server.
    /// </value>
    public string Host { get; private set; }

    /// <summary>
    ///     Gets the port number of the Url.
    /// </summary>
    /// <value>
    ///     The port number of the Url.
    /// </value>
    public int? Port => GetStandardPort();

    /// <summary>
    ///     Gets the path segment collection to the resource referenced by the Url.
    /// </summary>
    /// <value>
    ///     The path segment collection to the resource referenced by the Url.
    /// </value>
    public IList<string> Path { get; }

    /// <summary>
    ///     Gets the query string dictionary information included in the Url.
    /// </summary>
    /// <value>
    ///     The query string dictionary information included in the Url.
    /// </value>
    public IDictionary<string, ICollection<string>> Query { get; }

    /// <summary>
    ///     Gets the fragment portion of the Url.
    /// </summary>
    /// <value>
    ///     The fragment portion of the Url.
    /// </value>
    public string Fragment { get; private set; }


    /// <summary>
    ///     Replace the schema name for the current Url.
    /// </summary>
    /// <param name="value">The schema name.</param>
    /// <returns></returns>
    public UrlBuilder SetScheme(string value)
    {
        if (value == null)
            value = string.Empty;

        var index = value.IndexOf(':');
        if (index != -1)
            value = value.Substring(0, index);

        if (value.Length != 0)
        {
            if (!Uri.CheckSchemeName(value))
                throw new ArgumentException("Invalid URI: The URI scheme is not valid.", nameof(value));

            value = value.ToLowerInvariant();
        }

        Scheme = value;
        return this;
    }

    /// <summary>
    ///     Replace the user name for the current Url.
    /// </summary>
    /// <param name="value">The user name associated with the user that access the Url.</param>
    /// <returns></returns>
    public UrlBuilder SetUserName(string value)
    {
        if (value == null)
            value = string.Empty;

        UserName = value;
        return this;
    }

    /// <summary>
    ///     Replace the password for the current Url.
    /// </summary>
    /// <param name="value">The password associated with the user that access the Url.</param>
    /// <returns></returns>
    public UrlBuilder SetPassword(string value)
    {
        if (value == null)
            value = string.Empty;

        Password = value;
        return this;
    }

    /// <summary>
    ///     Replace the Domain Name System (DNS) host name or IP address for the current Url.
    /// </summary>
    /// <param name="value">The Domain Name System (DNS) host name or IP address.</param>
    /// <returns></returns>
    public UrlBuilder SetHost(string value)
    {
        if (value == null)
            value = string.Empty;

        Host = value;
        //probable ipv6 address - Note: this is only supported for cases where the authority is inet-based.
        if (Host.IndexOf(':') >= 0)
            //set brackets
            if (Host[0] != '[')
                Host = "[" + Host + "]";

        return this;
    }

    /// <summary>
    ///     Replace the port number for the current Url.
    /// </summary>
    /// <param name="value">The port number.</param>
    /// <returns></returns>
    public UrlBuilder SetPort(int value)
    {
        if (value < -1 || value > 0xFFFF)
            throw new ArgumentOutOfRangeException(nameof(value));

        _port = value;
        return this;
    }

    /// <summary>
    ///     Replace the port number for the current Url.
    /// </summary>
    /// <param name="value">The port number.</param>
    /// <returns></returns>
    public UrlBuilder SetPort(string value)
    {
        if (!string.IsNullOrEmpty(value) && int.TryParse(value, out var port))
            return SetPort(port);

        _port = null;
        return this;
    }

    /// <summary>
    ///     Replace the fragment portion for the current Url.
    /// </summary>
    /// <param name="value">The fragment portion.</param>
    /// <returns></returns>
    public UrlBuilder SetFragment(string value)
    {
        if (value == null)
            value = string.Empty;

        if (value.Length > 0 && value[0] != '#')
            value = '#' + value;

        Fragment = value;
        return this;
    }


    /// <summary>
    ///     Appends a path segment to the current Url.
    /// </summary>
    /// <param name="path">The path segment to append.</param>
    /// <returns></returns>
    public UrlBuilder AppendPath(Uri path)
    {
        if (path == null)
            return this;

        ParsePath(path.AbsolutePath);

        return this;
    }

    /// <summary>
    ///     Appends a path segment to the current Url.
    /// </summary>
    /// <param name="path">The path segment to append.</param>
    /// <returns></returns>
    public UrlBuilder AppendPath(string path)
    {
        if (path == null)
            return this;

        ParsePath(path);

        return this;
    }

    /// <summary>
    ///     Appends a path segment to the current Url.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="path">The path segment to append.</param>
    /// <returns></returns>
    public UrlBuilder AppendPath<TValue>(TValue path)
    {
        if (path == null)
            return this;

        var v = path.ToString();
        ParsePath(v);

        return this;
    }

    /// <summary>
    ///     Appends the path segments to the current Url.
    /// </summary>
    /// <param name="paths">The path segments to append.</param>
    /// <returns></returns>
    public UrlBuilder AppendPath(IEnumerable<string> paths)
    {
        if (paths == null)
            return this;

        foreach (var path in paths)
            ParsePath(path);

        return this;
    }

    /// <summary>
    ///     Appends the path segments to the current Url.
    /// </summary>
    /// <param name="paths">The path segments to append.</param>
    /// <returns></returns>
    public UrlBuilder AppendPaths(params string[] paths)
    {
        if (paths == null)
            return this;

        foreach (var path in paths)
            ParsePath(path);

        return this;
    }

    /// <summary>
    ///     Appends a string formatted path segment to the current Url.
    /// </summary>
    /// <param name="format">A composite format string.</param>
    /// <param name="arguments">An array that contains zero or more objects to format.</param>
    /// <returns></returns>
    public UrlBuilder AppendPathFormat(string format, params object[] arguments)
    {
        var p = string.Format(format, arguments);

        return AppendPath(p);
    }


    /// <summary>
    ///     Replace the entire path for the current Url.  The <see cref="Path" /> collection is replaced with this path.
    /// </summary>
    /// <param name="path">The path segment to set.</param>
    /// <returns></returns>
    public UrlBuilder SetPath(string path)
    {
        Path.Clear();
        if (path == null)
            return this;

        ParsePath(path);
        return this;
    }


    /// <summary>
    ///     Appends the query string name and value to the current url.
    /// </summary>
    /// <param name="name">The query string name.</param>
    /// <param name="value">The query string value.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">name is <c>null</c></exception>
    public UrlBuilder AppendQuery(string name, string value)
    {
        if (name == null)
            throw new ArgumentNullException(nameof(name));

        var v = value ?? string.Empty;

        var list = Query.GetOrAdd(name, n => new List<string>());
        list.Add(v);

        return this;
    }

    /// <summary>
    ///     Appends the query string name and value to the current url.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="name">The query string name.</param>
    /// <param name="value">The query string value.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">name is <c>null</c></exception>
    public UrlBuilder AppendQuery<TValue>(string name, TValue value)
    {
        if (name == null)
            throw new ArgumentNullException(nameof(name));

        var v = value != null ? value.ToString() : string.Empty;
        return AppendQuery(name, v);
    }

    /// <summary>
    ///     Conditionally appends the query string name and value to the current url if the specified
    ///     <paramref name="condition" /> is <c>true</c>.
    /// </summary>
    /// <param name="condition">The condition on weather the query string is appended.</param>
    /// <param name="name">The query string name.</param>
    /// <param name="value">The query string value.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">name is <c>null</c></exception>
    public UrlBuilder AppendQueryIf(Func<bool> condition, string name, string value)
    {
        if (condition == null || !condition())
            return this;

        return AppendQuery(name, value);
    }

    /// <summary>
    ///     Conditionally appends the query string name and value to the current url if the specified
    ///     <paramref name="condition" /> is <c>true</c>.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <param name="condition">The condition on weather the query string is appended.</param>
    /// <param name="name">The query string name.</param>
    /// <param name="value">The query string value.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">name is <c>null</c></exception>
    public UrlBuilder AppendQueryIf<TValue>(Func<bool> condition, string name, TValue value)
    {
        if (condition == null || !condition())
            return this;

        return AppendQuery(name, value);
    }

    /// <summary>
    ///     Appends the query string to the current url.
    /// </summary>
    /// <param name="queryString">The query string to append.</param>
    /// <returns></returns>
    public UrlBuilder AppendQuery(string queryString)
    {
        if (queryString == null)
            return this;

        ParseQueryString(queryString);
        return this;
    }


    /// <summary>
    ///     Replace the entire query string for the current Url.  The <see cref="Query" /> dictionary is replaced with this
    ///     query string.
    /// </summary>
    /// <param name="queryString">The query string to set.</param>
    /// <returns></returns>
    public UrlBuilder SetQuery(string queryString)
    {
        Query.Clear();
        if (queryString == null)
            return this;

        ParseQueryString(queryString);

        return this;
    }


    /// <summary>
    ///     Returns a <see cref="System.Uri" /> that represents this instance.
    /// </summary>
    /// <returns>
    ///     A <see cref="System.Uri" /> that represents this instance.
    /// </returns>
    public Uri ToUri()
    {
        var url = ToString();
        var uri = new Uri(url, UriKind.Absolute);

        return uri;
    }

    /// <summary>
    ///     Returns a <see cref="System.String" /> that represents this instance.
    /// </summary>
    /// <returns>
    ///     A <see cref="System.String" /> that represents this instance.
    /// </returns>
    public override string ToString()
    {
        var builder = new StringBuilder();

        if (!string.IsNullOrWhiteSpace(Scheme))
            builder.Append(Scheme).Append(_schemeDelimiter);

        if (!string.IsNullOrWhiteSpace(UserName))
        {
            builder.Append(UserName);
            if (!string.IsNullOrWhiteSpace(Password))
                builder.Append(":").Append(Password);

            builder.Append("@");
        }

        if (!string.IsNullOrWhiteSpace(Host))
        {
            builder.Append(Host);
            if (_port.HasValue && !IsStandardPort())
                builder.Append(":").Append(_port);
        }

        WritePath(builder);
        WriteQueryString(builder);

        if (!string.IsNullOrWhiteSpace(Fragment))
            builder.Append(Fragment);

        return builder.ToString();
    }


    private bool IsStandardPort()
    {
        if (_schemePorts.TryGetValue(Scheme, out var port))
            return port == _port;

        return false;
    }


    private void WritePath(StringBuilder builder)
    {
        builder.Append("/");
        if (Path == null || Path.Count == 0)
            return;

        var start = builder.Length;
        foreach (var p in Path)
        {
            if (builder.Length > start)
                builder.Append("/");

            var s = p.Replace(" ", "+");
            s = Uri.EscapeUriString(s);

            builder.Append(s);
        }
    }

    private void WriteQueryString(StringBuilder builder)
    {
        if (Query == null || Query.Count == 0)
            return;

        builder.Append("?");

        var start = builder.Length;
        foreach (var pair in Query)
        {
            var key = pair.Key;
            key = Uri.EscapeDataString(key);
            key = key.Replace("%20", "+");

            var values = pair.Value.ToList();

            foreach (var value in values)
            {
                if (builder.Length > start)
                    builder.Append("&");

                var v = value;
                v = Uri.EscapeDataString(v);
                v = v.Replace("%20", "+");

                builder
                    .Append(key)
                    .Append("=")
                    .Append(v);
            }
        }
    }


    private void SetFieldsFromUri(Uri uri)
    {
        Scheme = uri.Scheme;
        Host = uri.Host;
        _port = uri.Port;
        Fragment = uri.Fragment;

        ParseQueryString(uri.Query);
        ParsePath(uri.AbsolutePath);

        var userInfo = uri.UserInfo;

        if (userInfo.Length <= 0)
            return;

        var index = userInfo.IndexOf(':');

        if (index != -1)
        {
            Password = userInfo.Substring(index + 1);
            UserName = userInfo.Substring(0, index);
        }
        else
        {
            UserName = userInfo;
        }
    }

    // based on HttpUtility.ParseQueryString
    private void ParseQueryString(string s)
    {
        if (string.IsNullOrEmpty(s))
            return;

        var l = s.Length;
        var i = 0;

        // remove leading ?
        if (s[0] == '?')
            i = 1;

        while (i < l)
        {
            // find next & while noting first = on the way (and if there are more)
            var si = i;
            var ti = -1;

            while (i < l)
            {
                var ch = s[i];

                if (ch == '=')
                {
                    if (ti < 0)
                        ti = i;
                }
                else if (ch == '&')
                {
                    break;
                }

                i++;
            }

            // extract the name / value pair
            string name = null;
            string value = null;

            if (ti >= 0)
            {
                name = s.Substring(si, ti - si);
                value = s.Substring(ti + 1, i - ti - 1);
            }
            else
            {
                value = s.Substring(si, i - si);
            }

            // decode
            name = string.IsNullOrEmpty(name) ? string.Empty : Uri.UnescapeDataString(name);
            value = string.IsNullOrEmpty(value) ? string.Empty : Uri.UnescapeDataString(value);

            // add name / value pair to the collection
            if (!string.IsNullOrEmpty(name))
                AppendQuery(name, value);

            // trailing '&'

            //if (i == l-1 && s[i] == '&')
            //    base.Add(null, String.Empty);

            i++;
        }
    }

    private void ParsePath(string s)
    {
        if (string.IsNullOrEmpty(s))
            return;

        var parts = s.Split('/');
        foreach (var part in parts)
        {
            if (string.IsNullOrEmpty(part))
                continue;

            var p = Uri.UnescapeDataString(part);

            Path.Add(p);
        }
    }


    private int? GetStandardPort()
    {
        if (_port.HasValue)
            return _port;

        if (string.IsNullOrEmpty(Scheme))
            return _port;

        _schemePorts.TryGetValue(Scheme, out var port);
        return port;
    }
}