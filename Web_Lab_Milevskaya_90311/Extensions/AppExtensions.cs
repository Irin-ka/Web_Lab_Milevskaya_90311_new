using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Lab_Milevskaya_90311.Middleware;


namespace Web_Lab_Milevskaya_90311.Extensions
{
    public static class AppExtensions
    {
        public static IApplicationBuilder UseFileLogging
            (this IApplicationBuilder app) => app.UseMiddleware<LogMiddleware>();
    }
}
