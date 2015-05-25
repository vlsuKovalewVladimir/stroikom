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
    /// Логика взаимодействия для SaleAddGoods.xaml
    /// </summary>
    public partial class SaleAddGoods : Window
    {
        private static SaleAddGoods _SaleAddGoods;

        private static ModuleCollection moduleCollection;
        private static DbOrderStorageSaleGoods orderStorageSaleGoods;
        private static OrderStorageSaleGoodsCollectoin storageGoodsCollectoin;

        public SaleAddGoods()
        {
            InitializeComponent();

            orderStorageSaleGoods = null;

            moduleCollection = new ModuleCollection();
            ModulComboBox.DataContext = moduleCollection;

            storageGoodsCollectoin = new OrderStorageSaleGoodsCollectoin(2);
            GoodsDataGrid.DataContext = storageGoodsCollectoin;

            ApplyButton.Click += ApplyButton_Click;
            CancelButton.Click += ExitButton_Click;
            ExitButton.Click += ExitButton_Click;
        }

        public static DbOrderStorageSaleGoods Show(FrameworkElement inputFrameworkElement)
        {
            Window inputWindow = helperFindWindow(inputFrameworkElement);
            _SaleAddGoods = new SaleAddGoods();
            _SaleAddGoods.Owner = inputWindow;
            inputWindow.Opacity = 0.6;

            _SaleAddGoods.ShowDialog();
            inputWindow.Opacity = 1;
            return orderStorageSaleGoods;
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

        void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            if (GoodsDataGrid.SelectedItem == null)
            {
                WpfMessageBox.Show(this, "Выберите товар", "Товар не выбран", MessageBoxImage.Error);
                return;
            }

            try
            {
                DbOrderStorageSaleGoods goods = GoodsDataGrid.SelectedItem as DbOrderStorageSaleGoods;
                DbModules modules = ModulComboBox.SelectedItem as DbModules;
                int goods_id = goods.Goods_id;
                int count = Int32.Parse(CountTextBox.Text);
                int module_id = modules.IdModule;
                double priceOfUnit = double.Parse(PriceOfUnitTextBox.Text);
                string comment = CommentTextBox.Text;

                string nameGoods = goods.Goods.Name;
                string nameModule = modules.LittleModule;

                orderStorageSaleGoods = new DbOrderStorageSaleGoods()
                {
                    Goods_id = goods_id,
                    Count = count,
                    Module_id = module_id,
                    PriceOfUnit = priceOfUnit,
                    Comment = comment,
                    NameGoods = nameGoods,
                    NameModule = nameModule
                };

                if (count > goods.Count)
                {
                    WpfMessageBox.Show(this, "Нет такого кол-ва товара", "Ошибка", MessageBoxImage.Error);
                    return;
                }

                using (var db = new Db_StroikomEntities())
                {
                    var go = db.OrderStorageSaleGoods.Single(o => o.IdGoods == goods.IdGoods);
                    go.Count -= count;
                    if (go.Count <= 0)
                        go.isDelete = true;
                    db.SaveChanges();
                }

                this.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
                WpfMessageBox.Show(this, "Пожалуйста введите корректные данные", "Ошибка", MessageBoxImage.Error);
            }
        }

        void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
