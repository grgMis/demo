using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

namespace ChildrensCreativity
{
    public partial class OrderBin : Window
    {
        orders currentOrder;
        double orderSum;
        List<order_bins> orderBinList;
        Products productsWindow;

        public OrderBin(orders order, Products product)
        {
            InitializeComponent();
            currentOrder = order;
            productsWindow = product;
            InitializeData();
            SumCalculation();
        }

        public void InitializeData()
        {
            orderBinList = ChildrenCreativityEntities.GetContext().order_bins.Where(ob => ob.fk_order_id == currentOrder.order_id).ToList();
            listOrderBin.ItemsSource = orderBinList;

            comboBoxPoints.ItemsSource = ChildrenCreativityEntities.GetContext().delivery_points.ToList();

            if (orderSum > 0)
            {
                OrderBinSum.Content = $"Сумма заказа: {orderSum}";
            } else
            {
                orderSum = 0;
                OrderBinSum.Content = $"Сумма заказа: {orderSum}";
            }
            
        }

        public void SumCalculation()
        {
            foreach (var item in orderBinList)
            {
                orderSum += (double)item.products.product_price * ((100 - (double)item.products.product_discount) / 100);
            }
            OrderBinSum.Content = $"Сумма заказа: {orderSum}";
        }

        private void ClosePage(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void PlusOrderCount(object sender, RoutedEventArgs e)
        {
            order_bins selectedOrderBin = (order_bins)listOrderBin.SelectedItem;

            if (selectedOrderBin == null)
            {
                MessageBox.Show("Выберите товар");
                return;
            }

            orderSum += (double)selectedOrderBin.products.product_price * ((100 - (double)selectedOrderBin.products.product_discount) / 100);

            selectedOrderBin.order_bin_count++;
            SaveChanges();
            InitializeData();
        }

        private void MinusOrderCount(object sender, RoutedEventArgs e)
        {
            order_bins selectedOrderBin = (order_bins)listOrderBin.SelectedItem;

            if (selectedOrderBin == null)
            {
                MessageBox.Show("Выберите товар");
                return;
            }

            orderSum -= (double)selectedOrderBin.products.product_price * ((100 - (double)selectedOrderBin.products.product_discount) / 100);

            if (selectedOrderBin.order_bin_count == 1)
            {
                ChildrenCreativityEntities.GetContext().order_bins.Remove(selectedOrderBin);
                SaveChanges();
                InitializeData();
            } else
            {
                selectedOrderBin.order_bin_count--;
                SaveChanges();
                InitializeData();
            }
        }

        private void SaveChanges()
        {
            try
            {
                ChildrenCreativityEntities.GetContext().SaveChanges();
            }
            catch (Exception) { }
        }

        private void CreateOrder(object sender, RoutedEventArgs e)
        {
            Random random = new Random();

            delivery_points point = (delivery_points)comboBoxPoints.SelectedItem;

            if (point == null)
            {
                MessageBox.Show("Выберите пункт выдачи");
                return;
            }

            foreach (var item in orderBinList)
            {
                if (item.products.product_count > item.order_bin_count)
                {
                    item.products.product_count -= item.order_bin_count;
                    SaveChanges();
                    currentOrder.order_delivery_date = DateTime.Now.AddDays(3);
                    break;
                } else
                {
                    item.products.product_count = 0;
                    currentOrder.order_delivery_date = DateTime.Now.AddDays(6);
                    break;
                }
            }

            currentOrder.order_date = DateTime.Now;
            currentOrder.order_code = random.Next(100, 999);
            currentOrder.order_status = "Новый";
            currentOrder.order_sum = orderSum;
            currentOrder.fk_delivery_point_id = point.delivery_point_id;

            ChildrenCreativityEntities.GetContext().orders.Add(currentOrder);
            SaveChanges();

            Order order = new Order(currentOrder);
            this.Close();
            productsWindow.Close();
            order.Show();
        }
    }
}
