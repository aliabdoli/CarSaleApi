using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSaleApi.Repositories;
using CarSaleApi.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CarSaleApi.Extensions
{
    public static class IocExtensions
    {
        public static IServiceCollection AddServicesAndRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<ICarService, CarService>()
                .AddScoped<IDiscountAggregatorService>(x => new DiscountAggregatorService(
                    x.GetRequiredService<ICarService>(),
                    new List<IDiscountService>()
                    {
                        new AmountDiscountService(),
                        new CountDiscountService(),
                        new MadeDateDiscountService()
                    }))
                .AddScoped<ICarRepository, CarRepository>()

                .AddLogging();
        }
    }
}
