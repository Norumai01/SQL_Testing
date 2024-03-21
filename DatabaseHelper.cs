using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Testing
{
    public class DatabaseHelper
    {
        // Allow changeable connnectionString to SQL, whenever using different objects.
        private readonly string _connectionString;

        // Constructor
        public DatabaseHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Open connection to SQL.
        public IDbConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
