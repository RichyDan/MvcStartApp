using System;
using System.Threading.Tasks;

namespace MvcStartApp.Models.Db.Repositories
{
    public interface ILoggingRepository
    {
        Task AddRequest(Request request);
        Task<Request[]> GetRequests();
    }
}
