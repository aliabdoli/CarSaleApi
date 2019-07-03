using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CarSaleApi.Models;
using CarSaleApi.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace CarSaleApi.IntegrationTest
{
    public class BasicEnpointTests
        : IClassFixture<WebApplicationFactory<CarSaleApi.Startup>>
    {
        private readonly WebApplicationFactory<CarSaleApi.Startup> _factory;

        public BasicEnpointTests(WebApplicationFactory<CarSaleApi.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("api/car", "api/discount")]
        public async Task WhenCarsExist_ThenDiscountCalculate(string carUrl, string discountUrl)
        {
            // Arrange
            var client = _factory.CreateClient();

            var cars = Enumerable.Range(0, 4).Select(x => new Car()
            {
                Price = AmountDiscountService.AmountThreshold
            });

            var addedCarsId = new List<int>();
            foreach (var car in cars)
            {
                var postCarResponse = await client.PostAsJsonAsync(carUrl, car);
                postCarResponse.EnsureSuccessStatusCode(); // Status Code 200-299

                var postCarId = int.Parse(await postCarResponse.Content.ReadAsStringAsync());
                addedCarsId.Add(postCarId);
            }

            var discountRequest = string.Join("&", addedCarsId.Select(x => $"carIds={x}"));

            // Act
            var discountResponse = await client.GetAsync($"{discountUrl}?{discountRequest}");

            // Assert
            discountResponse.EnsureSuccessStatusCode(); // Status Code 200-299
            var discount = JsonConvert.DeserializeObject<Discount>(await discountResponse.Content.ReadAsStringAsync());
            var totalDiscount = AmountDiscountService.AmountPercent + CountDiscountService.QuantityPercent +
                                MadeDateDiscountService.MadeDateTimePercent;

            Assert.Equal(totalDiscount, discount.DiscountPercent);

            Assert.Equal("text/html; charset=utf-8",
                discountResponse.Content.Headers.ContentType.ToString());
        }
    }
}