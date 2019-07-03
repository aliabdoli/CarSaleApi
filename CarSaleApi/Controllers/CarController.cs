using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSaleApi.Models;
using CarSaleApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarSaleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly ILogger<CarController> _logger;

        public CarController(ICarService carService, ILogger<CarController> logger)
        {
            _carService = carService;
            _logger = logger;
        }
        [HttpPost]
        public async Task Post([FromBody] Car car)
        {
            using (_logger.BeginScope($"creating car. {car.Name}"))
            {
                //TODO: add stasD and logging here and throttling
                await _carService.AddAsync(car);
            }
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Car car)
        {
            using (_logger.BeginScope($"updating car. {car.Id}"))
            {
                //TODO: not found should 404
                await _carService.UpdateAsync(car);
            }
        }
    }
}
