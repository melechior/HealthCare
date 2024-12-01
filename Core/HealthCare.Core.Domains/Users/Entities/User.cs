using System.Net.NetworkInformation;
using HealthCare.Core.Domains.DamageFiles.Entities;
using HealthCare.Framework.Domain;
using HealthCare.Framework.Resources;
using HealthCare.Infrastructures.Shared.Helpers;

namespace HealthCare.Core.Domains.Users.Entities;

public class User : BaseEntity
{
    public string NationalId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? ImageAddress { get; set; }
    public bool IsActive { get; set; }
    public string? Email { get; set; }
    public bool IsAdmin { get; set; }
    public string JobPosition { get; set; }
 
    protected override void Validate()
    {
        if (string.IsNullOrEmpty(Username))
        {
            AddBrokenRule(new ResultMessage
            {
                MessageType = MessageType.Danger,
                MessageResource = MessageResource.UsernameIsEmpty,
                Message = EnumHelper<MessageResource>.GetDisplayValue(MessageResource.UsernameIsEmpty)
            });
        }

        if (string.IsNullOrEmpty(Password))
        {
            AddBrokenRule(new ResultMessage
            {
                MessageType = MessageType.Danger,
                MessageResource = MessageResource.PasswordIsEmpty,
                Message = EnumHelper<MessageResource>.GetDisplayValue(MessageResource.PasswordIsEmpty)
            });
        }
    }
}