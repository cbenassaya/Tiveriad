using System.Diagnostics;
using System.Security;

namespace Tiveriad.IdGenerator;

public static class Extensions
{
    private static readonly DateTime _unixEpoch = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    
    private static int _staticIncrement = new Random().Next();
    
    public static DateTime ToUniversalTime(this DateTime dateTime)
    {
        if (dateTime == DateTime.MinValue)
            return DateTime.SpecifyKind(DateTime.MinValue, DateTimeKind.Utc);
        return dateTime == DateTime.MaxValue
            ? DateTime.SpecifyKind(DateTime.MaxValue, DateTimeKind.Utc)
            : dateTime.ToUniversalTime();
    }
    
    public static int GetTimestampFromDateTime(this DateTime timestamp)
    {
        var num = (long)Math.Floor((ToUniversalTime(timestamp) - _unixEpoch).TotalSeconds);
        return num >= 0L && num <= uint.MaxValue
            ? (int)(uint)num
            : throw new ArgumentOutOfRangeException(nameof(timestamp));
    }

    public static int NextIncrement()
    {
        return Interlocked.Increment(ref _staticIncrement) & 16777215;
    }
    
    public static long CalculateRandomValue()
    {
        var random = new Random((int)DateTime.UtcNow.Ticks ^ GetMachineHash() ^ GetPid());
        return (((long)(uint)random.Next() << 32) | (uint)random.Next()) & 1099511627775L;
    }
    
    private static int GetMachineHash()
    {
        return 16777215 & Environment.MachineName.GetHashCode();
    }

    private static short GetPid()
    {
        try
        {
            return (short)Process.GetCurrentProcess().Id;
        }
        catch (SecurityException ex)
        {
            return 0;
        }
    }
}