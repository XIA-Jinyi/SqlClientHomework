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
            LocalServices.Register(username, password);
            IsButtonEnabled = true;
        }

        public void Login()
        {
            IsButtonEnabled = false;
            LocalServices.Login(username, password);
            IsButtonEnabled = true;
        }
    }
}
