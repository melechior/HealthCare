using HealthCare.Core.Domains.UnitOfWork;
using HealthCare.Core.Domains.Users.Entities;
using HealthCare.Core.Domains.Users.Queries;
using HealthCare.Core.Domains.Users.QueryViews;
using HealthCare.Framework.Queries;
using HealthCare.Framework.Resources;
using HealthCare.Infrastructures.Shared.Helpers;
using HealthCare.Infrastructures.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCare.Framework.Mapper;

namespace HealthCare.Core.ApplicationServices.Users.QueryHandlers
{
    public class LoginQueryHandler(IUnitOfWork unitOfWork, Settings settings)
    : IQueryHandler<LoginQuery, QueryResult<LoginQueryView>>
    {
        public QueryResult<LoginQueryView> Get(LoginQuery query)
        {
            var queryResult = new QueryResult<LoginQueryView>();

            try
            {
                var user = unitOfWork.UserQueryRepository.GetUserByUsername(query.Username);
                if (user == null)
                {
                    queryResult.Failed = true;
                    queryResult.ResultMessages.Add(new ResultMessage
                    {
                        MessageType = MessageType.Danger,
                        MessageResource = MessageResource.UserNotFound,
                        Message = EnumHelper<MessageResource>.GetDisplayValue(MessageResource.UserNotFound)
                    });

                    return queryResult;
                }

                if (!user.Password.Equals(query.Password))
                {
                    queryResult.Failed = true;
                    queryResult.ResultMessages.Add(new ResultMessage
                    {
                        MessageType = MessageType.Danger,
                        MessageResource = MessageResource.UserNotFound,
                        Message = EnumHelper<MessageResource>.GetDisplayValue(MessageResource.UserNotFound)
                    });

                    return queryResult;
                }

                if (!user.IsActive)
                {
                    queryResult.Failed = true;
                    queryResult.ResultMessages.Add(new ResultMessage
                    {
                        MessageType = MessageType.Danger,
                        MessageResource = MessageResource.UserIsInActive,
                        Message = EnumHelper<MessageResource>.GetDisplayValue(MessageResource.UserIsInActive)
                    });

                    return queryResult;
                }

                queryResult.QueryView = Mapper.Map<User, LoginQueryView>(user);
                //queryResult.QueryView.ImageBase64 = string.IsNullOrEmpty(user.ImageAddress) || !File.Exists(user.ImageAddress)
                //    ? $"data:image/jpeg;base64,{Convert.ToBase64String(File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets", "img", "avatars", "NoImage.PNG")))}"
                //    : $"data:image/jpeg;base64,{Convert.ToBase64String(File.ReadAllBytes(user.ImageAddress))}";
            }
            catch (Exception ex)
            {
                queryResult.Failed = true;

                queryResult.ResultMessages.Add(new ResultMessage
                {
                    MessageType = MessageType.Danger,
                    MessageResource = MessageResource.ErrorHasBeenOccoured,
                    Message = EnumHelper<MessageResource>.GetDisplayValue(MessageResource.ErrorHasBeenOccoured)
                });
            }

            return queryResult;
        }
    }
}