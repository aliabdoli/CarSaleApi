using System.Collections.Generic;
using System.Linq;
using CarSaleApi.Models;

namespace CarSaleApi.Services
{
    public class AmountDiscountService : IDiscountService
    {
        public const int AmountThreshold = 100000;
        public const int AmountPercent = 5;

        public int Calculate(List<Car> cars) => cars.Sum(x => x.Price) > AmountThreshold ? AmountPercent : 0;
    }
}
