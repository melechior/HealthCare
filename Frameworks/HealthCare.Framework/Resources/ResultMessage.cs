using System.ComponentModel.DataAnnotations;
using HealthCare.Infrastructures.Shared.Helpers;

namespace HealthCare.Framework.Resources
{
    public class ResultMessage
    {
        public ResultMessage()
        {

        }

        public ResultMessage(MessageType messageType, string message = "")
        {
            Message = message;
            MessageType = MessageType;
        }

        public MessageResource MessageResource { private get; set; }

        public string MessageResourceName
        {
            get
            {
                if (string.IsNullOrEmpty(Message))
                {
                    Message = EnumHelper<MessageResource>.GetDisplayValue(MessageResource);
                }
                //Message = EnumHelper<MessageResource>.GetDisplayValue(MessageResource);
                return Message;
            }
        }
        public ResultMessage(Exception ex)
        {
            MessageType = MessageType.Danger;
            Message = ex.Message;
        }

        public int? ErrorCode
        {
            get
            {
                return (int)MessageResource;
            }
        }

        public string Message { get; set; }

        public MessageType MessageType { get; set; }

        public string MessageTypeName
        {
            get
            {
                return EnumHelper<MessageType>.GetDisplayValue(MessageType);
            }
        }
    }

    public enum MessageType : int
    {
        [Display(Name = "Danger")]
        Danger = -1,
        [Display(Name = "Success")]
        Success = 0,
        [Display(Name = "Warning")]
        Warning = 1,
        [Display(Name = "Info")]
        Info = 2,
        [Display(Name = "Report")]
        Report = 3,
    }
}
