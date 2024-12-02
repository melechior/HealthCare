 
using HealthCare.Core.Domains.DamageFiles.Dtos;
using HealthCare.Core.Domains.DamageFiles.Entities;
using HealthCare.Core.Domains.Users.Repositories;
using HealthCare.Framework.Paging;
using HealthCare.Framework.Specification;
using HealthCare.Infrastructures.Data.SqlServer.DamagedFileDetails.Specifications;
using HealthCare.Infrastructures.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using HealthCare.Infrastructures.Shared.Helpers;

namespace HealthCare.Infrastructures.Data.SqlServer.DamageFiles.Repositories;

public class DamageFileQueryRepository(HealthCareDbContext context) : IDamageFileQueryRepository
{
    public DamageFile? GetById(long id)
    {
        return context.DamageFiles
            .Include(x => x.DamageFileDetails)
            .FirstOrDefault(x => x.Id == id);
    }

    public PagedQueryResult<DamageFileListDto> GetByFilter(string? searchValue, long? contractId,
        long? humanReceiptNumber,
        long? systemReceiptNumber,
        DateTime? fromDate, DateTime? toDate, string? mainPersonNationalId, string? mainPersonFullname,
        List<DamageFileState>? states, int pageIndex, int pageSize)
    {
        var detailsSearchValueSpecification=new DamageFileDetailsSearchValueSpecification(searchValue);
        var damageFileStatesSpecifications= new DamageFileDetailStatesSpecification(states);

        var query = context.DamageFileDetails
            .Include(x => x.DamageFile)
            .ThenInclude(x => x.DamageFileDetails)
            .Include(x => x.ContractOfPerson)
            .ThenInclude(x=>x.Personage)
            .Include(x => x.ContractOfPerson)
            .ThenInclude(x=>x.MainPersonage)
            .Where(damageFileStatesSpecifications.IsSatisfied()
                .And(detailsSearchValueSpecification.IsSatisfied()))
            .Select(y => new DamageFileListDto
            {
                Id = y.DamageFile.Id,
                ReceiptDate = y.DamageFile.ReceiptDate.GeorgianDateToPersianDate(),
                ContractId = y.DamageFile.DamageFileDetails.First().ContractOfPerson.ContractId,
                ContractName = y.ContractOfPerson.Contract.ContractNumber,
                HumanReceiptNumber = y.DamageFile.ReceiptNumber,
                MainPersonFullname =
                    $"{y.ContractOfPerson.MainPersonage.FirstName} {y.ContractOfPerson.MainPersonage.LastName}",
                SystemReceiptNumber = y.DamageFile.Id.ToString("000000"),
                MainPersonNationalId = y.ContractOfPerson.MainPersonage.NationalId,
                CountOfDetails = y.DamageFile.DamageFileDetails.Count
            }).Distinct().OrderByDescending(x => x.Id);


        // IOrderedQueryable<DamageFileListDto> query = null;
        // if (filter == null)
        // {
        //     query = context.DamageFiles
        //         .Select(y => new DamageFileListDto
        //         {
        //             Id = y.Id,
        //             ReceiptDate = y.ReceiptDate.GeorgianDateToPersianDate(),
        //             ContractId = y.DamageFileDetails.First().ContractOfPerson.Contract.Id,
        //             ContractName = y.DamageFileDetails.First().ContractOfPerson.Contract.ContractNumber,
        //             HumanReceiptNumber = y.ReceiptNumber,
        //             MainPersonFullname =
        //                 $"{y.DamageFileDetails.First().ContractOfPerson.MainPersonage.FirstName} {y.DamageFileDetails.First().ContractOfPerson.MainPersonage.LastName}",
        //             SystemReceiptNumber = y.Id.ToString("000000"),
        //             MainPersonNationalId = y.DamageFileDetails.First().ContractOfPerson.MainPersonage.NationalId,
        //             CountOfDetails = y.DamageFileDetails.Count
        //         }).OrderByDescending(x => x.Id);
        // }
        // else
        // {
        //     query = context.DamageFiles
        //         .Where(filter)
        //         //     .And(userIsActiveSpecification.IsSatisfied()))
        //         .Select(y => new DamageFileListDto
        //         {
        //             Id = y.Id,
        //             ReceiptDate = y.ReceiptDate.GeorgianDateToPersianDate(),
        //             ContractId = y.DamageFileDetails.First().ContractOfPerson.Contract.Id,
        //             ContractName = y.DamageFileDetails.First().ContractOfPerson.Contract.ContractNumber,
        //             HumanReceiptNumber = y.ReceiptNumber,
        //             MainPersonFullname =
        //                 $"{y.DamageFileDetails.First().ContractOfPerson.MainPersonage.FirstName} {y.DamageFileDetails.First().ContractOfPerson.MainPersonage.LastName}",
        //             SystemReceiptNumber = y.Id.ToString("000000"),
        //             MainPersonNationalId = y.DamageFileDetails.First().ContractOfPerson.MainPersonage.NationalId,
        //             CountOfDetails = y.DamageFileDetails.Count
        //         }).OrderByDescending(x => x.Id);
        // }


        var result = new PagedQueryResult<DamageFileListDto>
        {
            PageSize = pageSize,
            CurrentPage = pageIndex,
            TotalCount = query.Count(),
            Data = query
                .Skip((pageIndex - 1) * pageSize).Take(pageSize)
                .ToList()
        };

        return result;
    }

    public IList<DamageFile> GetByFilter()
    {
        throw new NotImplementedException();
    }

    public List<DamageFileDto> GetDamageFile(long? contractId)
    {
        throw new NotImplementedException();
    }

    public List<DamageReportDto> GetDamageReport(long? id)
    {
        return context.DamageFileDetails
            .Include(x => x.ContractOfPerson)
            .Where(x => x.DamageFileId == id)
            .Select(x => new DamageReportDto
            {
                Id = x.DamageFile.Id,
                PersonId = x.ContractOfPerson.PersonageId,
                MainPersonId = x.ContractOfPerson.MainPersonageId,
                ContractId = x.ContractOfPerson.ContractId,
                ReceiptNumber = $"{x.DamageFileId:000000}-{x.DamageFile.ReceiptNumber}",
                AssuranceName = "........",
                MainPerson =
                    $"{x.ContractOfPerson.MainPersonage.FirstName} {x.ContractOfPerson.MainPersonage.LastName}",
                MainPersonTel = x.ContractOfPerson.MainPersonage.MobileNumber,
                ReceiptDate = x.DamageFile.ReceiptDate,
                Description = x.Description,
                DamageFileDetailId = x.Id,
                DamageAmount = x.RequestedAmount,
                DamageDate = x.DamageDate,
                PersonName = $"{x.ContractOfPerson.Personage.FirstName} {x.ContractOfPerson.Personage.LastName}",
                PersonNationalId = x.ContractOfPerson.Personage.NationalId,
  
                DamageItemName = x.DamageItem,
                State = x.DamageFileState
            }).ToList();
    }

    public List<DamageMoalemReportDto> GetDamageMoalemReport(long id)
    {
        return context.DamageFileDetails.Where(x => x.InsuranceReceiptNumber == id.ToString())
            .Select(x =>
                new DamageMoalemReportDto
                {
                    DamageAmount = x.RequestedAmount,
                    DamageDate = x.DamageDate.GeorgianDateToPersianDate(),
                    PersonName = x.ContractOfPerson.Personage.FirstName + " " + x.ContractOfPerson.Personage.LastName,
                    DamageItem = x.DamageItem,
                    Relative = EnumHelper<Relative>.GetDisplayValue(x.ContractOfPerson.Relative),
                    MainPersonName = x.ContractOfPerson.MainPersonage.FirstName + " " +
                                     x.ContractOfPerson.MainPersonage.LastName,
                    MainNationalId = x.ContractOfPerson.MainPersonage.NationalId,
                    ReceiptNumber = x.DamageFile.ReceiptNumber.ToString(),
                    SystemReceiptNumber = x.DamageFile.Id.ToString("000000"),
                    SendDate = x.SendToInsuranceDate.GeorgianDateToPersianDate(),
                    PersonNNationalId = x.ContractOfPerson.Personage.NationalId,
                    ReceiveDate = x.DamageFile.ReceiptDate.Date.GeorgianDateToPersianDate(),
                    ContractName = x.ContractOfPerson.Contract.ContractNumber
                }).ToList();
    }

    
}