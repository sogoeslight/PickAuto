using System.ComponentModel.DataAnnotations;

namespace PickAuto.Models
{
    public class Address
    {
        public int Id { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string AddressLine1 { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string AddressLine2 { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 4)]
        public string PostalCode { get; set; }
        [Required]
        public City City { get; set; }
    }
}
