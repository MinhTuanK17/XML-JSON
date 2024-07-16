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

namespace ManageProductsApp
{
    /// <summary>
    /// Interaction logic for WindowManageProducts.xaml
    /// </summary>
    public partial class WindowManageProducts : Window
    {
        public WindowManageProducts()
        {
            InitializeComponent();
        }

        ManageProducts products = new ManageProducts();
        private void Window_Loaded(object sender, RoutedEventArgs e) => LoadProducts();

        private void LoadProducts()
        {
            lvProducts.ItemsSource = products.GetProducts();
        }
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var Product = new Product
                {
                    ProductID = int.Parse(txtProductID.Text),
                    ProductName = txtProductName.Text
                };
                products.InsertProduct(Product);
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert Product");
            }
        }


        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var Product = new Product
                {
                    ProductID = int.Parse(txtProductID.Text),
                    ProductName = txtProductName.Text
                };
                products.UpdateProduct(Product);
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Product");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var Product = new Product
                {
                    ProductID = int.Parse(txtProductID.Text)
                };
                products.DeleteProduct(Product);
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Product");
            }
        }


    }
}
