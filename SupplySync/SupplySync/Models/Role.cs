using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SupplySync.Constants;
using SupplySync.Constants.Enums;

namespace SupplySync.Models
{
	[Table("Role")]
	public class Role
	{
		[Key]
		public int RoleID { get; set; }

		[Required]
		public RoleType RoleType { get; set; } // Enum -> stored as string

		[Required]
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

		[Required]
		public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

		public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
	}
}
