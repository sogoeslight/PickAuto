﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PickAuto.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 2)]
        public string LastName { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }



        [Required]
        public Address Address { get; set; }

        public ICollection<Purchase> Purchases { get; set; }
        public ICollection<Rental> Rentals { get; set; }
    }
}
