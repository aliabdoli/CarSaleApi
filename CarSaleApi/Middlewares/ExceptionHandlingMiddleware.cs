using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CarSaleApi.Exeptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CarSaleApi.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException notFoundException)
            {
                context.Response.StatusCode = (int) HttpStatusCode.NotFound;
            }
        }
    }
}
