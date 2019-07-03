using System;
using System.Collections.Generic;
using System.Linq;
using CarSaleApi.Models;
using CarSaleApi.Services;
using NSubstitute;
using Xunit;

namespace CarSalesApi.UnitTest.Services
{
    public class CountDiscountServiceTests
    {
        [Fact]
        public void WhenNumberOfCarsIsHigherThanThreshold_ThenDiscountAdded()
        {
            //arrange
            var carService = Substitute.For<ICarService>();
            var discountService = new CountDiscountService();

            var cars = Enumerable.Range(0, 5).Select(x => new Car
            {
                MadeDateTime = DateTime.Now
            }).ToList();

            carService.GetCarsAsync(Arg.Any<List<int>>()).Returns(cars);


            //act
            var result = discountService.Calculate(cars);

            //assert
            Assert.Equal(CountDiscountService.QuantityPercent, result);
        }
    }
}