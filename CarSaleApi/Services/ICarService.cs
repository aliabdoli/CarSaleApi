using System.Collections.Generic;
using System.Threading.Tasks;
using CarSaleApi.Models;

namespace CarSaleApi.Services
{
    public interface ICarService
    {
        Task<int> AddAsync(Car car);
        Task UpdateAsync(Car car);
        Task<Car> GetCarAsync(int id);
        Task<List<Car>> GetCarsAsync(List<int> ids);
    }
}