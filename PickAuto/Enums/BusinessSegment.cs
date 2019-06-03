using System.ComponentModel.DataAnnotations;

public enum BusinessSegment
{
    [Display(Name = "For Sell")]
    ForSell,
    [Display(Name = "For Rental")]
    ForRental,
    [Display(Name = "For Sell or Rental")]
    ForSellOrRental
}