using DbdRoulette.Addons;
using DbdRoulette.Components;
using DbdRoulette.ViewModels;
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

namespace DbdRoulette.Pages
{
    /// <summary>
    /// Логика взаимодействия для PowerListPage.xaml
    /// </summary>
    public partial class PowerListPage : Page
    {
        LoadingControl contextContentLoader;
        public bool FirstTry;
        public PowerListPage(LoadingControl loadingControl)
        {
            InitializeComponent();

            CbSort.Items.Add("По названию");
            CbSort.Items.Add("По имени владельца");

            contextContentLoader = loadingControl;
            DataContext = new PowerListViewModel();

        }

        private void PowerBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var selectedPower = (sender as Grid).DataContext as Power;
            NavigationService.Navigate(new PowerAddonsPage(selectedPower));
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack == true)
            {
                NavigationService.GoBack();
            }
        }

        private void LvPowers_TargetUpdated(object sender, DataTransferEventArgs e)
        {
            if (FirstTry == true)
            {
                contextContentLoader.StopAnimation();
            }
            else
            {
                FirstTry = true;
            }

            if (LvPowers.Items.Count == 0)
            {
                NothingFoundElement.Visibility = Visibility.Visible;
            }
            else
            {
                NothingFoundElement.Visibility = Visibility.Collapsed;
                LvPowers.BeginAnimation(ListView.OpacityProperty, MiscUtilities.AppearOpacityAnimation);
            }
        }
    }
}
