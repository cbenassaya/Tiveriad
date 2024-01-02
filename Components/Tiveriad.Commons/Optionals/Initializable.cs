
namespace Tiveriad.Commons.Optionals;

/// <summary>
///     A value which can either be initialized or not.
/// </summary>
/// <typeparam name="T">Type of the value.</typeparam>
public class Initializable<T> : IInitializable<T>
{
    private T value;

    private Initializable()
    {
    }

    /// <summary>
    ///     Gets a value indicating whether this instance is initialized (has a set value).
    /// </summary>
    /// <value>
    ///     <c>true</c> if this instance is initialized; otherwise, <c>false</c>.
    /// </value>
    public bool IsInitialized { get; private set; }

    public Initializable<TResult> Map<TResult>(Func<T, TResult> func)
    {
        return
            IsInitialized
                ? Initializable<TResult>.Initialized(func(value))
                : Initializable<TResult>.UnInitialized();
    }

    public T ExtractOrThrow()
    {
        CheckInitialized();
        return value;
    }

    public static Initializable<T> UnInitialized()
    {
        return new Initializable<T>();
    }

    public static Initializable<T> Initialized(T t)
    {
        return new Initializable<T>
        {
            value = t,
            IsInitialized = true
        };
    }

    public T ExtractOr(T valueIfNotInitialized)
    {
        return
            IsInitialized
                ? value
                : valueIfNotInitialized;
    }

    private void CheckInitialized()
    {
        if (!IsInitialized) throw new InvalidOperationException();
    }
}