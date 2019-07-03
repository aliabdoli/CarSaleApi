using System.Collections.Generic;
using System.Threading.Tasks;
using CarSaleApi.Models;

namespace CarSaleApi.Services
{
    public class DiscountAggregatorService : IDiscountAggregatorService
    {
        private readonly ICarService _carService;
        private readonly List<IDiscountService> _discountServices;

        public DiscountAggregatorService(ICarService carService, List<IDiscountService> discountServices)
        {
            _carService = carService;
            _discountServices = discountServices;
        }

        public async Task<Discount> CalculateAsync(List<int> ids)
        {
            var cars = await _carService.GetCarsAsync(ids);
            var discount = new Discount
            {
                CarIds = ids
            };

            foreach (var discountService in _discountServices)
                discount.DiscountPercent += discountService.Calculate(cars);

            return discount;
        }
    }
}