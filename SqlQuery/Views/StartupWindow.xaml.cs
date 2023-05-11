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
using System.Windows.Shapes;
using SqlQuery.ViewModels;

namespace SqlQuery.Views
{
    /// <summary>
    /// StartupWindow.xaml 的交互逻辑
    /// </summary>
    public partial class StartupWindow : Window
    {
        StartupWindowVM vm = new StartupWindowVM();

        public StartupWindow()
        {
            DataContext = vm;
            InitializeComponent();
        }

        private void ConnButtonClick(object sender, RoutedEventArgs e)
        {
            vm.ConnServer();
            if (LocalServices.TestConn())
            {
                Close();
            }
        }

        private void PasswordChanged(object sender, RoutedEventArgs e)
        {
            vm.UpdatePassword(((PasswordBox)sender).Password);
        }
    }
}
