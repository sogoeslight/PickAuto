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
        public DateTime RentalStart { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime RentalEnd { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }



        //[Required]
        //[ForeignKey("CustomerID")]
        //public Customer Customer { get; set; }
        //[Required]
        //[ForeignKey("WorkerID")]
        //public Worker Worker { get; set; }
        //[Required]
        //[ForeignKey("CarID")]
        //public Car Car { get; set; }
    }
}
