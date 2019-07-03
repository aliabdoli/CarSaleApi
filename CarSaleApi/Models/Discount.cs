using System.Collections.Generic;

namespace CarSaleApi.Models
{
    public class Discount
    {
        public List<int> CarIds { get; set; }
        public int DiscountPercent { get; set; }
    }
}