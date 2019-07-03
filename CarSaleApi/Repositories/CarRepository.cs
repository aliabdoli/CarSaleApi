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
    /// This is for mocking purposes
    /// Being thread safe and uniqueness of
    /// the ids is out of scope of the test and this class 
    /// </summary>
    public class CarRepository : ICarRepository
    {
        //to make it thread safe
        private static ConcurrentBag<Car> _cars = new ConcurrentBag<Car>();

        //not thread safe for the sake of the test
        private static int _identifier = 0;
        //todo: why warning
        public async Task<Car> AddAsync(Car car)
        {
            _identifier++;
            car.Id = _identifier;
            _cars.Add(car);
            return car;
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
            if (!_cars.Any(x => ids.Contains(x.Id)))
            {
                throw new NotFoundException();
            }

            return _cars.Where(x => ids.Contains(x.Id)).ToList();
        }

        public async Task<Car> GetCarAsync(int id)
        {
           var result = _cars.SingleOrDefault(x => x.Id == id);
            if (result == null)
            {
                throw new NotFoundException();
            }

            return result;
        }
    }
}
