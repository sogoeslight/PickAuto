using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PickAuto.Models
{
    public class City
    {
        public int Id { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 2)]
        public string Name { get; set; }



        [Required]
        public Country Country { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}
