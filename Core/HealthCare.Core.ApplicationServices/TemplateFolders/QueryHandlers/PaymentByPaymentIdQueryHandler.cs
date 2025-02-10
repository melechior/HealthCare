using HealthCare.Core.Domains.Payments.Queries;
using HealthCare.Core.Domains.Payments.QueryViews;
using HealthCare.Core.Domains.UnitOfWork;
using HealthCare.Framework.Queries;
using HealthCare.Framework.Resources;
using HealthCare.Infrastructures.Shared.Helpers;

namespace HealthCare.Core.ApplicationServices.TemplateFolders.QueryHandlers;

public class PaymentByPaymentIdQueryHandler(IUnitOfWork unitOfWork)
    : IQueryHandler<PaymentByPaymentIdQuery, QueryResult<List<PaymentByPaymentIdQueryView>>>
{
    public QueryResult<List<PaymentByPaymentIdQueryView>> Get(PaymentByPaymentIdQuery query)
    {
        var queryResult = new QueryResult<List<PaymentByPaymentIdQueryView>>
        {
            QueryView = []
        };

        try
        {
            var payments = unitOfWork.PaymentQueryRepository.GetByIds(query.PaymentIds);

            if (payments.Count == 0)
            {
                queryResult.Failed = true;

                queryResult.ResultMessages.Add(new ResultMessage
                {
                    MessageType = MessageType.Danger,
                    MessageResource = MessageResource.DataNotFound,
                    Message = EnumHelper<MessageResource>.GetDisplayValue(MessageResource.DataNotFound)
                });
            }

            queryResult.QueryView = payments.Select(x => new PaymentByPaymentIdQueryView
            {
                Id = x.Id,
                Amount = x.Amount,
                ReceiptNumber = x.ReceiptNumber,
                PersianPaymentDate = x.ReceiptDate.GeorgianDateToPersianDate(),
            }).ToList();
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