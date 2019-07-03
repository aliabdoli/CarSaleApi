using System.Collections.Generic;
using CarSaleApi.Models;

namespace CarSaleApi.Services
{
    public interface IDiscountService
    {
        int Calculate(List<Car> cars);
    }
}