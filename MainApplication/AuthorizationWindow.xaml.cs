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

namespace MainApplication
{
    /// <summary>
    /// Логика взаимодействия для АuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();

            NextButton.Click += NextButton_Click;
            ExitButton.Click += ExitButton_Click;
        }

        void NextButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Password;
            Parameters.Instance.StartWindowCurrent = new StartWindow(login, password);
            Parameters.Instance.StartWindowCurrent.Show();
            this.Close();
        }

        void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
