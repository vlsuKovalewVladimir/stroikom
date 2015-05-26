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
    /// Логика взаимодействия для TaskView.xaml
    /// </summary>
    public partial class TaskView : UserControl
    {
        private TaskCollection taskCollection;

        public TaskView()
        {
            InitializeComponent();

            this.IsVisibleChanged += TaskView_IsVisibleChanged;
        }

        void TaskView_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.OldValue) return;

            taskCollection = new TaskCollection();
            dg_main.DataContext = taskCollection;
        }
    }
}
