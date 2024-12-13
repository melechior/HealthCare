using HealthCare.Framework.Commands;
using HealthCare.Framework.Queries;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.WebApi;

    public class BaseController : ControllerBase
    {
        public Int64 UserId
        {
            get
            {
                return User.Identity.IsAuthenticated
                    ? Convert.ToInt32(User.Identities.FirstOrDefault()
                        ?.Claims.SingleOrDefault(x => x.Type == "UserId")
                        ?.Value)
                    : 0;
            }
            //set => UserId = value;
        }

        public string Fullname
        {
            get
            {
                return User.Identity.IsAuthenticated
                    ? User.Identities.FirstOrDefault()
                        ?.Claims.SingleOrDefault(x => x.Type == "Fullname")
                        ?.Value
                    : null;
            }
        }

        public string JobPosition
        {
            get
            {
                return User.Identity.IsAuthenticated
                    ? User.Identities.FirstOrDefault()
                        ?.Claims.SingleOrDefault(x => x.Type == "JobPosition")
                        ?.Value
                    : null;
            }
        }

        public bool IsAdmin
        {
            get
            {
                return User.Identity.IsAuthenticated
                    ? Convert.ToBoolean(User.Identities.FirstOrDefault()
                        ?.Claims.SingleOrDefault(x => x.Type == "IsAdmin")
                        ?.Value)
                    : false;
            }
            //set => IsAdmin = value;
        }

        protected CommandDispatcher _commandDispatcher;

        public CommandDispatcher CommandDispatcher
        {
            get
            {
                if (_commandDispatcher == null && HttpContext != null)
                    _commandDispatcher =
                        (CommandDispatcher)HttpContext.RequestServices.GetService(typeof(CommandDispatcher));
                return _commandDispatcher;
            }
        }

        protected QueryDispatcher _queryDispatcher;

        public QueryDispatcher QueryDispatcher
        {
            get
            {
                if (_queryDispatcher == null && HttpContext != null)
                    _queryDispatcher = (QueryDispatcher)HttpContext.RequestServices.GetService(typeof(QueryDispatcher));
                return _queryDispatcher;
            }
        }
    }