using HealthCare.Core.Domains.ContractOfPersons.Dtos;
using HealthCare.Core.Domains.ContractOfPersons.Queries;
using HealthCare.Core.Domains.ContractOfPersons.QueryViews;
using HealthCare.Core.Domains.UnitOfWork;
using HealthCare.Framework.Mapper;
using HealthCare.Framework.Queries;
using HealthCare.Framework.Resources;
using HealthCare.Infrastructures.Shared.Helpers;


namespace HealthCare.Core.ApplicationServices.ContractOfPersons.QueryHandlers;

public class ContractPeopleByNationalIdQueryHandler(IUnitOfWork unitOfWork)
    : IQueryHandler<ContractPeopleByNationalIdQuery, QueryResult<List<ContractPeopleByNationalIdQueryView>>>
{
    public QueryResult<List<ContractPeopleByNationalIdQueryView>> Get(ContractPeopleByNationalIdQuery query)
    {
        var queryResult = new QueryResult<List<ContractPeopleByNationalIdQueryView>>();

        try
        {
            var result =
                unitOfWork.ContractOfPersonQueryRepository.GetContractOfPersonByMainPersonNationalId(query.NationalId);
            
            queryResult.QueryView =
                Mapper.Map<ContractOfPersonByMainPersonDto, ContractPeopleByNationalIdQueryView>(result);
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