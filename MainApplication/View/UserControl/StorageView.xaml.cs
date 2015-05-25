using MainApplication.Model;
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

namespace MainApplication.View
{
    /// <summary>
    /// Логика взаимодействия для StorageView.xaml
    /// </summary>
    public partial class StorageView : UserControl
    {
        private OrderStorageSaleGoodsCollectoin storageGoodsCollectoin;

        public StorageView()
        {
            InitializeComponent();

            this.IsVisibleChanged += StorageView_IsVisibleChanged;
        }

        private void StorageView_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            storageGoodsCollectoin = new OrderStorageSaleGoodsCollectoin(2);
            dg_main.DataContext = storageGoodsCollectoin;
        }
    }
}
