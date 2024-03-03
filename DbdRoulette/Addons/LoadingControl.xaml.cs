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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DbdRoulette.Addons
{
    /// <summary>
    /// Логика взаимодействия для LoadingControl.xaml
    /// </summary>
    public partial class LoadingControl : UserControl
    {
        public LoadingControl()
        {
            InitializeComponent();

            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if(LoadingTextTb.Text == "Загрузка")
            {
                LoadingTextTb.Text = "Загрузка.";
            }
            else if (LoadingTextTb.Text == "Загрузка.")
            {
                LoadingTextTb.Text = "Загрузка..";
            }
            else if (LoadingTextTb.Text == "Загрузка..")
            {
                LoadingTextTb.Text = "Загрузка...";
            }
            else if (LoadingTextTb.Text == "Загрузка...")
            {
                LoadingTextTb.Text = "Загрузка";
            }
        }

        
    }
}
