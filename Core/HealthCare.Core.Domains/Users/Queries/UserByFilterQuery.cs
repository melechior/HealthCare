using HealthCare.Framework.Paging;
using HealthCare.Framework.Queries;

namespace HealthCare.Core.Domains.Users.Queries;

public class UserByFilterQuery : PagedQuery, IQuery
{
    public string Username { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public bool IsActive { get; set; }
    public bool IsAdmin { get; set; }
}