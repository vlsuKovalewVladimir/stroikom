using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
    /// Логика взаимодействия для WpfMessageBox.xaml
    /// </summary>
    public partial class WpfMessageBox : Window
    {
       private static WpfMessageBox _messageBox;
        private static MessageBoxResult _result = MessageBoxResult.OK;

        public WpfMessageBox()
        {
            InitializeComponent();
        }

        #region Show

        /// <summary>
        /// Отображает окно с сообщением
        /// </summary>
        /// <param name="inputWindow">Текущий FrameworkElement</param>
        /// <param name="inputText">Текст</param>
        /// <returns>Нажатая кнопка</returns>
        public static MessageBoxResult Show(FrameworkElement inputFrameworkElement, string inputText)
        {
            return Show(inputFrameworkElement, inputText, "");
        }

        /// <summary>
        /// Отображает окно с сообщением
        /// </summary>
        /// <param name="inputWindow">Текущий FrameworkElement</param>
        /// <param name="inputText">Текст</param>
        /// <param name="inputTitle">Текст заголовка</param>
        /// <returns>Нажатая кнопка</returns>
        public static MessageBoxResult Show(FrameworkElement inputFrameworkElement, string inputText, string inputTitle)
        {
            return Show(inputFrameworkElement, inputText, inputTitle, MessageBoxImage.Information);
        }

        /// <summary>
        /// Отображает окно с сообщением
        /// </summary>
        /// <param name="inputWindow">Текущий FrameworkElement</param>
        /// <param name="inputText">Текст</param>
        /// <param name="inputTitle">Текст заголовка</param>
        /// <param name="inputImage">Тип сообщения</param>
        /// <returns>Нажатая кнопка</returns>
        public static MessageBoxResult Show(FrameworkElement inputFrameworkElement, string inputText, string inputTitle, MessageBoxImage inputImage)
        {
            return Show(inputFrameworkElement, inputText, inputTitle, inputImage, MessageBoxButton.OK);
        }

        /// <summary>
        /// Отображает окно с сообщением
        /// </summary>
        /// <param name="inputWindow">Текущий FrameworkElement</param>
        /// <param name="inputText">Текст</param>
        /// <param name="inputTitle">Текст заголовка</param>
        /// <param name="inputImage">Тип сообщения</param>
        /// <param name="inputButton">Тип кнопок</param>
        /// <returns>Нажатая кнопка</returns>
        public static MessageBoxResult Show(FrameworkElement inputFrameworkElement, string inputText, string inputTitle, MessageBoxImage inputImage, MessageBoxButton inputButton)
        {
            Window inputWindow = helperFindWindow(inputFrameworkElement);
            if (inputWindow == null)
                return MessageBox.Show("inputText", "inputTitle", inputButton, inputImage);


            _messageBox = new WpfMessageBox();
            _messageBox.Owner = inputWindow;

            inputWindow.Opacity = 0.6;

            _messageBox.tbl_title.Text = inputTitle;
            _messageBox.tbl_text.Text = inputText;
            
            switch (inputImage)
            {
                case MessageBoxImage.Error:
                    SystemSounds.Hand.Play();
                    _messageBox.i_image.Source = new BitmapImage(new Uri(@"../Resources/error.png", UriKind.Relative));
                    break;

                case MessageBoxImage.Warning:
                    SystemSounds.Exclamation.Play();
                    _messageBox.i_image.Source = new BitmapImage(new Uri(@"../Resources/warning.png", UriKind.Relative));
                    break;

                case MessageBoxImage.Question:
                    SystemSounds.Question.Play();
                    _messageBox.i_image.Source = new BitmapImage(new Uri(@"../Resources/question.png", UriKind.Relative));
                    break;

                case MessageBoxImage.Information:
                    SystemSounds.Asterisk.Play();
                    _messageBox.i_image.Source = new BitmapImage(new Uri(@"../Resources/info.png", UriKind.Relative));
                    break;

                default:
                    SystemSounds.Beep.Play();
                    _messageBox.i_image.Source = new BitmapImage(new Uri(@"../Resources/info.png", UriKind.Relative));
                    break;
            }

            switch (inputButton)
            { 
                case MessageBoxButton.OK:
                    _messageBox.b_no.Visibility = Visibility.Collapsed;
                    _messageBox.b_ok.Content = "ОК";
                    break;
                //case MessageBoxButton.YesNo
            }  

            _messageBox.ShowDialog();

            inputWindow.Opacity = 1;

            return _result;
        }

        #endregion

        // Помогает получить текущее окно
        private static Window helperFindWindow(FrameworkElement input)
        {
            if (input == null) 
                return null;
            FrameworkElement res = input.Parent as FrameworkElement;
            while (!(res is Window))
                res = res.Parent as FrameworkElement;
            return res as Window;
        }

        // Кнопка выход (х)
        private void b_exit_Click(object sender, RoutedEventArgs e)
        {
            _result = MessageBoxResult.Cancel;
            this.Close();
        }

        // Кнопка Ок
        private void b_ok_Click(object sender, RoutedEventArgs e)
        {
            _result = MessageBoxResult.OK;
            this.Close();
        }

        // Кнопка No
        private void b_no_Click(object sender, RoutedEventArgs e)
        {
            _result = MessageBoxResult.No;
            this.Close();
        }
    }
}
