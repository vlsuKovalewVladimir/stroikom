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

            IsVisibleChanged += OrderView_IsVisibleChanged;
            OrderAddButton.Click += OrderAddButton_Click;
        }

        void OrderView_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {   
            if ((bool)e.OldValue) return;

            dg_main.DataContext = ordersOrSalesCollection;
        }

        void OrderAddButton_Click(object sender, RoutedEventArgs e)
        {

            DbOrdersOrSales ordersOrSales = new DbOrdersOrSales() 
            { 
                DateOrderOrSale = DateTime.Now,
                Status_id = 1,
                Partner_id = 1,
                PeriodDate = DateTime.Now,
                Storage_id = 1,
                isOrder = true,
                Personnel_id = Parameters.Instance.Personnel.IdPersonnel
            };

            //ordersOrSalesCollection.AddOrdersOrSales(ordersOrSales);

            OrderAddUserControl.Visibility = Visibility.Visible;
        }
    }
}
