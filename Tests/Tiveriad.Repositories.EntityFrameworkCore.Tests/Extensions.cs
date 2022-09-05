using System.Linq.Expressions;

namespace Tiveriad.Repositories.EntityFrameworkCore.Tests;

public static class Extensions
{
    public static T? RandomElement<T>(this IQueryable<T> queryable, Expression<Func<T, bool>> expression)
    {
        var random = new Random();
        queryable = queryable.Where(expression);
        var count = random.Next(queryable.Count());

        var result = queryable.Skip(count).FirstOrDefault();

        return result;
    }
}