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

using System.Threading;
using System.Xml;
using System.IO;


namespace MainApplication
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        private string connectionDbFormat = "server={0};user id={2};database={4};port={1};password={3};";
        private string key;
        private int time = 100;

        private string login;
        private string password;

        public StartWindow(string _login, string _password)
        {
            InitializeComponent();

            this.login = _login;
            this.password = _password;

            this.key = Parameters.Instance.Key;

            threadStart();

            SettingButton.Click += SettingButton_Click;
            RepeatButton.Click += RepeatButton_Click;
            ExitButton.Click += ExitButton_Click;
        }

        void SettingButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var tmpSettingsConnectionWindow = new SettingsConnectionWindow();
            tmpSettingsConnectionWindow.Show();
        }

        void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            ProblemButtonStackPanel.Visibility = Visibility.Collapsed;
            ProgressBarView.Visibility = Visibility.Visible;
            threadStart();
        }

        void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        void threadStart()
        {
            StatusTextBlock.Text = "Установка параметров подключения"; 
            Thread thread = new Thread(updateText);
            thread.Start();
        }

        void updateText()
        {
            // Загружает данные из файла
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(Parameters.Instance.NameFileConfig);
                string[] str = new string[5];
                for (int i = 0; i < 5; i++)
                {
                    str[i] = Crypt.Decrypt(streamReader.ReadLine(), key);
                }
                Parameters.Instance.ConnectionDb = String.Format(connectionDbFormat, str[0], str[1], str[2], str[3], str[4]);
            }
            catch (IOException ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
            }
            finally
            {
                if (streamReader != null) streamReader.Dispose();
            }

            // Подключение к базе данных и авторизация
            Thread.Sleep(time);
            this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                (ThreadStart)delegate()
                {
                    StatusTextBlock.Text = "Подключение к серверу базы данных..";
                });
            using (var db = new Model.Db_StroikomEntities()) 
            {
                try
                {
                    var p = db.Personnels.ToList().Single(pes =>
                      (pes.LastName + pes.IdPersonnel == this.login) && pes.Password == this.password);
                    Parameters.Instance.Personnel = new Model.PersonnelModel(p.IdPersonnel, p.LastName, p.FirstName, p.SoName,
                        p.Dtr, p.Gender, p.Adress, p.Phone, p.Post.Post, p.Password);
                }
                catch (System.Data.Entity.Core.EntityException ex)
                {
                    System.Diagnostics.Debug.Print(ex.Message);

                    this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                    (ThreadStart)delegate()
                    {
                        StatusTextBlock.Text = "Ошибка при подключении";
                        ProblemButtonStackPanel.Visibility = Visibility.Visible;
                        ProgressBarView.Visibility = Visibility.Collapsed;
                    });

                    return;
                }
                catch (System.InvalidOperationException ex)
                {
                    System.Diagnostics.Debug.Print(ex.Message);

                    this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                    (ThreadStart)delegate()
                    {
                        WpfMessageBox.Show(this, "Неверный логин или пароль", "Ошибка авторизации", MessageBoxImage.Error);
                        var tmpАuthorizationWindow = new AuthorizationWindow();
                        tmpАuthorizationWindow.Show();
                        this.Close();
                    });

                    return;
                }
            }

            this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                    (ThreadStart)delegate()
                    {
                        var tmpMainWindows = new MainWindow();
                        tmpMainWindows.Show();
                        this.Close();
                    });
        }
    }
}
