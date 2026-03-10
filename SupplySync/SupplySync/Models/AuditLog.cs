using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupplySync.Models
{
	[Table("AuditLog")]
	public class AuditLog
	{
		[Key]
		public int AuditID { get; set; }

		// Nullable if system job
		[ForeignKey(nameof(User))]
		public int? UserID { get; set; }

		[Required, MaxLength(100)]
		public string Action { get; set; } = default!; // e.g., CREATE_PO, APPROVE_INVOICE

		[Required, MaxLength(200)]
		public string Resource { get; set; } = default!; // e.g., "PO:1004"

		[Required]
		public DateTime Timestamp { get; set; } = DateTime.UtcNow;

		[Required]
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

		[Required]
		public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

		// Navigation
		public virtual User? User { get; set; }
	}
}