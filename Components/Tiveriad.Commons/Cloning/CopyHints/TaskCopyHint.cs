namespace Tiveriad.Commons.Cloning.CopyHints;

/// <summary>Handles copying tasks for the cloner.</summary>
public sealed class TaskCopyHint : CopyHint
{
    /// <inheritdoc />
    protected internal override (bool, object) TryCopy(object source, CloneChainer clone)
    {
        if (clone == null) throw new ArgumentNullException(nameof(clone));
        if (source == null) return (true, null);

        if (source is Task task && task.GetType().IsGenericType)
            return (true, Copy(task, clone));
        return (false, null);
    }

    /// <summary>Deep clones an object.</summary>
    /// <param name="source">Object to clone.</param>
    /// <param name="clone">Handles callback behavior for child values.</param>
    /// <returns>Duplicate object.</returns>
    private static Task Copy(Task source, CloneChainer clone)
    {
        var taskType = source.GetType();

        var content = taskType.GetProperty(nameof(Task<object>.Result)).GetValue(source);

        return (Task)typeof(Task)
            .GetMethod(nameof(Task.FromResult))
            .MakeGenericMethod(taskType.GetGenericArguments().Single())
            .Invoke(null, new[] { clone.Copy(content) });
    }
}