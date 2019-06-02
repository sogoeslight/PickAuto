using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickAuto.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }


        public int CarForeignKey { get; set; }
        public Car Car { get; set; }


        public int? WorkerId { get; set; }
        public virtual Worker Worker { get; set; }
        public int? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
