using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Testing
{
    public class Account
    {
        public int AccID { get; private set; }
        public string name { get; private set; } = string.Empty;
        public decimal Checking { get; private set; }
        public decimal Saving { get; private set; }
    }

    public class DataRepository
    {
        private readonly DatabaseHelper _databaseHelper;
        public DataRepository(DatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public Account GetData(int id)
        {
            using (var connection = _databaseHelper.GetConnection())
            {
                connection.Open();

                string sql = "SELECT AccID, name, Checking, Saving FROM SQLTutorial.dbo.BankAccount WHERE AccID = @AccID";

                return connection.QueryFirstOrDefault<Account>(sql, new { AccID = id });
            }
        }
    }
}
