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

            this.IsVisibleChanged += OrderView_IsVisibleChanged;

            OrderAddButton.Click += OrderAddButton_Click;
            OrderEditButton.Click += OrderEditButton_Click;

            dg_main.MouseDoubleClick += dg_main_MouseDoubleClick;
        }

        void OrderEditButton_Click(object sender, RoutedEventArgs e)
        {
            DbOrdersOrSales os = dg_main.SelectedItem as DbOrdersOrSales;
            if (os == null) 
            {
                WpfMessageBox.Show(this, "Выберите", "не выбрана", MessageBoxImage.Error);
                return;
            }

            ordersOrSalesCollection.EditStatus(os);

            if (Parameters.Instance.CurrentState == State.Order)
            {
                ordersOrSalesCollection = new OrdersOrSalesCollection(true);
                dg_main.DataContext = ordersOrSalesCollection;
                //OrderRemoveButton.Visibility = System.Windows.Visibility.Visible;
            }
            if (Parameters.Instance.CurrentState == State.Sale)
            {
                ordersOrSalesCollection = new OrdersOrSalesCollection(false);
                dg_main.DataContext = ordersOrSalesCollection;
                //OrderRemoveButton.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void OrderView_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.OldValue) return;

            OrderAddUserControl.Visibility = System.Windows.Visibility.Collapsed;

            if (Parameters.Instance.CurrentState == State.Order)
            {
                ordersOrSalesCollection = new OrdersOrSalesCollection(true);
                dg_main.DataContext = ordersOrSalesCollection;
                //OrderRemoveButton.Visibility = System.Windows.Visibility.Visible;
            }
            if (Parameters.Instance.CurrentState == State.Sale)
            {
                ordersOrSalesCollection = new OrdersOrSalesCollection(false);
                dg_main.DataContext = ordersOrSalesCollection;
                //OrderRemoveButton.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void dg_main_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DbOrdersOrSales os = dg_main.SelectedItem as DbOrdersOrSales;
            if (os == null) return;

            OrderOrSaleGoods.Show(this, os);
        }

        private void OrderAddButton_Click(object sender, RoutedEventArgs e)
        {
            OrderAddUserControl.Show(ordersOrSalesCollection);
        }
    }
}
