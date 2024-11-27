namespace HealthCare.Framework.Queries;

public sealed class QueryDispatcher(IServiceProvider provider)
{
    public T Dispatch<T>(IQuery query)
    {
        var type = typeof(IQueryHandler<,>);
        Type[] typeArgs = [query.GetType(), typeof(T)];
        var handlerType = type.MakeGenericType(typeArgs);
        dynamic handler = provider.GetService(handlerType);
        T result = handler.Get((dynamic)query);

        return result;
    }
    // public T Dispatch<T>(List<IQuery> query)
    // {
    //     var type = typeof(IQueryHandler<,>);
    //     Type[] typeArgs = { query.GetType(), typeof(T) };
    //     var handlerType = type.MakeGenericType(typeArgs);
    //     dynamic handler = provider.GetService(handlerType)!;
    //     T result = handler.Get((dynamic)query);
    //     return result;
    // }
}