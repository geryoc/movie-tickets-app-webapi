using System.Linq.Expressions;

namespace MovieTicketsApp.WebApi.Shared.Helpers;

public static class IQueryableExtensions
{
    public static IQueryable<T> OrderBy<T, E>(this IQueryable<T> query, List<E> orderByOptions) where E : System.Enum
    {
        if (orderByOptions == null || !orderByOptions.Any())
        {
            return query;
        }

        var firstOption = orderByOptions.First();
        orderByOptions.Remove(firstOption);

        IOrderedQueryable<T> orderedQuery = query.OrderByOption(firstOption);
        foreach (var option in orderByOptions)
        {
            orderedQuery = orderedQuery.ThenByOption(option);
        }

        return orderedQuery;
    }

    public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> query, string propertyName, IComparer<object> comparer = null)
    {
        return CallOrderedQueryable(query, "OrderBy", propertyName, comparer);
    }

    public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> query, string propertyName, IComparer<object> comparer = null)
    {
        return CallOrderedQueryable(query, "OrderByDescending", propertyName, comparer);
    }

    public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> query, string propertyName, IComparer<object> comparer = null)
    {
        return CallOrderedQueryable(query, "ThenBy", propertyName, comparer);
    }

    public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> query, string propertyName, IComparer<object> comparer = null)
    {
        return CallOrderedQueryable(query, "ThenByDescending", propertyName, comparer);
    }

    private static IOrderedQueryable<T> CallOrderedQueryable<T>(this IQueryable<T> query, string methodName, string propertyName,
            IComparer<object> comparer = null)
    {
        var param = Expression.Parameter(typeof(T), "x");

        var body = propertyName.Split('.').Aggregate<string, Expression>(param, Expression.PropertyOrField);

        return comparer != null
            ? (IOrderedQueryable<T>)query.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable),
                    methodName,
                    new[] { typeof(T), body.Type },
                    query.Expression,
                    Expression.Lambda(body, param),
                    Expression.Constant(comparer)
                )
            )
            : (IOrderedQueryable<T>)query.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable),
                    methodName,
                    new[] { typeof(T), body.Type },
                    query.Expression,
                    Expression.Lambda(body, param)
                )
            );
    }

    private static IOrderedQueryable<T> OrderByOption<T>(this IQueryable<T> query, System.Enum option)
    {
        IOrderedQueryable<T> result;

        if (option.ToString().Contains("Descending"))
        {
            result = query.OrderByDescending(option.ToString().Replace("Descending", string.Empty));
        }
        else
        {
            result = query.OrderBy(option.ToString());
        }

        return result;
    }

    private static IOrderedQueryable<T> ThenByOption<T>(this IOrderedQueryable<T> query, System.Enum option)
    {
        IOrderedQueryable<T> result;

        if (option.ToString().Contains("Descending"))
        {
            result = query.ThenByDescending(option.ToString().Replace("Descending", string.Empty));
        }
        else
        {
            result = query.ThenBy(option.ToString());
        }

        return result;
    }
}