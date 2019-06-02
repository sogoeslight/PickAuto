using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickAuto.Models
{
    public class Car
    {
        public int CarId { get; set; }
        [Required]
        public long Mileage { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PurchasePrice { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal RentalPrice { get; set; }



        public int CarModelId { get; set; }
        public CarModel CarModel { get; set; }

        public int CarStatudId { get; set; }
        public CarStatus CarStatus { get; set; }

        public virtual Purchase Purchase { get; set; }
        public virtual Rental Rental { get; set; }
    }
}
