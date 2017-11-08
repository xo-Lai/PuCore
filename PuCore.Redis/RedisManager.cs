using PuCore.Utility.Config;
using StackExchange.Redis;

namespace PuCore.Redis
{
    public class RedisManager
    {
        private static ConnectionMultiplexer _connectionMultiplexer;
        private static readonly object Locker = new object();
        public static ConnectionMultiplexer GetConnection(string readWriteHosts)
        {
            if (_connectionMultiplexer == null)
            {
                lock (Locker)
                {
                    if (_connectionMultiplexer == null)
                    {                      
                      _connectionMultiplexer = ConnectionMultiplexer.Connect(readWriteHosts??AppConfig.RedisConnection);
                    }
                }
            }
            return _connectionMultiplexer;
        }
    }
}
