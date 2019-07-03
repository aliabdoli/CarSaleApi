using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarSaleApi.Models;
using CarSaleApi.Services;
using NSubstitute;
using Xunit;

namespace CarSalesApi.UnitTest.Services
{
    public class DiscountAggregatorServiceTests
    {

        [Fact]
        public async Task WhenMultipleDiscount_ThenDiscountIsCumulative()
        {
            //arrange
            var carService = Substitute.For<ICarService>();
            var numberOfDiscountServices = 3;

            var discountServices = Enumerable.Range(0, numberOfDiscountServices).Select(x =>
            {
                var service = Substitute.For<IDiscountService>();
                service.Calculate(Arg.Any<List<Car>>()).Returns(1);
                return service;
            }).ToList();

            var discountService = new DiscountAggregatorService(carService, discountServices);

            carService.GetCarsAsync(Arg.Any<List<int>>()).Returns(new List<Car>());

            //act
            var result = await discountService.CalculateAsync(new List<int>() {1, 2});

            //assert
            Assert.Equal(numberOfDiscountServices, result.DiscountPercent);
        }
    }
}
