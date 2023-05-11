using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SqlQuery.ViewModels
{
    internal class MainWindowVM : ObservableObject
    {
        private string username = null;

        public string Username { get => username; set => SetProperty(ref username, value); }

        private bool isButtonEnabled = true;

        public bool IsButtonEnabled { get => isButtonEnabled; set => SetProperty(ref isButtonEnabled, value); }

        private string password = null;

        public string Password { get => password; set => SetProperty(ref password, value); }

        public void UpdatePassword(string pwd) => password = pwd;

        public void Register()
        {
            IsButtonEnabled = false;
            // MessageBox.Show($"用户名: {username}\n密　码: {password}", "Register");
            LocalServices.Register(username, password);
            IsButtonEnabled = true;
        }

        public void Login()
        {
            IsButtonEnabled = false;
            // MessageBox.Show($"用户名: {username}\n密　码: {password}", "Login");
            LocalServices.Login(username, password);
            IsButtonEnabled = true;
        }
    }
}
