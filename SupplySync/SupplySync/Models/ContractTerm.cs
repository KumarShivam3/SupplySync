using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SupplySync.Constants.Enums;

namespace SupplySync.Models
{
	[Table("ContractTerm")]
	public class ContractTerm
	{
		[Key]
		public int TermID { get; set; }

		[Required]
		public int ContractID { get; set; }

		public virtual Contract Contract { get; set; } 

		[Required]
		public string Description { get; set; } 

		[Required]
		public bool ComplianceFlag {  get; set; } 

		public DateTime CreatedAt { get; set; } 
		public DateTime? UpdatedAt { get; set; } 
	}
}
