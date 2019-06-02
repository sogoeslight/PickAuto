using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickAuto.Models
{
    public class Rental
    {
        public int RentalId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start of Rental")]
        public DateTime RentalStart { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End of Rental")]
        public DateTime RentalEnd { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Payment")]
        public DateTime PaymentDate { get; set; }


        [Display(Name = "Car")]
        public int CarForeignKey { get; set; }
        public Car Car { get; set; }


        [Display(Name = "Worker")]
        public int? WorkerId { get; set; }
        public Worker Worker { get; set; }
        [Display(Name = "Customer")]
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
