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
        [Display(Name = "Purchase Price")]
        public decimal PurchasePrice { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Rental Price")]
        public decimal RentalPrice { get; set; }



        public int CarModelId { get; set; }
        [Display(Name = "Model")]
        public CarModel CarModel { get; set; }

        [Display(Name = "Status")]
        public int CarStatudId { get; set; }
        public CarStatus CarStatus { get; set; }

        public virtual Purchase Purchase { get; set; }
        public virtual Rental Rental { get; set; }
    }
}
