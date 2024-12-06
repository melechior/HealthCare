using HealthCare.Core.Domains.ContractOfPersons.Dtos;
using HealthCare.Core.Domains.ContractOfPersons.Queries;
using HealthCare.Core.Domains.ContractOfPersons.QueryViews;
using HealthCare.Core.Domains.UnitOfWork;
using HealthCare.Framework.Mapper;
using HealthCare.Framework.Queries;
using HealthCare.Framework.Resources;
using HealthCare.Infrastructures.Shared.Helpers;
 
namespace HealthCare.Core.ApplicationServices.ContractOfPersons.QueryHandlers
{
    public class ContractOfPersonsQueryHandlers(IUnitOfWork unitOfWork)
        : IQueryHandler<ContractPeopleQuery, QueryResult<List<ContractPeopleQueryView>>>
    {
        public QueryResult<List<ContractPeopleQueryView>> Get(ContractPeopleQuery query)
        {
            var queryResult = new QueryResult<List<ContractPeopleQueryView>>();

            try
            {
                var result =
                    unitOfWork.ContractOfPersonQueryRepository.GetContractOfPersonByMainPerson(query.ContractId, query.MainPersonId);
                queryResult.QueryView = Mapper.Map<ContractOfPersonByMainPersonDto, ContractPeopleQueryView>(result);
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