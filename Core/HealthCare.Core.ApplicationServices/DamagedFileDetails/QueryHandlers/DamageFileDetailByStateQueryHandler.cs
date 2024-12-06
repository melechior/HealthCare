using HealthCare.Core.Domains.DamagedFileDetails.Queries;
using HealthCare.Core.Domains.DamagedFileDetails.QueryViews;
using HealthCare.Core.Domains.UnitOfWork;
using HealthCare.Framework.Paging;
using HealthCare.Framework.Queries;
using HealthCare.Framework.Resources;
using HealthCare.Infrastructures.Shared.Helpers;

namespace HealthCare.Core.ApplicationServices.DamagedFileDetails.QueryHandlers;

public class DamageFileDetailByStateQueryHandler(IUnitOfWork unitOfWork)
    : IQueryHandler<DamageFileDetailByStateQuery, QueryResult<PagedQueryResult<DamageFileDetailByStateQueryView>>>
{
    public QueryResult<PagedQueryResult<DamageFileDetailByStateQueryView>> Get(DamageFileDetailByStateQuery query)
    {
        var queryResult = new QueryResult<PagedQueryResult<DamageFileDetailByStateQueryView>>();

        try
        {
            var result =
                unitOfWork.DamagedFileDetailQueryRepository.GetByFilter(query.PersonId, query.DamageFileStates,
                    query.SearchValue, query.PageIndex, query.PageSize);
            queryResult.QueryView = new PagedQueryResult<DamageFileDetailByStateQueryView>
            {
                Data = result.Data.Select(x => new DamageFileDetailByStateQueryView
                {
                    Id = x.Id,
                    DamageFileState = x.DamageFileState,
                    Description = x.Description,
                    RequestedAmount = x.RequestedAmount,
                    DamageDate = x.DamageDate,
                    PersianDamageDate = x.PersianDamageDate,
                    DamageFileStateName = x.DamageFileStateName,
                    ContractName = x.DamageFileDto.ContractName,
                    ReceiptNumber = !x.DamageFileDto.ReceiptNumber.HasValue || x.DamageFileDto.ReceiptNumber.Value == 0
                        ? x.DamageFileDto.Id.ToString("000000")
                        : x.DamageFileDto.ReceiptNumber.ToString(),
                    DamageFileCreationDate = x.DamageFileDto.CreationDate,
                    DamageFilePersianCreationDate = x.DamageFileDto.PersianCreationDate,
                    Fullname = x.DamageFileDto.Fullname,
                    DamageFileId = x.DamageFileDto.Id,
                    //DamageItemId = x.DamageItemName,
                    DamageItemName = x.DamageItemName.Length > 30
                        ? x.DamageItemName[..30]
                        : x.DamageItemName,
                    ContractNumber = x.DamageFileDto.ContractNumber
                }).OrderBy(x => x.Id).ToList(),
                TotalCount = result.TotalCount,
                CurrentPage = query.PageIndex,
                PageSize = query.PageSize,
            };
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