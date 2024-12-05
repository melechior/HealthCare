using HealthCare.Framework.Queries;
 

namespace HealthCare.Core.Domains.Users.QueryViews
{
    public class LoginQueryView : QueryView
    {
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public string JobPosition { get; set; }
        public string? ImageBase64 { get; set; }
    }
}
