using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CarSaleApi.Models;
using Microsoft.AspNetCore.Mvc.Testing;
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
        [InlineData("api/car")]
        public async Task Post_EndpointsReturnSuccess(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            var car = new Car()
            {
                MadeDateTime = DateTime.Now,
                Price = 100,
                Name = "BMW"
            };
            // Act
            var response = await client.PostAsJsonAsync(url, car);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}