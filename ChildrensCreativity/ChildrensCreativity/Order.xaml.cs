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

namespace ChildrensCreativity
{
    public partial class Order : Window
    {
        orders currentOrder;

        public Order(orders order)
        {
            InitializeComponent();
            currentOrder = order;
            InitializeData();
        }

        public void InitializeData()
        {
            string dateDelivery = currentOrder.order_delivery_date.ToString();
            string dateOrder = currentOrder.order_date.ToString();

            orderDeliveryDate.Text = DateTime.Parse(dateDelivery).ToShortDateString();
            orderDate.Text = DateTime.Parse(dateOrder).ToShortDateString();

            dataGridOrderProducts.ItemsSource = ChildrenCreativityEntities.GetContext().order_bins.Where(ob => ob.fk_order_id == currentOrder.order_id).ToList();

            DataContext = currentOrder;
        }
    }
}
