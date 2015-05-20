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

        private OrderCollection oc;

        public OrderView()
        {
            InitializeComponent();
            this.IsVisibleChanged += OrderView_IsVisibleChanged;



            this.oc = new OrderCollection();
            ucGrid.DataContext = oc;

            b_add.Click += (object sender, RoutedEventArgs e) => 
            {
                oc.Add(new OrderModel() { Id = 555 });
            };

            b_delete.Click += (object sender, RoutedEventArgs e) =>
            {
                oc.Remove((OrderModel)dg_main.SelectedItem);
            };            
        }


        
        void OrderView_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
            if ((bool)e.OldValue)
                return;

            
            //dg_main.up
         
        }
    }
}
