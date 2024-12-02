namespace HealthCare.Core.Domains.Users.Dtos;

public class UserDto
{
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? ImageAddress { get; set; }
    public bool IsActive { get; set; }
    public string? Email { get; set; }
    public bool IsAdmin { get; set; }
    public string JobPosition { get; set; }
}