using System.ComponentModel.DataAnnotations;

namespace PickAuto.Models
{
    public class WheelDrive
    {
        public int Id { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 2)]
        public string Name { get; set; }
    }
}
