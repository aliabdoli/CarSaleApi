using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSaleApi.Models.Controllers
{
    public class DiscountGetRequest
    {
        public List<int> CarIds { get; set; }
    }
}
