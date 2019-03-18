using System;
using System.Threading.Tasks;

namespace Tunder.API.Services
{
    public interface ICachingService
    {
        Task<bool> SetValueASync(string key, string value, TimeSpan? expireTime);
        Task<long> IncrementValueFromKeyAsync(string key);
        Task<long> GetValueFromKeyAsync(string key);
    }
}