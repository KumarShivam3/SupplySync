using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupplySync.Models
{
	[Table("UserRole")]
	public class UserRole
	{
		[Key]
		public int UserRoleID { get; set; } // PK

		[Required, ForeignKey(nameof(User))]
		public int UserID { get; set; }

		[Required, ForeignKey(nameof(Role))]
		public int RoleID { get; set; }

		[Required]
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

		[Required]
		public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

		// Navigation
		public virtual User User { get; set; } = default!;
		public virtual Role Role { get; set; } = default!;
	}
}