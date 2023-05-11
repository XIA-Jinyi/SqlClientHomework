using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Services;

namespace SqlQuery
{
    static class LocalServices
    {
        private static SqlHelper sqlHelper = null;

        public static bool TestConn()
        {
            return sqlHelper != null && sqlHelper.TestConnection();
        }

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
    }
}
