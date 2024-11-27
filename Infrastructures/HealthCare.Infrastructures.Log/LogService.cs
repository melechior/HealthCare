using HealthCare.Core.Domain.Logger;
using Nest;

namespace HealthCare.Infrastructures.Log;

public class LogService : ILogService
{
    public async Task<bool> InsertActivityDocumentAsync(Core.Domain.Logger.ActivityLog activityLog, string url, string indexName)
    {
        bool status = false;
        var settings = new ConnectionSettings(new Uri(url)).DefaultIndex(indexName);
        var client = new ElasticClient(settings);
        var indexResponse = await client.IndexDocumentAsync(activityLog);

        if (indexResponse.IsValid)
        {
            status = true;
        }

        return status;
    }

    public async Task<bool> InsertErrorDocumentAsync(ErrorLog errorLog, string url, string indexName)
    {
        bool status = false;
        var settings = new ConnectionSettings(new Uri(url)).DefaultIndex(indexName);
        var client = new ElasticClient(settings);
        var indexResponse = await client.IndexDocumentAsync(errorLog);

        if (indexResponse.IsValid)
        {
            status = true;
        }

        return status;
    }
}