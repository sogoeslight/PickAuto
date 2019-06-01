﻿using System;
using System.ComponentModel.DataAnnotations;

namespace PickAuto.Models
{
    public class Payment
    {
        public int Id { get; set; }
        [Required]
        public Customer Customer { get; set; }
        [Required]
        public Staff Worker { get; set; }
        public Rental Rental { get; set; }
        [Required]
        public Car Car { get; set; }
        [Required]
        public long AmountOfMoney { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }
    }
}
