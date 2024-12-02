using System.Text;
using HealthCare.Core.Domain.Logger;
using Microsoft.AspNetCore.Http;

namespace HealthCare.Infrastructures.Log;

public class HttpRequestHelper
{
    public static async Task<BaseLog> FormatRequest(HttpRequest request)
    {
        var ResultModel = new BaseLog();
        var buffer = new byte[Convert.ToInt32(request.ContentLength)];
        await request.Body.ReadAsync(buffer, 0, buffer.Length);
        var bodyAsText = Encoding.UTF8.GetString(buffer);
        ResultModel.LogType = request.Method.ToString();
        ResultModel.Url = request.Scheme + request.Host + request.Path;
        ResultModel.RequestParameter = request.QueryString + bodyAsText;
        ResultModel.Device = request.Headers["User-Agent"].ToString();

        ResultModel.IpAddress = new IpAddress
        {
            RemoteIpAddress = request.HttpContext.Connection.RemoteIpAddress.ToString(),
            LocalIpAddress = request.HttpContext.Connection.LocalIpAddress.ToString()
        };

        request.Body.Position = 0;
        return ResultModel;
    }

    public static async Task<Core.Domain.Logger.ActivityLog> FormatResponse(HttpResponse response, Core.Domain.Logger.ActivityLog activityLog)
    {
        response.Body.Seek(0, SeekOrigin.Begin);
        activityLog.Body = await new StreamReader(response.Body).ReadToEndAsync();
        response.Body.Seek(0, SeekOrigin.Begin);
        return activityLog;
    }
}