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

using System.Collections.ObjectModel;
using MainApplication.Model;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MainApplication.View
{
    /// <summary>
    /// Логика взаимодействия для OrderControl.xaml
    /// </summary>
    public partial class OrderView : UserControl
    {
        private OrdersOrSalesCollection ordersOrSalesCollection;

        public OrderView()
        {
            InitializeComponent();

            ordersOrSalesCollection = new OrdersOrSalesCollection(true);
            dg_main.DataContext = ordersOrSalesCollection;

            dg_main.MouseDoubleClick += dg_main_MouseDoubleClick;

            OrderAddButton.Click += OrderAddButton_Click;
        }

        void dg_main_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DbOrdersOrSales os = dg_main.SelectedItem as DbOrdersOrSales;
            if (os == null) return;

            OrderOrSaleGoods.Show(this, os);
        }

        void OrderAddButton_Click(object sender, RoutedEventArgs e)
        {
            OrderAddUserControl.Show(ordersOrSalesCollection);           
        }
    }
}
