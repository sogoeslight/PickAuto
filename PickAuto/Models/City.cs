using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PickAuto.Models
{
    public class City
    {
        public int CityId { get; set; }
        [Required]
        [Display(Name = "Country")]
        public int CountryId { get; set; }
        public Country Country { get; set; }



        [Required]
        [StringLength(25, MinimumLength = 2)]
        public string Name { get; set; }



        public ICollection<Address> Addresses { get; set; }
    }
}
