using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickAuto.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        public long Mileage { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Purchase { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Rental { get; set; }



        [Required]
        public CarModel CarModel { get; set; }
        [Required]
        public CarStatus CarStatus { get; set; }
    }
}
