using System.Collections.Generic;
using System.Threading.Tasks;
using CarSaleApi.Models;

namespace CarSaleApi.Repositories
{
    public interface ICarRepository
    {
        Task<Car> AddAsync(Car car);
        Task UpdateAsync(Car car);
        Task<List<Car>> GetCarsAsync(List<int> ids);
        Task<Car> GetCarAsync(int id);
    }
}