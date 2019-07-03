using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSaleApi.Models;

namespace CarSaleApi.Services
{
    public interface IDiscountService
    {
       int Calculate(List<Car> cars);
    }
}
