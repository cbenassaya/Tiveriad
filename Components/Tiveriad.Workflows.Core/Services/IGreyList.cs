namespace Tiveriad.Workflows.Core.Services;

public interface IGreyList
{
    void Add(string id);
    void Remove(string id);
    bool Contains(string id);
}