using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
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
 		public DateTime CreatedAt { get; set; } 
		public DateTime UpdatedAt { get; set; } 
		public ICollection<UserRole> UserRoles { get; set; } 
	}
}
