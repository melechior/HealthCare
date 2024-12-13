using HealthCare.Core.Domains.UnitOfWork;
using HealthCare.Core.Domains.Users.Dtos;
using HealthCare.Core.Domains.Users.Queries;
using HealthCare.Core.Domains.Users.QueryViews;
using HealthCare.Framework.Mapper;
using HealthCare.Framework.Paging;
using HealthCare.Framework.Queries;
using HealthCare.Framework.Resources;
using HealthCare.Infrastructures.Shared.Helpers;

namespace HealthCare.Core.ApplicationServices.Users.QueryHandlers;

public class GetUserByFilterQueryHandler(IUnitOfWork unitOfWork)
    : IQueryHandler<UserByFilterQuery, QueryResult<PagedQueryResult<UserByFilterQueryView>>>
{
    public QueryResult<PagedQueryResult<UserByFilterQueryView>> Get(UserByFilterQuery query)
    {
        var queryResult = new QueryResult<PagedQueryResult<UserByFilterQueryView>>();

        try
        {
            var result = unitOfWork.UserQueryRepository.GetFilter(query.Username, query.Firstname, query.Lastname,
                query.IsActive, query.PageIndex, query.PageSize);
            queryResult.QueryView = Mapper.Map<UserDto, UserByFilterQueryView>(result);
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