using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
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

namespace ChildrensCreativity
{
    public partial class Products : Window
    {
        orders currentOrder;

        public Products()
        {
            InitializeComponent();
            InitializeData();
        }

        public void InitializeData()
        {
            listProducts.ItemsSource = ChildrenCreativityEntities.GetContext().products.ToList();
            buttonOrderBin.Visibility = Visibility.Hidden;
        }

        private void AddToOrderBin(object sender, RoutedEventArgs e)
        {
            products selectedProduct = (products)listProducts.SelectedItem;

            if (currentOrder == null)
            {
                CreateOrder();
            }

            var currentOrderBin = ChildrenCreativityEntities
                .GetContext()
                .order_bins
                .FirstOrDefault(ob => ob.fk_product_id == selectedProduct.product_id && ob.fk_order_id == currentOrder.order_id);

            if (currentOrderBin == null)
            {
                order_bins orderBin = new order_bins();
                orderBin.fk_order_id = currentOrder.order_id;
                orderBin.fk_product_id = selectedProduct.product_id;
                orderBin.order_bin_count = 1;
                buttonOrderBin.Visibility = Visibility.Visible;
                ChildrenCreativityEntities.GetContext().order_bins.Add(orderBin);
                SaveChanges();
                MessageBox.Show("Товар добавлен в корзину");
            } else
            {
                currentOrderBin.order_bin_count++;
                SaveChanges();
                MessageBox.Show("Товар добавлен в корзину");
            }
        }

        private void CreateOrder()
        {
            currentOrder = new orders();
            ChildrenCreativityEntities.GetContext().orders.Add(currentOrder);
            SaveChanges();
        }

        private void SaveChanges()
        {
            try
            {
                ChildrenCreativityEntities.GetContext().SaveChanges();
            }
            catch (Exception) { }
        }

        private void GoToOrderBin(object sender, RoutedEventArgs e)
        {
            OrderBin orderBinPage = new OrderBin(currentOrder, this);
            orderBinPage.Show();

        }
    }
}
