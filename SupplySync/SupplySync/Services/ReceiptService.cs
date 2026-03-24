using AutoMapper;
using SupplySync.DTOs.InventoryandWarehouse;
using SupplySync.Models;
using SupplySync.Repositories.Interfaces;
using SupplySync.Services.Interfaces;

namespace SupplySync.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly IReceiptRepository _receiptRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;

        public ReceiptService(IReceiptRepository receiptRepository, IWarehouseRepository warehouseRepository, IMapper mapper)
        {
            _receiptRepository = receiptRepository;
            _warehouseRepository = warehouseRepository;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(CreateReceiptRequestDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentException("Receipt data is required.");
            }

            // Validate warehouse exists
            Warehouse? warehouse = await _warehouseRepository.GetByIdAsync(dto.WarehouseID);
            if (warehouse == null || warehouse.IsDeleted == true)
            {
                throw new ArgumentException($"Warehouse with ID {dto.WarehouseID} not available.");
            }

            Receipt newReceipt = _mapper.Map<Receipt>(dto);
            newReceipt.CreatedAt = DateTime.UtcNow;
            newReceipt.IsDeleted = false;

            Receipt receipt = await _receiptRepository.InsertAsync(newReceipt);

            if (receipt == null)
            {
                throw new ArgumentException("Receipt not created. An error occurred.");
            }

            return receipt.ReceiptID;
        }

        public async Task<ReceiptResponseDto?> GetByIdAsync(int receiptId)
        {
            if (receiptId <= 0)
            {
                throw new ArgumentException("Receipt ID must be greater than 0.");
            }

            Receipt? receipt = await _receiptRepository.GetByIdAsync(receiptId);

            if (receipt == null || receipt.IsDeleted == true)
            {
                throw new KeyNotFoundException($"Receipt with ID {receiptId} not found.");
            }

            return _mapper.Map<ReceiptResponseDto>(receipt);
        }

        public async Task<ReceiptResponseDto?> UpdateAsync(int receiptId, UpdateReceiptRequestDto dto)
        {
            if (receiptId <= 0)
            {
                throw new ArgumentException("Receipt ID must be greater than 0.");
            }

            if (dto == null)
            {
                throw new ArgumentException("Receipt data is required.");
            }

            Receipt? existingReceipt = await _receiptRepository.GetByIdAsync(receiptId);

            if (existingReceipt == null || existingReceipt.IsDeleted == true)
            {
                throw new KeyNotFoundException($"Receipt with ID {receiptId} not found.");
            }

            // Validate warehouse if being updated
            if (dto.WarehouseID.HasValue && dto.WarehouseID != existingReceipt.WarehouseID)
            {
                Warehouse? warehouse = await _warehouseRepository.GetByIdAsync(dto.WarehouseID.Value);
                if (warehouse == null || warehouse.IsDeleted == true)
                {
                    throw new ArgumentException($"Warehouse with ID {dto.WarehouseID} not available.");
                }
            }

            _mapper.Map(dto, existingReceipt);
            existingReceipt.UpdatedAt = DateTime.UtcNow;

            Receipt? updatedReceipt = await _receiptRepository.UpdateAsync(existingReceipt);

            if (updatedReceipt == null)
            {
                throw new ArgumentException("Receipt data not updated. An error occurred.");
            }

            return _mapper.Map<ReceiptResponseDto>(updatedReceipt);
        }

        public async Task<bool> DeleteAsync(int receiptId)
        {
            if (receiptId <= 0)
            {
                throw new ArgumentException("Receipt ID must be greater than 0.");
            }

            Receipt? receipt = await _receiptRepository.GetByIdAsync(receiptId);

            if (receipt == null || receipt.IsDeleted == true)
            {
                throw new KeyNotFoundException($"Receipt with ID {receiptId} not found.");
            }

            bool result = await _receiptRepository.SoftDeleteAsync(receiptId);

            if (!result)
            {
                throw new ArgumentException("Receipt not deleted. An error occurred.");
            }

            return true;
        }

        public async Task<List<ReceiptListResponseDto>> ListAsync(
            int? warehouseId,
            int? deliveryId,
            string? status,
            DateOnly? fromDate,
            DateOnly? toDate)
        {
            // Validate warehouse if provided
            if (warehouseId.HasValue)
            {
                Warehouse? warehouse = await _warehouseRepository.GetByIdAsync(warehouseId.Value);
                if (warehouse == null || warehouse.IsDeleted == true)
                {
                    throw new KeyNotFoundException($"Warehouse with ID {warehouseId} not available.");
                }
            }

            List<Receipt> receipts = await _receiptRepository.ListAsync(warehouseId, deliveryId, status, fromDate, toDate);

            if (receipts.Count <= 0)
            {
                throw new KeyNotFoundException("No receipts available.");
            }

            return _mapper.Map<List<ReceiptListResponseDto>>(receipts);
        }
    }
}
