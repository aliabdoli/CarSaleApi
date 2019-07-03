using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSaleApi.Models;

namespace CarSaleApi.Services
{
    public interface ICarService
    {
        Task AddAsync(Car car);
        Task UpdateAsync(Car car);

        Task<List<Car>> GetCarsAsync(List<int> ids);
    }
}
