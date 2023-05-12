using System.Windows;
using System.Windows.Controls;
using SqlQuery.ViewModels;
using SqlQuery.Views;

namespace SqlQuery
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowVM viewModel = new MainWindowVM();

        public MainWindow()
        {
            Window startup = new StartupWindow();
            startup.ShowDialog();
            if (!LocalServices.TestConn())
            {
                Close();
            }
            DataContext = viewModel;
            InitializeComponent();
        }

        private void PasswordChanged(object sender, RoutedEventArgs e)
        {
            viewModel.UpdatePassword(((PasswordBox)sender).Password);
        }

        private void RegisterButtonClick(object sender, RoutedEventArgs e)
        {
            viewModel.Register();
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            viewModel.Login();
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LocalServices.CloseConn();
        }
    }
}
