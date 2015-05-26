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
    /// Логика взаимодействия для GoodsAddWindow.xaml
    /// </summary>
    public partial class GoodsAddWindow : Window
    {
        private static DbGoods goods;
        private static GoodsAddWindow _GoodsAddWindow;

        private GoodsAddWindow()
        {
            InitializeComponent();

            goods = null;

            ApplyButton.Click += ApplyButton_Click;
            CancelButton.Click += ExitButton_Click;
            ExitButton.Click += ExitButton_Click;
        }

        public static DbGoods Show(FrameworkElement inputFrameworkElement)
        {
            Window inputWindow = helperFindWindow(inputFrameworkElement);
            _GoodsAddWindow = new GoodsAddWindow();
            _GoodsAddWindow.Owner = inputWindow;
            inputWindow.Opacity = 0.6;


            _GoodsAddWindow.ShowDialog();
            inputWindow.Opacity = 1;
            return goods;
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
            string name = NameTextBox.Text;
            string article = ArticleTextBox.Text;
            string description = DescriptionTextBox.Text;

            if (name == "" || article == "" || description == "")
            {
                WpfMessageBox.Show(this, "Пожалуйста введите корректные данные", "Ошибка", MessageBoxImage.Error);
                return;
            }

            goods = new DbGoods()
            {
                Name = name,
                Article = article,
                Description = description
            };

            this.Close();
        }

        void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
