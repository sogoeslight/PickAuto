using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PickAuto.Models
{
    public class Manufacturer
    {
        public int ManufacturerId { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2)]
        public string Country { get; set; }

        public ICollection<CarModel> CarModels { get; set; }
    }
}
