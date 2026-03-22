using SupplySync.DTOs.Contract;
using SupplySync.Models;

namespace SupplySync.Repositories.Interfaces
{
	public interface IContractRepository
	{
		Task<Contract> CreateContract(Contract newContract);
		Task<ContractTerm> CreateContractTerm(ContractTerm newContractTerm);
		Task<List<ContractTerm>> GetAllContractTermByContractId(int contractId, ContractTermFiltersRequestDto contractTermFiltersRequestDto);
		Task<Contract> GetContractById(int contractId);
		Task<List<Contract>> GetContractsByVendorId(int vendorId, DTOs.Contract.ContractFiltersRequestDto contractFiltersRequestDto);
		Task<Contract?> UpdateContract(Contract contract);
	}
}
