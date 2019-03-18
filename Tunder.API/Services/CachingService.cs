using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace Tunder.API.Services
{
    public class CachingService : ICachingService
    {
        private readonly IConfiguration _configs;
        //private readonly ILogger _logger;
        private static Lazy<ConnectionMultiplexer> _lazyConnection;
        private readonly object _lock = new object();
        private readonly Lazy<IDatabase> _redisDb;


        public CachingService(IConfiguration configs)
        {
            _configs = configs;
            //_logger = logger;

            if (_lazyConnection == null)
            {
                lock (_lock)
                {
                    if (_lazyConnection == null)
                    {
                        _lazyConnection = SetConnectionMultiplexer();
                    }
                }
            }

            _redisDb = new Lazy<IDatabase>(() => _lazyConnection.Value.GetDatabase());
        }

        private Lazy<ConnectionMultiplexer> SetConnectionMultiplexer()
        {
            var configurationOptions = new ConfigurationOptions
            {
                EndPoints = { _configs.GetSection("AppSettings:Redis:Hostname").Value }
            };

            return new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(configurationOptions));
        }

        public async Task<bool> SetValueASync(string key, string value, TimeSpan? expireTime = null)
        {
            try
            {
                //_redisDb.Value.
                return await _redisDb.Value.StringSetAsync(key, value, expireTime);
            }
            catch (Exception e)
            {
                // _logger.LogError(1, e, "1");
                return false;
            }
        }

        public async Task<long> IncrementValueFromKeyAsync(string key)
        {
            return await _redisDb.Value.StringIncrementAsync(key);
        }

        public async Task<long> GetValueFromKeyAsync(string key)
        {
            var value = await _redisDb.Value.StringGetAsync(key);

            return (long)value;
        }
    }
}
