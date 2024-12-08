using HealthCare.Framework.Commands;

namespace HealthCare.Core.Domains.Users.Commands;

public class ChangePasswordCommand : ICommand
{
    public long UserId { get; set; }
    public string OldPassword { get; set; } = "";
    public string NewPassword { get; set; } = "";
    public string ConfirmPassword { get; set; } = "";
}