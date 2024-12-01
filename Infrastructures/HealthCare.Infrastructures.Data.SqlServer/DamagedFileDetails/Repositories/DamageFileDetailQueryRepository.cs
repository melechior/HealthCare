using System;
using HealthCare.Core.Domains.DamagedFileDetails;
using HealthCare.Core.Domains.DamagedFileDetails.Dto;
using HealthCare.Core.Domains.DamagedFileDetails.Dtos;
using HealthCare.Core.Domains.DamageFiles.Dtos;
using HealthCare.Core.Domains.Users.Repositories;
using HealthCare.Framework.Paging;
using HealthCare.Framework.Specification;
using HealthCare.Infrastructures.Data.SqlServer.DamagedFileDetails.Specifications;
using HealthCare.Infrastructures.Shared.Enums;
using HealthCare.Infrastructures.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Infrastructures.Data.SqlServer.DamagedFileDetails.Repositories;

public class DamageFileDetailQueryRepository(HealthCareDbContext context) : IDamagedFileDetailQueryRepository
{
    public DamageFileDetail? GetById(long id)
    {
        return context.DamageFileDetails
          
            .Include(x => x.ContractOfPerson)
            .FirstOrDefault(x => x.Id == id);
    }

    public DamageFileDetail? GetFullDataById(long id)
    {
        return context.DamageFileDetails
            .Include(x => x.DamageItem)
           
            .Include(x => x.ContractOfPerson)
            .ThenInclude(x => x.Personage)
            .Include(x => x.DamageFile)
            .Include(x => x.ContractOfPerson)
            .ThenInclude(x => x.Contract)
         
        
            .FirstOrDefault(x => x.Id == id);
    }

    public PagedQueryResult<DamageFileDetailDto> GetByFilter(List<DamageFileState>? states, int pageIndex, int pageSize)
    {
        var specification = new DamageFileDetailStatesSpecification(states);

        var query = context.DamageFileDetails
            .Where(specification.IsSatisfied())
            .Select(y => new DamageFileDetailDto
            {
                Id = y.Id,
                Description = y.Description,
                RequestedAmount = y.RequestedAmount,
                DamageFileState = y.DamageFileState,
                DamageDate = y.DamageDate,
                PersianDamageDate = y.DamageDate.GeorgianDateToPersianDate(),
                DamageFileStateName = EnumHelper<DamageFileState>.GetDisplayValue(y.DamageFileState),
                DamageItemId = y.DamageItemId,
                DamageItemName = y.DamageItem.Name,
                DamageFileDto = new DamageFileDto
                {
                    Id = y.DamageFile.Id,
                    CreationDate = y.DamageFile.ReceiptDate,
                    ReceiptNumber = y.DamageFile.ReceiptNumber,
                    PersianCreationDate = y.DamageFile.ReceiptDate.GeorgianDateToPersianDate(),
                    ContractName = y.ContractOfPerson.Contract.Name,
                    Fullname = $"{y.ContractOfPerson.Personage.FirstName} {y.ContractOfPerson.Personage.LastName}",
                    ContractNumber = y.ContractOfPerson.Contract.ContractNumber,
                }
            });

        var result = new PagedQueryResult<DamageFileDetailDto>
        {
            PageSize = pageSize,
            CurrentPage = pageIndex,
            TotalCount = query.Count(),
            Data = query.Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList()
        };

        return result;
    }

    public PagedQueryResult<DamageFileDetailDto> GetByFilter(List<DamageFileState>? states, string search,
        int pageIndex, int pageSize)
    {
        var specification = new DamageFileDetailStatesSpecification(states);
        var receiptNumberSpecification = new DamageFileDetailReceiptNumberSpecification(search);

        var query = context.DamageFileDetails
            .Where(specification.IsSatisfied().And(receiptNumberSpecification.IsSatisfied()))
            .Select(y => new DamageFileDetailDto
            {
                Id = y.Id,
                Description = y.Description,
                RequestedAmount = y.RequestedAmount,
                DamageFileState = y.DamageFileState,
                DamageDate = y.DamageDate,
                PersianDamageDate = y.DamageDate.GeorgianDateToPersianDate(),
                DamageFileStateName = EnumHelper<DamageFileState>.GetDisplayValue(y.DamageFileState),
                DamageItemId = y.DamageItemId,
                DamageItemName = y.DamageItem.Name,
                DamageFileDto = new DamageFileDto
                {
                    Id = y.DamageFile.Id,
                    CreationDate = y.DamageFile.ReceiptDate,
                    ReceiptNumber = y.DamageFile.ReceiptNumber,
                    PersianCreationDate = y.DamageFile.ReceiptDate.GeorgianDateToPersianDate(),
                    ContractName = y.ContractOfPerson.Contract.Name,
                    Fullname = $"{y.ContractOfPerson.Personage.FirstName} {y.ContractOfPerson.Personage.LastName}",
                    ContractNumber = y.ContractOfPerson.Contract.ContractNumber,
                }
            });

        var result = new PagedQueryResult<DamageFileDetailDto>
        {
            PageSize = pageSize,
            CurrentPage = pageIndex,
            TotalCount = query.Count(),
            Data = query.Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList()
        };

        return result;
    }

    public PagedQueryResult<DamageFileDetailDto> GetByFilter(long? personId, List<DamageFileState>? states,
        string search,
        int pageIndex, int pageSize)
    {
        var fileDetailStatesSpecification = new DamageFileDetailStatesSpecification(states);
        var receiptNumberSpecification = new DamageFileDetailReceiptNumberSpecification(search);
        var detailByPersonSpecification = new DamageFileDetailByPersonSpecification(personId);

        var query = context.DamageFileDetails
            .Where(fileDetailStatesSpecification.IsSatisfied()
                .And(receiptNumberSpecification.IsSatisfied())
                .And(detailByPersonSpecification.IsSatisfied()))
            .Select(y => new DamageFileDetailDto
            {
                Id = y.Id,
                Description = y.Description!,
                RequestedAmount = y.RequestedAmount,
                DamageFileState = y.DamageFileState,
                DamageDate = y.DamageDate,
                PersianDamageDate = y.DamageDate.GeorgianDateToPersianDate(),
                DamageFileStateName = EnumHelper<DamageFileState>.GetDisplayValue(y.DamageFileState),
           
                DamageItemName = y.DamageItem.Name,
                DamageFileDto = new DamageFileDto
                {
                    Id = y.DamageFile.Id,
                    CreationDate = y.DamageFile.ReceiptDate,
                    ReceiptNumber = y.DamageFile.ReceiptNumber,
                    PersianCreationDate = y.DamageFile.ReceiptDate.GeorgianDateToPersianDate(),
                    ContractName = y.ContractOfPerson.Contract.Name,
                    Fullname = $"{y.ContractOfPerson.Personage.FirstName} {y.ContractOfPerson.Personage.LastName}",
                    ContractNumber = y.ContractOfPerson.Contract.ContractNumber,
                }
            }).OrderBy(x => x.Id);

        var result = new PagedQueryResult<DamageFileDetailDto>
        {
            PageSize = pageSize,
            CurrentPage = pageIndex,
            TotalCount = query.Count(),
            Data = query.Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList()
        };

        return result;
    }

    // public List<DamageFileDetailDto> GetDamageFileDetailByPersonId(long personId, long contractId)
    // {
    //     return context.DamageFileDetails.Where(x =>
    //         x.DamageItem.Assurance.AssuranceContractItems.Any(y =>
    //             y.ContractItem.Priority == ContractPriority.Main) && x.ContractOfPerson.PersonageId == personId &&
    //         x.ContractOfPerson.ContractId == contractId).Select(s => new DamageFileDetailDto
    //     {
    //         Id = s.Id,
    //         Description = s.Description,
    //         RequestedAmount = s.RequestedAmount,
    //         FinalizeAmount = s.RequestedAmount,
    //         DamageFileDto = new DamageFileDto
    //         {
    //             Id = s.DamageFileId,
    //             CreationDate = s.DamageFile.CreationDate,
    //             ReceiptNumber = s.DamageFile.ReceiptNumber,
    //             PersianCreationDate = s.DamageFile.ReceiptDate.GeorgianDateTimeToPersianDateTime()
    //         }
    //     }).ToList();
    // }

    // public DamageFileControlDto? GetDetailFromDamageFileId(long id)
    // {
    //     var _ = context.DamageFileDetails
    //         .Include(x => x.DamageItem)
    //         .Include(x => x.ContractOfPerson)
    //         .Select(x => new DamageFileControlDto
    //         {
    //             Id = x.Id,
    //             ContractOfPersonId = x.ContractOfPersonId,
    //             TotalAmountUsed = 0,
    //             RequestedAmount = x.RequestedAmount,
    //             AssuranceId = x.DamageItem.AssuranceId,
    //             ContractId = x.ContractOfPerson.ContractId,
    //             PersonageId = x.ContractOfPerson.PersonageId,
    //             MainPersonageId = x.ContractOfPerson.MainPersonageId,
    //             ContractItems = context.AssuranceContractItems
    //                 .Select(s => new ContractItemDto
    //                 {
    //                     Id = s.ContractItemId,
    //                     ContractId = s.ContractItem.ContractId,
    //                     Priority = s.ContractItem.Priority,
    //                     InsuranceCompanyId = s.ContractItem.InsuranceCompanyId,
    //                     MaxItemAmount = s.ContractItem.MaxItemAmount,
    //                     AssuranceId = s.AssuranceId
    //                 }).Where(y => y.AssuranceId == x.DamageItem.AssuranceId &&
    //                               y.ContractId == x.ContractOfPerson.ContractId).ToList()
    //         }).SingleOrDefault(x => x.Id == id);
    //     return _;
    // }

    public long GetMaxReceiptNumber()
    {
        if (context.DamageFileDetails.FirstOrDefault(x => x.InsuranceReceiptNumber != null) == null)
            return 0;
        return context.DamageFileDetails.Max(x => Convert.ToInt64(x.InsuranceReceiptNumber));
    }

    // public bool IsPayment(long damageFileDetailId)
    // {
    //     return context.PaymentDamageFiles
    //         .FirstOrDefault(x => x.DamageFileDetailId == damageFileDetailId) != null;
    // }

    List<DamageFileDetail> IDamagedFileDetailQueryRepository.GetDamageDetailId(string nationalId, DateTime damageDate,
        decimal damageAmount)
    {
        return context.DamageFileDetails
            .Include(x => x.ContractOfPerson)
             
            .Where(x => x.ContractOfPerson.Personage.NationalId == nationalId
                        && x.DamageDate == damageDate && x.RequestedAmount == damageAmount).ToList();
    }

    public List<DamageFileDetail> GetDamageDetailId(string nationalId, DateTime damageDate, decimal damageAmount,
        string receiptNumber)
    {
        var damageFileId = Convert.ToInt64(receiptNumber.Split("-")[0]);
        return context.DamageFileDetails
            .Include(x => x.ContractOfPerson)
             
            
            .Where(x => x.ContractOfPerson.Personage.NationalId == nationalId
                        && x.DamageDate == damageDate && x.RequestedAmount == damageAmount
                        && x.DamageFileId == damageFileId).ToList();
    }

    public List<DamageFileDetail> GetDamageDetailId(string nationalId, DateTime damageDate, decimal damageAmount,
        string receiptNumber, string damageItemName)
    {
        throw new NotImplementedException();
    }

     public List<DamageFileDetail> GetDamageDetailId(string nationalId, DamageFileState state)
    {
        return context.DamageFileDetails
            .Include(x => x.DamageItem)
     
            .Where(x =>
                x.ContractOfPerson.Personage.NationalId == nationalId && x.DamageFileState == state)
            .ToList();
    }
   
}