using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
using SupplySync.Constants.Enums;

namespace SupplySync.Models
{
	[Table("VendorDocument")]
	public class VendorDocument
	{
		[Key]
		public int DocumentID { get; set; }

		[Required]
		public int VendorID { get; set; }

		[Required]
		public VendorDocumentDocType DocType { get; set; }

		[Required]
		public string FileURI { get; set; }  
		public DateTime UploadedDate { get; set; }  
		public VendorDocumentVerificationStatus VerificationStatus { get; set; }  
		public DateTime CreatedAt { get; set; } 
		public DateTime? UpdatedAt { get; set; }  
		public virtual Vendor Vendor { get; set; } 

	}
}
