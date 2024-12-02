
using HealthCare.Core.Domains.Contracts.Entities;
using HealthCare.Core.Domains.Users.Repositories;
using HealthCare.Infrastructures.Shared.Enums;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Infrastructures.Data.SqlServer.Contracts.Repositories;

public class ContractCommandRepository(HealthCareDbContext context) : IContractCommandRepository
{
    public void Create(Contract contract)
    {
        context.Contracts.Add(contract);
    }

    public void Edit(Contract contract)
    {
        context.Contracts.Update(contract);
    }

    public void Delete(Contract contract)
    {
        context.Contracts.Remove(contract);
    }

    public void RefreshContractInfo(long contractId)
    {
        var contractInfo = context.Contracts
            .Include(contract => contract.ContractOfPersons)
            .FirstOrDefault(x => x.Id == contractId);

        if (contractInfo == null)
        {
            throw new Exception("Contract info not found");
        }

        contractInfo.TotalPersonage = contractInfo.ContractOfPersons.Count;

        //TODO
        contractInfo.FileDefect = context.DamageFileDetails
            .Count(x => x.DamageFileState == DamageFileState.Defective && x.ContractOfPerson.ContractId == contractId);

        contractInfo.CompletedFile = context.DamageFileDetails
            .Count(x => x.DamageFileState == DamageFileState.Completed && x.ContractOfPerson.ContractId == contractId);

        contractInfo.FileSent = context.DamageFileDetails
            .Count(x => x.DamageFileState == DamageFileState.Posted && x.ContractOfPerson.ContractId == contractId);

        contractInfo.FileNotSend = context.DamageFileDetails
            .Count(x => (x.DamageFileState == DamageFileState.InitialRegistration ||
                         x.DamageFileState == DamageFileState.RegistrationDocuments) &&
                        x.ContractOfPerson.ContractId == contractId);

        context.Contracts.Update(contractInfo);
    }
}