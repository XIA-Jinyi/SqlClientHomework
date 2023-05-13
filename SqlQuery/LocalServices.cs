using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using Services;

namespace SqlQuery
{
    static class LocalServices
    {
        /// <summary>
        /// SQL 连接辅助对象。
        /// </summary>
        private static SqlHelper sqlHelper = null;

        /// <summary>
        /// 测试 SQL 连接状态。
        /// </summary>
        /// <returns>若连接处于开启状态，返回 <c>true</c>；否则返回 <c>false</c>。</returns>
        public static bool TestConn()
        {
            return sqlHelper != null && sqlHelper.TestConnection();
        }

        /// <summary>
        /// 连接 SQL Server 服务器。
        /// </summary>
        /// <param name="host">服务器主机名</param>
        /// <param name="user">SQL Server 登录名</param>
        /// <param name="password">密码</param>
        public static void Connect(string host, string user, string password)
        {
            SqlHelper helper = new SqlHelper();
            try
            {
                helper.Connect(host, user, password);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            sqlHelper = helper;
        }

        /// <summary>
        /// 注册管理系统的用户。
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        public static void Register(string username, string password)
        {
            if (username == null || password == null || username == String.Empty || password == String.Empty)
            {
                MessageBox.Show($"用户名和密码不能为空！", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (username.Length > 19)
            {
                MessageBox.Show($"用户名 {username} 过长！", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                sqlHelper.Query($"INSERT INTO StudentCourse.dbo.UserTable(username, password) VALUES('{username}', '{password.GetHashCode()}');");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBox.Show("注册成功！", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// 验证用户能否登录到管理系统。
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        public static void Login(string username, string password)
        {
            if (username == null || password == null || username == String.Empty || password == String.Empty)
            {
                MessageBox.Show($"用户名和密码不能为空！", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (username.Length > 19)
            {
                MessageBox.Show($"用户名 {username} 过长！", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                DataSet result = sqlHelper.Query($"SELECT * FROM StudentCourse.dbo.UserTable WHERE username='{username}' AND password='{password.GetHashCode()}';");
                if (result.Tables.Count > 0 && result.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("验证成功！", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("用户名或密码错误！", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        /// <summary>
        /// 关闭 SQL 连接。
        /// </summary>
        public static void CloseConn()
        {
            sqlHelper?.Close();
            sqlHelper = null;
        }
    }
}
