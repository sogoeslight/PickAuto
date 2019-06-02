using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickAuto.Models
{
    public class Store
    {
        [ForeignKey("Address")]
        public int StoreId { get; set; }
        [Required]
        [StringLength(35, MinimumLength = 2)]
        public string Name { get; set; }



        [Required]
        public Address Address { get; set; }



        public ICollection<Worker> Workers { get; set; }
    }
}
