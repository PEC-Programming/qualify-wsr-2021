using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using НамордникDesktop.Scripts;
using НамордникDesktop.Pages;

namespace НамордникDesktop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ConnectHelper.entObj = new wsruser3Entities();
            FrameApp.frmObj = frmMain;
            frmMain.Navigate(new product_list());

        }
    }
}
