using SupplySync.Constants.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupplySync.Models
{
    [Table("Payment")]
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        [Required]
        public int InvoiceId { get; set; }
        [ForeignKey("InvoiceId")]
        public virtual Invoice Invoice { get; set; } = default!;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01,double.MaxValue)]
        public decimal Amount { get; set;  }

        [Required]
        public DateTime Date { get; set; } 
        [Required]
        public PaymentMethod Method { get; set;  }
        [Required]
        public PaymentStatus Status { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;


    }
}
