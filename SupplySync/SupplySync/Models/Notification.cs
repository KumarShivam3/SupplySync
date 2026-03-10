using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
using SupplySync.Constants.Enums;

namespace SupplySync.Models
{
	[Table("Notification")]
	public class Notification
	{
		[Key]
		public int NotificationID { get; set; } // PK (Identity)

		[Required]
		public int UserID { get; set; } // required

 		public int? ContractID { get; set; } // nullable

		[Required]
		public string Message { get; set; }   // TEXT (no HTML)

		[Required]
		public NotificationCategory Category { get; set; } // VARCHAR(20)

		[Required]
		public NotificationStatus Status { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		// Navigation
		public virtual User User { get; set; }
		public virtual Contract? Contract { get; set; }
	}
}