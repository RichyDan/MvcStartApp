using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using MvcStartApp.Models.Db.Repositories;
using MvcStartApp.Models.Db;

namespace MvcStartApp.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private ILoggingRepository _loggingRepository;
        public LoggingMiddleware(RequestDelegate next, ILoggingRepository loggingRepository)
        {
            _next = next;
            _loggingRepository = loggingRepository;
        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            LogConsole(context);
            await LogDb(context);

            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }

        private async Task LogDb(HttpContext context)
        {
            var request = new Request()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Url = $"{context.Request.Host.Value + context.Request.Path}"
            };

            await _loggingRepository.AddRequest(request);
        }
        private void LogConsole(HttpContext context)
        {
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");
        }
    }
}
