using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSaleApi.Exeptions;
using CarSaleApi.Models;
using CarSaleApi.Repositories;
using Microsoft.Extensions.Logging;

namespace CarSaleApi.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly ILogger<CarService> _logger;

        public CarService(ICarRepository carRepository, ILogger<CarService> logger)
        {
            _carRepository = carRepository;
            _logger = logger;
        }
        public async Task AddAsync(Car car)
        {
            _logger.LogInformation("adding a car");
            await _carRepository.AddAsync(car);
        }

        public async Task UpdateAsync(Car car)
        {
            _logger.LogInformation($"updating the car. car id: {car.Id}");
            await _carRepository.UpdateAsync(car);
        }

        public async Task<List<Car>> GetCarsAsync(List<int> ids)
        {
            _logger.LogInformation($"getting list of cars. car ids: {string.Join(",", ids)}");
            return await _carRepository.GetCarsAsync(ids);
        }
    }
}
