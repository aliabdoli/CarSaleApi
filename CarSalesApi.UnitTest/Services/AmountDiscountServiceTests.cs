using System;
using System.Collections.Generic;
using CarSaleApi.Models;
using CarSaleApi.Services;
using Xunit;

namespace CarSalesApi.UnitTest.Services
{
    public class AmountDiscountServiceTests
    {
        [Fact]
        public void WhenAmountIsHigherThanThreshold_ThenDiscountAdded()
        {
            //arrange
            var discountService = new AmountDiscountService();

            var cars = new List<Car>
            {
                new Car
                {
                    Price = AmountDiscountService.AmountThreshold - 1,
                    MadeDateTime = DateTime.Now
                },
                new Car
                {
                    Price = AmountDiscountService.AmountThreshold,
                    MadeDateTime = DateTime.Now
                }
            };


            //act
            var result = discountService.Calculate(cars);

            //assert
            Assert.Equal(AmountDiscountService.AmountPercent, result);
        }


        [Fact]
        public void WhenAmountIsLowerThanThreshold_ThenNoDiscount()
        {
            //arrange
            var discountService = new AmountDiscountService();

            var cars = new List<Car>
            {
                new Car
                {
                    Price = AmountDiscountService.AmountThreshold - 1,
                    MadeDateTime = DateTime.Now
                }
            };


            //act
            var result = discountService.Calculate(cars);

            //assert
            Assert.Equal(0, result);
        }
    }
}