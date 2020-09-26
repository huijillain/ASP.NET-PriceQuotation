using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PriceQuotationMVC.Models
{
    public class PriceQuotationModel
    {
        [Required(ErrorMessage = "Please enter the Subtotal amount!")]
        [Range(0, 10000, ErrorMessage = "Subtotal amount must be greater than zero.")]
        public decimal Subtotal { get; set; }   // property
        [Required(ErrorMessage = "Please enter the discount percentage!")]
        [Range(0, 100, ErrorMessage = "Discount percentage must be in range 0 to 100")]
        public decimal DiscountPercent { get; set; }  // property      
        public decimal CalculateDiscountAmount()            // method
        {
            decimal discountAmount = Subtotal * DiscountPercent / 100;
            return discountAmount;
        }
        public decimal CalculateTotal()            // method
        {
            decimal discountAmount = Subtotal * DiscountPercent / 100;
            decimal total = Subtotal - discountAmount;
            return total;
        }
    }
}
