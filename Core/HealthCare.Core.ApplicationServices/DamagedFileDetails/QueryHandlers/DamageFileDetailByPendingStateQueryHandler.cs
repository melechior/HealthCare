using HealthCare.Core.Domains.DamagedFileDetails.Queries;
using HealthCare.Core.Domains.DamagedFileDetails.QueryViews;
using HealthCare.Core.Domains.UnitOfWork;
using HealthCare.Framework.Queries;
using HealthCare.Framework.Resources;
using HealthCare.Infrastructures.Shared.Helpers;

namespace HealthCare.Core.ApplicationServices.DamagedFileDetails.QueryHandlers;

public class DamageFileDetailByPendingStateQueryHandler(IUnitOfWork unitOfWork)
    : IQueryHandler<DamageFileDetailByPendingStateQuery, QueryResult<List<DamageFileDetailByPendingStateQueryView>>>
{
    public QueryResult<List<DamageFileDetailByPendingStateQueryView>> Get(DamageFileDetailByPendingStateQuery query)
    {
        var queryResult = new QueryResult<List<DamageFileDetailByPendingStateQueryView>>();

        try
        {
            var result =
                unitOfWork.DamagedFileDetailQueryRepository.GetByFilter(query.PersonId, query.DamageFileStates,
                    query.SearchValue, query.FromDate, query.ToDate);

            //queryResult.QueryView = Mapper.Map<DamageFileDetailDto, DamageFileDetailByPendingStateQueryView>(result);

            queryResult.QueryView = result.Select(x => new DamageFileDetailByPendingStateQueryView
            {
                Id = x.Id,
                //InsuranceCompanyName = x.InsuranceCompanyName,
                DamageFileState = x.DamageFileState,
                Description = x.Description,
                RequestedAmount = x.RequestedAmount,
                DamageDate = x.DamageDate,
                PersianDamageDate = x.PersianDamageDate,
                DamageFileStateName = x.DamageFileStateName,
                ContractName = x.DamageFileDto.ContractName,
                NationalId = x.NationalId,
                Fullname = x.Fullname,
                ReceiptNumber = !x.DamageFileDto.ReceiptNumber.HasValue || x.DamageFileDto.ReceiptNumber.Value == 0
                    ? x.DamageFileDto.Id.ToString("000000")
                    : x.DamageFileDto.ReceiptNumber.ToString(),
                DamageFileCreationDate = x.DamageFileDto.CreationDate,
                DamageFilePersianCreationDate = x.DamageFileDto.PersianCreationDate,
                DamageFileId = x.DamageFileDto.Id,
                DamageItemId = x.DamageItemId,
                SendPersianDate = x.SendPersianDate,
                DamageItemName = x.DamageItemName.Length > 30
                    ? x.DamageItemName[..30]
                    : x.DamageItemName,
                ContractNumber = x.DamageFileDto.ContractNumber,
                PaymentAmount = x.PaymentAmount,
                ShebaNumber = x.ShebaNumber,
                PaymentDate = x.PaymentDate,
                PaymentId = x.PaymentId,
                PaymentPersianDate = x.PaymentPersianDate
            }).OrderBy(x => x.Id).ToList();
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