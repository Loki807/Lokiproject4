using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Lokiproject4.DataConnect
{
    public static class Connection
    {


        // ✅ Clean connection string
        private static string connectionstring = "Data Source=megadata.db;Version=3;";

        public static SQLiteConnection GetConnection()
        {
            // ❗ Only return the connection, do NOT open it here.
            return new SQLiteConnection(connectionstring);
        }
    }   
    
}
