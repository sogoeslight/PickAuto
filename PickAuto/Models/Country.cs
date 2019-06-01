using System.ComponentModel.DataAnnotations;

namespace PickAuto.Models
{
    public class Country
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Name { get; set; }
    }
}
