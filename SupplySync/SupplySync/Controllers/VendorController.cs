using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SupplySync.DTOs.Vendor;
using SupplySync.Services.Interfaces;

namespace SupplySync.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VendorController : ControllerBase
	{
		private readonly IVendorService _vendorService;
		public VendorController(IVendorService vendorService) 
		{
			_vendorService = vendorService;
		}

		/// <summary>
		///  Vendor Endpoints
		/// </summary>

		/// <summary>
		///  get Vendor
		/// </summary>
		
		[Authorize]
		[HttpGet("{vendorId}")]
		public async Task<IActionResult> GetVendorById([FromRoute] int vendorId)
		{
			VendorResponseDto vendorResponseDto = await _vendorService.GetVendorById(vendorId);
			return Ok(vendorResponseDto);
		}

		/// <summary>
		///  get All Vendor with filter
		/// </summary>
		[Authorize(Roles = "Admin,ProcurementOfficer,WarehouseManager,FinanceOfficer,ComplianceOfficer")]
		[HttpGet("")]
		public async Task<IActionResult> GetAllVendorWithFilter([FromQuery] GetVendorFiltersRequestDto getVendorFiltersRequestDto)
		{
			List<VendorResponseDto> vendorResponseDto = await _vendorService.GetAllVendorWithFilter(getVendorFiltersRequestDto);
			return Ok(vendorResponseDto);
		}



		/// <summary>
		///  Create Vendor
		/// </summary>
		[HttpPost("")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> CreateVendor([FromBody] CreateVendorRequestDto createVendorRequestDto)
		{
			VendorResponseDto createdVendor = await _vendorService.CreateVendor(createVendorRequestDto);

			return Ok(createdVendor);
		}

		/// <summary>
		///  update Vendor
		/// </summary>
		[Authorize(Roles = "Admin,VendorUser")]
		[HttpPut("{vendorId}")]
		public async Task<IActionResult> UpdateVendor([FromRoute] int vendorId, [FromBody] UpdateVendorRequestDto updateVendorRequestDto)
		{
			VendorResponseDto? vendorResponseDto = await _vendorService.UpdateVendor(vendorId, updateVendorRequestDto);

			return Ok(vendorResponseDto);
		}


		/// <summary>
		///  Vendor Document Endpoints
		/// </summary>

		/// <summary>
		///  get All Vendor Document
		/// </summary>
		[Authorize]
		[HttpGet("{vendorId}/documents")]
		public async Task<IActionResult> GetAllVendorDocument([FromRoute] int vendorId)
		{
			List<VendorDocumentResponseDto> vendorDocumentResponseDtos = await _vendorService.GetAllVendorDocument(vendorId);
			return Ok(vendorDocumentResponseDtos);
		}

		/// <summary>
		///  Create Vendor Document
		/// </summary>
		[Authorize(Roles = "Admin,VendorUser")]
		[HttpPost("{vendorId}/documents")]
		public async Task<IActionResult> CreateVendorDocument([FromBody] CreateVendorDocumentRequestDto createVendorDocumentRequestDto)
		{
			VendorDocumentResponseDto createdVendorDocument = await _vendorService.CreateVendorDocument(createVendorDocumentRequestDto);
			return Ok(createdVendorDocument);
		}

	}
}
