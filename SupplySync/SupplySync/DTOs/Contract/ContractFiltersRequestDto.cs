using SupplySync.Constants.Enums;

namespace SupplySync.DTOs.Contract
{
	public class ContractFiltersRequestDto
	{
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public decimal? StartValue { get; set; }
		public decimal? EndValue { get; set; }
		public ContractStatus? Status { get; set; }
	}
}
