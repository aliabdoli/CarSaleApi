using System.Collections.Generic;
using System.Threading.Tasks;
using CarSaleApi.Models;

namespace CarSaleApi.Services
{
    public interface IDiscountAggregatorService
    {
        Task<Discount> CalculateAsync(List<int> ids);
    }
}