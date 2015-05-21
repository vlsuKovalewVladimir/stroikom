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

using System.Collections.ObjectModel;
using MainApplication.Model;

namespace MainApplication.View
{
    /// <summary>
    /// Логика взаимодействия для OrderControl.xaml
    /// </summary>
    public partial class OrderView : UserControl
    {
        private OrderCollection orderCollection;

        public OrderView()
        {
            InitializeComponent();

            this.orderCollection = new OrderCollection();

            IsVisibleChanged += OrderView_IsVisibleChanged;
            OrderAddButton.Click += OrderAddButton_Click;
        }

        void OrderView_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {   
            if ((bool)e.OldValue) return;
                ucGrid.DataContext = orderCollection;
        }

        void OrderAddButton_Click(object sender, RoutedEventArgs e)
        {
            OrderAddUserControl.Visibility = Visibility.Visible;
        }
    }
}
