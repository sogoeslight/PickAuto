using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickAuto.Models
{
    public class Address
    {
        [ForeignKey("Customer")]
        public int AddressId { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string AddressLine1 { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string AddressLine2 { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 4)]
        public string PostalCode { get; set; }


        public int CityId { get; set; }
        public City City { get; set; }

        public virtual Store Store { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
