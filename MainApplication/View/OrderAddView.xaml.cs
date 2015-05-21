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
    /// Логика взаимодействия для AddOrderView.xaml
    /// </summary>
    public partial class OrderAddView : UserControl
    {
        public OrderAddView()
        {
            InitializeComponent();

            this.IsVisibleChanged += OrderAddView_IsVisibleChanged;

            SaveButton.Click += SaveButton_Click;
            ExitButton.Click += ExitButton_Click;
        }

        void OrderAddView_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }

        void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
