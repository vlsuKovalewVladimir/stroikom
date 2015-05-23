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

        public OrderAddView()
        {
            InitializeComponent();

            this.IsVisibleChanged += OrderAddView_IsVisibleChanged;

            SaveButton.Click += SaveButton_Click;
            ExitButton.Click += ExitButton_Click;

            PartnerAddButton.Click += PartnerAddButton_Click;
            StorageAddButton.Click += StorageAddButton_Click;

            GoodsAddButton.Click += GoodsAddButton_Click;
            GoodsEditButton.Click += GoodsEditButton_Click;
            GoodsRemoveButton.Click += GoodsRemoveButton_Click;
        }

        private void OrderAddView_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.OldValue) return;

            storagesCollection = new StoragesCollection();
            StoragesComboBox.DataContext = storagesCollection;

            partnersCollection = new PartnersCollection();
            PartnersComboBox.DataContext = partnersCollection;

            orderStorageSaleGoodsCollectoin = new OrderStorageSaleGoodsCollectoin();
            GoodsDataGrid.DataContext = orderStorageSaleGoodsCollectoin;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DbStorages a = StoragesComboBox.SelectedItem as DbStorages;
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
            DbOrderStorageSaleGoods ossg = OrderOrSaleGoodsWindow.Show(this);

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
