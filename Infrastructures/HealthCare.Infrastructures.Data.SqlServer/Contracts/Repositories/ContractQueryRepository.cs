
using HealthCare.Core.Domains.Contracts.Dtos;
using HealthCare.Core.Domains.Contracts.Entities;
using HealthCare.Core.Domains.Users.Repositories;
using HealthCare.Framework.Paging;
using HealthCare.Infrastructures.Shared;
using Microsoft.EntityFrameworkCore;
using HealthCare.Infrastructures.Shared.Helpers;
namespace HealthCare.Infrastructures.Data.SqlServer.Contracts.Repositories;
public class ContractQueryRepository(HealthCareDbContext context, Settings settings) : IContractQueryRepository
{
    public Contract? GetById(long id)
    {
        return context.Contracts
            .Include(x => x.ContractOfPersons)
            .ThenInclude(x => x.Personage)
            .FirstOrDefault(x => x.Id == id);
    }

    public PagedQueryResult<ContractDto> GetByFilter(int pageIndex, int pageSize)
    {
        var query = context.Contracts
            // .Where(userUserameSpecification.IsSatisfied()
            //     .And(userIsActiveSpecification.IsSatisfied()))
            .Select(y => new ContractDto
            {
                Id = y.Id,
                Name = y.Name,
                EndDate = y.EndDate,
                StartDate = y.StartDate,
                IsActive = y.IsActive,
                StartDateShamsi = y.StartDate.GeorgianDateToPersianDate(),
                EndDateShamsi = y.EndDate.GeorgianDateToPersianDate(),
                CountOfPersons = y.ContractOfPersons.Count
            });


        var result = new PagedQueryResult<ContractDto>
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

    public IList<Contract> GetByFilter()
    {
        return context.Contracts
            .ToList();
    }

    // public List<ContractInfoDto> GetContractInfo(long? contractId)
    // {
    //     if (settings.RedisSetting.IsActive)
    //     {
    //         var redis = ConnectionMultiplexer.Connect(settings.RedisSetting.RedisServer);
    //         var db = redis.GetDatabase();
    //         var contractInfo = db.StringGet("contract_info");
    //         if (!string.IsNullOrEmpty(contractInfo))
    //         {
    //             var informationContract = JsonConvert.DeserializeObject<List<ContractInfoDto>>(contractInfo);
    //             if (contractId.HasValue)
    //             {
    //                 return [informationContract.FirstOrDefault(x => x.Id == contractId)!];
    //             }

    //             return informationContract;
    //         }
    //     }

    //     var informationContracts = context.Contracts
    //         .Where(x => x.IsActive)
    //         .Select(x => new ContractInfoDto
    //         {
    //             Id = x.Id,
    //             StartDate = x.StartDate.GeorgianDateToPersianDate(),
    //             CompletedFile = x.CompletedFile,
    //             ContractName = x.Name,
    //             FileDefect = x.FileDefect,
    //             FileSent = x.FileSent,
    //             TotalPersonage = x.TotalPersonage,
    //             FileNotSend = x.FileNotSend
    //         }).ToList();

    //     if (settings.RedisSetting.IsActive)
    //     {
    //         var redis = ConnectionMultiplexer.Connect(settings.RedisSetting.RedisServer);
    //         var db = redis.GetDatabase();
    //         db.StringSet("contract_info",
    //             JsonConvert.SerializeObject(informationContracts),
    //             new DateTime().Date.AddHours(3).GetTimeSpan());
    //     }

    //     if (contractId.HasValue)
    //     {
    //         return [informationContracts.FirstOrDefault(x => x.Id == contractId)];
    //     }

    //     return informationContracts;
    // }

    public List<ContractDto> GetActiveContractByPersonId(long personId)
    {
        return context.ContractOfPeople
            .Include(x=>x.Contract)
            .Where(x => x.PersonageId == personId && x.Contract.IsActive)
            .Select(x => new ContractDto
            {
                Id = x.ContractId,
                StartDate = x.Contract.StartDate,
                IsActive = x.Contract.IsActive,
                StartDateShamsi = x.Contract.StartDate.GeorgianDateToPersianDate(),
                CountOfPersons = x.Contract.ContractOfPersons.Count,
                EndDateShamsi = x.Contract.EndDate.GeorgianDateToPersianDate(),
                EndDate = x.Contract.EndDate,
                Name = x.Contract.Name
            }).ToList();
    }
    
}