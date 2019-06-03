using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickAuto.Models
{
    public class Rental
    {
        public int RentalId { get; set; }
        [Required]
        [Display(Name = "Car")]
        public int CarId { get; set; }
        public Car Car { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, 9999999)]
        [Display(Name = "Rental Monthly Rate, €")]
        public decimal RentalRate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start of Rental")]
        [DisplayFormat(DataFormatString = "{0:MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RentalStart { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End of Rental")]
        [DisplayFormat(DataFormatString = "{0:MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RentalEnd { get; set; }
                       
        [Required]
        [Display(Name = "Worker")]
        public int? WorkerId { get; set; }
        public Worker Worker { get; set; }

        [Required]
        [Display(Name = "Customer")]
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Payment")]
        public DateTime PaymentDate { get; set; }
    }
}
