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
    /// Логика взаимодействия для OrderOrSaleGoodsWindow.xaml
    /// </summary>
    public partial class OrderAddGoodsWindow : Window
    {    
        private static OrderAddGoodsWindow _OrderOrSaleGoodsWindow;

        private static ModuleCollection moduleCollection;
        private static GoodsCollection goodsCollection;
        private static DbOrderStorageSaleGoods orderStorageSaleGoods;


        private OrderAddGoodsWindow()
        {
            InitializeComponent();

            orderStorageSaleGoods = null;

            moduleCollection = new ModuleCollection();
            ModulComboBox.DataContext = moduleCollection;

            goodsCollection = new GoodsCollection();
            GoodsDataGrid.DataContext = goodsCollection;

            ApplyButton.Click += ApplyButton_Click;
            CancelButton.Click += ExitButton_Click;
            ExitButton.Click += ExitButton_Click;
        }

        public static DbOrderStorageSaleGoods Show(FrameworkElement inputFrameworkElement)
        {
            Window inputWindow = helperFindWindow(inputFrameworkElement);
            _OrderOrSaleGoodsWindow = new OrderAddGoodsWindow();
            _OrderOrSaleGoodsWindow.Owner = inputWindow;
            inputWindow.Opacity = 0.6;

            _OrderOrSaleGoodsWindow.ShowDialog();
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
            if (ModulComboBox.SelectedItem == null)
            {
                WpfMessageBox.Show(this, "Выберите ед. измерения", "ед. измерения не выбрана", MessageBoxImage.Error);
                return;
            }
            if (GoodsDataGrid.SelectedItem == null)
            {
                WpfMessageBox.Show(this, "Выберите товар", "Товар не выбран", MessageBoxImage.Error);
                return;
            }

            try
            {
                DbGoods goods = GoodsDataGrid.SelectedItem as DbGoods;
                DbModules modules = ModulComboBox.SelectedItem as DbModules;
                int goods_id = goods.IdGoods;
                int count = Int32.Parse(CountTextBox.Text);
                int module_id = modules.IdModule;
                double priceOfUnit = double.Parse(PriceOfUnitTextBox.Text);
                string comment = CommentTextBox.Text;

                string nameGoods = goods.Name;
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

                this.Close();
            }
            catch (SystemException ex)
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
