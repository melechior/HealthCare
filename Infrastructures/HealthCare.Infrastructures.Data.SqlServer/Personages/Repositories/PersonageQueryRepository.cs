using System;
using HealthCare.Core.Domains.DamageFiles.Entities;
using HealthCare.Core.Domains.Personages;
using HealthCare.Core.Domains.Personages.Dtos;
using HealthCare.Core.Domains.Users.Repositories;
using HealthCare.Framework.Paging;

namespace HealthCare.Infrastructures.Data.SqlServer.Personages.Repositories;

public class PersonageQueryRepository(HealthCareDbContext context) : IPersonagesQueryRepository
{
    public Personage? GetById(long id)
    {
        return context.Personages.FirstOrDefault(x => x.Id == id);
    }

    public Personage? GetByNationalId(string nationalId)
    {
        return context.Personages.FirstOrDefault(x => x.NationalId == nationalId);
    }

    public Personage? GetByInsuranceCoding(long systemNationalId)
    {
        return context.Personages.FirstOrDefault(x => x.InsuranceCoding == systemNationalId);
    }

    public PagedQueryResult<PersonageDto> GetByFilter(int pageIndex, int pageSize)
    {
        var query = context.Personages
            // .Where(userUserameSpecification.IsSatisfied()
            //     .And(userIsActiveSpecification.IsSatisfied()))
            .Select(personage => new PersonageDto
            {
                Id = personage.Id,
                NationalId = personage.NationalId,
                Birthdate = personage.Birthdate,
                FatherName = personage.FatherName,
                FirstName = personage.FirstName,
                IsActive = personage.IsActive,
                IsMan = personage.IsActive,
                LastName = personage.LastName,
                MobileNumber = personage.MobileNumber,
                BirthCertificateNumber = personage.BirthCertificateNumber
            }).OrderBy(x => x.FirstName).ThenBy(x => x.LastName);


        var result = new PagedQueryResult<PersonageDto>
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

    public PagedQueryResult<PersonageDto> GetByFilter(string searchValue, int pageIndex, int pageSize)
    {
        var specification = new PersonFirstNameOrLastNameSpecification(searchValue);
        var query = context.Personages
            .Where(specification.IsSatisfied())
            .Select(personage => new PersonageDto
            {
                Id = personage.Id,
                NationalId = personage.NationalId,
                Birthdate = personage.Birthdate,
                FatherName = personage.FatherName,
                FirstName = personage.FirstName,
                IsActive = personage.IsActive,
                IsMan = personage.IsActive,
                LastName = personage.LastName,
                MobileNumber = personage.MobileNumber,
                BirthCertificateNumber = personage.BirthCertificateNumber,
                ActiveContracts = string.Join(',',
                    personage.ContractOfPersons.Where(contract => contract.Contract.IsActive)
                        .Select(contract => contract.Contract.ContractNumber))
            }).OrderBy(x => x.FirstName).ThenBy(x => x.LastName);

        var result = new PagedQueryResult<PersonageDto>
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

    public IList<PersonageDto> GetByFilter()
    {
        return context.Personages.Select(personage => new PersonageDto
        {
            Id = personage.Id,
            NationalId = personage.NationalId,
            Birthdate = personage.Birthdate,
            FatherName = personage.FatherName,
            FirstName = personage.FirstName,
            IsActive = personage.IsActive,
            IsMan = personage.IsActive,
            LastName = personage.LastName,
            MobileNumber = personage.MobileNumber,
            BirthCertificateNumber = personage.BirthCertificateNumber
        }).ToList();
    }

    public IList<DamageFilePersonageInfoDto> GetAllPersonageInActiveContract()
    {
        return context.ContractOfPeople
            .Where(x => x.Contract.IsActive && x.PersonageId == x.MainPersonageId)
            .Select(contractPerson => new DamageFilePersonageInfoDto
            {
                Id = contractPerson.MainPersonage.Id,
                MainPersonage = new PersonageDto
                {
                    Id = contractPerson.MainPersonage.Id,
                    NationalId = contractPerson.MainPersonage.NationalId,
                    Birthdate = contractPerson.MainPersonage.Birthdate,
                    FatherName = contractPerson.MainPersonage.FatherName,
                    FirstName = contractPerson.MainPersonage.FirstName,
                    IsActive = contractPerson.MainPersonage.IsActive,
                    IsMan = contractPerson.MainPersonage.IsMan,
                    LastName = contractPerson.MainPersonage.LastName,
                    MobileNumber = contractPerson.MainPersonage.MobileNumber,
                    BirthCertificateNumber = contractPerson.MainPersonage.BirthCertificateNumber
                },
                Contracts = context.ContractOfPeople
                    .Where(x => x.PersonageId == contractPerson.PersonageId)
                    .Select(x => new ContractNameDto
                    {
                        Id = x.Contract.Id,
                        Name = x.Contract.Name,
                        StartDate = x.Contract.StartDate.GeorgianDateToPersianDate(),
                        EndDate = x.Contract.EndDate.GeorgianDateToPersianDate(),
                        Personages = x.Contract.ContractOfPersons.Where(y => y.MainPersonageId == x.MainPersonageId)
                            .Select(t => new PersonageDto
                            {
                                Id = t.PersonageId,
                                FirstName = t.Personage.FirstName,
                                IsActive = t.Personage.IsActive,
                                FatherName = t.Personage.FatherName,
                                LastName = t.Personage.LastName,
                                MobileNumber = t.Personage.MobileNumber,
                                BirthCertificateNumber = t.Personage.BirthCertificateNumber,
                                Birthdate = t.Personage.Birthdate,
                                IsMan = t.Personage.IsMan,
                                NationalId = t.Personage.NationalId
                            }).ToList()
                    }).ToList(),
            }).ToList();
    }

    // public List<PersonageProfileDto> GetPersonProfile(long personId)
    // {
    //     return context.ContractOfPeople.Where(x => x.PersonageId == personId && x.Contract.IsActive)
    //         .Select(y => new PersonageProfileDto
    //         {
    //             Id = y.ContractId,
    //             ContractName = y.Contract.ContractNumber,
    //             ShebaNumber = y.MainPersonage.BankAccounts.FirstOrDefault(a => a.IsMain) != null
    //                 ? y.MainPersonage.BankAccounts.First(a => a.IsMain).ShebaNumber
    //                 : "",
    //             MainNationalId = y.MainPersonage.NationalId,
    //             MainParentName = $"{y.MainPersonage.FirstName} {y.MainPersonage.LastName}"
    //         }).ToList();
    // }
}

internal class PersonFirstNameOrLastNameSpecification
{
    private string searchValue;

    public PersonFirstNameOrLastNameSpecification(string searchValue)
    {
        this.searchValue = searchValue;
    }
}