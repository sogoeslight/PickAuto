using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickAuto.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }



        //public int CustomerId { get; set; }

        //public int WorkerId { get; set; }
        //public Worker Worker { get; set; }

        //public int CarId { get; set; }
    }
}
