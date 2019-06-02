using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickAuto.Models
{
    public class Address
    {
        public int AddressId { get; set; }
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


        [Required]
        [Display(Name = "City")]
        public int CityId { get; set; }
        public City City { get; set; }

        public virtual Store Store { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
