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
    public class ContractOfPersonsByNationalIdQueryHandlers(IUnitOfWork unitOfWork)
        : IQueryHandler<ContractPeopleByNationalIdQuery, QueryResult<List<ContractPeopleByNationalIdQueryQueryViews>>>
    {
        public QueryResult<List<ContractPeopleByNationalIdQueryQueryViews>> Get(ContractPeopleByNationalIdQuery query)
        {
            var queryResult = new QueryResult<List<ContractPeopleByNationalIdQueryQueryViews>>();

            try
            {
                var result =
                    unitOfWork.ContractOfPersonQueryRepository.GetContractOfPersonByMainPersonNationalId(query.NationalId);
                queryResult.QueryView = Mapper.Map<ContractOfPersonByMainPersonDto, ContractPeopleByNationalIdQueryQueryViews>(result);
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
 
