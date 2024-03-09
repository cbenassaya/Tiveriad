using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Tiveriad.Core.Abstractions.Entities;

namespace Tiveriad.Repositories;

public static class QueryableExtensions
{
    public static IOrderedQueryable<T> OrderBy<T>(
        this IQueryable<T> source, 
        string property)
    {
        return ApplyOrder<T>(source, property, "OrderBy");
    }

    public static IOrderedQueryable<T> OrderByDescending<T>(
        this IQueryable<T> source, 
        string property)
    {
        return ApplyOrder<T>(source, property, "OrderByDescending");
    }

    public static IOrderedQueryable<T> ThenBy<T>(
        this IOrderedQueryable<T> source, 
        string property)
    {
        return ApplyOrder<T>(source, property, "ThenBy");
    }

    public static IOrderedQueryable<T> ThenByDescending<T>(
        this IOrderedQueryable<T> source, 
        string property)
    {
        return ApplyOrder<T>(source, property, "ThenByDescending");
    }

    private static IOrderedQueryable<T> ApplyOrder<T>(
        IQueryable<T> source, 
        string property, 
        string methodName) 
    {
        string[] props = property.Split('.');
        Type type = typeof(T);
        ParameterExpression arg = Expression.Parameter(type, "x");
        Expression expr = arg;
        foreach(string prop in props) {
            // use reflection (not ComponentModel) to mirror LINQ
            PropertyInfo pi = type.GetProperty(prop, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            expr = Expression.Property(expr, pi);
            type = pi.PropertyType;
        }
        Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
        LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);

        object result = typeof(Queryable).GetMethods().Single(
                method => method.Name == methodName
                          && method.IsGenericMethodDefinition
                          && method.GetGenericArguments().Length == 2
                          && method.GetParameters().Length == 2)
            .MakeGenericMethod(typeof(T), type)
            .Invoke(null, new object[] {source, lambda});
        return (IOrderedQueryable<T>)result;
    }
    
    public static PagedResult<T> GetPaged<T>(this IQueryable<T> query, 
        int? page = null, int? limit = null) where T : class
    {
        var result = new PagedResult<T>
        {
            Page = page ?? 1,
            Limit = limit ?? 50,
            RowCount = query.Count()
        };

        var pageCount = (double)result.RowCount / result.Limit;
        result.PageCount = (int)Math.Ceiling(pageCount);
 
        var skip = (result.Page - 1) * result.Limit;     
        result.Items = query.Skip(skip).Take(result.Limit).ToList();
 
        return result;
    }
}