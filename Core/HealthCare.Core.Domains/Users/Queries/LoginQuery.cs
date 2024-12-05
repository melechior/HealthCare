using HealthCare.Framework.Queries;
 

namespace HealthCare.Core.Domains.Users.Queries
{
    public class LoginQuery : IQuery
    {
        public string NationalId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool MemberMe { get; set; }
    }
}
