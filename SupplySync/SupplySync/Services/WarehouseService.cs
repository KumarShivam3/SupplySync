using AutoMapper;
using SupplySync.DTOs.InventoryandWarehouse;
using SupplySync.Models;
using SupplySync.Repositories.Interfaces;
using SupplySync.Services.Interfaces;

namespace SupplySync.Services
{
	public class WarehouseService : IWarehouseService
	{
		private readonly IWarehouseRepository _warehouseRepository;
		private readonly IMapper _mapper;

		public WarehouseService(IWarehouseRepository warehouseRepository, IMapper mapper)
		{
			_warehouseRepository = warehouseRepository;
			_mapper = mapper;
		}

		public async Task<int> CreateAsync(CreateWarehouseDto dto)
		{
			if (dto == null)
			{
				throw new ArgumentException("Warehouse data is required.");
			}

			Warehouse newWarehouse = _mapper.Map<Warehouse>(dto);
			newWarehouse.CreatedAt = DateTime.UtcNow;
			newWarehouse.IsDeleted = false;

			Warehouse warehouse = await _warehouseRepository.InsertAsync(newWarehouse);

			if (warehouse == null)
			{
				throw new ArgumentException("Warehouse not created. An error occurred.");
			}

			return warehouse.WarehouseID;
		}

		public async Task<WarehouseResponseDto?> GetByIdAsync(int warehouseId)
		{
			if (warehouseId <= 0)
			{
				throw new ArgumentException("Warehouse ID must be greater than 0.");
			}

			Warehouse? warehouse = await _warehouseRepository.GetByIdAsync(warehouseId);

			if (warehouse == null || warehouse.IsDeleted == true)
			{
				throw new KeyNotFoundException($"Warehouse with ID {warehouseId} not found.");
			}

			return _mapper.Map<WarehouseResponseDto>(warehouse);
		}

		public async Task<WarehouseResponseDto?> UpdateAsync(int warehouseId, UpdateWarehouseRequestDto dto)
		{
			if (warehouseId <= 0)
			{
				throw new ArgumentException("Warehouse ID must be greater than 0.");
			}

			if (dto == null)
			{
				throw new ArgumentException("Warehouse data is required.");
			}

			Warehouse? existingWarehouse = await _warehouseRepository.GetByIdAsync(warehouseId);

			if (existingWarehouse == null || existingWarehouse.IsDeleted == true)
			{
				throw new KeyNotFoundException($"Warehouse with ID {warehouseId} not found.");
			}

			_mapper.Map(dto, existingWarehouse);
			existingWarehouse.UpdatedAt = DateTime.UtcNow;

			Warehouse? updatedWarehouse = await _warehouseRepository.UpdateAsync(existingWarehouse);

			if (updatedWarehouse == null)
			{
				throw new ArgumentException("Warehouse data not updated. An error occurred.");
			}

			return _mapper.Map<WarehouseResponseDto>(updatedWarehouse);
		}

		public async Task<bool> DeleteAsync(int warehouseId)
		{
			if (warehouseId <= 0)
			{
				throw new ArgumentException("Warehouse ID must be greater than 0.");
			}

			Warehouse? warehouse = await _warehouseRepository.GetByIdAsync(warehouseId);

			if (warehouse == null || warehouse.IsDeleted == true)
			{
				throw new KeyNotFoundException($"Warehouse with ID {warehouseId} not found.");
			}

			bool result = await _warehouseRepository.SoftDeleteAsync(warehouseId);

			if (!result)
			{
				throw new ArgumentException("Warehouse not deleted. An error occurred.");
			}

			return true;
		}

		public async Task<List<WarehouseListResponseDto>> ListAsync(string? location, string? status, int? capacity)
		{
			List<Warehouse> warehouses = await _warehouseRepository.ListAsync(location, status, capacity);

			if (warehouses.Count <= 0)
			{
				throw new KeyNotFoundException("No warehouses available.");
			}

			return _mapper.Map<List<WarehouseListResponseDto>>(warehouses);
		}
	}
}

