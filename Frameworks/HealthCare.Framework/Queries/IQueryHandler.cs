namespace HealthCare.Framework.Queries
{
    public interface IQueryHandler<TQuery, TResult> where TResult : class
    {
        //QueryResult<TResult> Get(TQuery query);
        TResult Get(TQuery query);
    }
}
