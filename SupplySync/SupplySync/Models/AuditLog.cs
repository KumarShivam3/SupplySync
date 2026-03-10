using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SupplySync.Constants.Enums;

namespace SupplySync.Models
{
	[Table("AuditLog")]
	public class AuditLog
	{
		[Key]
		public int AuditID { get; set; }

		// Nullable if system job
		public int? UserID { get; set; }

		[Required, MaxLength(100)]
		public string Action { get; set; } 

		[Required, MaxLength(200)]
		public string Resource { get; set; } 

		public DateTime Timestamp { get; set; } 

 		public DateTime CreatedAt { get; set; } 

 		public DateTime UpdatedAt { get; set; } 

		// Navigation
		public virtual User? User { get; set; }
	}
}