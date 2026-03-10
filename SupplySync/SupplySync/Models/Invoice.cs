using SupplySync.Constants.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupplySync.Models
{
    [Table("Invoice")]
    public class Invoice
    {
        
        [Key]
        public int InvoiceId { get; set; }

        [Required]
        public int POID { get; set; }
        [ForeignKey("POID")]
        public virtual PurchaseOrder PurchaseOrder { get; set; } = default!; // FK → PurchaseOrder(POID)

        [Required]
        public int VendorId { get; set; }
        [ForeignKey("VendorId")]
        public virtual Vendor Vendor { get; set; } = default!; //FK → Vendor(VendorID)

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0,double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get;set;  }

        [Required]
        public InvoiceStatus Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;

    }
}
