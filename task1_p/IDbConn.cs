using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task1_p.Models;

namespace task1_p
{
    interface IDbConn
    {
        public IDatabase Connect(DbOptions dbOptions);
        public void Dispose();
    }
}
