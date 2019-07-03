using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSaleApi.Models
{
    public class Discount
    {
        public List<int> CarIds { get; set; }
        public int DiscountPercent { get; set; }
    }
}
