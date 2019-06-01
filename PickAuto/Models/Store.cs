using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PickAuto.Models
{
    public class Store
    {
        public int Id { get; set; }
        [Required]
        [StringLength(35, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        public Address Address { get; set; }
        public ICollection<Staff> Workers { get; set; }
    }
}
