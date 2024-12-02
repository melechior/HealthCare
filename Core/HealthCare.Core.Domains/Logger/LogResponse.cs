using System.Net;

namespace HealthCare.Core.Domain.Logger
{
    public class LogResponse
    {
        public bool Failed { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public object Data { get; set; }
        public object Message { get; set; }
    }
}