using Microsoft.Extensions.FileProviders;
using Tiveriad.Commons.Extensions;
using Tiveriad.TextTemplating.Extensions;

namespace Tiveriad.TextTemplating;

public class TemplateManager : ITemplateManager
{
    private readonly IDictionary<string, IFileInfo> _fileInfos;

    public TemplateManager(IDictionary<string, IFileInfo> fileInfos)
    {
        _fileInfos = fileInfos;
    }

    public TemplateDefinition Get(string name)
    {
        var fileInfo = _fileInfos.GetOrDefault(name);
        ArgumentNullException.ThrowIfNull(fileInfo);

        using var stream = fileInfo.CreateReadStream();
        using var streamReader = new StreamReader(stream);

        return TemplateDefinition.With(name, streamReader.ReadToEnd(), fileInfo.GetCultureInfo());
    }
}