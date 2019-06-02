﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickAuto.Models
{
    public class Rental
    {
        [ForeignKey("Car")]
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


        public virtual Car Car { get; set; }

        public int WorkerId { get; set; }
        public Worker Worker { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
