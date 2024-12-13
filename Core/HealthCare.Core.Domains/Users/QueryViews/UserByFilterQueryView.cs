using HealthCare.Framework.Queries;

namespace HealthCare.Core.Domains.Users.QueryViews;

public class UserByFilterQueryView : QueryView
{
    public string Username { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public bool IsActive { get; set; }
    public bool IsAdmin { get; set; }
}