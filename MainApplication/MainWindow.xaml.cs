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


namespace MainApplication
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            PersonnelNameTextBlock.Text = Parameters.Instance.Personnel.LittleName;
            PersonnelPostTextBlock.Text = Parameters.Instance.PersonnelPost.ToString();

            switch (Parameters.Instance.Personnel.Post_id)
            {
                case 3:
                    MenuCashTextBlock.Visibility = System.Windows.Visibility.Collapsed;
                    MenuStatisticsTextBlock.Visibility = System.Windows.Visibility.Collapsed;
                    break;
            }

            MenuOrderTextBlock.MouseUp += MenuTextBlock_MouseUp;
            MenuStorageTextBlock.MouseUp += MenuTextBlock_MouseUp;
            MenuSaleTextBlock.MouseUp += MenuTextBlock_MouseUp;
            MenuCashTextBlock.MouseUp += MenuTextBlock_MouseUp;
            MenuTaskTextBlock.MouseUp += MenuTextBlock_MouseUp;
            MenuStatisticsTextBlock.MouseUp += MenuTextBlock_MouseUp;

            MenuOrderTextBlock.MouseDown += MenuTextBlock_MouseDown;
            MenuStorageTextBlock.MouseDown += MenuTextBlock_MouseDown;
            MenuSaleTextBlock.MouseDown += MenuTextBlock_MouseDown;
            MenuCashTextBlock.MouseDown += MenuTextBlock_MouseDown;
            MenuTaskTextBlock.MouseDown += MenuTextBlock_MouseDown;
            MenuStatisticsTextBlock.MouseDown += MenuTextBlock_MouseDown;
        }

        private void MenuTextBlock_MouseUp(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = (TextBlock)sender;
            var backColor = new RadialGradientBrush(Color.FromArgb(154, 255, 255, 255), Colors.Transparent);
            MenuOrderTextBlock.Background = MenuStorageTextBlock.Background =
                MenuSaleTextBlock.Background = MenuCashTextBlock.Background =
                MenuTaskTextBlock.Background = MenuStatisticsTextBlock.Background = null;
            textBlock.Background = backColor;
        }

        private void MenuTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;

            OrderUserControl.Visibility =
                StorageUserControl.Visibility = 
                CashUserControl.Visibility = 
                TaskUserControl.Visibility =
                StatisticsUserControl.Visibility = System.Windows.Visibility.Collapsed;

            if (textBlock == MenuOrderTextBlock)
            {
                Parameters.Instance.CurrentState = State.Order;
                OrderUserControl.Visibility = System.Windows.Visibility.Visible;
            }

            if (textBlock == MenuStorageTextBlock)
            {
                Parameters.Instance.CurrentState = State.Storage;
                StorageUserControl.Visibility = System.Windows.Visibility.Visible;
            }

            if (textBlock == MenuSaleTextBlock)
            {
                Parameters.Instance.CurrentState = State.Sale;
                OrderUserControl.Visibility = System.Windows.Visibility.Visible;
            }

            if (textBlock == MenuCashTextBlock)
            {
                Parameters.Instance.CurrentState = State.Cash;
                CashUserControl.Visibility = System.Windows.Visibility.Visible;
            }
            if (textBlock == MenuTaskTextBlock)
            {
                Parameters.Instance.CurrentState = State.Task;
                TaskUserControl.Visibility = System.Windows.Visibility.Visible;
            }
            if (textBlock == MenuStatisticsTextBlock)
            {
                Parameters.Instance.CurrentState = State.Statistics;
                StatisticsUserControl.Visibility = System.Windows.Visibility.Visible;
            }   
        }


        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    using (var db = new DBContext())
        //    {
        //        var order = from o in db.OrderOrSales
        //                    where o.is_order == true
        //                    select new
        //                    {
        //                        IdOrder = o.id_order_or_sale,
        //                        DataOrder = o.date_order_or_sale,
        //                        StatusOrder = o.status.status1,
        //                        PartnerName = o.partner.name,
        //                        PeriodDateOrder = o.period_date,
        //                        StorageOrder = o.storage.name,
        //                        PersonnelOrder = o.personnel.firstname + " " + o.personnel.lastname,

        //                        Summa = o.order_storage_sale_goods.Sum(s => s.price_of_unit * s.count)
        //                    };

        //        //dg_main.ItemsSource = order.ToList();
        //    }   


        //    using (var db = new DBContext())
        //    {
        //        var storage = from s in db.OrderOrStorageOrSaleGoods1
        //                      where s.order_storage_sale == 2 && !s.is_delete
        //                      select new
        //                      {
        //                          IdGoods = s.id_goods,
        //                          ArticleGoods = s.good.article,
        //                          Goods = s.good.name,
        //                          CoutnGoods = s.count,
        //                          ModuleGoods = s.module.little_module,
        //                          PriceOfUnitGoods = s.price_of_unit,
        //                          StorageGoods = s.order_or_sale.storage.name,

        //                          StorageAdressGoods = s.order_or_sale.storage.ardess,
        //                          CommentGoods = s.comment,
        //                          DescriptionGoods = s.good.description

        //                      };


        //        //dg_main.ItemsSource = storage.ToList();
        //    }

        //    using (var db = new DBContext())
        //    {
        //        var sale = from s in db.OrderOrSales
        //                   where s.is_order == false
        //                   select new
        //                   {
        //                       IdOrder = s.id_order_or_sale,
        //                       DataOrder = s.date_order_or_sale,
        //                       StatusOrder = s.status.status1,
        //                       PartnerName = s.partner.name,
        //                       PeriodDateOrder = s.period_date,
        //                       StorageOrder = s.storage.name,
        //                       PersonnelOrder = s.personnel.firstname + " " + s.personnel.lastname,

        //                       Summa = s.order_storage_sale_goods.Sum(i => i.price_of_unit * i.count)
        //                   };

        //        //dg_main.ItemsSource = sale.ToList();
        //    }

        //    using (var db = new DBContext())
        //    {
        //        var cash = from c in db.Cashes1
        //                   select new
        //                   {
        //                       IdCash = c.id_cash,
        //                       DiscriptionCash = c.discription,
        //                       DateCash = c.date,
        //                       SumCash = c.sum,
        //                       OperationCash = c.operation.operation_vid,
        //                       DogovorCash = c.dogovor,
        //                   };

        //        //dg_main.ItemsSource = cash.ToList();
        //    }

        //    using (var db = new DBContext())
        //    {
        //        //dg_main.ItemsSource = db.Tasks.ToList();
        //    }
        //}

    }
}
