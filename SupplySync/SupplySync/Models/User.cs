using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SupplySync.Constants;
using SupplySync.Constants.Enums;

namespace SupplySync.Models
{
	[Table("User")]
	public class User
	{
		[Key]
		public int UserID { get; set; } // PK, Identity

		[Required, MaxLength(150)]
		public string Name { get; set; } = default!;

		[Required ]
		[MaxLength(50)]
		private string Email = default!;
		
		public string? Phone { get; set; } 

		[Required]
		public UserStatus Status { get; set; } = UserStatus.Pending; 

		[Required]
		public bool IsActive { get; set; } = false;

		[Required]
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

		[Required]
		public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

		public virtual ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
	}
}