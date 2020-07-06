using Microsoft.Extensions.Configuration;
using NPoco;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace task1_p
{
    public class DBConn : IDbConn
    {
        SqlConnection conn;
        public IDatabase Connect()
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"bin\" }, StringSplitOptions.None)[0];
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(projectPath)
                .AddJsonFile("appsettings.json")
                .Build();
            string connectionString = configuration.GetConnectionString("MyPersonalConnect");
            conn = new SqlConnection(connectionString);
            conn.Open();
            return new Database(conn);
        }

        public void Dispose()
        {
            conn.DisposeAsync();
        }
    }
}
