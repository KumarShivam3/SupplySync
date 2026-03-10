using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SupplySync.Constants;
using SupplySync.Constants.Enums;

namespace SupplySync.Models
{
	[Table("Notification")]
	public class Notification
	{
		[Key]
		public int NotificationID { get; set; } // PK (Identity)

		[Required, ForeignKey(nameof(User))]
		public int UserID { get; set; } // required

		[ForeignKey(nameof(Contract))]
		public int? ContractID { get; set; } // nullable

		[Required]
		public string Message { get; set; } = default!; // TEXT (no HTML)

		[Required]
		public NotificationCategory Category { get; set; } // VARCHAR(20)

		[Required]
		public NotificationStatus Status { get; set; } = NotificationStatus.Unread; // VARCHAR(20)

		[Required]
		public DateTime CreatedDate { get; set; } = DateTime.UtcNow; // TIMESTAMP (UTC)

		[Required]
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

		[Required]
		public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

		// Navigation
		public virtual User User { get; set; } = default!;
		public virtual Contract? Contract { get; set; }
	}
}