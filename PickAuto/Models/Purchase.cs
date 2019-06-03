using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickAuto.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }

        [Required]
        [Display(Name = "Car")]
        public int CarId { get; set; }
        public Car Car { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, 9999999)]
        [Display(Name = "Price, €")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Worker")]
        public int? WorkerId { get; set; }
        public virtual Worker Worker { get; set; }

        [Required]
        [Display(Name = "Customer")]
        public int? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Payment")]
        public DateTime PaymentDate { get; set; }
    }
}
