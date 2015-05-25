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

using MainApplication.Model;

namespace MainApplication.View
{
    /// <summary>
    /// Логика взаимодействия для AddOrderView.xaml
    /// </summary>
    public partial class OrderAddView : UserControl
    {
        private StoragesCollection storagesCollection;
        private PartnersCollection partnersCollection;
        private OrderStorageSaleGoodsCollectoin orderStorageSaleGoodsCollectoin;
        private OrdersOrSalesCollection ordersOrSalesCollection;

        public OrderAddView()
        {
            InitializeComponent();


            SaveButton.Click += SaveButton_Click;
            ExitButton.Click += ExitButton_Click;

            GoodsAddButton.Click += GoodsAddButton_Click;
            GoodsRemoveButton.Click += GoodsRemoveButton_Click;
        }

        internal void Show(OrdersOrSalesCollection orsc)
        {
            ordersOrSalesCollection = orsc;

            storagesCollection = new StoragesCollection();
            StoragesComboBox.DataContext = storagesCollection;

            partnersCollection = new PartnersCollection();
            PartnersComboBox.DataContext = partnersCollection;

            orderStorageSaleGoodsCollectoin = new OrderStorageSaleGoodsCollectoin();
            GoodsDataGrid.DataContext = orderStorageSaleGoodsCollectoin;

            this.Visibility = System.Windows.Visibility.Visible;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (StoragesComboBox.SelectedItem == null)
            {
                WpfMessageBox.Show(this, "Выберите склад", "Склад не выбран", MessageBoxImage.Error);
                return;
            }
            if (PartnersComboBox.SelectedItem == null)
            {
                WpfMessageBox.Show(this, "Выберите партнера", "Партнер не выбран", MessageBoxImage.Error);
                return;
            }
            if (orderStorageSaleGoodsCollectoin.Count == 0)
            {
                WpfMessageBox.Show(this, "Выберите товары", "Товары не выбраны", MessageBoxImage.Error);
                return;
            }

            int status_id = 1;
            bool isorder = true;
            if (Parameters.Instance.CurrentState == State.Sale)
            {
                status_id = 4;
                isorder = false;
            }

            int storage_id = (StoragesComboBox.SelectedItem as DbStorages).IdStorage;
            int partner_id = (PartnersComboBox.SelectedItem as DbPartners).IdPartner;

            DbOrdersOrSales ordersOrSales = new DbOrdersOrSales()
            {
                DateOrderOrSale = DateTime.Now,
                Status_id = status_id,
                Partner_id = partner_id,
                PeriodDate = DateTime.Now,
                Storage_id = storage_id,
                isOrder = isorder,
                Personnel_id = Parameters.Instance.Personnel.IdPersonnel
            };

            ordersOrSalesCollection.AddOrders(ordersOrSales, orderStorageSaleGoodsCollectoin);

            this.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        void GoodsAddButton_Click(object sender, RoutedEventArgs e)
        {
            DbOrderStorageSaleGoods ossg = null;
            if (Parameters.Instance.CurrentState == State.Order)
                ossg = OrderAddGoodsWindow.Show(this);
            if (Parameters.Instance.CurrentState == State.Sale)
                ossg = SaleAddGoods.Show(this);
            if (ossg != null)
            {
                ossg.OrderOrStorageOrSale = 1;
                if (Parameters.Instance.CurrentState == State.Sale)
                    ossg.OrderOrStorageOrSale = 3;
                orderStorageSaleGoodsCollectoin.AddGoodsNoSaveDb(ossg);
            }  
        }

        void GoodsRemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (GoodsDataGrid.SelectedItem == null)
            {
                WpfMessageBox.Show(this, "Выберете товар", "Товар не выбран", MessageBoxImage.Error);
                return;
            }
            orderStorageSaleGoodsCollectoin.Remove(GoodsDataGrid.SelectedItem as DbOrderStorageSaleGoods);
        }
    }
}
