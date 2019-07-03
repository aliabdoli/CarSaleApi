using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSaleApi.Exeptions;
using CarSaleApi.Models;

namespace CarSaleApi.Repositories
{
    /// <summary>
    /// This is for mocking purposes, 
    /// </summary>
    public class CarRepository : ICarRepository
    {
        //to make it thread safe
        private ConcurrentBag<Car> _cars = new ConcurrentBag<Car>();
        //todo: why warning
        public async Task AddAsync(Car car)
        {
            _cars.Add(car);
        }

        public async Task UpdateAsync(Car car)
        {
            var result = _cars.SingleOrDefault(x => x.Id == car.Id);
            if (result == null)
            {
                throw new NotFoundException();
            }
        }

        public async Task<List<Car>> GetCarsAsync(List<int> ids)
        {
            return _cars.Where(x => ids.Contains(x.Id)).ToList();
        }
    }
}
