using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SupplySync.Constants.Enums;

namespace SupplySync.Models
{
	[Table("Warehouse")]
	public class Warehouse
	{
      	    [Key]
			public int WarehouseID { get; set; }

			[Required] 
			public string Location { get; set; }
			public int? Capacity { get; set; }

			[Required]
			public WarehouseStatus Status { get; set; } 
			public DateTime CreatedAt { get; set; }
			public DateTime? UpdatedAt { get; set; }
			public ICollection<Inventory> Inventories { get; set; }
			public ICollection<Receipt> Receipts { get; set; }
		
	}


}


