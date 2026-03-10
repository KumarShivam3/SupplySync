using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SupplySync.Constants.Enums;

namespace SupplySync.Models
{
	[Table("Vendor")]
	public class Vendor
	{
		[Key]
		public int VendorID { get; set; }

		[Required, MaxLength(150)]
		public string Name { get; set; }  

		[Required, MaxLength(255)]
		public string ContactInfo { get; set; } 

		[Required]
		public VendorCategory Category { get; set; }

		[Required]
		public VendorStatus Status { get; set; } 
		public bool IsActive { get; set; }  
		public DateTime CreatedAt { get; set; } 
		public DateTime? UpdatedAt { get; set; } 

	}
}
