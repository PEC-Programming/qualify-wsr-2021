using ShadrinDem.DataFiles;
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

namespace ShadrinDem.PageMains
{
    /// <summary>
    /// Логика взаимодействия для PageMain.xaml
    /// </summary>
    public partial class PageMain : Page
    {
        private static int selected;
        private static bool z = false;
        public PageMain()
        {
            InitializeComponent();
            cmbSort.Items.Add("Сортировка от А-Я");
            cmbSort.Items.Add("Сортировка от Я-А");

            cmbFilt.SelectedValuePath = "ID";
            cmbFilt.DisplayMemberPath = "Title";
            cmbFilt.ItemsSource = ConnectHelper.entObj.ProductType.ToList();


            lbData.ItemsSource = ConnectHelper.entObj.ProductMaterial.ToList();

        }
        //переопределение данных для глобального использования
        public static int Selected { get => selected; set => selected = value; }
        public static bool Z { get => z; set => z = value; }

        private void cmbFilt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Selected = Convert.ToInt32(cmbFilt.SelectedValue);
            lbData.ItemsSource = ConnectHelper.entObj.ProductMaterial.Where(x => x.ProductID == Selected).ToList();
           
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Проверка на фильтрацию, если она есть то программа будет сортировать исходя по фильтрации
            if (Z == true)
            {
                if (cmbSort.SelectedIndex == 1)
                    lbData.ItemsSource = ConnectHelper.entObj.ProductMaterial.Where(x => x.ProductID == Selected).OrderBy(x => x.ProductID).ToList();
                else
                    lbData.ItemsSource = ConnectHelper.entObj.ProductMaterial.Where(x => x.ProductID == Selected).OrderByDescending(x => x.ProductID).ToList();
            }
            else
            {
                if (cmbSort.SelectedIndex == 1)
                    lbData.ItemsSource = ConnectHelper.entObj.ProductMaterial.OrderBy(x => x.ProductID).ToList();
                else
                    lbData.ItemsSource = ConnectHelper.entObj.ProductMaterial.OrderByDescending(x => x.ProductID).ToList();
            }

        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
