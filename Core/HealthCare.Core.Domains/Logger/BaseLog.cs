using System;

namespace HealthCare.Core.Domain.Logger
{
    public class BaseLog
    {
        /// <summary>
        /// Gets or sets the UserId.
        /// </summary>
        /// <value>The log types.</value>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the ActivityLogType.
        /// </summary>
        /// <value>The log types.</value>
        public string LogType { get; set; }

        /// <summary>
        /// Gets or sets the Url.
        /// </summary>
        /// <value>The log source.</value>

        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the IpAddress.
        /// </summary>
        /// <value>The ip address.</value>
        public IpAddress IpAddress { get; set; }

        public string PlayerUsername { get; set; }

        /// <summary>
        /// Gets or sets the Device.
        /// </summary>
        /// <value>The browser.</value>
        public string Device { get; set; }

        /// <summary>
        /// Gets or sets the create on.
        /// </summary>
        /// <value>The create on.</value>
        public DateTime CreateDateTime { get; set; }

        /// <summary>
        /// Request Data
        /// </summary>
        public string RequestParameter { get; set; }

    }
}
