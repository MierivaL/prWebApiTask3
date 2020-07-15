using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task1_p.Models
{
    public class DbOptions
    {
        /// <summary>
        /// Наименование секции настроек в файле конфигурации
        /// </summary>
        public const string Region = "DbOptions";
        /// <summary>
        /// SQL Server IP
        /// </summary>
        public string SQLIP { get; set; }
        /// <summary>
        /// SQL Username
        /// </summary>
        public string SQLUsername { get; set; }
        /// <summary>
        /// SQL Password
        /// </summary>
        public string SQLPassword { get; set; }
        /// <summary>
        /// Redis Server IP
        /// </summary>
        public string RedisIP { get; set; }
        /// <summary>
        /// Redis Password
        /// </summary>
        public string RedisPassword { get; set; }
    }
}
