using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task1_p
{
    public class JsonAppointment : User
    {
        public DateTime Date { get; set; }
        public string Comment { get; set; }
    }
}
