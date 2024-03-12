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
using task1.Efmodel;

namespace task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            cbSort.Items.Add("По алфавиту (а-я)");
            cbSort.Items.Add("По алфавиту (я-а)");
            cbSort.Items.Add("По убыванию цены");
            cbSort.Items.Add("По возрастанию цены");
            cbSort.SelectedIndex = 0;

        }


        public void update()
        {
            int maxCount = EfModel.Init().Products.ToList().Count;

            IEnumerable<Product> products = EfModel.Init().Products
                .Where(p => p.Title.Contains(tbSearch.Text) || p.Description.Contains(tbSearch.Text));

           switch(cbSort.SelectedIndex)
            {
                case 0:
                    products = products.OrderBy(p => p.Title);
                    break;
                case 1:
                    products = products.OrderByDescending(p => p.Title);
                    break;
                case 2:
                    products = products.OrderByDescending(p => p.Cost);
                    break;
                case 3:
                    products = products.OrderBy(p => p.Cost);
                    break;
            }

            lvProducts.ItemsSource = products.ToList();


            tbCount.Text = products.ToList().Count + "/" + maxCount + " записей";

        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            update();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            update();
        }
    }
}
