using Microsoft.EntityFrameworkCore;
using SupplySync.Config;
using SupplySync.DTOs.Contract;
using SupplySync.Models;
using SupplySync.Repositories.Interfaces;

namespace SupplySync.Repositories
{
	public class ContractRepository : IContractRepository
	{
		private readonly AppDbContext _appDbContext;
		public ContractRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public async Task<List<Contract>> GetContractsByVendorId(int vendorId, ContractFiltersRequestDto filters)
		{
			var query = _appDbContext.Contracts.AsQueryable();
			if (filters.StartDate.HasValue)
			{
				query = query.Where(c=>c.StartDate >= filters.StartDate);
			}
			if (filters.EndDate.HasValue)
			{
				query = query.Where(c => c.EndDate <= filters.EndDate);
			}
			if (filters.StartValue.HasValue)
			{
				query = query.Where(c => c.Value >= filters.StartValue);
			}
			if (filters.EndValue.HasValue)
			{ 
				query = query.Where(c => c.Value <= filters.EndValue);
			}
			if (filters.Status.HasValue) 
			{
				query = query.Where(c => c.Status == filters.Status);
			}

			return await query.Where(c => c.VendorID == vendorId && c.IsDeleted==false).Include(c=> c.ContractTerms).ToListAsync();

		}

		public async Task<Contract?> GetContractById(int contractId)
		{
			Contract? contract =  await _appDbContext.Contracts.FirstOrDefaultAsync(x => x.ContractID == contractId && x.IsDeleted==false);
			return contract;
		}

		public async Task<Contract> CreateContract(Contract newContract)
		{
			await _appDbContext.Contracts.AddAsync(newContract);
			await _appDbContext.SaveChangesAsync();
			return newContract;
		}

		public async Task<Contract?> UpdateContract(Contract contract)
		{
			_appDbContext.Contracts.Update(contract);
			await _appDbContext.SaveChangesAsync();
			return contract;
		}

		public async Task<ContractTerm> CreateContractTerm(ContractTerm newContractTerm)
		{
			await _appDbContext.ContractTerms.AddAsync(newContractTerm);
			await _appDbContext.SaveChangesAsync();
			return newContractTerm;
		}

		public async Task<List<ContractTerm>> GetAllContractTermByContractId(int contractId, ContractTermFiltersRequestDto filter)
		{

			var query = _appDbContext.ContractTerms
					.Where(c => !c.IsDeleted && c.ContractID == contractId)
					.AsQueryable();



			if (filter != null && filter.ComplianceFlag.HasValue)
			{
				query = query.Where(c => c.ComplianceFlag == filter.ComplianceFlag);
			}


			return await query.ToListAsync();
		}
	}
}
