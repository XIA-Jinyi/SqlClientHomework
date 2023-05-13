using System;
using System.Data;
using System.Data.SqlClient;

namespace Services
{
    /// <summary>
    /// SQL 连接辅助类。
    /// </summary>
    public class SqlHelper: IDisposable
    {
        /// <summary>
        /// SQL 连接对象。
        /// </summary>
        private SqlConnection _sqlConnection = null;

        public SqlHelper() { }

        /// <summary>
        /// 连接至 SQL Server 数据库。
        /// </summary>
        /// <param name="server">服务器主机名</param>
        /// <param name="username">SQL Server 登录名</param>
        /// <param name="password">密码</param>
        public void Connect(string server, string username, string password)
        {
            SqlConnection conn = new SqlConnection($"Server={server};uid={username};pwd={password};database=StudentCourse");
            conn.Open();
            _sqlConnection = conn;
        }

        /// <summary>
        /// 执行 SQL 查询。
        /// </summary>
        /// <param name="sqlCommand">SQL 查询语句</param>
        /// <returns>查询结果</returns>
        public DataSet Query(string sqlCommand)
        {
            SqlCommand sqlCmd = new SqlCommand(sqlCommand, _sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds;
        }

        /// <summary>
        /// 关闭 SQL 连接并释放资源。
        /// </summary>
        public void Close()
        {
            _sqlConnection?.Close();
            _sqlConnection = null;
        }

        /// <summary>
        /// 测试 SQL 连接状态。
        /// </summary>
        /// <returns>若连接处于开启状态，返回 <c>true</c>；否则返回 <c>false</c>。</returns>
        public bool TestConnection()
        {
            return _sqlConnection != null && _sqlConnection.State == ConnectionState.Open;
        }

        /// <summary>
        /// 关闭 SQL 连接并释放资源。
        /// </summary>
        public void Dispose()
        {
            Close();
        }
    }
}
