using System.Net;
using System.Threading.Tasks;
using CarSaleApi.Exceptions;
using Microsoft.AspNetCore.Http;

namespace CarSaleApi.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException)
            {
                context.Response.StatusCode = (int) HttpStatusCode.NotFound;
            }
        }
    }
}