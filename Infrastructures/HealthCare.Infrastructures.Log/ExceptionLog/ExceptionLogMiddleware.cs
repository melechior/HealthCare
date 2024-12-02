// namespace HealthCare.Infrastructures.Log.ExceptionLog;
//
// public static class ExceptionLogMiddleware
// {
//     public static void ConfigureExceptionHandler(this IApplicationBuilder app, string url, string indexName)
//     {
//         app.UseExceptionHandler(appError =>
//         {
//             appError.Run(async context =>
//             {
//                 context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
//                 context.Response.ContentType = "application/json";
//                 var request = await HttpRequestHellper.FormatRequest(context.Request);
//                 var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
//
//                 if (contextFeature != null)
//                 {
//                     var mLog = new LogService();
//
//                     var ErrorLog = new Core.Domain.Logger.ErrorLog
//                     {
//                         Url = request.Url,
//                         UserId = UserIdentity.UserId,
//                         Device = context.Request.Headers["User-Agent"].ToString(),
//                         CreateDateTime = DateTime.Now,
//                         RequestParameter = request.RequestParameter,
//                         LogType = request.LogType,
//                         IpAddress = new IpAddress { RemoteIpAddress = context.Request.HttpContext.Connection.RemoteIpAddress.ToString(), LocalIpAddress = context.Request.HttpContext.Connection.LocalIpAddress.ToString() },
//                         Exception = contextFeature
//                     };
//
//                     Task<bool> logStatus = mLog.InsertErrorDocumentAsync(ErrorLog, url, indexName);
//                 }
//             });
//         });
//     }
// }