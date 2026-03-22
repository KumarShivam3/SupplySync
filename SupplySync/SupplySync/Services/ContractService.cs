using System.Numerics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SupplySync.DTOs.Contract;
using SupplySync.Models;
using SupplySync.Repositories.Interfaces;
using SupplySync.Services.Interfaces;

namespace SupplySync.Services
{
	public class ContractService : IContractService
	{
		private readonly IContractRepository _contractRepository;
		private readonly IVendorRepository _vendorRepository;
		private readonly IMapper _mapper;

		public ContractService(IContractRepository contractRepository, IMapper mapper, IVendorRepository vendorRepository)
		{
			_contractRepository = contractRepository;
			_mapper = mapper;
			_vendorRepository = vendorRepository;
		}

		public async Task<List<ContractWithTermsResponseDto>> GetAllContractsByVendorId(int vendorId, ContractFiltersRequestDto contractFiltersRequestDto)
		{
			Vendor? vendor = await _vendorRepository.GetVendorById(vendorId);
			if(vendor == null || vendor.IsDeleted==true)
			{
				throw new ArgumentException("Vendor Not Available.");
			}

			List<Contract> contracts = await _contractRepository.GetContractsByVendorId(vendorId, contractFiltersRequestDto);

			if (contracts.Count <= 0)
			{
				throw new KeyNotFoundException($"There is no Contracts available for Vendor Id {vendorId}");
			}


			List<ContractWithTermsResponseDto> contractWithTermsResponseDtos = _mapper.Map<List<ContractWithTermsResponseDto>>(contracts);

			return contractWithTermsResponseDtos;
		}

		[HttpGet("{contractId}")]
		public async Task<ContractResponseDto> GetContractById(int contractId)
		{
			Contract? contract = await _contractRepository.GetContractById(contractId);
			if (contract == null || contract.IsDeleted==true) {
				throw new KeyNotFoundException("Contract Not Found");
			}
			return _mapper.Map<ContractResponseDto>(contract);
		}
		public async Task<ContractResponseDto> CreateContract(CreateContractRequestDto createContractRequestDto)
		{
			Contract newContract = _mapper.Map<Contract>(createContractRequestDto);
			
			Contract contract = await _contractRepository.CreateContract(newContract);
			if (contract == null)
			{
				throw new ArgumentException("Contract Not Created, some error occured");
			}
			ContractResponseDto contractResponseDto = _mapper.Map<ContractResponseDto>(contract);

			return contractResponseDto;
		}

		public async Task<ContractResponseDto> UpdateContract(int contractId, UpdateContractRequestDto updateContractRequestDto)
		{

			Contract? existingContract = await _contractRepository.GetContractById(contractId);

			if (existingContract == null || existingContract.IsDeleted == true)
			{
				throw new KeyNotFoundException($"Vendor with ID {contractId} not found.");
			}

			_mapper.Map(updateContractRequestDto, existingContract);
			existingContract.ContractID = contractId;
			Contract? updatedContract = await _contractRepository.UpdateContract(existingContract);

			if (updatedContract != null) {
				throw new KeyNotFoundException("Contract Data not Updated.");
			}

			ContractResponseDto contractResponseDto = _mapper.Map<ContractResponseDto>(existingContract);

			return contractResponseDto;
		}

		public async Task<ContractTermResponseDto> CreateContractTerm(CreateContractTermRequestDto createContractTermRequestDto)
		{
			ContractTerm newContractTerm = _mapper.Map<ContractTerm>(createContractTermRequestDto);

			ContractTerm? contractTerm = await _contractRepository.CreateContractTerm(newContractTerm);
			if (contractTerm == null || contractTerm.IsDeleted == true)
			{
				throw new ArgumentException("Contract Term Not Created, some error occured");
			}
			ContractTermResponseDto contractTermResponseDto = _mapper.Map<ContractTermResponseDto>(contractTerm);
			return contractTermResponseDto;
		}

		public async Task<List<ContractTermResponseDto>> GetAllContractTermByContractId(int contractId, ContractTermFiltersRequestDto contractTermFiltersRequestDto)
		{
			Contract? contract = await _contractRepository.GetContractById(contractId);
			if (contract == null || contract.IsDeleted == true)
			{
				throw new KeyNotFoundException("Contract Not Available");
			}

			List<ContractTerm> contractTerms = await _contractRepository.GetAllContractTermByContractId(contractId, contractTermFiltersRequestDto);

			if (contractTerms.Count <= 0)
			{
				throw new KeyNotFoundException("Contract Term Not Available");
			}

			return _mapper.Map<List<ContractTermResponseDto>>(contractTerms);
		}
	}
}
