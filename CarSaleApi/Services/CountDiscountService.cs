using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSaleApi.Models;

namespace CarSaleApi.Services
{
    public class CountDiscountService : IDiscountService
    {
        public const int QuantityThreshold = 2;
        public const int QuantityPercent = 3;
        public int Calculate(List<Car> cars) => cars.Count() > QuantityThreshold ? QuantityPercent : 0;
    }
}
