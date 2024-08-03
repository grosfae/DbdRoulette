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
        System.Windows.Threading.DispatcherTimer DispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        Storyboard MainStoryboard;
        public LoadingControl()
        {
            InitializeComponent();

            MainStoryboard = (Storyboard)LoaderGrid.Resources["MainStoryboard"];

            DispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            DispatcherTimer.Interval = TimeSpan.FromSeconds(1);
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
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

        public void StartAnimation()
        {
            this.Visibility = Visibility.Visible;
            MainStoryboard.Begin();
            DispatcherTimer.Start();
            LoadingTextTb.Text = "Загрузка";
        }
        public void StopAnimation()
        {
            this.Visibility = Visibility.Collapsed;
            MainStoryboard.Stop();
            DispatcherTimer.Stop();
        }
    }
}
