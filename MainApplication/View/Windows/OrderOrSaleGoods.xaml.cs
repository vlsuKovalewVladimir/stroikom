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
using System.Windows.Shapes;

namespace MainApplication.View
{
    /// <summary>
    /// Логика взаимодействия для OrderOrSaleGoods.xaml
    /// </summary>
    public partial class OrderOrSaleGoods : Window
    {
        private static OrderOrSaleGoods _OrderOrSaleGoods;
        private static ICollection<DbOrderStorageSaleGoods> orderStorageSaleGoodsCollectoin;

        private OrderOrSaleGoods()
        {
            InitializeComponent();

            GoodsDataGrid.DataContext = orderStorageSaleGoodsCollectoin;

            ExitButton.Click += ExitButton_Click;
        }

        void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public static void Show(FrameworkElement inputFrameworkElement, DbOrdersOrSales os)
        {
            orderStorageSaleGoodsCollectoin = new OrderStorageSaleGoodsCollectoin(os);

            Window inputWindow = helperFindWindow(inputFrameworkElement);
            _OrderOrSaleGoods = new OrderOrSaleGoods();
            _OrderOrSaleGoods.Owner = inputWindow;
            inputWindow.Opacity = 0.6;           

            _OrderOrSaleGoods.ShowDialog();
            inputWindow.Opacity = 1;
        }

        // Помогает получить текущее окно
        private static Window helperFindWindow(FrameworkElement input)
        {
            if (input == null)
                return null;
            FrameworkElement res = input;
            while (!(res is Window))
                res = res.Parent as FrameworkElement;
            return res as Window;
        }
    }
}
