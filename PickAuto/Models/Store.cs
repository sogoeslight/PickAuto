using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickAuto.Models
{
    public class Store
    {
        public int StoreId { get; set; }

        [Required]
        [StringLength(35, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Country { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string City { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 2)]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 2)]
        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 4)]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
                     
        public ICollection<Worker> Workers { get; set; }
    }
}
