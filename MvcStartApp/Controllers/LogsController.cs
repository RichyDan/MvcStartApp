using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Models.Db.Repositories;
using System.Threading.Tasks;

namespace MvcStartApp.Controllers
{
    public class LogsController: Controller
    {
        private ILoggingRepository _loggingRepository;
        public LogsController(ILoggingRepository loggingRepository)
        {
            _loggingRepository = loggingRepository;
        }

        public async Task<IActionResult> Index()
        {
            var requests = await _loggingRepository.GetRequests();
            return View(requests);
        }
    }
}
