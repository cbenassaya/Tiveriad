using System.Collections;
using System.Runtime.CompilerServices;

namespace Tiveriad.IdGenerator;

public class StringIdGenerator : IIdGenerator<string>
{
    
    // Object to lock() on while generating Id's
    private readonly object _genlock = new();
    private readonly string _generatorid;
    private int _sequence = 0;
    private long _lastgen = -1;
    private readonly long MASK_SEQUENCE;
    private readonly int MASK_TIME;
    private readonly int MASK_GENERATOR;

    private readonly int SHIFT_TIME;
    private readonly int SHIFT_GENERATOR;
    
    
    /// <summary>
    /// Gets the <see cref="IdGeneratorOptions"/>.
    /// </summary>
    public IdGeneratorOptions Options { get; }
    
    
    /// <summary>
    /// Gets the Id of the generator.
    /// </summary>
    public string Id => (string)_generatorid;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="LongIdGenerator"/> class.
    /// </summary>
    /// <param name="generatorId">The Id of the generator.</param>
    public StringIdGenerator()
        : this(new IdGeneratorOptions()) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="LongIdGenerator"/> class with the specified <see cref="IdGeneratorOptions"/>.
    /// </summary>
    /// <param name="generatorId">The Id of the generator.</param>
    /// <param name="options">The <see cref="IdGeneratorOptions"/> for the <see cref="LongIdGenerator"/></param>.
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="options"/> is null.</exception>
    public StringIdGenerator(IdGeneratorOptions options )
    {
        Options = options ?? throw new ArgumentNullException(nameof(options));

        // Precalculate some values
        MASK_TIME = GetMask(options.IdStructure.TimestampBits);
        MASK_GENERATOR = GetMask(options.IdStructure.GeneratorIdBits);
        MASK_SEQUENCE = GetMask(options.IdStructure.SequenceBits);
        SHIFT_TIME = options.IdStructure.GeneratorIdBits + options.IdStructure.SequenceBits;
        SHIFT_GENERATOR = options.IdStructure.SequenceBits;
    }
    
    
    public string CreateId()
    {
        var id = CreateIdImpl(out var ex);
        if (ex != null)
        {
            throw ex;
        }

        return id;
    }
    
    
    /// <summary>
    /// Creates a new Id.
    /// </summary>
    /// <param name="exception">If any exceptions occur they will be returned in this argument.</param>
    /// <returns>
    /// Returns an Id based on the <see cref="LongIdGenerator"/>'s epoch, generatorid and sequence or
    /// a negative value when an exception occurred.
    /// </returns>
    /// <exception cref="InvalidSystemClockException">Thrown when clock going backwards is detected.</exception>
    /// <exception cref="SequenceOverflowException">Thrown when sequence overflows.</exception>
    private string  CreateIdImpl(out Exception? exception)
    {
        lock (_genlock)
        {
            
            
            var increment = Extensions.NextIncrement();
            var timestamp = DateTime.UtcNow.GetTimestampFromDateTime();
            var random = Extensions.CalculateRandomValue();
            if (random < 0L || random > 1099511627775L)
                throw new ArgumentOutOfRangeException(nameof(random),
                    "The random value must be between 0 and 1099511627775 (it must fit in 5 bytes).");
            if (increment < 0 || increment > 16777215)
                throw new ArgumentOutOfRangeException(nameof(increment),
                    "The increment value must be between 0 and 16777215 (it must fit in 3 bytes).");
            


            // If we're in the same "timeslot" as previous time we generated an Id, up the sequence number
            if (timestamp == _lastgen)
            {
                if (_sequence >= MASK_SEQUENCE)
                {
                    switch (Options.SequenceOverflowStrategy)
                    {
                        case SequenceOverflowStrategy.SpinWait:
                            SpinWait.SpinUntil(() => _lastgen != DateTime.UtcNow.GetTimestampFromDateTime());
                            return CreateIdImpl(out exception); // Try again
                        case SequenceOverflowStrategy.Throw:
                        default:
                            exception = new SequenceOverflowException("Sequence overflow. Refusing to generate id for rest of tick");
                            return string.Empty;
                    }
                }
                _sequence++;
            }
            else // We're in a new(er) "timeslot", so we can reset the sequence and store the new(er) "timeslot"
            {
                _sequence = 0;
                _lastgen = timestamp;
            }

            unchecked
            {
                // If we made it here then no exceptions occurred; make sure we communicate that to the caller by setting `exception` to null
                exception = null;
                return BuildString(timestamp, (int)(random >> 8), (int)(random << 24) | (increment+_sequence));
            }
        }
    }
    
    
    /// <summary>
    /// Build id by shifting all bits into their place
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="c"></param>
    /// <returns></returns>
    private static string BuildString(int a, int b, int c)
    {
        return new string(new char[24]
        {
            ToHexChar((a >> 28) & 15),
            ToHexChar((a >> 24) & 15),
            ToHexChar((a >> 20) & 15),
            ToHexChar((a >> 16) & 15),
            ToHexChar((a >> 12) & 15),
            ToHexChar((a >> 8) & 15),
            ToHexChar((a >> 4) & 15),
            ToHexChar(a & 15),
            ToHexChar((b >> 28) & 15),
            ToHexChar((b >> 24) & 15),
            ToHexChar((b >> 20) & 15),
            ToHexChar((b >> 16) & 15),
            ToHexChar((b >> 12) & 15),
            ToHexChar((b >> 8) & 15),
            ToHexChar((b >> 4) & 15),
            ToHexChar(b & 15),
            ToHexChar((c >> 28) & 15),
            ToHexChar((c >> 24) & 15),
            ToHexChar((c >> 20) & 15),
            ToHexChar((c >> 16) & 15),
            ToHexChar((c >> 12) & 15),
            ToHexChar((c >> 8) & 15),
            ToHexChar((c >> 4) & 15),
            ToHexChar(c & 15)
        });
    }
    
    /// <summary>
    /// Convert int to Hex Char
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    private static char ToHexChar(int value)
    {
        return (char)(value + (value < 10 ? 48 : 87));
    }
    
    /// <summary>
    /// Returns a bitmask masking out the desired number of bits; a bitmask of 2 returns 000...000011, a bitmask of
    /// 5 returns 000...011111.
    /// </summary>
    /// <param name="bits">The number of bits to mask.</param>
    /// <returns>Returns the desired bitmask.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int GetMask(byte bits) => (1 << bits) - 1;

    /// <summary>
    /// Returns a 'never ending' stream of Id's.
    /// </summary>
    /// <returns>A 'never ending' stream of Id's.</returns>
    private IEnumerable<string> IdStream()
    {
        while (true)
        {
            yield return CreateId();
        }
    }

    /// <summary>
    /// Returns an enumerator that iterates over Id's.
    /// </summary>
    /// <returns>An <see cref="IEnumerator&lt;T&gt;"/> object that can be used to iterate over Id's.</returns>
    public IEnumerator<string> GetEnumerator() => IdStream().GetEnumerator();

    /// <summary>
    /// Returns an enumerator that iterates over Id's.
    /// </summary>
    /// <returns>An <see cref="IEnumerator"/> object that can be used to iterate over Id's.</returns>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}