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
    /// Логика взаимодействия для CashView.xaml
    /// </summary>
    public partial class CashView : UserControl
    {
        private CashCollection cashCollection;

        public CashView()
        {
            InitializeComponent();

            this.IsVisibleChanged += CashView_IsVisibleChanged;

            CashAddButton.Click += CashAddButton_Click;
        }

        void CashAddButton_Click(object sender, RoutedEventArgs e)
        {
            CashAddUserControl.Show(cashCollection);
        }

        void CashView_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.OldValue) return;

            CashAddUserControl.Visibility = System.Windows.Visibility.Collapsed;

            cashCollection = new CashCollection();
            dg_main.DataContext = cashCollection;
        }
    }
}
