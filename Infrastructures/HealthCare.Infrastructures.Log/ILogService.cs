using System.Threading.Tasks;
using HealthCare.Core.Domain.Logger;

namespace HealthCare.Infrastructures.Log;

public interface ILogService
{
    Task<bool> InsertErrorDocumentAsync(ErrorLog errorLog, string url, string indexName);
    Task<bool> InsertActivityDocumentAsync(Core.Domain.Logger.ActivityLog activityLog, string url, string indexName);
}