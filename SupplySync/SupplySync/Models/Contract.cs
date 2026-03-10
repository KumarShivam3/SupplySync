using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SupplySync.Constants.Enums;

namespace SupplySync.Models
{
	[Table("Contract")]
	public class Contract
	{
		[Key]
		public int ContractID { get; set; }

		[Required]
		public int VendorID {  get; set; }

		public virtual Vendor Vendor { get; set; } 

		[Required]
		public DateTime StartDate { get; set; }  

		[Required]
		public DateTime EndDate { get; set; }
		
		[Required]
		public decimal Value {  get; set; }

 		public ContractStatus Status { get; set; }
		public DateTime CreatedAt { get; set; } 
		public DateTime? UpdatedAt { get; set; } 

	}
}
