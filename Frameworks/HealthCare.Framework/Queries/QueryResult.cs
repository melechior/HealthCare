using HealthCare.Framework.Resources;

namespace HealthCare.Framework.Queries;

public class QueryResult<TQueryView> where TQueryView : class
{
    public QueryResult()
    {
        ResultMessages = new List<ResultMessage>();
    }

    public TQueryView QueryView { get; set; }

    public bool Failed { get; set; }

    public IList<ResultMessage> ResultMessages { get; set; }
}