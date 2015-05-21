using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для SettingsConnectionWindow.xaml
    /// </summary>
    public partial class SettingsConnectionWindow : Window
    {
        private string key;

        public SettingsConnectionWindow()
        {
            InitializeComponent();

            this.key = Parameters.Instance.Key;

            StreamReader streamReader = null;
            try 
            {
                streamReader = new StreamReader(Parameters.Instance.NameFileConfig);
                string[] str = new string[5];
                for (int i = 0; i < 5; i++)
                {
                    str[i] = Crypt.Decrypt(streamReader.ReadLine(), key);
                }
                HostTextBox.Text = str[0];
                PortTextBox.Text = str[1];
                UserTextBox.Text = str[2];
                PasswordTextBox.Text = str[3];
                NameDbTextBox.Text = str[4];    
            }
            catch (IOException ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
            }
            finally
            {
                if (streamReader != null) streamReader.Dispose();
            }
            

            SaveButton.Click += SaveButton_Click;
            SaveButton.Click += ExitButton_Click;
            ExitButton.Click += ExitButton_Click;
        }

        void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter fi = null; 
            try 
            {
                fi = File.CreateText(Parameters.Instance.NameFileConfig);
                fi.WriteLine(String.Format("{0}\r\n{1}\r\n{2}\r\n{3}\r\n{4}", Crypt.Encrypt(HostTextBox.Text.Trim(), key),
                    Crypt.Encrypt(PortTextBox.Text.Trim(), key), Crypt.Encrypt(UserTextBox.Text.Trim(), key),
                    Crypt.Encrypt(PasswordTextBox.Text.Trim(), key), Crypt.Encrypt(NameDbTextBox.Text.Trim(), key)));
                WpfMessageBox.Show(this, "Данные сохранены", "Сохранено");
            }
            catch (IOException ex) 
            {
                WpfMessageBox.Show(this, ex.Message, "Ошибка", MessageBoxImage.Error);
            }
            finally
            {
                if (fi != null) fi.Dispose();
            }
        }

        void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Parameters.Instance.StartWindowCurrent.Show();
            this.Close();
        }
    }
}
