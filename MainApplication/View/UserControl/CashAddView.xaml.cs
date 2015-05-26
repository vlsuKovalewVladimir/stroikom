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
    /// Логика взаимодействия для CashAddView.xaml
    /// </summary>
    public partial class CashAddView : UserControl
    {
        private OrdersOrSalesCollection ordersOrSalesCollection;
        private CashCollection cashCollection;
        private OperationsCollection operationsCollection;

        public CashAddView()
        {
            InitializeComponent();

            SaveButton.Click += SaveButton_Click;
            ExitButton.Click += ExitButton_Click;
           
        }

        internal void Show(CashCollection cc)
        {
            cashCollection = cc;

            ordersOrSalesCollection = new OrdersOrSalesCollection();
            OrderOrSaleDataGrid.DataContext = ordersOrSalesCollection;

            operationsCollection = new OperationsCollection();
            OperationComboBox.DataContext = operationsCollection;

            this.Visibility = System.Windows.Visibility.Visible;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            if (OperationComboBox.SelectedItem == null)
            {
                WpfMessageBox.Show(this, "Выберите операцию", "Операция не выбрана", MessageBoxImage.Error);
                return;
            }
            if (OrderOrSaleDataGrid.SelectedItem == null)
            {
                WpfMessageBox.Show(this, "Выберите 'Поставки и закупки'", "Не выбрана", MessageBoxImage.Error);
                return;
            }

            try
            {
                double sum = Double.Parse(SummaTextBox.Text);
                string dogovor = DogovorTextBox.Text;
                string discription = DiscriptionTextBox.Text;

                int idOperation = (OperationComboBox.SelectedItem as DbOperations).IdOperation;
                int orderOrSale_Id = (OrderOrSaleDataGrid.SelectedItem as DbOrdersOrSales).IdOrderOrSale;

                cashCollection.AddCash(new DbCash()
                {
                    Discription = discription,
                    Date = DateTime.Now,
                    Sum = sum,
                    Operation_id = idOperation,
                    Dogovor = dogovor,
                    OrderOrSale_Id = orderOrSale_Id
                });

                this.Visibility = System.Windows.Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
                WpfMessageBox.Show(this, "Пожалуйста введите корректные данные", "Ошибка", MessageBoxImage.Error);
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

    }
}
