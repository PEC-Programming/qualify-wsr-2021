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
using НамордникDesktop.Scripts;

namespace НамордникDesktop.Pages
{
    /// <summary>
    /// Логика взаимодействия для product_list.xaml
    /// </summary>
    public partial class product_list : Page
    {
        public product_list()
        {
            InitializeComponent();
            products = ConnectHelper.entObj.ProductView.ToList();
            foreach(ProductView product in products)
            {
                Grid grid = new Grid { Width = 500, Height = 100, Margin=new Thickness(10) };
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.3, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.3, GridUnitType.Star) });
                Border border = new Border { BorderThickness = new Thickness(2) };
                grid.Children.Add(border);
                Grid.SetColumnSpan(border, 3);
                string mat = "";
                foreach(MaterialView mv in ConnectHelper.entObj.MaterialView.Where(m => m.ProductID == product.ID).ToList()) { mat += mv.Title + ", "; }
                if(mat!="")
                mat.Substring(0, mat.Length - 2);
                if (product.Image.Contains("products"))
                    grid.Children.Add(new Image { Source = new BitmapImage(new Uri("/Resources" + product.Image.Replace('\\','/'), UriKind.Relative)),Margin = new Thickness(3) });
                else
                    grid.Children.Add(new Image { Source = new BitmapImage(new Uri("/Resources/picture.png", UriKind.Relative)), Margin = new Thickness(3) });
                TextBlock tb =new TextBlock { Text = $"{product.PtodType} | {product.ProdTitle}\n{product.Article}\n Материалы:\n{mat}" };
                grid.Children.Add(tb);
                Grid.SetColumn(tb, 1);
                
                spProdList.Children.Add(grid);
            }
        }
        List<ProductView> products = new List<ProductView>();
    }
}
