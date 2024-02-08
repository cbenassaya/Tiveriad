#region

using System.Collections;
using Tiveriad.Commons.Extensions;

#endregion

namespace Tiveriad.Commons.Reflexions;

public abstract class AbstractProcessor<T, U>
{
    private readonly IList<int> _memory = new List<int>();
    protected abstract bool ApplyIf(T value);
    protected abstract void DoApply(T value);


    public void Traverse(object objectToTraverse)
    {
        _memory.Clear();
        DoTraverse(objectToTraverse);
    }

    private void DoTraverse(object? objectToTraverse)
    {
        if (objectToTraverse == null) return;

        if (_memory.Contains(objectToTraverse.GetHashCode())) return;

        _memory.Add(objectToTraverse.GetHashCode());

        if (objectToTraverse is T objectToApply)
            if (ApplyIf(objectToApply))
                DoApply(objectToApply);

        var propertyInfos = objectToTraverse.GetType().GetProperties()
            .Where(x => x.CanRead && x.GetIndexParameters().Length == 0).ToList();

        foreach (var propertyInfo in propertyInfos)
        {
            var value = propertyInfo.GetValue(objectToTraverse, null);

            if (value is null or string or ValueType) continue;

            if (value is U)
                DoTraverse(value);

            if (value is IEnumerable)
                foreach (var item in value.AsEnumerableItems())
                    if (item is U)
                        DoTraverse(item);
        }
    }
}

public abstract class AbstractProcessor<T> : AbstractProcessor<T, T>
{
}