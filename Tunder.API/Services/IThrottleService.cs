using System.Threading.Tasks;
using Data.Model;

namespace Tunder.API.Services
{
    public interface IThrottleService
    {
        Task<long> LogFailLoginAttemptAsync(User user);
        Task<long> GetFailLoginAttemptAsync(User user);
    }
}