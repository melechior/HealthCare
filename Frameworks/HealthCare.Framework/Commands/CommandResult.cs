using System.Collections.Generic;
using HealthCare.Framework.Resources;

namespace HealthCare.Framework.Commands
{
    public class CommandResult
    {
        public List<ResultMessage> ResultMessages { get; set; } = [];

        ///// <summary>
        ///// پیامی که نیاز است در اختیار کاربر قرار گیرد.
        ///// </summary>
        //public string Message { get; set; }
        /// <summary>
        /// نتیجه انجام عملیات به کمک این متغیر بازگشت داده می‌شود.
        /// </summary>
        public bool Failed { get; set; }
    }
}
