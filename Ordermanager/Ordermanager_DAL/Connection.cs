using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using MySql.Data.MySqlClient;

namespace Ordermanager_DAL
{
    public static class Connection
    {
        private static readonly string ConnectionString = "Server=127.0.0.1;Database=ordermanager;Uid=root;Pwd=;";

        public static MySqlConnection Conn()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
