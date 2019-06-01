﻿using System;
using System.ComponentModel.DataAnnotations;

namespace PickAuto.Models
{
    public class Rental
    {
        public int Id { get; set; }
        [Required]
        public Customer Customer { get; set; }
        [Required]
        public Staff Worker { get; set; }
        [Required]
        public Car Car { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime RentalStart { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime RentalEnd { get; set; }
    }
}