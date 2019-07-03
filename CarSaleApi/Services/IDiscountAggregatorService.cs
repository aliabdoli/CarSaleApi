using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSaleApi.Models;

namespace CarSaleApi.Services
{
    public interface IDiscountAggregatorService
    {
        Task<Discount> CalculateAsync(List<int> ids);
    }
}
