#region

using System.Linq.Expressions;

#endregion

namespace Tiveriad.Workflows.Core.Models.Search;

public abstract class SearchFilter
{
    public bool IsData { get; set; }
    public Type DataType { get; set; }
    public Expression Property { get; set; }

    private static Func<T, V> Lambda<T, V>(Func<T, V> del)
    {
        return del;
    }
}

public class ScalarFilter : SearchFilter
{
    public object Value { get; set; }

    public static SearchFilter Equals(Expression<Func<WorkflowSearchResult, object>> property, object value)
    {
        return new ScalarFilter
        {
            Property = property,
            Value = value
        };
    }

    public static SearchFilter Equals<T>(Expression<Func<T, object>> property, object value)
    {
        return new ScalarFilter
        {
            IsData = true,
            DataType = typeof(T),
            Property = property,
            Value = value
        };
    }
}

public class DateRangeFilter : SearchFilter
{
    public DateTime? BeforeValue { get; set; }
    public DateTime? AfterValue { get; set; }

    public static DateRangeFilter Before(Expression<Func<WorkflowSearchResult, object>> property, DateTime value)
    {
        return new()
        {
            Property = property,
            BeforeValue = value
        };
    }

    public static DateRangeFilter After(Expression<Func<WorkflowSearchResult, object>> property, DateTime value)
    {
        return new()
        {
            Property = property,
            AfterValue = value
        };
    }

    public static DateRangeFilter Between(Expression<Func<WorkflowSearchResult, object>> property, DateTime start,
        DateTime end)
    {
        return new()
        {
            Property = property,
            BeforeValue = end,
            AfterValue = start
        };
    }

    public static DateRangeFilter Before<T>(Expression<Func<T, object>> property, DateTime value)
    {
        return new()
        {
            IsData = true,
            DataType = typeof(T),
            Property = property,
            BeforeValue = value
        };
    }

    public static DateRangeFilter After<T>(Expression<Func<T, object>> property, DateTime value)
    {
        return new()
        {
            IsData = true,
            DataType = typeof(T),
            Property = property,
            AfterValue = value
        };
    }

    public static DateRangeFilter Between<T>(Expression<Func<T, object>> property, DateTime start, DateTime end)
    {
        return new()
        {
            IsData = true,
            DataType = typeof(T),
            Property = property,
            BeforeValue = end,
            AfterValue = start
        };
    }
}

public class NumericRangeFilter : SearchFilter
{
    public double? LessValue { get; set; }
    public double? GreaterValue { get; set; }

    public static NumericRangeFilter LessThan(Expression<Func<WorkflowSearchResult, object>> property, double value)
    {
        return new()
        {
            Property = property,
            LessValue = value
        };
    }

    public static NumericRangeFilter GreaterThan(Expression<Func<WorkflowSearchResult, object>> property, double value)
    {
        return new()
        {
            Property = property,
            GreaterValue = value
        };
    }

    public static NumericRangeFilter Between(Expression<Func<WorkflowSearchResult, object>> property, double start,
        double end)
    {
        return new()
        {
            Property = property,
            LessValue = end,
            GreaterValue = start
        };
    }

    public static NumericRangeFilter LessThan<T>(Expression<Func<T, object>> property, double value)
    {
        return new()
        {
            IsData = true,
            DataType = typeof(T),
            Property = property,
            LessValue = value
        };
    }

    public static NumericRangeFilter GreaterThan<T>(Expression<Func<T, object>> property, double value)
    {
        return new()
        {
            IsData = true,
            DataType = typeof(T),
            Property = property,
            GreaterValue = value
        };
    }

    public static NumericRangeFilter Between<T>(Expression<Func<T, object>> property, double start, double end)
    {
        return new()
        {
            IsData = true,
            DataType = typeof(T),
            Property = property,
            LessValue = end,
            GreaterValue = start
        };
    }
}

public class StatusFilter : ScalarFilter
{
    protected StatusFilter()
    {
        Expression<Func<WorkflowSearchResult, object>> lambda = x => x.Status;
        Property = lambda;
    }

    public static StatusFilter Equals(WorkflowStatus value)
    {
        return new()
        {
            Value = value.ToString()
        };
    }
}