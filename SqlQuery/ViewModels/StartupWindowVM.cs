using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SqlQuery.ViewModels
{
    internal class StartupWindowVM : ObservableObject
    {

        private string hostName = "10.21.138.186";

        public string HostName { get => hostName; set => SetProperty(ref hostName, value); }

        private string username = "sa";

        public string Username { get => username; set => SetProperty(ref username, value); }

        private string Password { get; set; }

        public void UpdatePassword(string password) => Password = password;

        public void ConnServer()
        {
            LocalServices.Connect(HostName, Username, Password);
        }
    }
}
