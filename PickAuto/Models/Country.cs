using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PickAuto.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }
        public ICollection<Manufacturer> Manufacturers { get; set; }
    }
}
