using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Services
{
    public class SqlHelper: IDisposable
    {
        private SqlConnection _sqlConnection = null;

        public SqlHelper() { }

        public void Connect(string server, string username, string password)
        {
            SqlConnection conn = new SqlConnection($"Server={server};uid={username};pwd={password};database=StudentCourse");
            conn.Open();
            _sqlConnection = conn;
        }

        public DataSet Query(string sqlCommand)
        {
            SqlCommand sqlCmd = new SqlCommand(sqlCommand, _sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds;
        }

        public void Close()
        {
            _sqlConnection?.Dispose();
            _sqlConnection = null;
        }

        public bool TestConnection()
        {
            return _sqlConnection != null && _sqlConnection.State == ConnectionState.Open;
        }

        public void Dispose()
        {
            Close();
        }
    }
}
