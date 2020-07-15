using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task1_p
{
    public class ErrorContainer
    {
        public string Message { get; set; }

        public ErrorContainer(string Message)
        {
            this.Message = Message;
        }
    }
}
