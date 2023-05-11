using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SqlQuery.ViewModels;
using SqlQuery.Views;
using SqlQuery;

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
    }
}
