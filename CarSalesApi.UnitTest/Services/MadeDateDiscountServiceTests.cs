using System.Collections.Generic;
using System.Linq;
using CarSaleApi.Models;
using CarSaleApi.Services;
using NSubstitute;
using Xunit;

namespace CarSalesApi.UnitTest.Services
{
    public class MadeDateDiscountServiceTests
    {
        [Fact]
        public void WhenMadeDateOfCarsIsBeforeTheThreshold_ThenDiscountAdded()
        {
            //arrange
            var carService = Substitute.For<ICarService>();
            var discountService = new MadeDateDiscountService();

            var cars = Enumerable.Range(0, 2).Select(x => new Car
            {
                MadeDateTime = discountService.MadeDateTimeThreshold.AddDays(-1)
            }).ToList();

            carService.GetCarsAsync(Arg.Any<List<int>>()).Returns(cars);


            //act
            var result = discountService.Calculate(cars);

            //assert
            Assert.Equal(MadeDateDiscountService.MadeDateTimePercent, result);
        }

        [Fact]
        public void WhenMadeDateOfCarsIsAfterTheThreshold_ThenNoDiscount()
        {
            //arrange
            var carService = Substitute.For<ICarService>();
            var discountService = new MadeDateDiscountService();

            var cars = Enumerable.Range(0, 2).Select(x => new Car
            {
                MadeDateTime = discountService.MadeDateTimeThreshold.AddDays(1)
            }).ToList();

            carService.GetCarsAsync(Arg.Any<List<int>>()).Returns(cars);


            //act
            var result = discountService.Calculate(cars);

            //assert
            Assert.Equal(0, result);
        }

    }
}