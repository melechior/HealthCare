using System;
using System.Globalization;
using HealthCare.Core.Domains.ContractOfPersons.Dtos;
using HealthCare.Core.Domains.ContractOfPersons.Entities;
using HealthCare.Core.Domains.Users.Repositories;
using HealthCare.Framework.Paging;

namespace HealthCare.Infrastructures.Data.SqlServer.ContractOfPersons.Repositories;

public class ContractOfPersonQueryRepository(HealthCareDbContext context) : IContractOfPersonQueryRepository
{
    public ContractOfPerson? GetById(long id)
    {
        return context.ContractOfPeople.FirstOrDefault(x => x.Id == id);
    }

    public PagedQueryResult<ContractOfPersonDto> GetByFilter(int pageIndex, int pageSize)
    {
        var query = context.ContractOfPeople
            .Select(y => new ContractOfPersonDto
            {
                Id = y.Id,
            });

        var result = new PagedQueryResult<ContractOfPersonDto>
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

    public IList<ContractOfPerson> GetByFilter(long? contractId = null)
    {
        return context.ContractOfPeople
            .ToList();
    }

    public ContractOfPerson GetContractOfPerson(long contractId, long personId)
    {
        return context.ContractOfPeople.Single(x => x.ContractId == contractId && x.PersonageId == personId);
    }

    public List<ContractOfPersonByMainPersonDto> GetContractOfPersonByMainPerson(long contractId, long personId)
    {
        return context.ContractOfPeople.Where(x => x.ContractId == contractId && x.MainPersonageId == personId)
            .Select(x => new ContractOfPersonByMainPersonDto
            {
                Id = x.PersonageId,
                NationalId = x.Personage.NationalId,
                Firstname = x.Personage.FirstName,
                Lastname = x.Personage.LastName,
            }).ToList();
    }

    public List<ContractOfPersonByMainPersonDto> GetContractOfPersonByMainPersonNationalId(string nationalId)
    {
        return context.ContractOfPeople
            .Where(x => x.MainPersonage.NationalId == nationalId)
            .Select(x => new ContractOfPersonByMainPersonDto
            {
                Id = x.Id,
                NationalId = x.Personage.NationalId,
                Firstname = x.Personage.FirstName,
                Lastname = x.Personage.LastName,
                ContractName = x.Contract.Name,
                Relative = x.Relative,
                IsMan = x.Personage.IsMan,
            }).ToList();
    }

    public List<InsuranceContractPersonDto> GetInsuranceContract(long contractId)
    {
        var pc = new PersianCalendar();
        return context.ContractOfPeople.Where(x => x.ContractId == contractId)
            .Select(x => new InsuranceContractPersonDto
            {
                Id = x.Id,
                Jens = (bool)x.Personage.IsMan! ? 26 : 27,
                Mobile = x.Personage.MobileNumber,
                BSKind = x.PersonageId == x.MainPersonageId ? 31 : 32,
                Name = x.Personage.FirstName,

                Tarh = x.Contract.Name.Contains("VIP") ? 2 : 1,

                BirthDay = pc.GetDayOfMonth(x.Personage.Birthdate!.Value),
                BirthMonth = pc.GetMonth(x.Personage.Birthdate.Value),
                CodeMelli = x.Personage.NationalId,
                BirthYear = pc.GetYear(x.Personage.Birthdate.Value),

                FatherName = x.Personage.FatherName,
                LName = x.Personage.FirstName,
                IdentityNo = x.Personage.BirthCertificateNumber,
                TakafolKind = 21,

                PersonelCode = x.MainPersonage.NationalId,
                MainNationalId = x.MainPersonage.NationalId,
            }).ToList();
    }
}