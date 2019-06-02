using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickAuto.Models
{
    public class Customer
    {
        [ForeignKey("Address")]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }




        public virtual Address Address { get; set; }

        public ICollection<Purchase> Purchases { get; set; }
        public ICollection<Rental> Rentals { get; set; }
    }
}
