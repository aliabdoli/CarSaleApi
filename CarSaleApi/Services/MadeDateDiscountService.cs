using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSaleApi.Models;

namespace CarSaleApi.Services
{
    public class MadeDateDiscountService : IDiscountService
    {
        public DateTime MadeDateTimeThreshold { get; } = new DateTime(2000, 1, 1);
        public const int MadeDateTimePercent = 10;

        public int Calculate(List<Car> cars) =>
            cars.All(x => x.MadeDateTime < MadeDateTimeThreshold) ? MadeDateTimePercent : 0;

    }
}
