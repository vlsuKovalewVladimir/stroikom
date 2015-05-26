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
    /// Логика взаимодействия для StatisticsView.xaml
    /// </summary>
    public partial class StatisticsView : UserControl
    {
        public StatisticsView()
        {
            InitializeComponent();

            PartnersButton.Click += PartnersButton_Click;
            GoodsButton.Click += GoodsButton_Click;
        }

        void GoodsButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new Db_StroikomEntities())
            {
                var goods = from g in db.Goods
                            select new
                            {
                                Name = g.Name,
                                Count = g.OrderStorageSaleGoods.Where(g1 => g1.OrderOrStorageOrSale == 2).Sum(s => s.Count)
                            };
                ps_stat.ItemsSource = goods.ToList();
                ps_stat.DependentValuePath = "Count";
                ps_stat.IndependentValuePath = "Name";
            }
        }

        void PartnersButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new Db_StroikomEntities())
            {
                var st = from p in db.Partners
                         select new
                         {
                             Name = p.Name,
                             Count = p.OrderOrSales.Count
                         };

                ps_stat.ItemsSource = st.ToList();
                ps_stat.DependentValuePath = "Count";
                ps_stat.IndependentValuePath = "Name";
            }
        }
    }
}
