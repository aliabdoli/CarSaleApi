using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSaleApi.Models;
using CarSaleApi.Models.Controllers;
using CarSaleApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarSaleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountAggregatorService _discountService;
        private readonly ILogger<DiscountController> _logger;

        public DiscountController(IDiscountAggregatorService discountService, ILogger<DiscountController> logger)
        {
            _discountService = discountService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<Discount> Get(DiscountGetRequest discountGetRequest)
        {
            using (_logger.BeginScope($"calculating discount. {string.Join(",", discountGetRequest.CarIds)}"))
            {
                return await _discountService.CalculateAsync(discountGetRequest.CarIds);
            }
        }
    }
}