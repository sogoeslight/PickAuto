using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickAuto.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ProductionYear { get; set; }
        [Required]
        [Range(1, 70)]
        public int NumberOfSeats { get; set; }



        [Required]
        public Gearbox Gearbox { get; set; }
        [Required]
        public FuelType FuelType { get; set; }
        [Required]
        public WheelDrive WheelDrive { get; set; }
        [Required]
        //[ForeignKey("ManufacturerID")]
        public Manufacturer Manufacturer { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
