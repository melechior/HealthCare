using HealthCare.Framework.Commands;

namespace HealthCare.Core.Domains.Users.Commands;

public class CreateUserCommand : ICommand
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? ImageAddress { get; set; }
    public bool IsActive { get; set; }
    public string? Email { get; set; }
    public bool IsAdmin { get; set; }
    public string JobPosition { get; set; }
}