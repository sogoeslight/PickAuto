using System.ComponentModel.DataAnnotations;

namespace PickAuto.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        public Manufacturer Manufacturer { get; set; }
    }
}
