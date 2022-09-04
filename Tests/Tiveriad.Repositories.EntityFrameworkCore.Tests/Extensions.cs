using System.Linq.Expressions;

namespace Tiveriad.Repositories.EntityFrameworkCore.Tests;

public  static class Extensions
{
    public static T RandomElement<T>(this IQueryable<T> q, Expression<Func<T,bool>> e)
    {
        var r = new Random();
        q  = q.Where(e);
        return q.Skip(r.Next(q.Count())).FirstOrDefault();
    }
}