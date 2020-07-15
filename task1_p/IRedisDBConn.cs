using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task1_p
{
    public interface IRedisDBConn
    {
        public bool Connect(string connectonString);
        public bool Disconnect();
        public bool IsDataAvailable(string key);
        public string GetData(string key);
        public bool SendData(string key, string data, int expireSecond = 60);
    }
}
