using HealthCare.Framework.Commands;

namespace HealthCare.Core.Domains.Users.Commands;

public class ResetPasswordCommand : ICommand
{
    public long UserId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}