using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task1_p
{
    interface IDbConn
    {
        public IDatabase Connect();
        public void Dispose();
    }
}
