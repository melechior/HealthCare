// using HealthCare.Core.Domain.Logger;
// using HealthCare.Infrastructures.Log;
// using Microsoft.AspNetCore.Http;
//
// namespace HealthCare.Infrastructures.ActivityLog;
//
// public class ActivityLogMiddleware
// {
//     private readonly RequestDelegate _next;
//     private readonly string _url;
//     private readonly string _indexName;
//
//     public ActivityLogMiddleware(RequestDelegate next, string url, string indexName)
//     {
//         _next = next;
//         _url = url;
//         _indexName = indexName;
//     }
//
//     public async Task Invoke(HttpContext context)
//     {
//         var activitymodel = new Core.Domain.Logger.ActivityLog();
//         context.Request.EnableBuffering();
//         var baseLog = await HttpRequestHellper.FormatRequest(context.Request);
//
//         UserIdentity.UserId = "Anonymous";
//         var claims = context.User.Claims.ToList();
//
//         if (claims.Count != 0)
//         {
//             UserIdentity.UserId = claims.SingleOrDefault(x => x.Type == "UserId")!.Value;
//         }
//
//         activitymodel.IpAddress = baseLog.IpAddress;
//         activitymodel.LogType = baseLog.LogType;
//         activitymodel.Url = baseLog.Url;
//         activitymodel.RequestParameter = baseLog.RequestParameter;
//         activitymodel.Device = baseLog.Device;
//
//         var originalBodyStream = context.Response.Body;
//
//         using (var responseBody = new MemoryStream())
//         {
//             context.Response.Body = responseBody;
//             await _next(context);
//             activitymodel = await HttpRequestHellper.FormatResponse(context.Response, activitymodel);
//             await responseBody.CopyToAsync(originalBodyStream);
//         }
//
//         var mLog = new LogService();
//         activitymodel.UserId = UserIdentity.UserId;
//         activitymodel.CreateDateTime = DateTime.Now;
//         var logStatus = mLog.InsertActivityDocumentAsync(activitymodel, _url, _indexName);
//         context.Request.Body.Position = 0;
//     }
// }