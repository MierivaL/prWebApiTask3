﻿using Microsoft.Extensions.Configuration;
using NPoco;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using task1_p.Models;

namespace task1_p
{
    public class DBConn : IDbConn
    {
        SqlConnection conn;
        public IDatabase Connect(DbOptions dbOptions)
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"bin\" }, StringSplitOptions.None)[0];
            //IConfigurationRoot configuration = new ConfigurationBuilder()
            //    .SetBasePath(projectPath)
            //    .AddJsonFile("appsettings.json")
            //    .Build();
            //string connectionString = configuration.GetConnectionString("MyPersonalConnect");
            string connectionString = String.Format(
                "Data Source=tcp:{0}\\SQLEXPRESS,1433;Initial Catalog=bpsDB;Integrated Security=false;User Id={1};password={2};Language=english;",
                dbOptions.SQLIP, dbOptions.SQLUsername, dbOptions.SQLPassword);
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
