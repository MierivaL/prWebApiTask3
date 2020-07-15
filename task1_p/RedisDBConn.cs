using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task1_p
{
    public class RedisDBConn : IRedisDBConn
    {
        private ConnectionMultiplexer redis;
        IDatabase db;
        public bool Connect(string connectionString)
        {
            if (null == redis || !redis.IsConnected)
            {
               redis = ConnectionMultiplexer.Connect(connectionString);
               db = redis.GetDatabase();
            }
            return true;
        }

        public bool Disconnect()
        {
            if (null != redis && redis.IsConnected)
            {
                redis.Close(); redis = null; db = null;
            }
            return true;
        }

        public string GetData(string key)
        {
            if (IsDataAvailable(key))
                return db.StringGet(key);
            return "";
        }

        public bool IsDataAvailable(string key)
        {
            return db.KeyExists(key);
        }

        public bool SendData(string key, string data, int expireSecond = 60)
        {
            db.StringSet(key, data, TimeSpan.FromSeconds(expireSecond));
            return true;
        }
    }
}
