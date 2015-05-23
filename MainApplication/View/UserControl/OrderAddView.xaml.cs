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

            PartnerAddButton.Click += PartnerAddButton_Click;
            StorageAddButton.Click += StorageAddButton_Click;

            GoodsAddButton.Click += GoodsAddButton_Click;
            GoodsEditButton.Click += GoodsEditButton_Click;
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

            int storage_id = (StoragesComboBox.SelectedItem as DbStorages).IdStorage;
            int partner_id = (PartnersComboBox.SelectedItem as DbPartners).IdPartner;

            DbOrdersOrSales ordersOrSales = new DbOrdersOrSales()
            {
                DateOrderOrSale = DateTime.Now,
                Status_id = 1,
                Partner_id = partner_id,
                PeriodDate = DateTime.Now,
                Storage_id = storage_id,
                isOrder = true,
                Personnel_id = Parameters.Instance.Personnel.IdPersonnel
            };

            ordersOrSalesCollection.AddOrdersOrSales(ordersOrSales, orderStorageSaleGoodsCollectoin);

            this.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        void PartnerAddButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        void StorageAddButton_Click(object sender, RoutedEventArgs e)
        {
           // DbStorages st = new DbStorages() { Name = "sdsd", Ardess = "adres" };
            //storagesCollection.AddStorage(st);
        }

        void GoodsAddButton_Click(object sender, RoutedEventArgs e)
        {
            DbOrderStorageSaleGoods ossg = OrderAddGoodsWindow.Show(this);
            if (ossg != null)
            {
                ossg.OrderOrStorageOrSale = 1;
                orderStorageSaleGoodsCollectoin.AddGoodsNoSaveDb(ossg);
            }  
        }

        void GoodsEditButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
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
