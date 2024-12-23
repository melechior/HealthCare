

using HealthCare.Framework.Commands;

namespace HealthCare.Core.Domains.Users.Commands
{
    public class ResetPassWorldCommand : ICommand
    {
        public string UserName { get; set; }
        public string Password{ get; set; }

    }
}
